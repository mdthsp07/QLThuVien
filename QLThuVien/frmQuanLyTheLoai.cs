using System;
using System.Windows.Forms;
using QLThuVien.Repositories;

namespace QLThuVien
{
    public partial class frmQuanLyTheLoai : Form
    {
        private enum CheDo { Xem, Them, Sua }
        private CheDo cheDo = CheDo.Xem;

        public frmQuanLyTheLoai()
        {
            InitializeComponent();
        }

        private void frmQuanLyTheLoai_Load(object sender, EventArgs e)
        {
            LoadData();
            DatCheDo(CheDo.Xem);
        }

        private void LoadData()
        {
            try
            {
                dgvData.DataSource = new TheLoaiRepository().TimKiem(txtTimKiem.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DatCheDo(CheDo moi)
        {
            cheDo = moi;
            bool dangNhap = moi != CheDo.Xem;
            txtTenTheLoai.ReadOnly = !dangNhap;
            btnThem.Enabled = !dangNhap;
            btnSua.Enabled = !dangNhap;
            btnXoa.Enabled = !dangNhap;
            btnLuu.Enabled = dangNhap;
            btnHuy.Enabled = dangNhap;
            dgvData.Enabled = !dangNhap;
        }

        private TheLoaiView DongDangChon()
        {
            return dgvData.CurrentRow?.DataBoundItem as TheLoaiView;
        }

        private void HienThi(TheLoaiView tl)
        {
            txtMaTheLoai.Text = tl?.MaTheLoai.ToString() ?? "";
            txtTenTheLoai.Text = tl?.TenTheLoai ?? "";
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem) HienThi(DongDangChon());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HienThi(null);
            DatCheDo(CheDo.Them);
            txtTenTheLoai.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (DongDangChon() == null)
            {
                MessageBox.Show("Vui lòng chọn thể loại cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DatCheDo(CheDo.Sua);
            txtTenTheLoai.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            TheLoaiView tl = DongDangChon();
            if (tl == null)
            {
                MessageBox.Show("Vui lòng chọn thể loại cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Xóa thể loại '{tl.TenTheLoai}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                new TheLoaiRepository().XoaTheLoai(tl.MaTheLoai);
                LoadData();
                MessageBox.Show("Đã xóa thể loại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ten = txtTenTheLoai.Text.Trim();
            if (ten == "")
            {
                MessageBox.Show("Tên thể loại không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenTheLoai.Focus();
                return;
            }

            try
            {
                var repo = new TheLoaiRepository();
                if (cheDo == CheDo.Them)
                {
                    repo.ThemTheLoai(new TheLoai { TenTheLoai = ten });
                }
                else
                {
                    repo.CapNhatTheLoai(new TheLoai { MaTheLoai = int.Parse(txtMaTheLoai.Text), TenTheLoai = ten });
                }
                DatCheDo(CheDo.Xem);
                LoadData();
                MessageBox.Show("Lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DatCheDo(CheDo.Xem);
            HienThi(DongDangChon());
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadData();
                e.SuppressKeyPress = true;
            }
        }
    }
}
