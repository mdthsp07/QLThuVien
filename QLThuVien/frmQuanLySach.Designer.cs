namespace QLThuVien
{
    partial class frmQuanLySach
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
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.cboLoc = new System.Windows.Forms.ComboBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.lblMaSach = new System.Windows.Forms.Label();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.lblTheLoai = new System.Windows.Forms.Label();
            this.cboTheLoai = new System.Windows.Forms.ComboBox();
            this.lblTenSach = new System.Windows.Forms.Label();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.lblNXB = new System.Windows.Forms.Label();
            this.cboNXB = new System.Windows.Forms.ComboBox();
            this.lblTacGia = new System.Windows.Forms.Label();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.lblNamXuatBan = new System.Windows.Forms.Label();
            this.nudNamXuatBan = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongTong = new System.Windows.Forms.Label();
            this.nudSoLuongTong = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuongCon = new System.Windows.Forms.Label();
            this.txtSoLuongCon = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNamXuatBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongTong)).BeginInit();
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
            this.lblTieuDe.Text = "QUẢN LÝ SÁCH";
            this.lblTieuDe.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblMaSach);
            this.panel1.Controls.Add(this.txtMaSach);
            this.panel1.Controls.Add(this.lblTheLoai);
            this.panel1.Controls.Add(this.cboTheLoai);
            this.panel1.Controls.Add(this.lblTenSach);
            this.panel1.Controls.Add(this.txtTenSach);
            this.panel1.Controls.Add(this.lblNXB);
            this.panel1.Controls.Add(this.cboNXB);
            this.panel1.Controls.Add(this.lblTacGia);
            this.panel1.Controls.Add(this.txtTacGia);
            this.panel1.Controls.Add(this.lblNamXuatBan);
            this.panel1.Controls.Add(this.nudNamXuatBan);
            this.panel1.Controls.Add(this.lblSoLuongTong);
            this.panel1.Controls.Add(this.nudSoLuongTong);
            this.panel1.Controls.Add(this.lblSoLuongCon);
            this.panel1.Controls.Add(this.txtSoLuongCon);
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
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(590, 217);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(72, 16);
            this.lblTimKiem.Text = "Tìm kiếm:";
            this.lblTimKiem.TabIndex = 7;
            // 
            // cboLoc
            // 
            this.cboLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoc.FormattingEnabled = true;
            this.cboLoc.Location = new System.Drawing.Point(660, 213);
            this.cboLoc.Name = "cboLoc";
            this.cboLoc.Size = new System.Drawing.Size(110, 24);
            this.cboLoc.TabIndex = 8;
            this.cboLoc.SelectedIndexChanged += new System.EventHandler(this.cboLoc_SelectedIndexChanged);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(775, 214);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(115, 22);
            this.txtTimKiem.TabIndex = 9;
            this.txtTimKiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimKiem_KeyDown);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(898, 210);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 30);
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.TabIndex = 10;
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
            this.dgvData.Size = new System.Drawing.Size(976, 336);
            this.dgvData.TabIndex = 11;
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            // 
            // lblMaSach
            // 
            this.lblMaSach.AutoSize = true;
            this.lblMaSach.Location = new System.Drawing.Point(15, 18);
            this.lblMaSach.Name = "lblMaSach";
            this.lblMaSach.Size = new System.Drawing.Size(64, 16);
            this.lblMaSach.Text = "Mã sách:";
            this.lblMaSach.TabIndex = 0;
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(135, 15);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.ReadOnly = true;
            this.txtMaSach.Size = new System.Drawing.Size(320, 22);
            this.txtMaSach.TabIndex = 1;
            // 
            // lblTheLoai
            // 
            this.lblTheLoai.AutoSize = true;
            this.lblTheLoai.Location = new System.Drawing.Point(495, 18);
            this.lblTheLoai.Name = "lblTheLoai";
            this.lblTheLoai.Size = new System.Drawing.Size(72, 16);
            this.lblTheLoai.Text = "Thể loại:";
            this.lblTheLoai.TabIndex = 2;
            // 
            // cboTheLoai
            // 
            this.cboTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTheLoai.FormattingEnabled = true;
            this.cboTheLoai.Location = new System.Drawing.Point(615, 15);
            this.cboTheLoai.Name = "cboTheLoai";
            this.cboTheLoai.Size = new System.Drawing.Size(320, 24);
            this.cboTheLoai.TabIndex = 3;
            // 
            // lblTenSach
            // 
            this.lblTenSach.AutoSize = true;
            this.lblTenSach.Location = new System.Drawing.Point(15, 53);
            this.lblTenSach.Name = "lblTenSach";
            this.lblTenSach.Size = new System.Drawing.Size(72, 16);
            this.lblTenSach.Text = "Tên sách:";
            this.lblTenSach.TabIndex = 4;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(135, 50);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(320, 22);
            this.txtTenSach.TabIndex = 5;
            // 
            // lblNXB
            // 
            this.lblNXB.AutoSize = true;
            this.lblNXB.Location = new System.Drawing.Point(495, 53);
            this.lblNXB.Name = "lblNXB";
            this.lblNXB.Size = new System.Drawing.Size(104, 16);
            this.lblNXB.Text = "Nhà xuất bản:";
            this.lblNXB.TabIndex = 6;
            // 
            // cboNXB
            // 
            this.cboNXB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNXB.FormattingEnabled = true;
            this.cboNXB.Location = new System.Drawing.Point(615, 50);
            this.cboNXB.Name = "cboNXB";
            this.cboNXB.Size = new System.Drawing.Size(320, 24);
            this.cboNXB.TabIndex = 7;
            // 
            // lblTacGia
            // 
            this.lblTacGia.AutoSize = true;
            this.lblTacGia.Location = new System.Drawing.Point(15, 88);
            this.lblTacGia.Name = "lblTacGia";
            this.lblTacGia.Size = new System.Drawing.Size(64, 16);
            this.lblTacGia.Text = "Tác giả:";
            this.lblTacGia.TabIndex = 8;
            // 
            // txtTacGia
            // 
            this.txtTacGia.Location = new System.Drawing.Point(135, 85);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(320, 22);
            this.txtTacGia.TabIndex = 9;
            // 
            // lblNamXuatBan
            // 
            this.lblNamXuatBan.AutoSize = true;
            this.lblNamXuatBan.Location = new System.Drawing.Point(495, 88);
            this.lblNamXuatBan.Name = "lblNamXuatBan";
            this.lblNamXuatBan.Size = new System.Drawing.Size(104, 16);
            this.lblNamXuatBan.Text = "Năm xuất bản:";
            this.lblNamXuatBan.TabIndex = 10;
            // 
            // nudNamXuatBan
            // 
            this.nudNamXuatBan.Location = new System.Drawing.Point(615, 85);
            this.nudNamXuatBan.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.nudNamXuatBan.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNamXuatBan.Name = "nudNamXuatBan";
            this.nudNamXuatBan.Size = new System.Drawing.Size(120, 22);
            this.nudNamXuatBan.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudNamXuatBan.TabIndex = 11;
            // 
            // lblSoLuongTong
            // 
            this.lblSoLuongTong.AutoSize = true;
            this.lblSoLuongTong.Location = new System.Drawing.Point(15, 123);
            this.lblSoLuongTong.Name = "lblSoLuongTong";
            this.lblSoLuongTong.Size = new System.Drawing.Size(112, 16);
            this.lblSoLuongTong.Text = "Số lượng tổng:";
            this.lblSoLuongTong.TabIndex = 12;
            // 
            // nudSoLuongTong
            // 
            this.nudSoLuongTong.Location = new System.Drawing.Point(135, 120);
            this.nudSoLuongTong.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSoLuongTong.Name = "nudSoLuongTong";
            this.nudSoLuongTong.Size = new System.Drawing.Size(120, 22);
            this.nudSoLuongTong.TabIndex = 13;
            // 
            // lblSoLuongCon
            // 
            this.lblSoLuongCon.AutoSize = true;
            this.lblSoLuongCon.Location = new System.Drawing.Point(495, 123);
            this.lblSoLuongCon.Name = "lblSoLuongCon";
            this.lblSoLuongCon.Size = new System.Drawing.Size(104, 16);
            this.lblSoLuongCon.Text = "Số lượng còn:";
            this.lblSoLuongCon.TabIndex = 14;
            // 
            // txtSoLuongCon
            // 
            this.txtSoLuongCon.Location = new System.Drawing.Point(615, 120);
            this.txtSoLuongCon.Name = "txtSoLuongCon";
            this.txtSoLuongCon.ReadOnly = true;
            this.txtSoLuongCon.Size = new System.Drawing.Size(120, 22);
            this.txtSoLuongCon.TabIndex = 15;
            // 
            // frmQuanLySach
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
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.cboLoc);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.dgvData);
            this.MinimumSize = new System.Drawing.Size(1018, 647);
            this.Name = "frmQuanLySach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý sách";
            this.Load += new System.EventHandler(this.frmQuanLySach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNamXuatBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongTong)).EndInit();
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
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.ComboBox cboLoc;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label lblMaSach;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Label lblTheLoai;
        private System.Windows.Forms.ComboBox cboTheLoai;
        private System.Windows.Forms.Label lblTenSach;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.Label lblNXB;
        private System.Windows.Forms.ComboBox cboNXB;
        private System.Windows.Forms.Label lblTacGia;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label lblNamXuatBan;
        private System.Windows.Forms.NumericUpDown nudNamXuatBan;
        private System.Windows.Forms.Label lblSoLuongTong;
        private System.Windows.Forms.NumericUpDown nudSoLuongTong;
        private System.Windows.Forms.Label lblSoLuongCon;
        private System.Windows.Forms.TextBox txtSoLuongCon;
    }
}
