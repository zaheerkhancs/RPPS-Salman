using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RightPathSchool
{
    public partial class MdiParent : Form
    {
        public MdiParent()
        {
            InitializeComponent();
        }

        private void studentRecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var post_dt = new Forms.NewStudentEnrollment();
            post_dt.MdiParent = this;
            post_dt.Show();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void feeTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var post_dt = new Forms.FeeCard();
            post_dt.MdiParent = this;
            post_dt.Show();
        }

        private void studentSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void attandancePostingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var post_dt = new Forms.GetAttandanceManual();
            post_dt.MdiParent = this;
            post_dt.Show();
        }

        private void studentBarCodeGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var post_dt = new Forms.StudentBarCodeGenerator();
            post_dt.MdiParent = this;
            post_dt.Show();
        }

        private void testFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var post_dt = new Forms.TestForm();
            post_dt.MdiParent = this;
            post_dt.Show();
        }

        private void createLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var post_dt = new Forms.CreateLogin();
            post_dt.MdiParent = this;
            post_dt.Show();
        }
    }
}
