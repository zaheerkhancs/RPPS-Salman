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
using BarcodeLib;
using System.Drawing.Imaging;
using KeepAutomation.Barcode.Bean;

namespace RightPathSchool.Forms
{
    public partial class StudentBarCodeGenerator : Form
    {
        public static string UniCon = ConfigurationManager.ConnectionStrings["RightPathSchool.Properties.Settings.Setting"].ToString();
        public static string Barcode = "";

        public StudentBarCodeGenerator()
        {
            InitializeComponent();
        }

        private void StudentBarCodeGenerator_Load(object sender, EventArgs e)
        {
            GetCLass();
            GetSession();
            //GetStudentsOfClass();
            GetGridViewData();


        }
        public void GetSession()
        {
            var Qry = "Select SessionID, SessionDetail from Session Where CurrentSession=1 and Active=1";
            try
            {
                var dt = new DataTable();
                var sqlCon = new SqlConnection(UniCon);
                var da = new SqlDataAdapter(Qry, sqlCon);
                da.Fill(dt);
                this.cmbSession.ValueMember = dt.Columns["SessionID"].ToString();
                this.cmbSession.DisplayMember = dt.Columns["SessionDetail"].ToString();
                cmbSession.DataSource = dt;
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
                var dt = new DataTable();
                var Qry = "Select ClassID, ClassName from ClassDetails Where Active=1";
                var sqlCon = new SqlConnection(UniCon);
                var da = new SqlDataAdapter(Qry, sqlCon);
                da.Fill(dt);
                this.cmbClass.ValueMember = dt.Columns["ClassID"].ToString();
                this.cmbClass.DisplayMember = dt.Columns["ClassName"].ToString();
                cmbClass.DataSource = dt;
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
        public void GetGridViewData() {
            var Qry = "Select BarCodepath, *from StudentEnrollment Where BarCodePath  IN(select BarcodePath from StudentEnrollment)";
            var sqlcon = new SqlConnection(UniCon);
            var dt = new DataTable();
            var da = new SqlDataAdapter(Qry, sqlcon);

                try {
                da.Fill(dt);
                this.dataGridView1.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            
            }
        }
        private void cmbClass_SelectedValueChanged(object sender, EventArgs e)
        {

            var dt = new DataTable();
            var sqlCon = new SqlConnection(UniCon);


            try
            {
                var Qry = "SELECT        TOP (100) PERCENT " +
                    "dbo.CurrentEnrStudentRec.StudentID, " +
                    "dbo.CurrentEnrStudentRec.StudentName " +
                    "FROM dbo.CurrentEnrStudentRec " +
                    "INNER JOIN                          " +
                    "dbo.ClassDetails ON " +
                    "dbo.CurrentEnrStudentRec.EnrolledClassID = dbo.ClassDetails.ClassID " +
                    "WHERE(dbo.ClassDetails.ClassID = '" + cmbClass.SelectedValue + "') " +
                    "GROUP BY dbo.CurrentEnrStudentRec.StudentID, dbo.CurrentEnrStudentRec.StudentName " +
                    "ORDER BY dbo.CurrentEnrStudentRec.StudentName";
                var da = new SqlDataAdapter(Qry, sqlCon);

                if (sqlCon.State != ConnectionState.Open)
                {
                    this.cmbStudentName.SelectedIndex = -1;

                    da.Fill(dt);
                    this.cmbStudentName.ValueMember = "StudentID";
                    this.cmbStudentName.DisplayMember = "StudentName";
                    this.cmbStudentName.DataSource = dt;



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
            try
            {

               

                /*
                Zen.Barcode.Code128BarcodeDraw brCode =
                Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                PictureBoxBarcode.Image = brCode.Draw(cmbStudentName.SelectedValue.ToString(), 120);
                */
            }
            catch (Exception)
            {

            }
           
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            PictureBoxBarcode.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] ar = new byte[ms.Length];
            ms.Write(ar, 0, ar.Length);

        }

        private void cmbStudentName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbStudentName.SelectedValue != null)
            {

                var Qry = "SELECT StudentID, PicturePath, NameEn, FatherName, SessionID from StudentEnrollment  Where IsDeleted =0 and StudentID='" + cmbStudentName.SelectedValue + "'";
                var sqlCon = new SqlConnection(UniCon);
                var sqlcom = new SqlCommand(Qry, sqlCon);
                sqlCon.Open();

                SqlDataReader reader = sqlcom.ExecuteReader();
                try
                {
                    String NameEn = "";
                    String FatherName = "";
                    String SessionID = "";
                    String path = "";
                    String StudentID = "";


                    while (reader.Read())
                    {
                        path = reader["PicturePath"].ToString();
                        StudentID = reader["StudentID"].ToString();
                        NameEn = reader["NameEn"].ToString();
                        FatherName = reader["FatherName"].ToString();
                        SessionID = reader["SessionID"].ToString();

                    }
                    this.PictureBox1.Image = new Bitmap(path);
                    this.txtStudentIdentity.Text = StudentID;


                    try
                    {
                        Barcode = StudentID+"-"+ NameEn + "-" + FatherName;

                        Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                        var barcodeImage = barcode.Draw(Barcode, 50);

                        var resultImage = new Bitmap(barcodeImage.Width, barcodeImage.Height + 20); // 20 is bottom padding, adjust to your text

                        using (var graphics = Graphics.FromImage(resultImage))
                        using (var font = new Font("Consolas", 12))
                        using (var brush = new SolidBrush(Color.Black))
                        using (var format = new StringFormat()
                        {
                            Alignment = StringAlignment.Center, // Also, horizontally centered text, as in your example of the expected output
                            LineAlignment = StringAlignment.Far
                        })
                        {
                            graphics.Clear(Color.White);
                            graphics.DrawImage(barcodeImage, 0, 0);
                            graphics.DrawString(Barcode, font, brush, resultImage.Width / 2, resultImage.Height, format);
                        }

                        PictureBoxBarcode.Image = resultImage;
                        PictureBoxBarcode.Image.Save("D:\\Solution Code\\RightPathSchool\\BarCode\\StudentProfile\\" + Barcode + ".jpg");

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message.ToString());
                }
                finally
                {
                    sqlCon.Close();
                    sqlcom.Dispose();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                BarCode code39 = new BarCode();
                code39.Symbology = KeepAutomation.Barcode.Symbology.Code39;
                code39.CodeToEncode = Barcode;
                code39.generateBarcodeToImageFile(@"D:\\Solution Code\\RightPathSchool\\BarCode\\StudentProfile\\" + Barcode + ".jpg");
                PictureBoxBarcode.Image=new Bitmap(@"D:\\Solution Code\\RightPathSchool\\BarCode\\StudentProfile\\" + Barcode + ".jpg");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
