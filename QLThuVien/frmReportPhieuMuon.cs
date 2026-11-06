using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms; 
using QLThuVien.Repositories;      

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
            try
            {
                PhieuMuonRepository repo = new PhieuMuonRepository();
                var data = repo.LayDuLieuBaoCaoPhieuMuon();

                reportViewerPhieuMuon.LocalReport.DataSources.Clear();

                ReportDataSource rds = new ReportDataSource("DataSet1", data);
                reportViewerPhieuMuon.LocalReport.DataSources.Add(rds);

                this.reportViewerPhieuMuon.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
