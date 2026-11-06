using System;
using System.Windows.Forms;
using QLThuVien.Repositories;

namespace QLThuVien
{
    public partial class frmQuanLyNhaXuatBan : Form
    {
        private enum CheDo { Xem, Them, Sua }
        private CheDo cheDo = CheDo.Xem;

        public frmQuanLyNhaXuatBan()
        {
            InitializeComponent();
        }

        private void frmQuanLyNhaXuatBan_Load(object sender, EventArgs e)
        {
            LoadData();
            DatCheDo(CheDo.Xem);
        }

        private void LoadData()
        {
            try
            {
                dgvData.DataSource = new NhaXuatBanRepository().TimKiem(txtTimKiem.Text);
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
            txtTenNXB.ReadOnly = !dangNhap;
            txtDiaChi.ReadOnly = !dangNhap;
            txtSoDienThoai.ReadOnly = !dangNhap;
            btnThem.Enabled = !dangNhap;
            btnSua.Enabled = !dangNhap;
            btnXoa.Enabled = !dangNhap;
            btnLuu.Enabled = dangNhap;
            btnHuy.Enabled = dangNhap;
            dgvData.Enabled = !dangNhap;
        }

        private NhaXuatBanView DongDangChon()
        {
            return dgvData.CurrentRow?.DataBoundItem as NhaXuatBanView;
        }

        private void HienThi(NhaXuatBanView x)
        {
            txtMaNXB.Text = x?.MaNXB.ToString() ?? "";
            txtTenNXB.Text = x?.TenNXB ?? "";
            txtDiaChi.Text = x?.DiaChi ?? "";
            txtSoDienThoai.Text = x?.SoDienThoai ?? "";
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem) HienThi(DongDangChon());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HienThi(null);
            DatCheDo(CheDo.Them);
            txtTenNXB.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (DongDangChon() == null)
            {
                MessageBox.Show("Vui lòng chọn nhà xuất bản cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DatCheDo(CheDo.Sua);
            txtTenNXB.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NhaXuatBanView x = DongDangChon();
            if (x == null)
            {
                MessageBox.Show("Vui lòng chọn nhà xuất bản cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Xóa nhà xuất bản '{x.TenNXB}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                new NhaXuatBanRepository().XoaNXB(x.MaNXB);
                LoadData();
                MessageBox.Show("Đã xóa nhà xuất bản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string ten = txtTenNXB.Text.Trim();
            string sdt = txtSoDienThoai.Text.Trim();
            if (ten == "")
            {
                MessageBox.Show("Tên nhà xuất bản không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNXB.Focus();
                return;
            }

            var nxb = new NhaXuatBan
            {
                TenNXB = ten,
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = sdt
            };

            try
            {
                var repo = new NhaXuatBanRepository();
                if (cheDo == CheDo.Them)
                {
                    repo.ThemNXB(nxb);
                }
                else
                {
                    nxb.MaNXB = int.Parse(txtMaNXB.Text);
                    repo.CapNhatNXB(nxb);
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
