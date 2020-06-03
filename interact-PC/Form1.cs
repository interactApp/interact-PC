using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interact_PC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int version = Convert.ToInt16("SSSS");

            int pixel = Convert.ToInt16("12");

            string str_msg = "SSSS";

            int int_icon_size = Convert.ToInt16("12");

            int int_icon_border = Convert.ToInt16("1");

            Bitmap bmp = chestnut_qrcode.Encoder.code(str_msg, version, pixel, "E:/seaconch/git/1.jpg", int_icon_size, int_icon_border);

            pb_qrcode.Image = bmp;

        }
    }
}
