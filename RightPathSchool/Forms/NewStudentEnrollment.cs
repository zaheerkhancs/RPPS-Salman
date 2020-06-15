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
using System.IO;

namespace RightPathSchool.Forms
{
    public partial class NewStudentEnrollment : Form
    {
        public static string OfileName;
        public static string DbFileName;
        public static string UniCon = ConfigurationManager.ConnectionStrings["RightPathSchool.Properties.Settings.Setting"].ToString();
        public NewStudentEnrollment()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void NewStudentEnrollment_Load(object sender, EventArgs e)
        {
            cmbSession.SelectedIndex = 0;
            cmbAddmissionYear.SelectedIndex = 0;
            cmbGender.SelectedIndex = 0;
            cmbClassSought.SelectedIndex = 0;
            cmbReligion.SelectedIndex = 0;
            cmbMediumSchool.SelectedIndex = 0;
            cmbHostel.SelectedIndex = 0;
            cmbTransport.SelectedIndex = 0;
            cmbTypoGraphic.SelectedIndex = 0;
            cmbCurrentStatus.SelectedIndex = 0;



            GetGridview();
        }
        private void GetGridview()
        {
            var qry = " SELECT * FROM vwGetStudentRec";
            var da = new SqlDataAdapter(qry, new SqlConnection(UniCon));
            DataTable dt_ = new DataTable();
            da.Fill(dt_);
            gGridView.DataSource = dt_;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (PictureBox1.Image == null)
            {
                MessageBox.Show("Picture Can not be Empty");
                return;
            }
            DbFileName = OfileName;
            var Qry = "INSERT INTO StudentEnrollment" +
           "([SessionID]" +
           ",[AdmissionYear]" +
           ",[StudenEnrollmentNo]" +
           ",[PrevAdwNo]" +
           ",[NameEn]" +
           ",[NameUr]" +
           ",[DOB]" +
           ",[DOBinWords]" +
           ",[FatherName]" +
           ",[FatherNameUr]" +
           ",[FatherCNIC]" +
           ",[FatherProfession]" +
           ",[Gender]" +
           ",[Guardian]" +
           ",[GuardianCellNo]" +
           ",[LastSchool]" +
           ",[ClassSought]" +
           ",[Medium]" +
           ",[Nationality]" +
           ",[Religion]" +
           ",[Address]" +
           ",[Address2]" +
           ",[Mobile1]" +
           ",[Mobile2]" +
           ",[FirstContactPerson]" +
           ",[FirstContactPersonCell]" +
           ",[FirstContactPersonRel]" +
           ",[IsHostel]" +
           ",[IsTransport]" +
           ",[TypoGrapicNote]" +
           ",[CurrentStatus]" +
           ",[Flag]" +
           ",[IsDeleted]" +
           ",[DateModified]" +
           ",[DateCreate]" +
           ",[ModifiedBy]" +
           ",[CreatedBy])" +
     "VALUES" +
           "('" + cmbSession.SelectedItem.ToString() + "'" +
           ",'" + cmbAddmissionYear.SelectedItem.ToString() + "'" +
           ",'" + txtEnrollmentNo.Text.ToString().Trim() + "'" +
           ",'" + txtPreviousAddmisionNo.Text.Trim().ToString() + "'" +
           ",'" + txtaName.Text.ToString().Trim() + "'" +
           ",'" + txtNameUr.Text.ToString().Trim() + "'" +
           ",'" + dtDOB.Value.ToShortDateString().ToString() + "'" +
           ",'" + txtDOBinWords.Text.ToString() + "'" +
           ",'" + txtFName.Text.ToString() + "'" +
           ",'" + txtFNameUr.Text.ToString() + "'" +
           ",'" + txtFatherCNIC.Text.ToString() + "'" +
           ",'" + txtFatherProfession.Text.ToString() + "'" +
           ",'" + cmbGender.SelectedItem.ToString() + "'" +
           ",'" + txtGuardianName.Text.ToString() + "'" +
           ",'" + txtGuardianCellNo.Text.ToString() + "'" +
           ",'" + txtLastAttendSchool.Text.ToString() + "'" +
           ",'" + cmbClassSought.SelectedItem.ToString() + "'" +
           ",'" + cmbMediumSchool.SelectedItem.ToString() + "'" +
           ",'" + txtNationality.Text.ToString() + "'" +
           ",'" + cmbReligion.SelectedItem.ToString() + "'" +
           ",'" + txtAddressPer.Text.ToString() + "'" +
           ",'" + txtAddressTemp.Text.ToString() + "'" +
           ",'" + txtMobile1.Text.ToString() + "'" +
           ",'" + txtMobile2.Text.ToString() + "'" +
           ",'" + txtFirstPersonContact.Text.ToString() + "'" +
           ",'" + txtFirstPersonMobile.Text.ToString() + "'" +
           ",'" + txtFirstPersonRelation.Text.ToString() + "'" +
           ",'" + cmbHostel.SelectedItem.ToString() + "'" +
           ",'" + cmbTransport.SelectedItem.ToString() + "'" +
           ",'" + cmbTypoGraphic.SelectedItem.ToString() + "'" +
           ",'" + cmbCurrentStatus.SelectedItem.ToString() + "'" +
           ",'" + 1 + "'" +
           ",'" + 0 + "'" +
           ",'" + System.DateTime.Now.ToLongTimeString() + "'" +
           ",'" + System.DateTime.Now.ToLongTimeString() + "'" +
           ",'" + "ZAHEER" + "'" +
           ",'" + "ZAHEER" + "')";

            try
            {
                var sqlcon = new SqlConnection(UniCon);
                var sqlcom = new SqlCommand(Qry, sqlcon);
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                var sqlcom2 = new SqlCommand("SELECT SCOPE_IDENTITY()", sqlcon);
                var IDentity = sqlcom2.ExecuteScalar();
                sqlcon.Close();
                try
                {
                    if (OfileName != null) {
                        File.Copy(OfileName, @"D:\\Solution Code\\RightPathSchool\\res\\StudentProfiles\\" + IDentity + ".jpg");
                        sqlcon.Open();
                        var sqlcom3 = new SqlCommand("UPDATE StudentEnrollment Set PicturePath = '" + "D:\\Solution Code\\RightPathSchool\\res\\StudentProfiles\\" + IDentity + ".jpg" + "' Where StudentID ='" + IDentity + "' ", sqlcon);
                        sqlcom3.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    sqlcon.Close();
                }
                MessageBox.Show("Record Inserted...");
                GetGridview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void gGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gGridView.SelectedRows.Count > 0) // make sure user select at least 1 row 
                {

                    String StudentID = gGridView.SelectedRows[0].Cells[0].Value + string.Empty;
                    txtStudentIdentity.Text = StudentID;
                    String SessionID = gGridView.SelectedRows[0].Cells[1].Value + string.Empty;
                    cmbSession.SelectedItem = SessionID.ToString();
                    String AdmissionYear = gGridView.SelectedRows[0].Cells[2].Value + string.Empty;
                    cmbAddmissionYear.SelectedItem = AdmissionYear;
                    String StudenEnrollmentNo = gGridView.SelectedRows[0].Cells[3].Value + string.Empty;
                    txtEnrollmentNo.Text = StudenEnrollmentNo;
                    String PrevAdwN = gGridView.SelectedRows[0].Cells[4].Value + string.Empty;
                    txtPreviousAddmisionNo.Text = PrevAdwN;
                    String NameEn = gGridView.SelectedRows[0].Cells[5].Value + string.Empty;
                    txtaName.Text = NameEn;
                    String NameUr = gGridView.SelectedRows[0].Cells[6].Value + string.Empty;
                    txtNameUr.Text = NameUr;
                    String DOB = gGridView.SelectedRows[0].Cells[7].Value + string.Empty;
                    dtDOB.Value = DateTime.Parse(DOB.ToString());
                    String DOBinWords = gGridView.SelectedRows[0].Cells[8].Value + string.Empty;
                    txtDOBinWords.Text = DOBinWords;
                    String FatherName = gGridView.SelectedRows[0].Cells[9].Value + string.Empty;
                    txtFName.Text = FatherName;
                    String FatherNameUr = gGridView.SelectedRows[0].Cells[10].Value + string.Empty;
                    txtFNameUr.Text = FatherNameUr;
                    String FatherCNIC = gGridView.SelectedRows[0].Cells[11].Value + string.Empty;
                    txtFatherCNIC.Text = FatherCNIC;
                    String FatherProfession = gGridView.SelectedRows[0].Cells[12].Value + string.Empty;
                    txtFatherProfession.Text = FatherProfession;
                    String Gender = gGridView.SelectedRows[0].Cells[13].Value + string.Empty;
                    cmbGender.SelectedItem = Gender;
                    String Guardian = gGridView.SelectedRows[0].Cells[14].Value + string.Empty;
                    txtGuardianName.Text = Guardian;
                    String GuardianCellNo = gGridView.SelectedRows[0].Cells[15].Value + string.Empty;
                    txtGuardianCellNo.Text = GuardianCellNo;
                    String LastSchool = gGridView.SelectedRows[0].Cells[16].Value + string.Empty;
                    txtLastAttendSchool.Text = LastSchool;
                    String ClassSought = gGridView.SelectedRows[0].Cells[17].Value + string.Empty;
                    cmbClassSought.SelectedItem = ClassSought;
                    String Medium = gGridView.SelectedRows[0].Cells[18].Value + string.Empty;
                    cmbMediumSchool.SelectedItem = Medium;
                    String Nationality = gGridView.SelectedRows[0].Cells[19].Value + string.Empty;
                    txtNationality.Text = Nationality;
                    String Religion = gGridView.SelectedRows[0].Cells[20].Value + string.Empty;
                    cmbReligion.SelectedItem = Religion;
                    String Address = gGridView.SelectedRows[0].Cells[21].Value + string.Empty;
                    txtAddressPer.Text = Address;
                    String Address2 = gGridView.SelectedRows[0].Cells[22].Value + string.Empty;
                    txtAddressTemp.Text = Address2;
                    String Mobile1 = gGridView.SelectedRows[0].Cells[23].Value + string.Empty;
                    txtMobile1.Text = Mobile1;
                    String Mobile2 = gGridView.SelectedRows[0].Cells[24].Value + string.Empty;
                    txtMobile2.Text = Mobile2;
                    String FirstContactPerson = gGridView.SelectedRows[0].Cells[25].Value + string.Empty;
                    txtFirstPersonContact.Text = FirstContactPerson;
                    String FirstContactPersonCell = gGridView.SelectedRows[0].Cells[26].Value + string.Empty;
                    txtFirstPersonMobile.Text = FirstContactPersonCell;
                    String FirstContactPersonRel = gGridView.SelectedRows[0].Cells[27].Value + string.Empty;
                    txtFirstPersonRelation.Text = FirstContactPersonRel;
                    String IsHostel = gGridView.SelectedRows[0].Cells[28].Value + string.Empty;
                    cmbHostel.SelectedItem = IsHostel;
                    String IsTransport = gGridView.SelectedRows[0].Cells[29].Value + string.Empty;
                    cmbTransport.SelectedItem = IsTransport;
                    String TypoGrapicNote = gGridView.SelectedRows[0].Cells[30].Value + string.Empty;
                    cmbTypoGraphic.SelectedItem = TypoGrapicNote;
                    String CurrentStatus = gGridView.SelectedRows[0].Cells[31].Value + string.Empty;
                    cmbCurrentStatus.SelectedItem = CurrentStatus;
                    String Picture_ = gGridView.SelectedRows[0].Cells[32].Value + string.Empty;
                    PictureBox1.Image = new Bitmap(Picture_);
                    lblPicturePath.Text = Picture_;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void StudentPicture_Click(object sender, EventArgs e)
        {
            var Ofile = new OpenFileDialog();
            Ofile.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
            try
            {
                if (Ofile.ShowDialog() == DialogResult.OK)
                {

                    OfileName = Ofile.FileName;
                    PictureBox1.Image = new Bitmap(Ofile.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                Ofile.Dispose();
            }


        }

        private void dtDOB_ValueChanged(object sender, EventArgs e)
        {
            var output = WrittenNumerics.DateToWritten(DateTime.Parse(dtDOB.Value.ToString()));
            txtDOBinWords.Text = output;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var Qry = " UPDATE[dbo].[StudentEnrollment]" +
                      " SET[SessionID] = '" + cmbSession.SelectedItem + "'"
                          + ",[AdmissionYear] = '" + cmbAddmissionYear.SelectedItem.ToString() + "'"
                           + ",[StudenEnrollmentNo] = '" + txtEnrollmentNo.Text.ToString().Trim() + "'"
                          + ",[PrevAdwNo] = '" + txtPreviousAddmisionNo.Text.Trim().ToString() + "'"
                          + ",[NameEn] = '" + txtaName.Text.ToString().Trim() + "'"
                          + ",[NameUr] = '" + txtNameUr.Text.ToString().Trim() + "'"
                          + ",[DOB] = '" + dtDOB.Value.ToShortDateString().ToString() + "'"
                          + ",[DOBinWords] = '" + txtDOBinWords.Text.ToString() + "'"
                          + ",[FatherName] = '" + txtFName.Text.ToString() + "'"
                          + ",[FatherNameUr] = '" + txtFNameUr.Text.ToString() + "'"
                          + ",[FatherCNIC] = '" + txtFatherCNIC.Text.ToString() + "'"
                          + ",[FatherProfession] = '" + txtFatherProfession.Text.ToString() + "'"
                          + ",[Gender] = '" + cmbGender.SelectedItem.ToString() + "'"
                          + ",[Guardian] = '" + txtGuardianName.Text.ToString() + "'"
                          + ",[GuardianCellNo] ='" + txtGuardianCellNo.Text.ToString() + "'"
                          + ",[LastSchool] = '" + txtLastAttendSchool.Text.ToString() + "'"
                          + ",[ClassSought] = '" + cmbClassSought.SelectedItem.ToString() + "'"
                          + ",[Medium] = '" + cmbMediumSchool.SelectedItem.ToString() + "'"
                          + ",[Nationality] ='" + txtNationality.Text.ToString() + "'"
                          + ",[Religion] = '" + cmbReligion.SelectedItem.ToString() + "'"
                          + ",[Address] = '" + txtAddressPer.Text.ToString() + "'"
                          + ",[Address2] ='" + txtAddressTemp.Text.ToString() + "'"
                          + ",[Mobile1] = '" + txtMobile1.Text.ToString() + "'"
                          + ",[Mobile2] = '" + txtMobile2.Text.ToString() + "'"
                          + ",[FirstContactPerson] = '" + txtFirstPersonContact.Text.ToString() + "'"
                          + ",[FirstContactPersonCell] = '" + txtFirstPersonMobile.Text.ToString() + "'"
                          + ",[FirstContactPersonRel] = '" + txtFirstPersonRelation.Text.ToString() + "'"
                          + ",[IsHostel] = '" + cmbHostel.SelectedItem.ToString() + "'"
                          + ",[IsTransport] = '" + cmbTransport.SelectedItem.ToString() + "'"
                          + ",[TypoGrapicNote] = '" + cmbTypoGraphic.SelectedItem.ToString() + "'"
                          + ",[CurrentStatus] = '" + cmbCurrentStatus.SelectedItem.ToString() + "'"
                          + ",[PicturePath] = '" + lblPicturePath.Text + "'"
                          + ",[DateModified] = '" + System.DateTime.Now.ToString() + "'"
                          + ",[ModifiedBy] = 'ZAHEER'"
                          + "WHERE StudentID='" + txtStudentIdentity.Text + "'";
            try
            {
                var sqlcon = new SqlConnection(UniCon);
                var sqlcom = new SqlCommand(Qry, sqlcon);
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("Record Updated...");
                GetGridview();
                sqlcon.Close();
                sqlcom.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally { 
                
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var Qry = " UPDATE[dbo].[StudentEnrollment]" +
                      " SET IsDeleted=1 WHERE StudentID='" + txtStudentIdentity.Text + "'";
            try
            {
                var sqlcon = new SqlConnection(UniCon);
                var sqlcom = new SqlCommand(Qry, sqlcon);
                sqlcon.Open();
                sqlcom.ExecuteNonQuery();
                MessageBox.Show("Record Deleted...");
                GetGridview();
                sqlcon.Close();
                sqlcom.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {

            }
        }
    }
    
}

