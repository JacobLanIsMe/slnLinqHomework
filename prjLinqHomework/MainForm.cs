using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjLinqHomework
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Frm作業_1 frm1 = new Frm作業_1();
            frm1.MdiParent = this;
            frm1.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Frm作業_2 frm2 = new Frm作業_2();
            frm2.MdiParent = this;
            frm2.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Frm作業_3 frm3 = new Frm作業_3();
            frm3.MdiParent = this;
            frm3.Show();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Frm作業_4 frm4 = new Frm作業_4();
            frm4.MdiParent = this;
            frm4.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null) ActiveMdiChild.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            while (ActiveMdiChild != null) ActiveMdiChild.Close();
        }
    }
}
