using System;
using System.Windows.Forms;
using QLThuVien.Repositories;

namespace QLThuVien
{
    public partial class frmQuanLyDocGia : Form
    {
        private enum CheDo { Xem, Them, Sua }
        private CheDo cheDo = CheDo.Xem;

        private static readonly string[] LoaiDocGias = { "Sinh viên", "Giảng viên", "Cán bộ", "Khách" };

        public frmQuanLyDocGia()
        {
            InitializeComponent();
        }

        private void frmQuanLyDocGia_Load(object sender, EventArgs e)
        {
            cboLoaiDocGia.Items.AddRange(LoaiDocGias);
            cboLoaiDocGia.SelectedIndex = 0;
            dtpNgaySinh.MaxDate = DateTime.Today;
            LoadData();
            DatCheDo(CheDo.Xem);
        }

        private void LoadData()
        {
            try
            {
                dgvData.DataSource = new DocGiaRepository().TimKiem(txtTimKiem.Text);
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
            txtHoTen.ReadOnly = !dangNhap;
            txtSoDienThoai.ReadOnly = !dangNhap;
            txtEmail.ReadOnly = !dangNhap;
            txtDiaChi.ReadOnly = !dangNhap;
            cboLoaiDocGia.Enabled = dangNhap;
            dtpNgaySinh.Enabled = dangNhap;
            btnThem.Enabled = !dangNhap;
            btnSua.Enabled = !dangNhap;
            btnXoa.Enabled = !dangNhap;
            btnLuu.Enabled = dangNhap;
            btnHuy.Enabled = dangNhap;
            dgvData.Enabled = !dangNhap;
        }

        private DocGiaView DongDangChon()
        {
            return dgvData.CurrentRow?.DataBoundItem as DocGiaView;
        }

        private void HienThi(DocGiaView d)
        {
            txtMaDocGia.Text = d?.MaDocGia.ToString() ?? "";
            txtHoTen.Text = d?.HoTen ?? "";
            txtSoDienThoai.Text = d?.SoDienThoai ?? "";
            txtEmail.Text = d?.Email ?? "";
            txtDiaChi.Text = d?.DiaChi ?? "";

            DateTime ngaySinh = d?.NgaySinh ?? DateTime.Today.AddYears(-18);
            if (ngaySinh < dtpNgaySinh.MinDate) ngaySinh = dtpNgaySinh.MinDate;
            if (ngaySinh > dtpNgaySinh.MaxDate) ngaySinh = dtpNgaySinh.MaxDate;
            dtpNgaySinh.Value = ngaySinh;

            int idx = d == null ? 0 : cboLoaiDocGia.Items.IndexOf(d.LoaiDocGia ?? "");
            if (idx < 0 && !string.IsNullOrEmpty(d?.LoaiDocGia))
                idx = cboLoaiDocGia.Items.Add(d.LoaiDocGia);   // giữ lại loại cũ có trong CSDL
            cboLoaiDocGia.SelectedIndex = idx < 0 ? 0 : idx;
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem) HienThi(DongDangChon());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HienThi(null);
            DatCheDo(CheDo.Them);
            txtHoTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (DongDangChon() == null)
            {
                MessageBox.Show("Vui lòng chọn độc giả cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DatCheDo(CheDo.Sua);
            txtHoTen.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DocGiaView d = DongDangChon();
            if (d == null)
            {
                MessageBox.Show("Vui lòng chọn độc giả cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Xóa độc giả '{d.HoTen}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                new DocGiaRepository().XoaDocGia(d.MaDocGia);
                LoadData();
                MessageBox.Show("Đã xóa độc giả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Họ tên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }

            var docGia = new DocGia
            {
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtpNgaySinh.Value.Date,
                DiaChi = txtDiaChi.Text.Trim(),
                SoDienThoai = txtSoDienThoai.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                LoaiDocGia = cboLoaiDocGia.Text
            };

            try
            {
                var repo = new DocGiaRepository();
                if (cheDo == CheDo.Them)
                {
                    repo.ThemDocGia(docGia);
                }
                else
                {
                    docGia.MaDocGia = int.Parse(txtMaDocGia.Text);
                    repo.CapNhatDocGia(docGia);
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
