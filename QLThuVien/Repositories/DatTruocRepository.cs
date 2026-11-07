using System;
using System.Collections.Generic;
using System.Linq;

namespace QLThuVien.Repositories
{
    public class DatTruocRepository : MauRepository<DatTruoc>
    {
        /// <summary>Danh sách đặt trước theo trạng thái (null = tất cả), tìm theo tên độc giả / tên sách.</summary>
        public List<DatTruocView> TimKiem(string trangThai, string tuKhoa)
        {
            tuKhoa = (tuKhoa ?? "").Trim();
            var query = from dt in db.DatTruocs
                        join d in db.DocGias on dt.MaDocGia equals d.MaDocGia
                        join s in db.Saches on dt.MaSach equals s.MaSach
                        where (trangThai == null || dt.TrangThai == trangThai)
                              && (tuKhoa == "" || d.HoTen.Contains(tuKhoa) || s.TenSach.Contains(tuKhoa))
                        orderby dt.NgayDat descending, dt.MaDatTruoc descending
                        select new DatTruocView
                        {
                            MaDatTruoc = dt.MaDatTruoc,
                            MaDocGia = dt.MaDocGia,
                            HoTen = d.HoTen,
                            MaSach = dt.MaSach,
                            TenSach = s.TenSach,
                            SoLuongCon = s.SoLuongCon,
                            NgayDat = dt.NgayDat,
                            TrangThai = dt.TrangThai
                        };
            return query.ToList();
        }

        /// <summary>Các lượt đặt trước đang chờ của những sách trong danh sách (dùng khi trả sách để báo).</summary>
        public List<DatTruocView> GetDangChoTheoSach(List<int> maSachs)
        {
            return (from dt in db.DatTruocs
                    join d in db.DocGias on dt.MaDocGia equals d.MaDocGia
                    join s in db.Saches on dt.MaSach equals s.MaSach
                    where dt.TrangThai == TrangThai.DangCho && maSachs.Contains(s.MaSach)
                    orderby dt.NgayDat
                    select new DatTruocView
                    {
                        MaDatTruoc = dt.MaDatTruoc,
                        MaDocGia = dt.MaDocGia,
                        HoTen = d.HoTen,
                        MaSach = dt.MaSach,
                        TenSach = s.TenSach,
                        SoLuongCon = s.SoLuongCon,
                        NgayDat = dt.NgayDat,
                        TrangThai = dt.TrangThai
                    }).ToList();
        }

        public void DatSach(int maDocGia, int maSach, DateTime ngayDat)
        {
            bool coDocGia = (from d in db.DocGias where d.MaDocGia == maDocGia select d).Any();
            if (!coDocGia) throw new Exception("Độc giả không tồn tại.");

            Sach sach = (from s in db.Saches where s.MaSach == maSach select s).SingleOrDefault();
            if (sach == null) throw new Exception("Sách không tồn tại.");
            if ((sach.SoLuongCon ?? 0) > 0)
                throw new Exception($"Sách '{sach.TenSach}' còn {sach.SoLuongCon} cuốn trong kho, hãy lập phiếu mượn trực tiếp.");

            bool daDat = (from dt in db.DatTruocs
                          where dt.MaDocGia == maDocGia && dt.MaSach == maSach && dt.TrangThai == TrangThai.DangCho
                          select dt).Any();
            if (daDat) throw new Exception("Độc giả đã đặt trước cuốn sách này và đang chờ.");

            Insert(new DatTruoc
            {
                MaDocGia = maDocGia,
                MaSach = maSach,
                NgayDat = ngayDat.Date,
                TrangThai = TrangThai.DangCho
            });
        }

        /// <summary>Chuyển trạng thái phiếu đặt (chỉ áp dụng cho phiếu "Đang chờ").</summary>
        public void CapNhatTrangThai(int maDatTruoc, string trangThaiMoi)
        {
            DatTruoc dt = (from x in db.DatTruocs where x.MaDatTruoc == maDatTruoc select x).SingleOrDefault();
            if (dt == null) throw new Exception("Không tìm thấy phiếu đặt trước.");
            if (dt.TrangThai != TrangThai.DangCho)
                throw new Exception($"Phiếu đặt đang ở trạng thái '{dt.TrangThai}', không thể thay đổi.");

            dt.TrangThai = trangThaiMoi;
            db.SubmitChanges();
        }

        public void XoaDatTruoc(int maDatTruoc)
        {
            DatTruoc dt = (from x in db.DatTruocs where x.MaDatTruoc == maDatTruoc select x).SingleOrDefault();
            if (dt == null) throw new Exception("Không tìm thấy phiếu đặt trước.");
            Delete(dt);
        }
    }
}
