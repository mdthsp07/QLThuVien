using System;
using System.Collections.Generic;
using System.Linq;

namespace QLThuVien.Repositories
{
    public class NhaXuatBanRepository : MauRepository<NhaXuatBan>
    {
        public List<NhaXuatBanView> TimKiem(string tuKhoa)
        {
            tuKhoa = (tuKhoa ?? "").Trim();
            var query = from nxb in db.NhaXuatBans
                        where tuKhoa == ""
                              || nxb.TenNXB.Contains(tuKhoa)
                              || nxb.DiaChi.Contains(tuKhoa)
                              || nxb.SoDienThoai.Contains(tuKhoa)
                        orderby nxb.TenNXB
                        select new NhaXuatBanView
                        {
                            MaNXB = nxb.MaNXB,
                            TenNXB = nxb.TenNXB,
                            DiaChi = nxb.DiaChi,
                            SoDienThoai = nxb.SoDienThoai,
                            SoDauSach = nxb.Saches.Count()
                        };
            return query.ToList();
        }

        public List<NhaXuatBan> GetDanhSachSapXep()
        {
            return (from nxb in db.NhaXuatBans orderby nxb.TenNXB select nxb).ToList();
        }

        public bool TrungTen(string ten, int boQuaMa)
        {
            return (from nxb in db.NhaXuatBans
                    where nxb.TenNXB == ten && nxb.MaNXB != boQuaMa
                    select nxb).Any();
        }

        private static void KiemTraHopLe(NhaXuatBan nxb)
        {
            if (string.IsNullOrWhiteSpace(nxb.TenNXB))
                throw new Exception("Tên nhà xuất bản không được để trống.");
            if (!string.IsNullOrEmpty(nxb.SoDienThoai) && !nxb.SoDienThoai.All(char.IsDigit))
                throw new Exception("Số điện thoại chỉ gồm chữ số.");
        }

        public void ThemNXB(NhaXuatBan nxb)
        {
            KiemTraHopLe(nxb);
            if (TrungTen(nxb.TenNXB, 0))
                throw new Exception("Tên nhà xuất bản đã tồn tại.");
            Insert(nxb);
        }

        public void CapNhatNXB(NhaXuatBan nxb)
        {
            KiemTraHopLe(nxb);
            NhaXuatBan cu = (from x in db.NhaXuatBans where x.MaNXB == nxb.MaNXB select x).SingleOrDefault();
            if (cu == null) throw new Exception("Không tìm thấy nhà xuất bản cần sửa.");
            if (TrungTen(nxb.TenNXB, nxb.MaNXB))
                throw new Exception("Tên nhà xuất bản đã tồn tại.");

            cu.TenNXB = nxb.TenNXB;
            cu.DiaChi = nxb.DiaChi;
            cu.SoDienThoai = nxb.SoDienThoai;
            db.SubmitChanges();
        }

        public void XoaNXB(int maNXB)
        {
            NhaXuatBan cu = (from x in db.NhaXuatBans where x.MaNXB == maNXB select x).SingleOrDefault();
            if (cu == null) throw new Exception("Không tìm thấy nhà xuất bản cần xóa.");

            bool dangDung = (from s in db.Saches where s.MaNXB == maNXB select s).Any();
            if (dangDung) throw new Exception("Nhà xuất bản đang có sách, không thể xóa.");

            Delete(cu);
        }
    }
}
