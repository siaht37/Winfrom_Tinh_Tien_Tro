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
        public ElectricityWaterForm()
        {
            InitializeComponent();
            var context = new DBContext();
            _electricityWaterReadingService = new ElectricityWaterReadingService(context);
            LoadData();
        }
        private void LoadData()
        {
            var readings = _electricityWaterReadingService.GetAll();
            dataGridView1.DataSource = readings.ToList();
        }
        private void ElectricityWaterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
