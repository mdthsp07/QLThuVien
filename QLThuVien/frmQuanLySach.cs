using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QLThuVien.Repositories;

namespace QLThuVien
{
    public partial class frmQuanLySach : Form
    {
        private enum CheDo { Xem, Them, Sua }
        private CheDo cheDo = CheDo.Xem;
        private bool dangNapCombo;

        public frmQuanLySach()
        {
            InitializeComponent();
        }

        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
            try
            {
                LoadCombo();
                LoadData();
                DatCheDo(CheDo.Xem);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCombo()
        {
            dangNapCombo = true;

            List<TheLoai> theLoais = new TheLoaiRepository().GetDanhSachSapXep();
            cboTheLoai.DisplayMember = "TenTheLoai";
            cboTheLoai.ValueMember = "MaTheLoai";
            cboTheLoai.DataSource = theLoais;

            // Combo lọc: thêm dòng "Tất cả" ở đầu
            var loc = new List<TheLoai> { new TheLoai { MaTheLoai = 0, TenTheLoai = "-- Tất cả --" } };
            loc.AddRange(theLoais);
            cboLoc.DisplayMember = "TenTheLoai";
            cboLoc.ValueMember = "MaTheLoai";
            cboLoc.DataSource = loc;

            cboNXB.DisplayMember = "TenNXB";
            cboNXB.ValueMember = "MaNXB";
            cboNXB.DataSource = new NhaXuatBanRepository().GetDanhSachSapXep();

            dangNapCombo = false;
        }

        private void LoadData()
        {
            try
            {
                int? maTheLoai = null;
                if (cboLoc.SelectedValue is int ma && ma > 0) maTheLoai = ma;

                dgvData.DataSource = new SachRepository().TimKiem(txtTimKiem.Text, maTheLoai);
                if (dgvData.Columns["TenHienThi"] != null) dgvData.Columns["TenHienThi"].Visible = false;
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
            txtTenSach.ReadOnly = !dangNhap;
            txtTacGia.ReadOnly = !dangNhap;
            cboTheLoai.Enabled = dangNhap;
            cboNXB.Enabled = dangNhap;
            nudNamXuatBan.Enabled = dangNhap;
            nudSoLuongTong.Enabled = dangNhap;
            btnThem.Enabled = !dangNhap;
            btnSua.Enabled = !dangNhap;
            btnXoa.Enabled = !dangNhap;
            btnLuu.Enabled = dangNhap;
            btnHuy.Enabled = dangNhap;
            dgvData.Enabled = !dangNhap;
        }

        private SachView DongDangChon()
        {
            return dgvData.CurrentRow?.DataBoundItem as SachView;
        }

        private void HienThi(SachView s)
        {
            txtMaSach.Text = s?.MaSach.ToString() ?? "";
            txtTenSach.Text = s?.TenSach ?? "";
            txtTacGia.Text = s?.TacGia ?? "";
            if (s?.MaTheLoai != null) cboTheLoai.SelectedValue = s.MaTheLoai.Value;
            else if (cboTheLoai.Items.Count > 0) cboTheLoai.SelectedIndex = 0;
            if (s?.MaNXB != null) cboNXB.SelectedValue = s.MaNXB.Value;
            else if (cboNXB.Items.Count > 0) cboNXB.SelectedIndex = 0;
            nudNamXuatBan.Value = GioiHan(s?.NamXuatBan ?? DateTime.Today.Year, nudNamXuatBan);
            nudSoLuongTong.Value = GioiHan(s?.SoLuongTong ?? 0, nudSoLuongTong);
            txtSoLuongCon.Text = s?.SoLuongCon?.ToString() ?? "";
        }

        private static decimal GioiHan(int giaTri, NumericUpDown nud)
        {
            return Math.Max(nud.Minimum, Math.Min(nud.Maximum, giaTri));
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem) HienThi(DongDangChon());
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dangNapCombo) LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboTheLoai.Items.Count == 0 || cboNXB.Items.Count == 0)
            {
                MessageBox.Show("Cần có ít nhất một thể loại và một nhà xuất bản trước khi thêm sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HienThi(null);
            nudSoLuongTong.Value = 1;
            DatCheDo(CheDo.Them);
            txtTenSach.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (DongDangChon() == null)
            {
                MessageBox.Show("Vui lòng chọn sách cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DatCheDo(CheDo.Sua);
            txtTenSach.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            SachView s = DongDangChon();
            if (s == null)
            {
                MessageBox.Show("Vui lòng chọn sách cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Xóa sách '{s.TenSach}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                new SachRepository().XoaSach(s.MaSach);
                LoadData();
                MessageBox.Show("Đã xóa sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtTenSach.Text.Trim() == "")
            {
                MessageBox.Show("Tên sách không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenSach.Focus();
                return;
            }
            if (cboTheLoai.SelectedValue == null || cboNXB.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn thể loại và nhà xuất bản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var sach = new Sach
            {
                TenSach = txtTenSach.Text.Trim(),
                TacGia = txtTacGia.Text.Trim(),
                MaTheLoai = Convert.ToInt32(cboTheLoai.SelectedValue),
                MaNXB = Convert.ToInt32(cboNXB.SelectedValue),
                NamXuatBan = (int)nudNamXuatBan.Value,
                SoLuongTong = (int)nudSoLuongTong.Value
            };

            try
            {
                var repo = new SachRepository();
                if (cheDo == CheDo.Them)
                {
                    repo.ThemSach(sach);
                }
                else
                {
                    sach.MaSach = int.Parse(txtMaSach.Text);
                    repo.CapNhatSach(sach);
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
