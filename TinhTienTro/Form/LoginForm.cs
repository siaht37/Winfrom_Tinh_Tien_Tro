using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhTienTro
{
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;

        public LoginForm()
        {
            InitializeComponent();
            var context = new DBContext();
            _userService = new UserService(context);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text;
            var password = textBox2.Text;

            var user = _userService.Authenticate(username, password);

            if (user == null)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (user.Role == "admin")
                {
                    var homeForm = new HomeForm();
                    homeForm.Show();
                    this.Hide();
                }
                else if (user.Role == "tenant")
                {
                    var clientForm = new ClientForm(user.UserID); // Tạo instance của ClientForm và truyền UserID
                    clientForm.Show();
                    this.Hide(); // Ẩn LoginForm
                }
            }
        }
    }
}
