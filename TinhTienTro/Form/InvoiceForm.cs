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
        public InvoiceForm()
        {
            InitializeComponent();
            var context = new DBContext();
            _invoiceService = new InvoiceService(context);
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
    }
}
