using System;
using System.Collections.Generic;
using System.Linq;

namespace QLThuVien.Repositories
{
    public class TheLoaiRepository : MauRepository<TheLoai>
    {
        public List<TheLoaiView> TimKiem(string tuKhoa)
        {
            tuKhoa = (tuKhoa ?? "").Trim();
            var query = from tl in db.TheLoais
                        where tuKhoa == "" || tl.TenTheLoai.Contains(tuKhoa)
                        orderby tl.TenTheLoai
                        select new TheLoaiView
                        {
                            MaTheLoai = tl.MaTheLoai,
                            TenTheLoai = tl.TenTheLoai,
                            SoDauSach = tl.Saches.Count()
                        };
            return query.ToList();
        }

        public List<TheLoai> GetDanhSachSapXep()
        {
            return (from tl in db.TheLoais orderby tl.TenTheLoai select tl).ToList();
        }

        public bool TrungTen(string ten, int boQuaMa)
        {
            return (from tl in db.TheLoais
                    where tl.TenTheLoai == ten && tl.MaTheLoai != boQuaMa
                    select tl).Any();
        }

        public void ThemTheLoai(TheLoai theLoai)
        {
            if (TrungTen(theLoai.TenTheLoai, 0))
                throw new Exception("Tên thể loại đã tồn tại.");
            Insert(theLoai);
        }

        public void CapNhatTheLoai(TheLoai theLoai)
        {
            TheLoai cu = (from tl in db.TheLoais where tl.MaTheLoai == theLoai.MaTheLoai select tl).SingleOrDefault();
            if (cu == null) throw new Exception("Không tìm thấy thể loại cần sửa.");
            if (TrungTen(theLoai.TenTheLoai, theLoai.MaTheLoai))
                throw new Exception("Tên thể loại đã tồn tại.");

            cu.TenTheLoai = theLoai.TenTheLoai;
            db.SubmitChanges();
        }

        public void XoaTheLoai(int maTheLoai)
        {
            TheLoai cu = (from tl in db.TheLoais where tl.MaTheLoai == maTheLoai select tl).SingleOrDefault();
            if (cu == null) throw new Exception("Không tìm thấy thể loại cần xóa.");

            bool dangDung = (from s in db.Saches where s.MaTheLoai == maTheLoai select s).Any();
            if (dangDung) throw new Exception("Thể loại đang có sách, không thể xóa.");

            Delete(cu);
        }
    }
}
