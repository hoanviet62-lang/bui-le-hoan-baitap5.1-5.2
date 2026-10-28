using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace baitap12_10
{
    public class Form5_2 : Form
    {
        private Label lblPhone;
        private Label lblDob;
        private Label lblCourse;
        private TextBox txtPhone;
        private DateTimePicker dtpDob;
        private TextBox txtCourse;
        private Button btnSave;

        public Form5_2()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblPhone = new Label();
            this.lblDob = new Label();
            this.lblCourse = new Label();
            this.txtPhone = new TextBox();
            this.dtpDob = new DateTimePicker();
            this.txtCourse = new TextBox();
            this.btnSave = new Button();

            this.Text = "Bài 5.2 - Đăng ký học viên";
            this.Size = new Size(380, 260);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.lblPhone.Text = "Số điện thoại:";
            this.lblPhone.Location = new Point(30, 30);
            this.lblPhone.AutoSize = true;

            this.txtPhone.Location = new Point(140, 27);
            this.txtPhone.Size = new Size(180, 20);

            this.lblDob.Text = "Ngày sinh:";
            this.lblDob.Location = new Point(30, 75);
            this.lblDob.AutoSize = true;

            this.dtpDob.Location = new Point(140, 72);
            this.dtpDob.Size = new Size(180, 20);
            this.dtpDob.Format = DateTimePickerFormat.Short;

            this.lblCourse.Text = "Mã khóa học:";
            this.lblCourse.Location = new Point(30, 120);
            this.lblCourse.AutoSize = true;

            this.txtCourse.Location = new Point(140, 117);
            this.txtCourse.Size = new Size(180, 20);

            this.btnSave.Text = "Đăng ký";
            this.btnSave.Location = new Point(140, 165);
            this.btnSave.Size = new Size(100, 30);
            this.btnSave.Click += new EventHandler(this.BtnSave_Click);

            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblDob);
            this.Controls.Add(this.dtpDob);
            this.Controls.Add(this.lblCourse);
            this.Controls.Add(this.txtCourse);
            this.Controls.Add(this.btnSave);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtCourse.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connStr = "Server=127.0.0.1;Database=QuanLyHocVien;Uid=root;Pwd=;";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    string sql = "INSERT INTO HocVien (SoDienThoai, NgaySinh, MaKhoaHoc) VALUES (@phone, @dob, @course)";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@dob", dtpDob.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@course", txtCourse.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đăng ký học viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}