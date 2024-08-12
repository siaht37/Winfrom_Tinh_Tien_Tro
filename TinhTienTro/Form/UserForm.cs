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
        public UserForm()
        {
            InitializeComponent();
            var context = new DBContext();
            _userService= new UserService(context);
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LoadData()
        {
            var users = _userService.GetAll();
            dataGridView1.DataSource = users.ToList();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
