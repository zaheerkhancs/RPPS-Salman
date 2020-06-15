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
    }
}
