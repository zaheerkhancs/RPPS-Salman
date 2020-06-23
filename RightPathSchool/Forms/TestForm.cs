using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

using System.Data.SqlClient;
namespace RightPathSchool.Forms
{
    public partial class TestForm : Form
    {
        public static string UniCon = ConfigurationManager.ConnectionStrings["RightPathSchool.Properties.Settings.Setting"].ToString();

        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Zen.Barcode.Code128BarcodeDraw brCode =
            Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            pictureBox1.Image = brCode.Draw(textBox1.Text, 120);
            pictureBox1.Image.Save("D:\\zaheer.barcode.jpg");

        }
    }
}
