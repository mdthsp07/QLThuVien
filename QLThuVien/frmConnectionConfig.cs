using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLThuVien
{
    public partial class frmConnectionConfig : Form
    {
        public frmConnectionConfig()
        {
            InitializeComponent();
            LoadCurrentConfig();
            rdoWindows_CheckedChanged(null, null);
        }

        private string BuildConnectionString()
        {
            string server = txtServer.Text.Trim();
            string db = txtDatabase.Text.Trim();

          
            if (server.Contains("LocalDB"))
            {
                string dbFile = string.IsNullOrEmpty(db) ? "QLThuVien" : db;
                string auth = rdoWindows.Checked ? "Integrated Security=True;" : $"User ID={txtUser.Text};Password={txtPass.Text};";
                return $"Data Source={server};AttachDbFilename=|DataDirectory|\\{dbFile}.mdf;{auth}Encrypt=False;TrustServerCertificate=True;";
            }
            else
            {
            
                if (rdoWindows.Checked)
                {
                    return $"Data Source={server};Initial Catalog={db};Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
                }
                else
                {
                    return $"Data Source={server};Initial Catalog={db};User ID={txtUser.Text};Password={txtPass.Text};Encrypt=False;TrustServerCertificate=True;";
                }
            }
        }

        private void LoadCurrentConfig()
        {
            try
            {
                string currentConn = ConfigurationManager.ConnectionStrings["QLThuVienConn"].ConnectionString;
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(currentConn);

                txtServer.Text = builder.DataSource;
                txtDatabase.Text = builder.InitialCatalog;

                if (builder.IntegratedSecurity)
                {
                    rdoWindows.Checked = true;
                }
                else
                {
                    rdoSqlAuth.Checked = true;
                    txtUser.Text = builder.UserID;
                    txtPass.Text = builder.Password;
                }
            }
            catch {  }
        }
        private void frmConnectionConfig_Load(object sender, EventArgs e)
        {

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = BuildConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kết nối thất bại: \n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string newConnStr = BuildConnectionString();

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                config.ConnectionStrings.ConnectionStrings["QLThuVienConn"].ConnectionString = newConnStr;

                config.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("connectionStrings");

                MessageBox.Show("Đã lưu cấu hình! Vui lòng khởi động lại ứng dụng để áp dụng.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu cấu hình: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdoWindows_CheckedChanged(object sender, EventArgs e)
        {
           
            bool isWindowsAuth = rdoWindows.Checked;

            txtUser.Enabled = !isWindowsAuth;
            txtPass.Enabled = !isWindowsAuth;

            if (isWindowsAuth)
            {
                txtUser.Clear();
                txtPass.Clear();
            }
        }
    }
}
