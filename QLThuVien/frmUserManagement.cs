using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using QLThuVien.Helpers;
using QLThuVien.Repositories;

namespace QLThuVien
{
    public partial class frmUserManagement : Form
    {
        private readonly NguoiDungRepository userRepository;

        public frmUserManagement()
        {
            InitializeComponent();
            userRepository = new NguoiDungRepository();
            Load += frmUserManagement_Load;
            
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            LoadRoles();
            LoadUsers();
        }

        private void LoadRoles()
        {
            List<VaiTro> roles = new MauRepository<VaiTro>().GetAll();
            cboVaiTro.DisplayMember = "TenVaiTro";
            cboVaiTro.ValueMember = "MaVaiTro";
            cboVaiTro.DataSource = roles;
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = userRepository.GetAll();
            if (dgvUsers.Columns["MatKhau"] != null)
            {
                dgvUsers.Columns["MatKhau"].Visible = false;
            }
            if (dgvUsers.Columns["VaiTro"] != null)
            {
                dgvUsers.Columns["VaiTro"].Visible = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string username = txtTenDangNhap.Text.Trim();
            string fullName = txtHoTen.Text.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(fullName) || cboVaiTro.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập, họ tên và chọn vai trò.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (userRepository.GetAll().Any(existingUser => string.Equals(existingUser.TenDangNhap, username, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NguoiDung user = new NguoiDung
            {
                TenDangNhap = username,
                HoTen = fullName,
                MaVaiTro = Convert.ToInt32(cboVaiTro.SelectedValue)
            };

            
            user.MatKhau = SecurityHelper.HashPassword("123456", user);

            try
            {
                userRepository.Insert(user);
                txtTenDangNhap.Clear();
                txtHoTen.Clear();
                LoadUsers();
                MessageBox.Show("Đã thêm người dùng. Mật khẩu mặc định: 123456.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thêm người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null || dgvUsers.CurrentRow.Cells["MaND"].Value == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần đặt lại mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["MaND"].Value);
            NguoiDung user = userRepository.GetAll().FirstOrDefault(existingUser => existingUser.MaND == userId);
            if (user == null)
            {
                MessageBox.Show("Không tìm thấy người dùng cần đặt lại mật khẩu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn đặt lại mật khẩu của '{user.TenDangNhap}' về 123456?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            user.MatKhau = SecurityHelper.HashPassword("123456", user);

            try
            {
                userRepository.Update(user);
                LoadUsers();
                MessageBox.Show("Đã đặt lại mật khẩu mặc định: 123456.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể đặt lại mật khẩu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["MaND"].Value);
            string username = dgvUsers.CurrentRow.Cells["TenDangNhap"].Value.ToString();

            // Chặn tự xóa chính mình
            if (userId == CurrentUser.MaND)
            {
                MessageBox.Show("Bạn không thể xóa tài khoản đang đăng nhập!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Bạn có chắc muốn xóa tài khoản '{username}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    NguoiDung user = userRepository.GetAll().FirstOrDefault(u => u.MaND == userId);
                    if (user != null)
                    {
                        userRepository.Delete(user);
                        LoadUsers();
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể xóa tài khoản này vì đã có dữ liệu liên quan (Phiếu mượn...).\nChi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null) return;

            int userId = Convert.ToInt32(dgvUsers.CurrentRow.Cells["MaND"].Value);

            if (userId == CurrentUser.MaND)
            {
                MessageBox.Show("Bạn không thể tự sửa vai trò của chính mình!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            NguoiDung user = userRepository.GetAll().FirstOrDefault(u => u.MaND == userId);

            if (user != null)
            {
                user.HoTen = txtHoTen.Text.Trim();
                user.MaVaiTro = Convert.ToInt32(cboVaiTro.SelectedValue);

                try
                {
                    userRepository.Update(user);
                    LoadUsers();
                    MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi cập nhật: " + ex.Message);
                }
            }
        }
    }
}
