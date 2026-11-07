using System;
using System.Drawing;
using System.Windows.Forms;
using QLThuVien.Repositories;

namespace QLThuVien
{
    public partial class frmQuanLyPhat : Form
    {
        private enum CheDo { Xem, Them, Sua }
        private CheDo cheDo = CheDo.Xem;
        private bool dangNapCombo;
        private bool dangHienThi;

        public frmQuanLyPhat()
        {
            InitializeComponent();
        }

        private void frmQuanLyPhat_Load(object sender, EventArgs e)
        {
            dangNapCombo = true;
            cboLoc.Items.AddRange(new object[] { "Tất cả", TrangThai.ChuaThanhToan, TrangThai.DaThanhToan });
            cboLoc.SelectedIndex = 0;
            dangNapCombo = false;

            try
            {
                LoadPhieuMuon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadData();
            DatCheDo(CheDo.Xem);
        }

        private void LoadPhieuMuon()
        {
            cboPhieuMuon.DisplayMember = "TenHienThi";
            cboPhieuMuon.ValueMember = "MaPhieu";
            cboPhieuMuon.DataSource = new PhatRepository().GetPhieuMuonDeChon();
        }

        private void LoadData()
        {
            try
            {
                var repo = new PhatRepository();
                string trangThai = cboLoc.SelectedIndex <= 0 ? null : cboLoc.SelectedItem.ToString();
                dgvData.DataSource = repo.TimKiem(trangThai, txtTimKiem.Text);
                if (dgvData.Columns["SoTien"] != null) dgvData.Columns["SoTien"].DefaultCellStyle.Format = "N0";
                if (dgvData.Columns["DonGiaPhat"] != null) dgvData.Columns["DonGiaPhat"].DefaultCellStyle.Format = "N0";

                lblTongNo.Text = $"Tổng tiền phạt chưa thanh toán: {repo.TongTien(TrangThai.ChuaThanhToan):N0} đ";
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
            cboPhieuMuon.Enabled = moi == CheDo.Them;
            txtLyDo.ReadOnly = !dangNhap;
            dtpNgayPhat.Enabled = dangNhap;
            nudSoNgayTre.Enabled = dangNhap;
            nudDonGiaPhat.Enabled = dangNhap;
            nudSoTien.Enabled = dangNhap;
            btnThem.Enabled = !dangNhap;
            btnSua.Enabled = !dangNhap;
            btnXoa.Enabled = !dangNhap;
            btnThanhToan.Enabled = !dangNhap;
            btnLuu.Enabled = dangNhap;
            btnHuy.Enabled = dangNhap;
            dgvData.Enabled = !dangNhap;
        }

        private PhatView DongDangChon()
        {
            return dgvData.CurrentRow?.DataBoundItem as PhatView;
        }

        private void HienThi(PhatView p)
        {
            dangHienThi = true;
            txtMaPhat.Text = p?.MaPhat.ToString() ?? "";
            dtpNgayPhat.Value = p?.NgayPhat ?? DateTime.Today;
            if (p?.MaPhieu != null) cboPhieuMuon.SelectedValue = p.MaPhieu.Value;
            txtLyDo.Text = p?.LyDo ?? "";
            nudSoNgayTre.Value = GioiHan(p?.SoNgayTre ?? 0, nudSoNgayTre);
            nudDonGiaPhat.Value = GioiHan(p?.DonGiaPhat ?? PhieuMuonRepository.DonGiaPhatMacDinh, nudDonGiaPhat);
            nudSoTien.Value = GioiHan(p?.SoTien ?? 0, nudSoTien);
            txtTrangThai.Text = p?.TrangThaiThanhToan ?? TrangThai.ChuaThanhToan;
            dangHienThi = false;
        }

        private static decimal GioiHan(decimal giaTri, NumericUpDown nud)
        {
            return Math.Max(nud.Minimum, Math.Min(nud.Maximum, giaTri));
        }

        /// <summary>Số tiền = số ngày trễ x đơn giá (khi người dùng thay đổi một trong hai).</summary>
        private void TinhLaiSoTien(object sender, EventArgs e)
        {
            if (dangHienThi || cheDo == CheDo.Xem) return;
            if (nudSoNgayTre.Value > 0)
                nudSoTien.Value = GioiHan(nudSoNgayTre.Value * nudDonGiaPhat.Value, nudSoTien);
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (cheDo == CheDo.Xem) HienThi(DongDangChon());
        }

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var p = dgvData.Rows[e.RowIndex].DataBoundItem as PhatView;
            if (p != null && p.TrangThaiThanhToan == TrangThai.ChuaThanhToan)
                e.CellStyle.ForeColor = Color.Red;
        }

        private void cboLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dangNapCombo) LoadData();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadPhieuMuon();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboPhieuMuon.Items.Count == 0)
            {
                MessageBox.Show("Chưa có phiếu mượn nào để lập phạt.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            HienThi(null);
            txtLyDo.Text = "Làm mất / hư hỏng sách";
            DatCheDo(CheDo.Them);
            cboPhieuMuon.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            PhatView p = DongDangChon();
            if (p == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu phạt cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (p.TrangThaiThanhToan == TrangThai.DaThanhToan)
            {
                MessageBox.Show("Phiếu phạt đã thanh toán, không thể sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DatCheDo(CheDo.Sua);
            txtLyDo.Focus();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            PhatView p = DongDangChon();
            if (p == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu phạt cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Xóa phiếu phạt #{p.MaPhat} ({p.SoTien:N0} đ)?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                new PhatRepository().XoaPhat(p.MaPhat);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            PhatView p = DongDangChon();
            if (p == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu phạt cần thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show($"Xác nhận độc giả '{p.HoTen}' đã nộp {p.SoTien:N0} đ?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                new PhatRepository().ThanhToan(p.MaPhat);
                LoadData();
                MessageBox.Show("Đã thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboPhieuMuon.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var phat = new Phat
            {
                MaPhieu = Convert.ToInt32(cboPhieuMuon.SelectedValue),
                LyDo = txtLyDo.Text.Trim(),
                NgayPhat = dtpNgayPhat.Value.Date,
                SoNgayTre = (int)nudSoNgayTre.Value,
                DonGiaPhat = nudDonGiaPhat.Value,
                SoTien = nudSoTien.Value
            };

            try
            {
                var repo = new PhatRepository();
                if (cheDo == CheDo.Them)
                {
                    repo.ThemPhat(phat);
                }
                else
                {
                    phat.MaPhat = int.Parse(txtMaPhat.Text);
                    repo.CapNhatPhat(phat);
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
