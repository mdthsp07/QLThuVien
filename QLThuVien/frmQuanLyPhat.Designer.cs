namespace QLThuVien
{
    partial class frmQuanLyPhat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.cboLoc = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.lblTongNo = new System.Windows.Forms.Label();
            this.lblMaPhat = new System.Windows.Forms.Label();
            this.txtMaPhat = new System.Windows.Forms.TextBox();
            this.lblNgayPhat = new System.Windows.Forms.Label();
            this.dtpNgayPhat = new System.Windows.Forms.DateTimePicker();
            this.lblPhieuMuon = new System.Windows.Forms.Label();
            this.cboPhieuMuon = new System.Windows.Forms.ComboBox();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.lblSoNgayTre = new System.Windows.Forms.Label();
            this.nudSoNgayTre = new System.Windows.Forms.NumericUpDown();
            this.lblDonGiaPhat = new System.Windows.Forms.Label();
            this.nudDonGiaPhat = new System.Windows.Forms.NumericUpDown();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.nudSoTien = new System.Windows.Forms.NumericUpDown();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoNgayTre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGiaPhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTien)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTieuDe.Location = new System.Drawing.Point(12, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(500, 30);
            this.lblTieuDe.Text = "QUẢN LÝ PHẠT";
            this.lblTieuDe.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMaPhat);
            this.panel1.Controls.Add(this.txtMaPhat);
            this.panel1.Controls.Add(this.lblNgayPhat);
            this.panel1.Controls.Add(this.dtpNgayPhat);
            this.panel1.Controls.Add(this.lblPhieuMuon);
            this.panel1.Controls.Add(this.cboPhieuMuon);
            this.panel1.Controls.Add(this.lblLyDo);
            this.panel1.Controls.Add(this.txtLyDo);
            this.panel1.Controls.Add(this.lblSoNgayTre);
            this.panel1.Controls.Add(this.nudSoNgayTre);
            this.panel1.Controls.Add(this.lblDonGiaPhat);
            this.panel1.Controls.Add(this.nudDonGiaPhat);
            this.panel1.Controls.Add(this.lblSoTien);
            this.panel1.Controls.Add(this.nudSoTien);
            this.panel1.Controls.Add(this.lblTrangThai);
            this.panel1.Controls.Add(this.txtTrangThai);
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(976, 155);
            this.panel1.TabIndex = 1;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 210);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(90, 30);
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.TabIndex = 2;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(107, 210);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(90, 30);
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.TabIndex = 3;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(202, 210);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(90, 30);
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.TabIndex = 4;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(297, 210);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(90, 30);
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.TabIndex = 5;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(392, 210);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(90, 30);
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(487, 210);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(90, 30);
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.TabIndex = 7;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(590, 217);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(72, 16);
            this.lblTimKiem.Text = "Tìm kiếm:";
            this.lblTimKiem.TabIndex = 8;
            // 
            // cboLoc
            // 
            this.cboLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoc.FormattingEnabled = true;
            this.cboLoc.Location = new System.Drawing.Point(660, 213);
            this.cboLoc.Name = "cboLoc";
            this.cboLoc.Size = new System.Drawing.Size(110, 24);
            this.cboLoc.TabIndex = 9;
            this.cboLoc.SelectedIndexChanged += new System.EventHandler(this.cboLoc_SelectedIndexChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(775, 214);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(115, 22);
            this.txtTimKiem.TabIndex = 10;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(898, 210);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 30);
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.TabIndex = 11;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 252);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersWidth = 51;
            this.dgvData.RowTemplate.Height = 24;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(976, 306);
            this.dgvData.TabIndex = 12;
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            this.dgvData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvData_CellFormatting);
            // 
            // lblTongNo
            // 
            this.lblTongNo.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.lblTongNo.AutoSize = true;
            this.lblTongNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongNo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTongNo.Location = new System.Drawing.Point(12, 568);
            this.lblTongNo.Name = "lblTongNo";
            this.lblTongNo.Size = new System.Drawing.Size(600, 19);
            this.lblTongNo.Text = "Tổng tiền phạt chưa thanh toán: 0 đ";
            this.lblTongNo.TabIndex = 13;
            // 
            // lblMaPhat
            // 
            this.lblMaPhat.AutoSize = true;
            this.lblMaPhat.Location = new System.Drawing.Point(15, 18);
            this.lblMaPhat.Name = "lblMaPhat";
            this.lblMaPhat.Size = new System.Drawing.Size(64, 16);
            this.lblMaPhat.Text = "Mã phạt:";
            this.lblMaPhat.TabIndex = 0;
            // 
            // txtMaPhat
            // 
            this.txtMaPhat.Location = new System.Drawing.Point(135, 15);
            this.txtMaPhat.Name = "txtMaPhat";
            this.txtMaPhat.ReadOnly = true;
            this.txtMaPhat.Size = new System.Drawing.Size(320, 22);
            this.txtMaPhat.TabIndex = 1;
            // 
            // lblNgayPhat
            // 
            this.lblNgayPhat.AutoSize = true;
            this.lblNgayPhat.Location = new System.Drawing.Point(495, 18);
            this.lblNgayPhat.Name = "lblNgayPhat";
            this.lblNgayPhat.Size = new System.Drawing.Size(80, 16);
            this.lblNgayPhat.Text = "Ngày phạt:";
            this.lblNgayPhat.TabIndex = 2;
            // 
            // dtpNgayPhat
            // 
            this.dtpNgayPhat.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayPhat.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayPhat.Location = new System.Drawing.Point(615, 15);
            this.dtpNgayPhat.Name = "dtpNgayPhat";
            this.dtpNgayPhat.Size = new System.Drawing.Size(150, 22);
            this.dtpNgayPhat.TabIndex = 3;
            // 
            // lblPhieuMuon
            // 
            this.lblPhieuMuon.AutoSize = true;
            this.lblPhieuMuon.Location = new System.Drawing.Point(15, 53);
            this.lblPhieuMuon.Name = "lblPhieuMuon";
            this.lblPhieuMuon.Size = new System.Drawing.Size(88, 16);
            this.lblPhieuMuon.Text = "Phiếu mượn:";
            this.lblPhieuMuon.TabIndex = 4;
            // 
            // cboPhieuMuon
            // 
            this.cboPhieuMuon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhieuMuon.FormattingEnabled = true;
            this.cboPhieuMuon.Location = new System.Drawing.Point(135, 50);
            this.cboPhieuMuon.Name = "cboPhieuMuon";
            this.cboPhieuMuon.Size = new System.Drawing.Size(320, 24);
            this.cboPhieuMuon.TabIndex = 5;
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Location = new System.Drawing.Point(495, 53);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(48, 16);
            this.lblLyDo.Text = "Lý do:";
            this.lblLyDo.TabIndex = 6;
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(615, 50);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(320, 22);
            this.txtLyDo.TabIndex = 7;
            // 
            // lblSoNgayTre
            // 
            this.lblSoNgayTre.AutoSize = true;
            this.lblSoNgayTre.Location = new System.Drawing.Point(15, 88);
            this.lblSoNgayTre.Name = "lblSoNgayTre";
            this.lblSoNgayTre.Size = new System.Drawing.Size(96, 16);
            this.lblSoNgayTre.Text = "Số ngày trễ:";
            this.lblSoNgayTre.TabIndex = 8;
            // 
            // nudSoNgayTre
            // 
            this.nudSoNgayTre.Location = new System.Drawing.Point(135, 85);
            this.nudSoNgayTre.Maximum = new decimal(new int[] {
            3650,
            0,
            0,
            0});
            this.nudSoNgayTre.Name = "nudSoNgayTre";
            this.nudSoNgayTre.Size = new System.Drawing.Size(120, 22);
            this.nudSoNgayTre.TabIndex = 9;
            this.nudSoNgayTre.ValueChanged += new System.EventHandler(this.TinhLaiSoTien);
            // 
            // lblDonGiaPhat
            // 
            this.lblDonGiaPhat.AutoSize = true;
            this.lblDonGiaPhat.Location = new System.Drawing.Point(495, 88);
            this.lblDonGiaPhat.Name = "lblDonGiaPhat";
            this.lblDonGiaPhat.Size = new System.Drawing.Size(104, 16);
            this.lblDonGiaPhat.Text = "Đơn giá phạt:";
            this.lblDonGiaPhat.TabIndex = 10;
            // 
            // nudDonGiaPhat
            // 
            this.nudDonGiaPhat.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudDonGiaPhat.Location = new System.Drawing.Point(615, 85);
            this.nudDonGiaPhat.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudDonGiaPhat.Name = "nudDonGiaPhat";
            this.nudDonGiaPhat.Size = new System.Drawing.Size(150, 22);
            this.nudDonGiaPhat.ThousandsSeparator = true;
            this.nudDonGiaPhat.TabIndex = 11;
            this.nudDonGiaPhat.ValueChanged += new System.EventHandler(this.TinhLaiSoTien);
            // 
            // lblSoTien
            // 
            this.lblSoTien.AutoSize = true;
            this.lblSoTien.Location = new System.Drawing.Point(15, 123);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(96, 16);
            this.lblSoTien.Text = "Số tiền (đ):";
            this.lblSoTien.TabIndex = 12;
            // 
            // nudSoTien
            // 
            this.nudSoTien.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudSoTien.Location = new System.Drawing.Point(135, 120);
            this.nudSoTien.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudSoTien.Name = "nudSoTien";
            this.nudSoTien.Size = new System.Drawing.Size(150, 22);
            this.nudSoTien.ThousandsSeparator = true;
            this.nudSoTien.TabIndex = 13;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(495, 123);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(88, 16);
            this.lblTrangThai.Text = "Trạng thái:";
            this.lblTrangThai.TabIndex = 14;
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(615, 120);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.ReadOnly = true;
            this.txtTrangThai.Size = new System.Drawing.Size(320, 22);
            this.txtTrangThai.TabIndex = 15;
            // 
            // frmQuanLyPhat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.cboLoc);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.lblTongNo);
            this.MinimumSize = new System.Drawing.Size(1018, 647);
            this.Name = "frmQuanLyPhat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý phạt";
            this.Load += new System.EventHandler(this.frmQuanLyPhat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoNgayTre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDonGiaPhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoTien)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.ComboBox cboLoc;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lblTongNo;
        private System.Windows.Forms.Label lblMaPhat;
        private System.Windows.Forms.TextBox txtMaPhat;
        private System.Windows.Forms.Label lblNgayPhat;
        private System.Windows.Forms.DateTimePicker dtpNgayPhat;
        private System.Windows.Forms.Label lblPhieuMuon;
        private System.Windows.Forms.ComboBox cboPhieuMuon;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label lblSoNgayTre;
        private System.Windows.Forms.NumericUpDown nudSoNgayTre;
        private System.Windows.Forms.Label lblDonGiaPhat;
        private System.Windows.Forms.NumericUpDown nudDonGiaPhat;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.NumericUpDown nudSoTien;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.TextBox txtTrangThai;
    }
}
