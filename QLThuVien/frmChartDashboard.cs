using QLThuVien.Repositories;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QLThuVien
{
    public partial class frmChartDashboard : Form
    {
        public frmChartDashboard()
        {
            InitializeComponent();
        }

        private void frmChartDashboard_Load(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ Repository qua LINQ và đổ thẳng vào Series đầu tiên
            var data = new SachRepository().GetThongKeSachTheoTheLoai();

            chartTheLoai.Series[0].Points.Clear();
            foreach (var item in data)
            {
                chartTheLoai.Series[0].Points.AddXY(item.Key, item.Value);
            }
            
            chartDuong.Series[0].ChartType = SeriesChartType.Line;
            chartDuong.Series[0].Points.Clear();
            
            using (var db = new QuanLyThuVienDataContext())
            {
                var dataThang = db.PhieuMuons
                    .Where(pm => pm.NgayMuon != null)
                    .GroupBy(pm => pm.NgayMuon.Value.Month)
                    .Select(g => new { Thang = g.Key, SoPhieu = g.Count() })
                    .OrderBy(x => x.Thang)
                    .ToList();

                foreach (var item in dataThang)
                {
                    chartDuong.Series[0].Points.AddXY("Tháng " + item.Thang, item.SoPhieu);
                }
            }
            
            chartTron.Series[0].ChartType = SeriesChartType.Pie;
            chartTron.Series[0].Points.Clear();
            foreach (var item in data)
            {
                chartTron.Series[0].Points.AddXY(item.Key, item.Value);
            }
        }

        private void chartTheLoai_Click(object sender, EventArgs e)
        {

        }
    }
}