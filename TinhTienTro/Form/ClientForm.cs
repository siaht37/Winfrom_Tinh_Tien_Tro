using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhTienTro
{
    public partial class ClientForm : Form
    {
        private readonly InvoiceService _invoiceService;
        private readonly RoomService _roomService;
        private int _currentUserId; // Lưu trữ ID của người dùng hiện tại

        public ClientForm(int userId)
        {
            InitializeComponent();
            _invoiceService = new InvoiceService(new DBContext());
            _roomService = new RoomService(new DBContext());
            _currentUserId = userId;
            LoadInvoices();
        }

        private void LoadInvoices()
        {
            // Lấy danh sách phòng mà người dùng hiện tại đang thuê
            var rooms = _roomService.GetAll().Where(room => room.TenantID == _currentUserId).ToList();
            var roomIds = rooms.Select(room => room.RoomID).ToList();

            // Lấy danh sách hóa đơn liên quan đến các phòng trên
            var invoices = _invoiceService.GetAll().Where(invoice => roomIds.Contains(invoice.RoomID)).ToList();

            // Data binding
            dataGridView1.DataSource = invoices;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var QRForm = new QRForm();
            QRForm.Show();
        }
    }
  
}
