using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QrCodeClass;

namespace QrcodeDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text==""||textBox2.Text=="")
            {
                MessageBox.Show(@"内容不得为空");
                return;
            }
            int width = Convert.ToInt16(textBox2.Text);
            pictureBox1.Width = width;
            pictureBox1.Image = Zxing.GenByZxingNet(textBox1.Text, width);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Zxing.BitmapSave((Bitmap)pictureBox1.Image, "D:/123.Jpeg");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text=="")
            {
                MessageBox.Show("文件路径不为空");
                return;
            }
            Bitmap image = Zxing.GetiImage(textBox3.Text);
           richTextBox1.Text= Zxing.DecodeQrCode(image);

        }

    }
}
