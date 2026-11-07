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
            this.Load += frmChartDashboard_Load;
        }

        private void frmChartDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                
                var data = new SachRepository().GetThongKeSachTheoTheLoai();

                chartTheLoai.Series[0].Points.Clear();
                foreach (var item in data)
                {
                    chartTheLoai.Series[0].Points.AddXY(item.Key, item.Value);
                }

              
                
                chartDuong.Series[0].Points.Clear();

                
                
                
                chartDuong.Legends[0].Enabled = false;

                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["QLThuVienConn"].ConnectionString;
                using (var db = new QuanLyThuVienDataContext(connStr))
                {
                    var dataThang = db.Phats
                        .Where(p => p.NgayPhat != null)
                        .GroupBy(p => p.NgayPhat.Value.Month)
                        .Select(g => new {
                            Thang = g.Key,
                            TongTien = g.Sum(p => p.SoTien) // Đã dùng hàm SUM theo yêu cầu
                        })
                        .OrderBy(x => x.Thang)
                        .ToList();

                    foreach (var item in dataThang)
                    {
                        chartDuong.Series[0].Points.AddXY("Tháng " + item.Thang, item.TongTien);
                    }
                }

                
                
                chartTron.Series[0].Points.Clear();
                
                foreach (var item in data)
                {
                    chartTron.Series[0].Points.AddXY(item.Key, item.Value);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Lỗi khi tải biểu đồ: " + ex.Message, "Lỗi");
            }
        }

        private void chartTheLoai_Click(object sender, EventArgs e)
        {

        }
    }
}