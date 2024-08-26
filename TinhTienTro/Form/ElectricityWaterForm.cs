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
    public partial class ElectricityWaterForm : Form
    {
        private readonly ElectricityWaterReadingService _electricityWaterReadingService;
        private readonly RoomService _roomService;

        public ElectricityWaterForm()
        {
            InitializeComponent();
            var context = new DBContext();
            _electricityWaterReadingService = new ElectricityWaterReadingService(context);
            _roomService = new RoomService(context); // Thêm dịch vụ phòng để lấy danh sách phòng
            LoadData();
            LoadRooms(); // Tải danh sách phòng vào comboBox
        }

        private void LoadData()
        {
            var readings = _electricityWaterReadingService.GetAll();
            dataGridView1.DataSource = readings.ToList();
        }

        private void LoadRooms()
        {
            var rooms = _roomService.GetAll();
            comboBox1.DataSource = rooms.ToList();
            comboBox1.DisplayMember = "RoomNumber"; // Hiển thị RoomNumber hoặc tên bạn muốn
            comboBox1.ValueMember = "RoomID"; // Sử dụng RoomID làm giá trị
        }
        private void ElectricityWaterForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var newReading = new ElectricityWaterReadingDTO
                {
                    RoomID = (int)comboBox1.SelectedValue,
                    Month = dateTimePicker1.Value,
                    ElectricityUsage = int.Parse(textBox1.Text),
                    WaterUsage = int.Parse(textBox2.Text),
                    ElectricityUnitPrice = 3000, // Giá điện cố định
                    WaterUnitPrice = 5000 // Giá nước cố định
                };

                _electricityWaterReadingService.Add(newReading); // Thêm phương thức Add trong ElectricityWaterReadingService
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm dữ liệu: {ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
