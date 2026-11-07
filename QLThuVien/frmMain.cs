using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QLThuVien.Helpers;

namespace QLThuVien
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent(); 
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ApplyRBAC();
        }

        // Ánh xạ tên menu -> tên chức năng trong bảng ChucNang
        private static readonly Dictionary<string, string> ChucNangTheoMenu = new Dictionary<string, string>
        {
            { "menuQuanLyNguoiDung", "Quản lý Tài khoản" },
            { "menuQuanLyVaiTro", "Quản lý Tài khoản" },
            { "menuQuanLySach", "Quản lý Sách" },
            { "menuQuanLyTheLoai", "Quản lý Sách" },
            { "menuQuanLyNhaXuatBan", "Quản lý Sách" },
            { "menuQuanLyDocGia", "Quản lý Độc giả" },
            { "menuLapPhieuMuon", "Lập phiếu mượn" },
            { "menuTraSach", "Lập phiếu mượn" },
            { "menuDatTruoc", "Lập phiếu mượn" },
            { "menuQuanLyPhat", "Lập phiếu mượn" },
            { "menuBaoCao", "Báo cáo - Thống kê" }
        };

        private void ApplyRBAC()
        {
            if (menuStrip1 != null)
            {
                foreach (ToolStripItem item in menuStrip1.Items)
                {
                    if (item.Name == "menuHeThong") continue;
                    ApDungQuyen(item);
                }
            }
        }

        // Duyệt cả menu con; menu cha bị ẩn nếu không còn menu con nào được phép.
        // Dùng Available (không dùng Visible) vì Visible của menu con luôn trả về false khi menu cha chưa mở.
        private bool ApDungQuyen(ToolStripItem item)
        {
            bool duocPhep;
            string tenChucNang;
            var menu = item as ToolStripMenuItem;

            if (ChucNangTheoMenu.TryGetValue(item.Name, out tenChucNang))
            {
                duocPhep = PhanQuyenHelper.CoQuyen(tenChucNang, CurrentUser.MaVaiTro);
            }
            else if (menu != null && menu.DropDownItems.Count > 0)
            {
                duocPhep = false;
                foreach (ToolStripItem con in menu.DropDownItems)
                {
                    if (ApDungQuyen(con)) duocPhep = true;
                }
            }
            else
            {
                duocPhep = true;
            }

            item.Available = duocPhep;
            return duocPhep;
        }

        private void MoForm(Form frm)
        {
            using (frm)
            {
                frm.ShowDialog(this);
            }
        }

        private void menuQuanLySach_Click(object sender, EventArgs e) => MoForm(new frmQuanLySach());
        private void menuQuanLyDocGia_Click(object sender, EventArgs e) => MoForm(new frmQuanLyDocGia());
        private void menuQuanLyTheLoai_Click(object sender, EventArgs e) => MoForm(new frmQuanLyTheLoai());
        private void menuQuanLyNhaXuatBan_Click(object sender, EventArgs e) => MoForm(new frmQuanLyNhaXuatBan());
        private void menuLapPhieuMuon_Click(object sender, EventArgs e) => MoForm(new frmLapPhieuMuon());
        private void menuTraSach_Click(object sender, EventArgs e) => MoForm(new frmTraSach());
        private void menuDatTruoc_Click(object sender, EventArgs e) => MoForm(new frmDatTruoc());
        private void menuQuanLyPhat_Click(object sender, EventArgs e) => MoForm(new frmQuanLyPhat());

        private void menuHeThong_Click(object sender, EventArgs e)
        {
          
        }

        private void menuDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword();
            frm.ShowDialog();
        }

        private void menuDangXuat_Click(object sender, EventArgs e)
        {
            CurrentUser.Clear();
            this.Hide();
            frmLogin login = new frmLogin();
            login.ShowDialog();
            this.Close();
        }

        private void menuQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            frmUserManagement frm = new frmUserManagement();
            frm.ShowDialog();
        }

        private void menuQuanLyVaiTro_Click(object sender, EventArgs e)
        {
            frmRoleManagement frm = new frmRoleManagement();
            frm.ShowDialog();
        }
    }
}