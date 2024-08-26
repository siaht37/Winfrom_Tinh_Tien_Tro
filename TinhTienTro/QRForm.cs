using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TinhTienTro
{
    public partial class QRForm : Form
    {
        public QRForm()
        {
            InitializeComponent();
            LoadImage();
        }

        private void LoadImage()
        {
          
            try
            {
                // Đường dẫn tới hình ảnh
                string imagePath = "D:\\Study\\HUTECH\\Nam4_Hk2\\Winform\\Do_an_cuoi_ky\\TinhTienTro\\TinhTienTro\\img\\img.png";

                // Kiểm tra xem hình ảnh có tồn tại không
                if (System.IO.File.Exists(imagePath))
                {
                    pictureBox1.Image = Image.FromFile(imagePath);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Điều chỉnh kích thước hình ảnh để phù hợp với PictureBox
                }
                else
                {
                    MessageBox.Show("Hình ảnh không tồn tại: " + imagePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hình ảnh: " + ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
