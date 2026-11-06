using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace QLThuVien.Repositories
{
    public class PhieuMuonRepository : MauRepository<PhieuMuon>
    {
        public const int SoNgayMuonMacDinh = 14;
        public const int SoSachToiDa = 5;
        public const decimal DonGiaPhatMacDinh = 5000;   // đồng / cuốn / ngày trễ

        /// <summary>
        /// Lập phiếu mượn (M1). Toàn bộ chạy trong TransactionScope:
        /// tạo phiếu -> kiểm tra tồn kho -> trừ kho -> thêm chi tiết -> cập nhật đặt trước.
        /// Lỗi ở bất kỳ bước nào => không gọi scope.Complete() => rollback.
        /// Lưu ý: sau khi gọi hàm này nên tạo PhieuMuonRepository mới cho lần sau.
        /// </summary>
        public bool LapPhieuMuon(PhieuMuon phieu, List<ChiTietMuon> chiTiets)
        {
            if (chiTiets == null || chiTiets.Count == 0)
                throw new Exception("Lỗi lập phiếu: Phiếu mượn phải có ít nhất một cuốn sách.");

            // Sử dụng TransactionScope để đảm bảo toàn vẹn dữ liệu
            using (var scope = new TransactionScope())
            {
                try
                {
                    // 0. Kiểm tra độc giả
                    bool coDocGia = (from d in db.DocGias where d.MaDocGia == phieu.MaDocGia select d).Any();
                    if (!coDocGia) throw new Exception("Độc giả không tồn tại.");

                    int dangMuon = (from pm in db.PhieuMuons
                                    join ct in db.ChiTietMuons on pm.MaPhieu equals ct.MaPhieu
                                    where pm.MaDocGia == phieu.MaDocGia && pm.TrangThai == TrangThai.DangMuon
                                    select ct.SoLuong).Sum() ?? 0;
                    int muonThem = chiTiets.Sum(ct => ct.SoLuong ?? 0);
                    if (dangMuon + muonThem > SoSachToiDa)
                        throw new Exception($"Mỗi độc giả chỉ được mượn tối đa {SoSachToiDa} cuốn (đang mượn {dangMuon}).");

                    if (string.IsNullOrEmpty(phieu.TrangThai)) phieu.TrangThai = TrangThai.DangMuon;
                    if (phieu.NgayMuon == null) phieu.NgayMuon = DateTime.Today;
                    if (phieu.HanTra == null) phieu.HanTra = phieu.NgayMuon.Value.AddDays(SoNgayMuonMacDinh);
                    if (phieu.HanTra < phieu.NgayMuon) throw new Exception("Hạn trả phải sau ngày mượn.");

                    // 1. Tạo phiếu mượn trước
                    db.PhieuMuons.InsertOnSubmit(phieu);
                    db.SubmitChanges(); // Lúc này phieu.MaPhieu tự động có giá trị

                    foreach (var ct in chiTiets)
                    {
                        if ((ct.SoLuong ?? 0) <= 0) throw new Exception("Số lượng mượn phải lớn hơn 0.");

                        // 2. Kiểm tra tồn kho
                        var sach = db.Saches.FirstOrDefault(s => s.MaSach == ct.MaSach);
                        if (sach == null || sach.SoLuongCon < ct.SoLuong)
                        {
                            throw new Exception($"Sách '{sach?.TenSach}' không đủ số lượng tồn kho!");
                        }

                        // 3. Trừ tồn kho
                        sach.SoLuongCon -= ct.SoLuong;

                        // 4. Thêm chi tiết
                        ct.MaPhieu = phieu.MaPhieu;
                        db.ChiTietMuons.InsertOnSubmit(ct);

                        // 5. Nếu độc giả đã đặt trước cuốn này -> chuyển sang "Đã nhận"
                        var datTruocs = from dt in db.DatTruocs
                                        where dt.MaDocGia == phieu.MaDocGia
                                              && dt.MaSach == ct.MaSach
                                              && dt.TrangThai == TrangThai.DangCho
                                        select dt;
                        foreach (var dt in datTruocs) dt.TrangThai = TrangThai.DaNhan;
                    }

                    db.SubmitChanges(); // Lưu tất cả thay đổi
                    scope.Complete();   // Xác nhận hoàn tất (Commit)
                    return true;
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, scope.Complete() không được gọi -> Tự động Rollback
                    throw new Exception("Lỗi lập phiếu: " + ex.Message);
                }
            }
        }

        /// <summary>Danh sách phiếu theo trạng thái (null = tất cả), tìm theo mã phiếu / tên độc giả.</summary>
        public List<PhieuMuonView> TimKiem(string trangThai, string tuKhoa)
        {
            tuKhoa = (tuKhoa ?? "").Trim();
            int maPhieu;
            bool laSo = int.TryParse(tuKhoa, out maPhieu);

            var query = from pm in db.PhieuMuons
                        join d in db.DocGias on pm.MaDocGia equals d.MaDocGia
                        where (trangThai == null || pm.TrangThai == trangThai)
                              && (tuKhoa == "" || d.HoTen.Contains(tuKhoa) || (laSo && pm.MaPhieu == maPhieu))
                        orderby pm.HanTra
                        select new PhieuMuonView
                        {
                            MaPhieu = pm.MaPhieu,
                            MaDocGia = pm.MaDocGia,
                            HoTen = d.HoTen,
                            NgayMuon = pm.NgayMuon,
                            HanTra = pm.HanTra,
                            NgayTraThucTe = pm.NgayTraThucTe,
                            TrangThai = pm.TrangThai,
                            TongSoSach = pm.ChiTietMuons.Sum(ct => ct.SoLuong) ?? 0
                        };
            return query.ToList();
        }

        public List<PhieuMuonView> GetPhieuDangMuon(string tuKhoa)
        {
            return TimKiem(TrangThai.DangMuon, tuKhoa);
        }

        public List<ChiTietMuonView> GetChiTiet(int maPhieu)
        {
            var query = from ct in db.ChiTietMuons
                        join s in db.Saches on ct.MaSach equals s.MaSach
                        where ct.MaPhieu == maPhieu
                        select new ChiTietMuonView
                        {
                            MaSach = s.MaSach,
                            TenSach = s.TenSach,
                            TacGia = s.TacGia,
                            SoLuong = ct.SoLuong ?? 0
                        };
            return query.ToList();
        }

        /// <summary>Số ngày trễ = ngày trả - hạn trả (âm thì tính 0).</summary>
        public static int TinhSoNgayTre(DateTime? hanTra, DateTime ngayTra)
        {
            if (hanTra == null) return 0;
            int soNgay = (ngayTra.Date - hanTra.Value.Date).Days;
            return soNgay > 0 ? soNgay : 0;
        }

        /// <summary>Tiền phạt quá hạn = số ngày trễ x đơn giá x tổng số cuốn trong phiếu.</summary>
        public decimal TinhTienPhat(int maPhieu, DateTime ngayTra, decimal donGia, out int soNgayTre)
        {
            var phieu = (from pm in db.PhieuMuons where pm.MaPhieu == maPhieu select pm).SingleOrDefault();
            if (phieu == null) throw new Exception("Không tìm thấy phiếu mượn.");

            soNgayTre = TinhSoNgayTre(phieu.HanTra, ngayTra);
            int tongSach = (from ct in db.ChiTietMuons where ct.MaPhieu == maPhieu select ct.SoLuong).Sum() ?? 0;
            return soNgayTre * donGia * tongSach;
        }

        /// <summary>
        /// Trả sách trong TransactionScope: cập nhật phiếu -> cộng lại tồn kho -> lập phiếu phạt nếu quá hạn.
        /// Trả về phiếu phạt (null nếu trả đúng hạn).
        /// </summary>
        public Phat TraSach(int maPhieu, DateTime ngayTra, decimal donGiaPhat)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    var phieu = (from pm in db.PhieuMuons where pm.MaPhieu == maPhieu select pm).SingleOrDefault();
                    if (phieu == null) throw new Exception("Không tìm thấy phiếu mượn.");
                    if (phieu.TrangThai != TrangThai.DangMuon) throw new Exception("Phiếu này đã được trả.");
                    if (phieu.NgayMuon != null && ngayTra.Date < phieu.NgayMuon.Value.Date)
                        throw new Exception("Ngày trả không được trước ngày mượn.");
                    if (donGiaPhat < 0) throw new Exception("Đơn giá phạt không được âm.");

                    // 1. Cập nhật phiếu
                    phieu.NgayTraThucTe = ngayTra.Date;
                    phieu.TrangThai = TrangThai.DaTra;

                    // 2. Cộng lại tồn kho
                    var chiTiets = (from ct in db.ChiTietMuons where ct.MaPhieu == maPhieu select ct).ToList();
                    int tongSach = 0;
                    foreach (var ct in chiTiets)
                    {
                        var sach = (from s in db.Saches where s.MaSach == ct.MaSach select s).Single();
                        int soLuong = ct.SoLuong ?? 0;
                        sach.SoLuongCon = Math.Min((sach.SoLuongCon ?? 0) + soLuong, sach.SoLuongTong ?? int.MaxValue);
                        tongSach += soLuong;
                    }

                    // 3. Tính phạt quá hạn
                    Phat phat = null;
                    int soNgayTre = TinhSoNgayTre(phieu.HanTra, ngayTra);
                    if (soNgayTre > 0)
                    {
                        phat = new Phat
                        {
                            MaPhieu = maPhieu,
                            SoNgayTre = soNgayTre,
                            DonGiaPhat = donGiaPhat,
                            SoTien = soNgayTre * donGiaPhat * tongSach,
                            LyDo = $"Trả quá hạn {soNgayTre} ngày ({tongSach} cuốn)",
                            NgayPhat = ngayTra.Date,
                            TrangThaiThanhToan = TrangThai.ChuaThanhToan
                        };
                        db.Phats.InsertOnSubmit(phat);
                    }

                    db.SubmitChanges();
                    scope.Complete();
                    return phat;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi trả sách: " + ex.Message);
                }
            }
        }
    }
}
