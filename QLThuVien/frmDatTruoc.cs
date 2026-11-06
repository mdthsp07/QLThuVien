using System;
using System.Drawing;
using System.Windows.Forms;
using QLThuVien.Repositories;

namespace QLThuVien
{
    public partial class frmDatTruoc : Form
    {
        private enum CheDo { Xem, Them }
        private CheDo cheDo = CheDo.Xem;
        private bool dangNapCombo;

        public frmDatTruoc()
        {
            InitializeComponent();
        }

        private void frmDatTruoc_Load(object sender, EventArgs e)
        {
            dangNapCombo = true;
            cboLoc.Items.AddRange(new object[] { "Tất cả", TrangThai.DangCho, TrangThai.DaNhan, TrangThai.DaHuy });
            cboLoc.SelectedItem = TrangThai.DangCho;
            dangNapCombo = false;

            try
            {
                cboDocGia.DisplayMember = "HoTen";
                cboDocGia.ValueMember = "MaDocGia";
                cboDocGia.DataSource = new DocGiaRepository().GetDanhSachSapXep();
                LoadSachHetHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();
            DatCheDo(CheDo.Xem);
        }

        private void LoadSachHetHang()
        {
            cboSach.DisplayMember = "TenHienThi";
            cboSach.ValueMember = "MaSach";
            cboSach.DataSource = new SachRepository().GetSachHetHang();
        }

        private void LoadData()
        {
            try
            {
                string trangThai = cboLoc.SelectedIndex <= 0 ? null : cboLoc.SelectedItem.ToString();
                dgvData.DataSource = new DatTruocRepository().TimKiem(trangThai, txtTimKiem.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DatCheDo(CheDo moi)
        {
            cheDo = moi;
            bool dangNhap = moi == CheDo.Them;
            cboDocGia.Enabled = dangNhap;
            cboSach.Enabled = dangNhap;
            dtpNgayDat.Enabled = dangNhap;
            btnThem.Enabled = !dangNhap;
            btnHuyDat.Enabled = !dangNhap;
            btnXoa.Enabled = !dangNhap;
            btnLuu.Enabled = dangNhap;
            btnHuy.Enabled = dangNhap;
            dgvData.Enabled = !dangNhap;
        }

        private DatTruocView DongDangChon()
        {
            return dgvData.CurrentRow?.DataBoundItem as DatTruocView;
        }

        private void HienThi(DatTruocView dt)
        {
            txtMaDatTruoc.Text = dt?.MaDatTruoc.ToString() ?? "";
            dtpNgayDat.Value = dt?.NgayDat ?? DateTime.Today;
            if (dt?.MaDocGia != null) cboDocGia.SelectedValue = dt.MaDocGia.Value;
            // Sách đã đặt có thể đã có hàng lại nên không còn trong combo "hết hàng"
            if (dt?.MaSach != null) cboSach.SelectedValue = dt.MaSach.Value;
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem) HienThi(DongDangChon());
        }

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var dt = dgvData.Rows[e.RowIndex].DataBoundItem as DatTruocView;
            if (dt == null) return;
            if (dt.TrangThai == TrangThai.DaHuy) e.CellStyle.ForeColor = Color.Gray;
            else if (dt.TrangThai == TrangThai.DangCho && (dt.SoLuongCon ?? 0) > 0)
                e.CellStyle.BackColor = Color.LightGreen;   // sách đã có lại -> báo độc giả đến mượn
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dangNapCombo) LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSachHetHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboDocGia.Items.Count == 0 || cboSach.Items.Count == 0)
            {
                MessageBox.Show("Không có độc giả hoặc không có sách nào đã hết hàng để đặt trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            txtMaDatTruoc.Text = "";
            dtpNgayDat.Value = DateTime.Today;
            DatCheDo(CheDo.Them);
            cboDocGia.Focus();
        }

        private void btnHuyDat_Click(object sender, EventArgs e)
        {
            DatTruocView dt = DongDangChon();
            if (dt == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu đặt trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Hủy đặt trước sách '{dt.TenSach}' của '{dt.HoTen}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                new DatTruocRepository().CapNhatTrangThai(dt.MaDatTruoc, TrangThai.DaHuy);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DatTruocView dt = DongDangChon();
            if (dt == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu đặt trước cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Xóa phiếu đặt trước đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                new DatTruocRepository().XoaDatTruoc(dt.MaDatTruoc);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboDocGia.SelectedValue == null || cboSach.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn độc giả và sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                new DatTruocRepository().DatSach(Convert.ToInt32(cboDocGia.SelectedValue),
                                                 Convert.ToInt32(cboSach.SelectedValue),
                                                 dtpNgayDat.Value);
                DatCheDo(CheDo.Xem);
                LoadData();
                MessageBox.Show("Đặt trước thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
