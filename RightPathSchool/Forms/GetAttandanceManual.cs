using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RightPathSchool.Forms
{
    public partial class GetAttandanceManual : Form
    {
        public static string UniCon = ConfigurationManager.ConnectionStrings["RightPathSchool.Properties.Settings.Setting"].ToString();

        public GetAttandanceManual()
        {
            InitializeComponent();
        }

        private void GetAttandanceManual_Load(object sender, EventArgs e)
        {
            //cmbSession.SelectedIndex = 0;
            //cmbClass.SelectedIndex = 0;
            //cmbFlags.SelectedIndex = 0;

            GetGridViewLoad();
            GetSession();
            GetAttandanceFlags();
            GetCLass();

        }


        public void GetGridViewLoad()
        {

            var qry = " SELECT * FROM vwGetAttandanceGrid";
            var da = new SqlDataAdapter(qry, new SqlConnection(UniCon));
            DataTable dt_ = new DataTable();
            da.Fill(dt_);
            dataGridView1.DataSource = dt_;
        }
        public void GetSession()
        {
            try
            {
                var Qry = "Select SessionID, SessionDetail from Session Where CurrentSession=1 and Active=1";
                var sqlCon = new SqlConnection(UniCon);
                if (sqlCon.State != ConnectionState.Open)
                {
                    sqlCon.Open();
                    var sqlcom = new SqlCommand(Qry, sqlCon);
                    sqlcom.CommandText = Qry;
                    SqlDataReader reader = sqlcom.ExecuteReader();
                    while (reader.Read())
                    {
                        this.cmbSession.Items.Add(reader["SessionDetail"].ToString());
                        this.cmbSession.ValueMember = reader["SessionID"].ToString();
                        this.cmbSession.DisplayMember = reader["SessionDetail"].ToString();
                    }
                    sqlCon.Close();
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message.ToString());
            }
            finally
            {

            }
        }
        public void GetCLass()
        {
            try
            {
                var Qry = "Select ClassID, ClassName from ClassDetails Where Active=1";
                var sqlCon = new SqlConnection(UniCon);
                if (sqlCon.State != ConnectionState.Open)
                {
                    sqlCon.Open();
                    var sqlcom = new SqlCommand(Qry, sqlCon);
                    sqlcom.CommandText = Qry;
                    SqlDataReader reader = sqlcom.ExecuteReader();
                    while (reader.Read())
                    {
                        this.cmbClass.Items.Add(reader["ClassName"].ToString());
                        this.cmbClass.ValueMember = reader["ClassID"].ToString();
                        this.cmbClass.DisplayMember = reader["ClassName"].ToString();
                    }
                    sqlCon.Close();
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message.ToString());
            }
            finally
            {

            }

        }
        public void GetStudentsOfClass()
        {
            cmbStudentName.Items.Clear();
            try
            {
                var Qry = "SELECT   " +
                    "dbo.CurrentEnrStudentRec.CurrentEnrStudentID as StudentID, " +
                    "dbo.StudentEnrollment.NameEn as Name " +
                    "FROM dbo.CurrentEnrStudentRec INNER JOIN " +
                    "dbo.StudentEnrollment ON dbo.CurrentEnrStudentRec.StudentID = dbo.StudentEnrollment.StudentID INNER JOIN " +
                    "dbo.Session ON dbo.CurrentEnrStudentRec.SessionID = dbo.Session.SessionID INNER JOIN  " +
                    "dbo.ClassDetails ON dbo.CurrentEnrStudentRec.ClassEnroll = dbo.ClassDetails.ClassID   " +
                    "WHERE(dbo.Session.SessionID = '"+cmbSession.ValueMember+"') " +
                    "AND(dbo.ClassDetails.ClassID = '"+cmbClass.ValueMember+"') " +
                    "ORDER BY dbo.StudentEnrollment.NameEn";
                var sqlCon = new SqlConnection(UniCon);
                if (sqlCon.State != ConnectionState.Open)
                {
                    sqlCon.Open();
                    var sqlcom = new SqlCommand(Qry, sqlCon);
                    sqlcom.CommandText = Qry;
                    SqlDataReader reader = sqlcom.ExecuteReader();
                    while (reader.Read())
                    {
                        this.cmbClass.Items.Add(reader["Name"].ToString());
                        this.cmbClass.ValueMember = reader["StudentID"].ToString();
                        this.cmbClass.DisplayMember = reader["Name"].ToString();
                    }
                    sqlCon.Close();
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message.ToString());
            }
            finally
            {

            }

        }
        public void GetAttandanceFlags()
        {
            try
            {
                var Qry = "Select AttandanceFlagID, Detail from AttandanceFlagDetails";
                var sqlCon = new SqlConnection(UniCon);
                if (sqlCon.State != ConnectionState.Open)
                {
                    sqlCon.Open();
                    var sqlcom = new SqlCommand(Qry, sqlCon);
                    sqlcom.CommandText = Qry;
                    SqlDataReader reader = sqlcom.ExecuteReader();
                    while (reader.Read())
                    {
                        this.cmbFlags.Items.Add(reader["Detail"].ToString());
                        this.cmbFlags.ValueMember = reader["Detail"].ToString();
                        this.cmbFlags.DisplayMember = reader["AttandanceFlagID"].ToString();
                    }
                    sqlCon.Close();
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void cmbClass_SelectedValueChanged(object sender, EventArgs e)
        {
            cmbStudentName.Items.Clear();
            try
            {
                var Qry = "SELECT   " +
                    "dbo.CurrentEnrStudentRec.CurrentEnrStudentID as StudentID, " +
                    "dbo.StudentEnrollment.NameEn as Name " +
                    "FROM dbo.CurrentEnrStudentRec INNER JOIN " +
                    "dbo.StudentEnrollment ON dbo.CurrentEnrStudentRec.StudentID = dbo.StudentEnrollment.StudentID INNER JOIN " +
                    "dbo.Session ON dbo.CurrentEnrStudentRec.SessionID = dbo.Session.SessionID INNER JOIN  " +
                    "dbo.ClassDetails ON dbo.CurrentEnrStudentRec.ClassEnroll = dbo.ClassDetails.ClassID   " +
                    "WHERE(dbo.Session.SessionID = '" + cmbSession.ValueMember + "') " +
                    "AND(dbo.ClassDetails.ClassID = '" + cmbClass.ValueMember + "') " +
                    "ORDER BY dbo.StudentEnrollment.NameEn";
                var sqlCon = new SqlConnection(UniCon);
                if (sqlCon.State != ConnectionState.Open)
                {
                    sqlCon.Open();
                    var sqlcom = new SqlCommand(Qry, sqlCon);
                    sqlcom.CommandText = Qry;
                    SqlDataReader reader = sqlcom.ExecuteReader();
                    while (reader.Read())
                    {
                        this.cmbStudentName.Items.Add(reader["Name"].ToString());
                        this.cmbStudentName.ValueMember = reader["StudentID"].ToString();
                        this.cmbStudentName.DisplayMember = reader["Name"].ToString();
                    }
                    sqlCon.Close();
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void cmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbStudentName.Items.Clear();
            try
            {
                var Qry = "SELECT   " +
                    "dbo.CurrentEnrStudentRec.CurrentEnrStudentID as StudentID, " +
                    "dbo.StudentEnrollment.NameEn as Name " +
                    "FROM dbo.CurrentEnrStudentRec INNER JOIN " +
                    "dbo.StudentEnrollment ON dbo.CurrentEnrStudentRec.StudentID = dbo.StudentEnrollment.StudentID INNER JOIN " +
                    "dbo.Session ON dbo.CurrentEnrStudentRec.SessionID = dbo.Session.SessionID INNER JOIN  " +
                    "dbo.ClassDetails ON dbo.CurrentEnrStudentRec.ClassEnroll = dbo.ClassDetails.ClassID   " +
                    "WHERE(dbo.Session.SessionID = '" + cmbSession.ValueMember + "') " +
                    "AND(dbo.ClassDetails.ClassID = '" + cmbClass.ValueMember + "') " +
                    "ORDER BY dbo.StudentEnrollment.NameEn";
                var sqlCon = new SqlConnection(UniCon);
                if (sqlCon.State != ConnectionState.Open)
                {
                    sqlCon.Open();
                    var sqlcom = new SqlCommand(Qry, sqlCon);
                    sqlcom.CommandText = Qry;
                    SqlDataReader reader = sqlcom.ExecuteReader();
                    while (reader.Read())
                    {
                        this.cmbStudentName.Items.Add(reader["Name"].ToString());
                        this.cmbStudentName.ValueMember = reader["StudentID"].ToString();
                        this.cmbStudentName.DisplayMember = reader["Name"].ToString();
                    }
                    sqlCon.Close();
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message.ToString());
            }
            finally
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
