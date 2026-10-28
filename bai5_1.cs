using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace baitap12_10
{
    public class Form5_1 : Form
    {
        private Label lblUsername;
        private Label lblPassword;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;

        public Form5_1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblUsername = new Label();
            this.lblPassword = new Label();
            this.txtUsername = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();

            this.Text = "Bài 5.1 - Đăng nhập";
            this.Size = new Size(350, 220);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.lblUsername.Text = "Tên đăng nhập:";
            this.lblUsername.Location = new Point(30, 30);
            this.lblUsername.AutoSize = true;

            this.txtUsername.Location = new Point(130, 27);
            this.txtUsername.Size = new Size(160, 20);

            this.lblPassword.Text = "Mật khẩu:";
            this.lblPassword.Location = new Point(30, 70);
            this.lblPassword.AutoSize = true;

            this.txtPassword.Location = new Point(130, 67);
            this.txtPassword.Size = new Size(160, 20);
            this.txtPassword.PasswordChar = '*';

            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.Location = new Point(130, 110);
            this.btnLogin.Size = new Size(100, 30);
            this.btnLogin.Click += new EventHandler(this.BtnLogin_Click);

            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string connStr = "Server=127.0.0.1;Database=QuanLyHocVien;Uid=root;Pwd=;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "SELECT COUNT(*) FROM Users WHERE Username=@user AND Password=@pass";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu hoặc tên đăng nhập sai!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}