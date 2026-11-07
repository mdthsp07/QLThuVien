using System;
using System.Collections.Generic;
using System.Linq;

namespace QLThuVien.Repositories
{
    public class PhatRepository : MauRepository<Phat>
    {
        /// <summary>Danh sách phạt theo trạng thái thanh toán (null = tất cả), tìm theo tên độc giả / mã phiếu.</summary>
        public List<PhatView> TimKiem(string trangThai, string tuKhoa)
        {
            tuKhoa = (tuKhoa ?? "").Trim();
            int maPhieu;
            bool laSo = int.TryParse(tuKhoa, out maPhieu);

            var query = from p in db.Phats
                        join pm in db.PhieuMuons on p.MaPhieu equals pm.MaPhieu
                        join d in db.DocGias on pm.MaDocGia equals d.MaDocGia
                        where (trangThai == null || p.TrangThaiThanhToan == trangThai)
                              && (tuKhoa == "" || d.HoTen.Contains(tuKhoa) || (laSo && p.MaPhieu == maPhieu))
                        orderby p.NgayPhat descending, p.MaPhat descending
                        select new PhatView
                        {
                            MaPhat = p.MaPhat,
                            MaPhieu = p.MaPhieu,
                            HoTen = d.HoTen,
                            SoNgayTre = p.SoNgayTre,
                            DonGiaPhat = p.DonGiaPhat,
                            SoTien = p.SoTien,
                            LyDo = p.LyDo,
                            NgayPhat = p.NgayPhat,
                            TrangThaiThanhToan = p.TrangThaiThanhToan
                        };
            return query.ToList();
        }

        public decimal TongTien(string trangThai)
        {
            return (from p in db.Phats
                    where trangThai == null || p.TrangThaiThanhToan == trangThai
                    select p.SoTien).Sum() ?? 0;
        }

        /// <summary>Danh sách mã phiếu mượn để chọn khi lập phạt thủ công (mất / hỏng sách...).</summary>
        public List<PhieuMuonView> GetPhieuMuonDeChon()
        {
            return (from pm in db.PhieuMuons
                    join d in db.DocGias on pm.MaDocGia equals d.MaDocGia
                    orderby pm.MaPhieu descending
                    select new PhieuMuonView
                    {
                        MaPhieu = pm.MaPhieu,
                        MaDocGia = pm.MaDocGia,
                        HoTen = d.HoTen,
                        NgayMuon = pm.NgayMuon,
                        HanTra = pm.HanTra,
                        NgayTraThucTe = pm.NgayTraThucTe,
                        TrangThai = pm.TrangThai
                    }).ToList();
        }

        public void ThemPhat(Phat phat)
        {
            KiemTraHopLe(phat);
            bool coPhieu = (from pm in db.PhieuMuons where pm.MaPhieu == phat.MaPhieu select pm).Any();
            if (!coPhieu) throw new Exception("Phiếu mượn không tồn tại.");

            if (phat.NgayPhat == null) phat.NgayPhat = DateTime.Today;
            if (string.IsNullOrEmpty(phat.TrangThaiThanhToan)) phat.TrangThaiThanhToan = TrangThai.ChuaThanhToan;
            Insert(phat);
        }

        public void CapNhatPhat(Phat phat)
        {
            KiemTraHopLe(phat);
            Phat cu = (from p in db.Phats where p.MaPhat == phat.MaPhat select p).SingleOrDefault();
            if (cu == null) throw new Exception("Không tìm thấy phiếu phạt.");
            if (cu.TrangThaiThanhToan == TrangThai.DaThanhToan)
                throw new Exception("Phiếu phạt đã thanh toán, không thể sửa.");

            cu.MaPhieu = phat.MaPhieu;
            cu.SoNgayTre = phat.SoNgayTre;
            cu.DonGiaPhat = phat.DonGiaPhat;
            cu.SoTien = phat.SoTien;
            cu.LyDo = phat.LyDo;
            cu.NgayPhat = phat.NgayPhat;
            db.SubmitChanges();
        }

        public void ThanhToan(int maPhat)
        {
            Phat cu = (from p in db.Phats where p.MaPhat == maPhat select p).SingleOrDefault();
            if (cu == null) throw new Exception("Không tìm thấy phiếu phạt.");
            if (cu.TrangThaiThanhToan == TrangThai.DaThanhToan)
                throw new Exception("Phiếu phạt này đã được thanh toán.");

            cu.TrangThaiThanhToan = TrangThai.DaThanhToan;
            db.SubmitChanges();
        }

        public void XoaPhat(int maPhat)
        {
            Phat cu = (from p in db.Phats where p.MaPhat == maPhat select p).SingleOrDefault();
            if (cu == null) throw new Exception("Không tìm thấy phiếu phạt.");
            if (cu.TrangThaiThanhToan == TrangThai.DaThanhToan)
                throw new Exception("Phiếu phạt đã thanh toán, không thể xóa.");
            Delete(cu);
        }

        private static void KiemTraHopLe(Phat phat)
        {
            if (phat.MaPhieu == null) throw new Exception("Vui lòng chọn phiếu mượn.");
            if ((phat.SoTien ?? 0) <= 0) throw new Exception("Số tiền phạt phải lớn hơn 0.");
            if ((phat.SoNgayTre ?? 0) < 0 || (phat.DonGiaPhat ?? 0) < 0)
                throw new Exception("Số ngày trễ / đơn giá không được âm.");
            if (string.IsNullOrWhiteSpace(phat.LyDo)) throw new Exception("Vui lòng nhập lý do phạt.");
        }
    }
}
