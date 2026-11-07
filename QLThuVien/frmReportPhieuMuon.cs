using Microsoft.Reporting.WinForms; 
using QLThuVien.Repositories;      
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLThuVien.Helpers;

namespace QLThuVien
{
    public partial class frmReportPhieuMuon : Form
    {

        public frmReportPhieuMuon()
        {
            InitializeComponent();
        }

        private void frmReportPhieuMuon_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
               
                int maPhieu;
                if (!int.TryParse(txtMaPhieu.Text.Trim(), out maPhieu))
                {
                    MessageBox.Show("Vui lòng nhập Mã Phiếu là số!", "Thông báo");
                    return;
                }

           
                PhieuMuonRepository repo = new PhieuMuonRepository();
                var allData = (IEnumerable<dynamic>)repo.LayDuLieuBaoCaoPhieuMuon();


                var data = allData.Where(x => x.MaPhieu == maPhieu).ToList();

                if (data.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy phiếu mượn số " + maPhieu, "Thông báo");
                    return;
                }

                
                reportViewerPhieuMuon.LocalReport.DataSources.Clear();
                ReportDataSource rds = new ReportDataSource("DataSet1", data); 
                reportViewerPhieuMuon.LocalReport.DataSources.Add(rds);

                string tenNguoiIn = CurrentUser.HoTen;
                if (string.IsNullOrEmpty(tenNguoiIn)) tenNguoiIn = "Admin";

                ReportParameter[] param = new ReportParameter[]
                {
                    new ReportParameter("NguoiInParam", tenNguoiIn)
                };
                reportViewerPhieuMuon.LocalReport.SetParameters(param);


                this.reportViewerPhieuMuon.RefreshReport();
            }
            catch (Exception ex)
            {
                string loiChiTiet = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show("Lỗi in báo cáo: " + loiChiTiet, "Lỗi");
            }
        }
    }
}
