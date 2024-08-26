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
    public partial class UserForm : Form
    {
        private readonly UserService _userService;
        private BindingSource userBindingSource = new BindingSource();

        public UserForm()
        {
            InitializeComponent();
            var context = new DBContext();
            _userService = new UserService(context);
            LoadData();
            BindControls();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadData()
        {
            var users = _userService.GetAll().ToList();
            userBindingSource.DataSource = users;

            comboBox1.Items.Clear();
            comboBox1.Items.Add("admin");
            comboBox1.Items.Add("tenant");

            dataGridView1.DataSource = userBindingSource;
        }

        private void BindControls()
        {
            textBox1.DataBindings.Add("Text", userBindingSource, "UserID");
            textBox2.DataBindings.Add("Text", userBindingSource, "Username");
            comboBox1.DataBindings.Clear();
            comboBox1.DataBindings.Add("SelectedItem", userBindingSource, "Role", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox4.DataBindings.Add("Text", userBindingSource, "FullName");
            textBox5.DataBindings.Add("Text", userBindingSource, "PhoneNumber");
            textBox6.DataBindings.Add("Text", userBindingSource, "Email");
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) // Thêm
        {
            var newUser = new UserDTO
            {
                Username = textBox2.Text,
                Role = comboBox1.SelectedItem.ToString(),
                FullName = textBox4.Text,
                PhoneNumber = textBox5.Text,
                Email = textBox6.Text
            };
            _userService.AddUser(newUser);
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e) // Xóa
        {
            var user = (UserDTO)userBindingSource.Current;
            if (user != null)
            {
                _userService.DeleteUser(user.UserID);
                LoadData();
            }
        }

        private void button3_Click(object sender, EventArgs e) // Sửa
        {
            var user = (UserDTO)userBindingSource.Current;
            if (user != null)
            {
                user.Username = textBox2.Text;
                user.Role = comboBox1.SelectedItem.ToString();
                user.FullName = textBox4.Text;
                user.PhoneNumber = textBox5.Text;
                user.Email = textBox6.Text;

                _userService.UpdateUser(user);
                LoadData();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
