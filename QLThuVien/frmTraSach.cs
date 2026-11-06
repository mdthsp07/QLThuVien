using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QLThuVien.Repositories;

namespace QLThuVien
{
    public partial class frmTraSach : Form
    {
        public frmTraSach()
        {
            InitializeComponent();
        }

        private void frmTraSach_Load(object sender, EventArgs e)
        {
            nudDonGiaPhat.Value = PhieuMuonRepository.DonGiaPhatMacDinh;
            dtpNgayTra.Value = DateTime.Today;
            LoadPhieu();
        }

        private void LoadPhieu()
        {
            try
            {
                dgvPhieuMuon.DataSource = new PhieuMuonRepository().GetPhieuDangMuon(txtTimKiem.Text);
                if (dgvPhieuMuon.Columns["TenHienThi"] != null) dgvPhieuMuon.Columns["TenHienThi"].Visible = false;
                if (dgvPhieuMuon.Columns["NgayTraThucTe"] != null) dgvPhieuMuon.Columns["NgayTraThucTe"].Visible = false;
                HienThiPhieu(PhieuDangChon());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private PhieuMuonView PhieuDangChon()
        {
            return dgvPhieuMuon.CurrentRow?.DataBoundItem as PhieuMuonView;
        }

        private void HienThiPhieu(PhieuMuonView p)
        {
            txtMaPhieu.Text = p?.MaPhieu.ToString() ?? "";
            txtDocGia.Text = p?.HoTen ?? "";
            txtHanTra.Text = p?.HanTra?.ToString("dd/MM/yyyy") ?? "";
            btnLuu.Enabled = p != null;

            try
            {
                dgvChiTiet.DataSource = p == null
                    ? new List<ChiTietMuonView>()
                    : new PhieuMuonRepository().GetChiTiet(p.MaPhieu);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được chi tiết phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            TinhPhatXemTruoc(null, EventArgs.Empty);
        }

        /// <summary>Xem trước tiền phạt = số ngày trễ x đơn giá x tổng số cuốn.</summary>
        private void TinhPhatXemTruoc(object sender, EventArgs e)
        {
            PhieuMuonView p = PhieuDangChon();
            if (p == null)
            {
                txtSoNgayTre.Text = "";
                txtTienPhat.Text = "";
                return;
            }

            int soNgayTre = PhieuMuonRepository.TinhSoNgayTre(p.HanTra, dtpNgayTra.Value);
            decimal tien = soNgayTre * nudDonGiaPhat.Value * p.TongSoSach;
            txtSoNgayTre.Text = soNgayTre.ToString();
            txtTienPhat.Text = tien.ToString("N0");
            txtTienPhat.ForeColor = tien > 0 ? Color.Red : SystemColors.WindowText;
        }

        private void dgvPhieuMuon_SelectionChanged(object sender, EventArgs e)
        {
            HienThiPhieu(PhieuDangChon());
        }

        private void dgvPhieuMuon_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var p = dgvPhieuMuon.Rows[e.RowIndex].DataBoundItem as PhieuMuonView;
            if (p != null && p.SoNgayQuaHan > 0)
            {
                e.CellStyle.ForeColor = Color.Red;
                e.CellStyle.SelectionForeColor = Color.Yellow;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadPhieu();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadPhieu();
                e.SuppressKeyPress = true;
            }
        }

        // Xác nhận trả sách: TransactionScope cộng kho + lập phiếu phạt nếu quá hạn
        private void btnLuu_Click(object sender, EventArgs e)
        {
            PhieuMuonView p = PhieuDangChon();
            if (p == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu mượn cần trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string xacNhan = $"Trả phiếu #{p.MaPhieu} của '{p.HoTen}' ngày {dtpNgayTra.Value:dd/MM/yyyy}?";
            if (txtTienPhat.Text != "" && txtTienPhat.Text != "0")
                xacNhan += $"\nPhiếu quá hạn {txtSoNgayTre.Text} ngày - tiền phạt: {txtTienPhat.Text} đ";
            if (MessageBox.Show(xacNhan, "Xác nhận trả sách", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                var chiTiet = new PhieuMuonRepository().GetChiTiet(p.MaPhieu);
                Phat phat = new PhieuMuonRepository().TraSach(p.MaPhieu, dtpNgayTra.Value, nudDonGiaPhat.Value);

                var thongBao = new StringBuilder("Trả sách thành công!");
                if (phat != null)
                    thongBao.Append($"\nĐã lập phiếu phạt #{phat.MaPhat}: {phat.SoTien:N0} đ ({phat.LyDo}).");

                // Báo các độc giả đang chờ đặt trước những cuốn vừa trả
                var maSachs = new List<int>();
                foreach (var ct in chiTiet) maSachs.Add(ct.MaSach);
                var dangCho = new DatTruocRepository().GetDangChoTheoSach(maSachs);
                if (dangCho.Count > 0)
                {
                    thongBao.Append("\n\nCó độc giả đang chờ đặt trước:");
                    foreach (var dt in dangCho)
                        thongBao.Append($"\n - {dt.HoTen}: '{dt.TenSach}' (đặt ngày {dt.NgayDat:dd/MM/yyyy})");
                }

                MessageBox.Show(thongBao.ToString(), "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPhieu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
