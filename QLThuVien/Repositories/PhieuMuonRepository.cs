using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace QLThuVien.Repositories
{
    public class PhieuMuonRepository : MauRepository<PhieuMuon>
    {
        public bool LapPhieuMuon(PhieuMuon phieu, List<ChiTietMuon> chiTiets)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    db.PhieuMuons.InsertOnSubmit(phieu);
                    db.SubmitChanges(); 

                    foreach (var ct in chiTiets)
                    {
                        var sach = db.Saches.FirstOrDefault(s => s.MaSach == ct.MaSach);
                        if (sach == null || sach.SoLuongCon < ct.SoLuong)
                        {
                            throw new Exception($"Sách '{sach?.TenSach}' không đủ số lượng tồn kho!");
                        }

                        sach.SoLuongCon -= ct.SoLuong;

                        ct.MaPhieu = phieu.MaPhieu;
                        db.ChiTietMuons.InsertOnSubmit(ct);
                    }

                    db.SubmitChanges(); 
                    scope.Complete();   
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi lập phiếu: " + ex.Message);
                }
            }
        }

        public dynamic LayDuLieuBaoCaoPhieuMuon()
        {
            var data = from pm in db.PhieuMuons
                       join dg in db.DocGias on pm.MaDocGia equals dg.MaDocGia
                       select new
                       {
                           MaPhieu = pm.MaPhieu,
                           TenDocGia = dg.HoTen,
                           NgayMuon = pm.NgayMuon,
                           NgayTra = pm.HanTra,
                           TrangThai = pm.TrangThai
                       };
            return data.ToList();
        }
    }
}