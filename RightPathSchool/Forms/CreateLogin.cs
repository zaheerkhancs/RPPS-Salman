using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using BarcodeLib;
using System.Drawing.Imaging;
using KeepAutomation.Barcode.Bean;

namespace RightPathSchool.Forms
{
    public partial class CreateLogin : Form
    {
        public static string UniCon = ConfigurationManager.ConnectionStrings["RightPathSchool.Properties.Settings.Setting"].ToString();


        public CreateLogin()
        {
            InitializeComponent();
        }

        private void CreateLogin_Load(object sender, EventArgs e)
        {
            cmbDesignation.SelectedIndex = 0;
            cmbRole.SelectedIndex = 0;
            GetGridView();
        }
        public void GetGridView() {
            var Qry = "SELECT UserID, UserName, FullName, Role, Desination FROM dbo.UserLogin WHERE(Flag = 1)";
            var dt = new DataTable();
            var da = new SqlDataAdapter(Qry, new SqlConnection(UniCon));
            da.Fill(dt);
            try
            {
                this.gvGridview.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            var Qry = "INSERT INTO [dbo].[UserLogin]           " +
                "([UserName]           " +
                ",[FullName]           " +
                ",[Role]           " +
                ",[Desination]           " +
                ",[Password]           " +
                ",[SecPassword]           " +
                ",[Hints]           " +
                ",[Flag])     " +
                "VALUES           " +
                "('" + txtLoginName.Text + "'" +
                ",'" + txtFullName.Text + "'" +
                ",'" + cmbRole.SelectedItem + "'" +
                ",'" + cmbDesignation.SelectedItem + "'" +
                ",'" + txtPassword.Text + "'" +
                ",'" + txtSecPassword.Text + "'" +
                ",'" + txtHints.Text + "'" +
                ",0)";
            var sqlcon = new SqlConnection(UniCon);
            var sqlcom = new SqlCommand(Qry, sqlcon);
            try
            {
                if (sqlcon.State != ConnectionState.Open) {
                    sqlcon.Open();
                    sqlcom.ExecuteNonQuery();
                    MessageBox.Show("Row Inserted...");
                    GetGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
