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
    public partial class RoomForm : Form
    {
        private readonly RoomService _roomService;
        public RoomForm()
        {
            InitializeComponent();
            var context = new DBContext();
            _roomService = new RoomService(context);
            LoadData();
        }
        private void LoadData()
        {
            var rooms = _roomService.GetAll();
            dataGridView1.DataSource = rooms.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RoomForm_Load(object sender, EventArgs e)
        {

        }
    }
}
