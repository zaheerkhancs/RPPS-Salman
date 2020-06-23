using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace RightPathSchool.Forms
{
    public partial class login : Form
    {
        public static string UniCon = ConfigurationManager.ConnectionStrings["RightPathSchool.Properties.Settings.Setting"].ToString();

        public login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string GetRetPass = "";
            try
            {
                var sqlcom = new SqlCommand("SELECT PASSWORD FROM USERLOGIN WHERE USERNAME='" + txtUserName.Text + "'", new SqlConnection(UniCon));
                sqlcom.Connection.Open();
                SqlDataReader reader_ = reader_ = sqlcom.ExecuteReader();
                while (reader_.Read())
                {
                    GetRetPass = reader_["password"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            string GetPass = txtPass.Text;
            if (GetPass.Trim() == GetRetPass.Trim())
            {
                this.Hide();
                var mdi_ = new MdiParent();
                mdi_.Show();
            }
            else
            {
                MessageBox.Show("Incorrect Login...");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            var sqlcon = new SqlConnection(UniCon);
            sqlcon.Open();
            MessageBox.Show("Con Opened.");
            sqlcon.Close();
       
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
    
}
