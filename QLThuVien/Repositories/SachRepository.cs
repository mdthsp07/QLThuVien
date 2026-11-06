using System;
using System.Collections.Generic;
using System.Linq;

namespace QLThuVien.Repositories
{
    public class SachRepository : MauRepository<Sach>
    {
        public List<Sach> GetSachConHang()
        {
            return db.Saches.Where(s => s.SoLuongCon > 0).ToList();
        }

        public Sach GetById(int maSach)
        {
            return db.Saches.FirstOrDefault(s => s.MaSach == maSach);
        }

        /// <summary>Tìm sách theo tên / tác giả, lọc theo thể loại (null = tất cả).</summary>
        public List<SachView> TimKiem(string tuKhoa, int? maTheLoai)
        {
            tuKhoa = (tuKhoa ?? "").Trim();
            var query = from s in db.Saches
                        join tl in db.TheLoais on s.MaTheLoai equals tl.MaTheLoai into gTL
                        from tl in gTL.DefaultIfEmpty()
                        join nxb in db.NhaXuatBans on s.MaNXB equals nxb.MaNXB into gNXB
                        from nxb in gNXB.DefaultIfEmpty()
                        where (tuKhoa == "" || s.TenSach.Contains(tuKhoa) || s.TacGia.Contains(tuKhoa))
                              && (maTheLoai == null || s.MaTheLoai == maTheLoai)
                        orderby s.TenSach
                        select new SachView
                        {
                            MaSach = s.MaSach,
                            TenSach = s.TenSach,
                            TacGia = s.TacGia,
                            MaTheLoai = s.MaTheLoai,
                            TenTheLoai = tl.TenTheLoai,
                            MaNXB = s.MaNXB,
                            TenNXB = nxb.TenNXB,
                            NamXuatBan = s.NamXuatBan,
                            SoLuongTong = s.SoLuongTong,
                            SoLuongCon = s.SoLuongCon
                        };
            return query.ToList();
        }

        /// <summary>Danh sách sách còn trong kho (dùng cho lập phiếu mượn).</summary>
        public List<SachView> TimSachConHang(string tuKhoa)
        {
            return TimKiem(tuKhoa, null).Where(s => (s.SoLuongCon ?? 0) > 0).ToList();
        }

        /// <summary>Danh sách sách đã hết trong kho (chỉ những sách này mới cho đặt trước).</summary>
        public List<SachView> GetSachHetHang()
        {
            return TimKiem("", null).Where(s => (s.SoLuongCon ?? 0) <= 0).ToList();
        }

        public void ThemSach(Sach sach)
        {
            KiemTraHopLe(sach);
            // Sách mới nhập: toàn bộ đều đang có trong kho
            sach.SoLuongCon = sach.SoLuongTong;
            Insert(sach);
        }

        public void CapNhatSach(Sach sach)
        {
            KiemTraHopLe(sach);
            Sach cu = (from s in db.Saches where s.MaSach == sach.MaSach select s).SingleOrDefault();
            if (cu == null) throw new Exception("Không tìm thấy sách cần sửa.");

            // Số sách đang được mượn = Tổng - Còn. Tổng mới không được nhỏ hơn số đang mượn.
            int dangMuon = (cu.SoLuongTong ?? 0) - (cu.SoLuongCon ?? 0);
            if ((sach.SoLuongTong ?? 0) < dangMuon)
                throw new Exception($"Đang có {dangMuon} cuốn được mượn, số lượng tổng không được nhỏ hơn {dangMuon}.");

            cu.TenSach = sach.TenSach;
            cu.TacGia = sach.TacGia;
            cu.MaTheLoai = sach.MaTheLoai;
            cu.MaNXB = sach.MaNXB;
            cu.NamXuatBan = sach.NamXuatBan;
            cu.SoLuongTong = sach.SoLuongTong;
            cu.SoLuongCon = sach.SoLuongTong - dangMuon;
            db.SubmitChanges();
        }

        public void XoaSach(int maSach)
        {
            Sach cu = (from s in db.Saches where s.MaSach == maSach select s).SingleOrDefault();
            if (cu == null) throw new Exception("Không tìm thấy sách cần xóa.");

            bool coLichSuMuon = (from ct in db.ChiTietMuons where ct.MaSach == maSach select ct).Any();
            if (coLichSuMuon) throw new Exception("Sách đã có lịch sử mượn, không thể xóa.");

            bool coDatTruoc = (from dt in db.DatTruocs where dt.MaSach == maSach select dt).Any();
            if (coDatTruoc) throw new Exception("Sách đang có phiếu đặt trước, không thể xóa.");

            Delete(cu);
        }

        private static void KiemTraHopLe(Sach sach)
        {
            if (string.IsNullOrWhiteSpace(sach.TenSach))
                throw new Exception("Tên sách không được để trống.");
            if ((sach.SoLuongTong ?? 0) < 0)
                throw new Exception("Số lượng không được âm.");
            if (sach.NamXuatBan != null && (sach.NamXuatBan < 1000 || sach.NamXuatBan > DateTime.Today.Year))
                throw new Exception("Năm xuất bản không hợp lệ.");
        }
    }
}
