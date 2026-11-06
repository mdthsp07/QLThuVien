using System;
using System.Collections.Generic;
using System.Linq;

namespace QLThuVien.Repositories
{
    public class DocGiaRepository : MauRepository<DocGia>
    {
        public DocGia GetById(int maDocGia)
        {
            return db.DocGias.FirstOrDefault(d => d.MaDocGia == maDocGia);
        }

        public List<DocGiaView> TimKiem(string tuKhoa)
        {
            tuKhoa = (tuKhoa ?? "").Trim();
            var query = from d in db.DocGias
                        where tuKhoa == ""
                              || d.HoTen.Contains(tuKhoa)
                              || d.SoDienThoai.Contains(tuKhoa)
                              || d.Email.Contains(tuKhoa)
                        orderby d.HoTen
                        select new DocGiaView
                        {
                            MaDocGia = d.MaDocGia,
                            HoTen = d.HoTen,
                            NgaySinh = d.NgaySinh,
                            DiaChi = d.DiaChi,
                            SoDienThoai = d.SoDienThoai,
                            Email = d.Email,
                            LoaiDocGia = d.LoaiDocGia,
                            SoSachDangMuon = (from pm in db.PhieuMuons
                                              join ct in db.ChiTietMuons on pm.MaPhieu equals ct.MaPhieu
                                              where pm.MaDocGia == d.MaDocGia && pm.TrangThai == TrangThai.DangMuon
                                              select ct.SoLuong).Sum() ?? 0
                        };
            return query.ToList();
        }

        public List<DocGia> GetDanhSachSapXep()
        {
            return (from d in db.DocGias orderby d.HoTen select d).ToList();
        }

        /// <summary>Tổng số cuốn sách độc giả đang mượn (chưa trả).</summary>
        public int SoSachDangMuon(int maDocGia)
        {
            return (from pm in db.PhieuMuons
                    join ct in db.ChiTietMuons on pm.MaPhieu equals ct.MaPhieu
                    where pm.MaDocGia == maDocGia && pm.TrangThai == TrangThai.DangMuon
                    select ct.SoLuong).Sum() ?? 0;
        }

        /// <summary>Độc giả có phiếu đang mượn đã quá hạn hay không.</summary>
        public bool CoPhieuQuaHan(int maDocGia)
        {
            DateTime homNay = DateTime.Today;
            return (from pm in db.PhieuMuons
                    where pm.MaDocGia == maDocGia
                          && pm.TrangThai == TrangThai.DangMuon
                          && pm.HanTra < homNay
                    select pm).Any();
        }

        /// <summary>Tổng tiền phạt độc giả chưa thanh toán.</summary>
        public decimal TienPhatChuaThanhToan(int maDocGia)
        {
            return (from p in db.Phats
                    join pm in db.PhieuMuons on p.MaPhieu equals pm.MaPhieu
                    where pm.MaDocGia == maDocGia && p.TrangThaiThanhToan == TrangThai.ChuaThanhToan
                    select p.SoTien).Sum() ?? 0;
        }

        public void ThemDocGia(DocGia docGia)
        {
            KiemTraHopLe(docGia);
            Insert(docGia);
        }

        public void CapNhatDocGia(DocGia docGia)
        {
            KiemTraHopLe(docGia);
            DocGia cu = (from d in db.DocGias where d.MaDocGia == docGia.MaDocGia select d).SingleOrDefault();
            if (cu == null) throw new Exception("Không tìm thấy độc giả cần sửa.");

            cu.HoTen = docGia.HoTen;
            cu.NgaySinh = docGia.NgaySinh;
            cu.DiaChi = docGia.DiaChi;
            cu.SoDienThoai = docGia.SoDienThoai;
            cu.Email = docGia.Email;
            cu.LoaiDocGia = docGia.LoaiDocGia;
            db.SubmitChanges();
        }

        public void XoaDocGia(int maDocGia)
        {
            DocGia cu = (from d in db.DocGias where d.MaDocGia == maDocGia select d).SingleOrDefault();
            if (cu == null) throw new Exception("Không tìm thấy độc giả cần xóa.");

            bool coPhieuMuon = (from pm in db.PhieuMuons where pm.MaDocGia == maDocGia select pm).Any();
            if (coPhieuMuon) throw new Exception("Độc giả đã có phiếu mượn, không thể xóa.");

            var datTruocs = (from dt in db.DatTruocs where dt.MaDocGia == maDocGia select dt).ToList();
            db.DatTruocs.DeleteAllOnSubmit(datTruocs);
            Delete(cu);
        }

        private static void KiemTraHopLe(DocGia docGia)
        {
            if (string.IsNullOrWhiteSpace(docGia.HoTen))
                throw new Exception("Họ tên không được để trống.");
            if (docGia.NgaySinh != null && docGia.NgaySinh > DateTime.Today)
                throw new Exception("Ngày sinh không hợp lệ.");
            if (!string.IsNullOrEmpty(docGia.SoDienThoai) && !docGia.SoDienThoai.All(char.IsDigit))
                throw new Exception("Số điện thoại chỉ gồm chữ số.");
            if (!string.IsNullOrEmpty(docGia.Email) && !docGia.Email.Contains("@"))
                throw new Exception("Email không hợp lệ.");
        }
    }
}
