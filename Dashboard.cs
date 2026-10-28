using System;
using System.Drawing;
using System.Windows.Forms;

namespace baitap12_10
{
    public class Dashboard : Form
    {
        private Button btnBai51;
        private Button btnBai52;
        private Label lblTitle;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnBai51 = new Button();
            this.btnBai52 = new Button();
            this.lblTitle = new Label();

            this.Text = "Menu Bài Tập .NET - Quản Lý Học Viên";
            this.Size = new Size(360, 260);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.lblTitle.Text = "CHỌN BÀI TẬP THỰC HÀNH";
            this.lblTitle.Font = new Font("Arial", 12, FontStyle.Bold);
            this.lblTitle.Location = new Point(50, 30);
            this.lblTitle.AutoSize = true;

            this.btnBai51.Text = "Bài 5.1 - Đăng nhập";
            this.btnBai51.Location = new Point(80, 80);
            this.btnBai51.Size = new Size(180, 40);
            this.btnBai51.Click += (sender, e) => {
                Form5_1 f51 = new Form5_1();
                f51.ShowDialog();
            };

            this.btnBai52.Text = "Bài 5.2 - Đăng ký học viên";
            this.btnBai52.Location = new Point(80, 140);
            this.btnBai52.Size = new Size(180, 40);
            this.btnBai52.Click += (sender, e) => {
                Form5_2 f52 = new Form5_2();
                f52.ShowDialog();
            };

            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnBai51);
            this.Controls.Add(this.btnBai52);
        }
    }
}