using QLThuVien.Helpers;
using QLThuVien.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

namespace QLThuVien
{
    public partial class frmRoleManagement : Form
    {
        private List<VaiTro> roles;
        private List<ChucNang> functions;
        private List<PhanQuyen> permissions;

        public frmRoleManagement()
        {
            InitializeComponent();
            Load += frmRoleManagement_Load;
        }

        private void frmRoleManagement_Load(object sender, EventArgs e)
        {
            LoadData();
            if (lstVaiTro.Items.Count > 0)
            {
                lstVaiTro_SelectedIndexChanged(lstVaiTro, EventArgs.Empty);
            }
        }

        private void LoadData()
        {
            roles = new MauRepository<VaiTro>().GetAll();
            functions = new MauRepository<ChucNang>().GetAll();
            permissions = new MauRepository<PhanQuyen>().GetAll();

            lstVaiTro.DataSource = roles;
            chkListChucNang.Items.Clear();
            foreach (ChucNang function in functions)
            {
                chkListChucNang.Items.Add(function);
            }
        }

        private void lstVaiTro_SelectedIndexChanged(object sender, EventArgs e)
        {
            VaiTro selectedRole = lstVaiTro.SelectedItem as VaiTro;
            for (int i = 0; i < chkListChucNang.Items.Count; i++)
            {
                ChucNang function = chkListChucNang.Items[i] as ChucNang;
                bool isAllowed = selectedRole != null && function != null && permissions.Any(permission =>
                    permission.MaVaiTro == selectedRole.MaVaiTro && permission.MaChucNang == function.MaChucNang);
                chkListChucNang.SetItemChecked(i, isAllowed);
            }
        }

        private void btnLuuPhanQuyen_Click(object sender, EventArgs e)
        {
            VaiTro selectedRole = lstVaiTro.SelectedItem as VaiTro;
            if (selectedRole == null)
            {
                MessageBox.Show("Vui lòng chọn vai trò.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<int> selectedFunctionIds = new List<int>();
            foreach (object item in chkListChucNang.CheckedItems)
            {
                ChucNang function = item as ChucNang;
                if (function != null)
                {
                    selectedFunctionIds.Add(function.MaChucNang);
                }
            }

            if (selectedRole.MaVaiTro == CurrentUser.MaVaiTro)
            {
                // Giả sử Mã Chức Năng 5 là "Quản lý Tài khoản" trong Database của bạn
                // (Bạn hãy mở SQL ra xem lại bảng ChucNang để chắc chắn mã 5 là Quản lý Tài khoản nhé)
                bool isAccountMgmtChecked = selectedFunctionIds.Contains(5);

                if (!isAccountMgmtChecked)
                {
                    MessageBox.Show("Bạn không thể tự xóa quyền 'Quản lý Tài khoản' của chính mình!\nHãy nhờ một Admin khác thực hiện việc này.",
                                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            string connectionString = ConfigurationManager.ConnectionStrings["QLThuVienConn"].ConnectionString;
            try
            {
                using (TransactionScope transaction = new TransactionScope())
                using (QuanLyThuVienDataContext db = new QuanLyThuVienDataContext(connectionString))
                {
                    List<PhanQuyen> oldPermissions = db.PhanQuyens
                        .Where(permission => permission.MaVaiTro == selectedRole.MaVaiTro)
                        .ToList();
                    db.PhanQuyens.DeleteAllOnSubmit(oldPermissions);

                    foreach (int functionId in selectedFunctionIds)
                    {
                        db.PhanQuyens.InsertOnSubmit(new PhanQuyen
                        {
                            MaVaiTro = selectedRole.MaVaiTro,
                            MaChucNang = functionId
                        });
                    }

                    db.SubmitChanges();
                    transaction.Complete();
                }

                permissions = new MauRepository<PhanQuyen>().GetAll();
                MessageBox.Show("Đã lưu phân quyền.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể lưu phân quyền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
