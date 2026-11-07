using System;
using System.Windows.Forms;
using QLThuVien.Helpers;
using QLThuVien.Repositories;

namespace QLThuVien
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string password = txtMatKhau.Text;

            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            NguoiDungRepository repo = new NguoiDungRepository();
            NguoiDung user = repo.GetByTenDangNhap(username);

           
            if (user != null && SecurityHelper.HashPassword(password, user) == user.MatKhau)
            {
               
                CurrentUser.MaND = user.MaND;
                CurrentUser.TenDangNhap = user.TenDangNhap;
                CurrentUser.MaVaiTro = user.MaVaiTro ?? 0;
                CurrentUser.HoTen = user.HoTen;

              
                this.Hide();
                frmMain main = new frmMain();
                main.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không chính xác!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }
    }
}