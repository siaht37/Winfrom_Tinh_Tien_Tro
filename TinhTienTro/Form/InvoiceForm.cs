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
    public partial class InvoiceForm : Form
    {
        private readonly InvoiceService _invoiceService;
        private readonly ElectricityWaterReadingService _electricityWaterReadingService;
        private readonly RoomService _roomService;

        public InvoiceForm()
        {
            InitializeComponent();
            var context = new DBContext();
            _invoiceService = new InvoiceService(context);
            _electricityWaterReadingService = new ElectricityWaterReadingService(context);
            _roomService = new RoomService(context);
            LoadData();
        }

        private void LoadData()
        {
            var invoices = _invoiceService.GetAll();
            dataGridView1.DataSource = invoices.ToList();
        }

        private void InvoiceForm_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giá trị tháng từ DateTimePicker
                var month = dateTimePicker1.Value.Date;

                // Lấy tất cả các bản ghi ElectricityWaterReading cho tháng này
                var readings = _electricityWaterReadingService.GetAll()
                    .Where(r => r.Month == month)
                    .ToList();

                // Tạo danh sách hóa đơn từ các bản ghi
                foreach (var reading in readings)
                {
                    var room = _roomService.GetById(reading.RoomID); // Lấy thông tin phòng
                    if (room != null)
                    {
                        var electricityCharge = reading.ElectricityUsage * reading.ElectricityUnitPrice;
                        var waterCharge = reading.WaterUsage * reading.WaterUnitPrice;
                        var roomCharge = room.RoomPrice;
                        var totalAmount = electricityCharge + waterCharge + roomCharge;

                        var newInvoice = new InvoiceDTO
                        {
                            RoomID = reading.RoomID,
                            Month = month,
                            ElectricityCharge = electricityCharge,
                            WaterCharge = waterCharge,
                            RoomCharge = roomCharge,
                            TotalAmount = totalAmount,
                            Status = false // Mặc định là false
                        };

                        _invoiceService.Add(newInvoice); // Thêm phương thức Add trong InvoiceService
                    }
                }

                // Cập nhật lại dữ liệu trong DataGridView
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo hóa đơn: {ex.Message}");
            }
        }
    }
}
