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
        private BindingSource roomBindingSource = new BindingSource();

        public RoomForm()
        {
            InitializeComponent();
            var context = new DBContext();
            _roomService = new RoomService(context);
            LoadData();
            BindControls();
        }

        private void LoadData()
        {
            var rooms = _roomService.GetAll().ToList();
            roomBindingSource.DataSource = rooms;

            dataGridView1.DataSource = roomBindingSource;

            var tenants = _roomService.GetAllTenants(); // Lấy danh sách tenants
            comboBox1.DataSource = tenants;
            comboBox1.DisplayMember = "FullName";
            comboBox1.ValueMember = "UserID";

            foreach (var tenant in tenants)
            {
                Console.WriteLine($"Tenant: {tenant.FullName}, ID: {tenant.UserID}");
            }
        }

        private void BindControls()
        {
            textBox1.DataBindings.Add("Text", roomBindingSource, "RoomID");
            textBox2.DataBindings.Add("Text", roomBindingSource, "RoomNumber");
            textBox3.DataBindings.Add("Text", roomBindingSource, "RoomPrice");

            // Thử hủy và gán lại binding cho comboBox1
            comboBox1.DataBindings.Clear();
            comboBox1.DataBindings.Add("SelectedValue", roomBindingSource, "TenantID", true, DataSourceUpdateMode.OnPropertyChanged);


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RoomForm_Load(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newRoom = new RoomDTO
            {
                RoomNumber = textBox2.Text,
                RoomPrice = decimal.Parse(textBox3.Text),
                TenantID = (int?)comboBox1.SelectedValue
            };
            _roomService.AddRoom(newRoom);
            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var room = (RoomDTO)roomBindingSource.Current;
            _roomService.DeleteRoom(room.RoomID);
            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var selectedTenantId = comboBox1.SelectedValue;
            Console.WriteLine($"Selected Tenant ID: {selectedTenantId}");

            var room = (RoomDTO)roomBindingSource.Current;
            room.RoomNumber = textBox2.Text;
            room.RoomPrice = decimal.Parse(textBox3.Text);
            room.TenantID = (int?)selectedTenantId;

            _roomService.UpdateRoom(room);
            LoadData();
        }
    }
}
