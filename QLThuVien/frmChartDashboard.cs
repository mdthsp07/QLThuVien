using System;
using System.Windows.Forms;
using QLThuVien.Repositories;

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
        }
    }
}