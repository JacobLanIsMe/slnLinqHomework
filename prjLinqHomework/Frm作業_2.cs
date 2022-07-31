using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjLinqHomework
{
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
            //splitContainer1.Panel2MinSize = Screen.PrimaryScreen.WorkingArea.Height * 3 / 4;
            productPhotoTableAdapter1.Fill(adventureWorkDataSet1.ProductPhoto);
            ForYearSelect();
        }
        //int position = -1;
        private void ForYearSelect()
        {
            var q = adventureWorkDataSet1.ProductPhoto.OrderBy(i => i.ModifiedDate).Select(i => i.ModifiedDate.Year).Distinct();
            foreach (int i in q)
            {
                comboBox3.Items.Add(i);
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            var q = adventureWorkDataSet1.ProductPhoto;
            dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime start = dateTimePicker1.Value;
            DateTime end = dateTimePicker2.Value;
            var q = adventureWorkDataSet1.ProductPhoto.Where(i => i.ModifiedDate >= start && i.ModifiedDate <= end);
            dataGridView1.DataSource = q.ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem == null) return;
            int year = (int)comboBox3.SelectedItem;
            var q = adventureWorkDataSet1.ProductPhoto.Where(i => i.ModifiedDate.Year == year);
            dataGridView1.DataSource = q.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null) return;
            string quarter = (string)comboBox2.SelectedItem;
            Dictionary<string, int[]> dic = new Dictionary<string, int[]>()
            {
                { "第一季", new int[] { 1, 2, 3} },
                { "第二季", new int[] { 4, 5, 6} },
                { "第三季", new int[] { 7, 8, 9} },
                { "第四季", new int[] { 10, 11, 12} },
            };
            var q = adventureWorkDataSet1.ProductPhoto.Where(i => dic[quarter].Contains(i.ModifiedDate.Month));
            dataGridView1.DataSource = q.ToList();
            MessageBox.Show("共有 " + q.Count() + "筆");
        }
        //int selectedRow = -1;
        //private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        //{
        //    selectedRow = e.RowIndex;
        //}

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            //if (selectedRow < 0) return;
            Byte[] byteData = (Byte[])dataGridView1.CurrentRow.Cells["LargePhoto"].Value;
            MemoryStream memoryStream = new MemoryStream(byteData);
            pictureBox1.Image = Image.FromStream(memoryStream);
            memoryStream.Close();
        }

        
    }
    
}
