using System.Configuration;
using System.Linq;

namespace QLThuVien.Helpers
{
    public static class PhanQuyenHelper
    {
        public static bool CoQuyen(string tenChucNang, int maVaiTro)
        {
            string connStr = ConfigurationManager.ConnectionStrings["QLThuVienConn"].ConnectionString;

            
            using (var db = new QuanLyThuVienDataContext(connStr))
            {
                var query = from pq in db.PhanQuyens
                            join cn in db.ChucNangs on pq.MaChucNang equals cn.MaChucNang
                            where pq.MaVaiTro == maVaiTro && cn.TenChucNang.Trim().ToLower() == tenChucNang.Trim().ToLower()
                            select pq;
                return query.Any();
            }
        }
    }
}