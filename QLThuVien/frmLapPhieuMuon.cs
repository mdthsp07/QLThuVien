using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using QLThuVien.Repositories;

namespace QLThuVien
{
    public partial class frmLapPhieuMuon : Form
    {
        // "Giỏ" sách của phiếu đang lập (chưa lưu xuống CSDL)
        private readonly BindingList<GioMuonItem> gio = new BindingList<GioMuonItem>();
        private bool dangNapCombo;

        public frmLapPhieuMuon()
        {
            InitializeComponent();
        }

        private void frmLapPhieuMuon_Load(object sender, EventArgs e)
        {
            nudSoLuong.Maximum = PhieuMuonRepository.SoSachToiDa;
            dgvChiTiet.DataSource = gio;
            gio.ListChanged += (s, ev) => CapNhatTongSach();

            try
            {
                dangNapCombo = true;
                cboDocGia.DisplayMember = "HoTen";
                cboDocGia.ValueMember = "MaDocGia";
                cboDocGia.DataSource = new DocGiaRepository().GetDanhSachSapXep();
                dangNapCombo = false;

                LamMoi();
            }
            catch (Exception ex)
            {
                dangNapCombo = false;
                MessageBox.Show("Không tải được dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LamMoi()
        {
            gio.Clear();
            dtpHanTra.MinDate = DateTimePicker.MinimumDateTime;
            dtpNgayMuon.Value = DateTime.Today;
            DatHanTraMacDinh();
            nudSoLuong.Value = 1;
            txtTimKiem.Clear();
            LoadSach();
            CapNhatThongTinDocGia();
        }

        private void LoadSach()
        {
            try
            {
                dgvSach.DataSource = new SachRepository().TimSachConHang(txtTimKiem.Text);
                if (dgvSach.Columns["TenHienThi"] != null) dgvSach.Columns["TenHienThi"].Visible = false;
                if (dgvSach.Columns["SoLuongTong"] != null) dgvSach.Columns["SoLuongTong"].Visible = false;
                if (dgvSach.Columns["TenNXB"] != null) dgvSach.Columns["TenNXB"].Visible = false;
                if (dgvSach.Columns["NamXuatBan"] != null) dgvSach.Columns["NamXuatBan"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DatHanTraMacDinh()
        {
            // Đặt MinDate trước rồi mới gán Value để không bị lỗi ngoài phạm vi
            dtpHanTra.MinDate = dtpNgayMuon.Value.Date;
            dtpHanTra.Value = dtpNgayMuon.Value.Date.AddDays(PhieuMuonRepository.SoNgayMuonMacDinh);
        }

        private void CapNhatThongTinDocGia()
        {
            if (cboDocGia.SelectedValue == null)
            {
                lblThongTinDocGia.Text = "";
                return;
            }

            try
            {
                int maDocGia = Convert.ToInt32(cboDocGia.SelectedValue);
                var repo = new DocGiaRepository();
                int dangMuon = repo.SoSachDangMuon(maDocGia);
                decimal no = repo.TienPhatChuaThanhToan(maDocGia);
                bool quaHan = repo.CoPhieuQuaHan(maDocGia);

                string thongTin = $"Đang mượn {dangMuon}/{PhieuMuonRepository.SoSachToiDa} cuốn";
                if (quaHan) thongTin += " | CÓ PHIẾU QUÁ HẠN";
                if (no > 0) thongTin += $" | Nợ phạt {no:N0} đ";
                lblThongTinDocGia.Text = thongTin;
            }
            catch (Exception ex)
            {
                lblThongTinDocGia.Text = "Lỗi: " + ex.Message;
            }
        }

        private void CapNhatTongSach()
        {
            int tong = 0;
            foreach (var item in gio) tong += item.SoLuong;
            lblTongSach.Text = $"Tổng: {tong} cuốn";
        }

        private void cboDocGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!dangNapCombo) CapNhatThongTinDocGia();
        }

        private void dtpNgayMuon_ValueChanged(object sender, EventArgs e)
        {
            DatHanTraMacDinh();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadSach();
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadSach();
                e.SuppressKeyPress = true;
            }
        }

        // Thêm sách đang chọn vào phiếu
        private void btnThem_Click(object sender, EventArgs e)
        {
            var sach = dgvSach.CurrentRow?.DataBoundItem as SachView;
            if (sach == null)
            {
                MessageBox.Show("Vui lòng chọn sách cần mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int soLuong = (int)nudSoLuong.Value;
            GioMuonItem daCo = null;
            foreach (var item in gio)
                if (item.MaSach == sach.MaSach) daCo = item;

            int tongSauKhiThem = (daCo?.SoLuong ?? 0) + soLuong;
            if (tongSauKhiThem > (sach.SoLuongCon ?? 0))
            {
                MessageBox.Show($"Sách '{sach.TenSach}' chỉ còn {sach.SoLuongCon} cuốn trong kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (daCo != null)
            {
                daCo.SoLuong = tongSauKhiThem;
                gio.ResetBindings();
            }
            else
            {
                gio.Add(new GioMuonItem { MaSach = sach.MaSach, TenSach = sach.TenSach, SoLuong = soLuong });
            }
        }

        // Bỏ sách khỏi phiếu
        private void btnXoa_Click(object sender, EventArgs e)
        {
            var item = dgvChiTiet.CurrentRow?.DataBoundItem as GioMuonItem;
            if (item == null)
            {
                MessageBox.Show("Vui lòng chọn sách cần bỏ khỏi phiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            gio.Remove(item);
        }

        // Lập phiếu: gọi Repository của M1 (TransactionScope kiểm tra tồn kho + trừ kho)
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (cboDocGia.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn độc giả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (gio.Count == 0)
            {
                MessageBox.Show("Phiếu mượn chưa có sách nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maDocGia = Convert.ToInt32(cboDocGia.SelectedValue);
            try
            {
                var docGiaRepo = new DocGiaRepository();
                if (docGiaRepo.CoPhieuQuaHan(maDocGia))
                {
                    MessageBox.Show("Độc giả đang có phiếu quá hạn chưa trả, không được mượn thêm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                decimal no = docGiaRepo.TienPhatChuaThanhToan(maDocGia);
                if (no > 0)
                {
                    MessageBox.Show($"Độc giả còn nợ phạt {no:N0} đ, vui lòng thanh toán trước khi mượn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var phieu = new PhieuMuon
                {
                    MaDocGia = maDocGia,
                    NgayMuon = dtpNgayMuon.Value.Date,
                    HanTra = dtpHanTra.Value.Date,
                    TrangThai = TrangThai.DangMuon
                };
                var chiTiets = new List<ChiTietMuon>();
                foreach (var item in gio)
                    chiTiets.Add(new ChiTietMuon { MaSach = item.MaSach, SoLuong = item.SoLuong });

                // Tạo repository mới cho mỗi lần lập phiếu (DataContext sạch)
                new PhieuMuonRepository().LapPhieuMuon(phieu, chiTiets);

                MessageBox.Show($"Lập phiếu mượn thành công!\nMã phiếu: {phieu.MaPhieu}\nHạn trả: {phieu.HanTra:dd/MM/yyyy}",
                                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LamMoi();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoadSach();   // tồn kho có thể đã thay đổi
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
    }
}
