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
//using LinqLabs;

namespace prjLinqHomework
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();
            ordersTableAdapter1.Fill(nwDataSet1.Orders);
            order_DetailsTableAdapter1.Fill(nwDataSet1.Order_Details);
            productsTableAdapter1.Fill(nwDataSet1.Products);
            students_scores = new List<Student>()
            {
                 new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                 new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                 new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                 new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                 new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                 new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },
            };
        }
        List<Student> students_scores;

        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get; set; }
            public string Gender { get; set; }
        }

        private IEnumerable<NWDataSet.Order_DetailsRow> GetOrderDetails(int year)
        {
            
            var q = from r in nwDataSet1.Orders
                    where r.OrderDate.Year == year && !r.IsShipRegionNull() && !r.IsShipPostalCodeNull() && !r.IsShippedDateNull()
                    select r;
            dataGridView1.DataSource = q.ToList();
            var q1 = from o in q.ToList()
                     join od in nwDataSet1.Order_Details on o.OrderID equals od.OrderID
                     select od;
            return q1;
        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }
        void ClearAllDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
        }
        

        private void button14_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files =  dir.GetFiles();
            var q = from f in files
                    where IsLogFile(f)
                    select f;
            this.dataGridView1.DataSource = q.ToList();
        }

        private bool IsLogFile(System.IO.FileInfo f)
        {
            return f.FullName.ToLower().Substring(f.FullName.Length - 4) == ".log";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();
            var q = from f in files
                    where f.CreationTime.Year == 2019
                    select f;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();
            var q = from f in files
                    where f.Length >= 1000000
                    select f;
            dataGridView1.DataSource = q.ToList();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            IsProducts = false;
            comboBox1.Items.Clear();
            ClearAllDataGridView();
            dataGridView1.DataSource = nwDataSet1.Orders;
            List<int> _year = new List<int>(); 
            foreach (DataRow r in nwDataSet1.Orders.Rows)
            {
                _year.Add(Convert.ToInt32((r["OrderDate"].ToString().Substring(0,4))));
            }
            List<int> year = _year.Distinct().ToList();
            foreach (int s in year)
            {
                comboBox1.Items.Add(s);
            }
        }
        bool IsProducts;
        int totalCount = 0;
        int count = 0;
        int step = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            IsProducts = false;
            count = 0;
            ClearAllDataGridView();
            if (!int.TryParse(comboBox1.Text, out int year)) return;
            step = Convert.ToInt32(textBox1.Text);
            var q1 = GetOrderDetails(year);
            totalCount = q1.Count();
            dataGridView2.DataSource = q1.Take(step).ToList();
            if (step >= totalCount) button13.Enabled = false;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            ClearAllDataGridView();
            count += step;
            if (IsProducts)
            {
                var q = from r in nwDataSet1.Products
                        select r;
                dataGridView2.DataSource = q.Skip(count).Take(step).ToList();
            }
            else
            {
                if (!int.TryParse(comboBox1.Text, out int year)) return;
                var q = GetOrderDetails(year);
                dataGridView2.DataSource = q.Skip(count).Take(step).ToList();
            }
            if (count + step >= totalCount) button13.Enabled = false;
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ClearAllDataGridView();
            count -= step;
            if (count < 0) count = 0;
            if (IsProducts)
            {
                var q = from r in nwDataSet1.Products
                        select r;
                dataGridView2.DataSource = q.Skip(count).Take(step).ToList();
            }
            else
            {
                if (!int.TryParse(comboBox1.Text, out int year)) return;
                var q = GetOrderDetails(year);
                dataGridView2.DataSource = q.Skip(count).Take(step).ToList();
            }
            if (count + step < totalCount) button13.Enabled = true;
        }

        private void btnLinkProducts_Click(object sender, EventArgs e)
        {
            IsProducts = true;
            count = 0;
            step = Convert.ToInt32(textBox1.Text);
            ClearAllDataGridView();
            var q = from r in nwDataSet1.Products
                    select r;
            totalCount = q.Count();
            dataGridView2.DataSource = q.Take(step).ToList();
            if (step >= totalCount) button13.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int a)) return;
            step = a;
            
            if (IsProducts)
            {
                var q = from r in nwDataSet1.Products
                        select r;
                dataGridView2.DataSource = q.Skip(count).Take(step).ToList();
            }
            else
            {
                if (!int.TryParse(comboBox1.Text, out int year)) return;
                var q = GetOrderDetails(year);
                dataGridView2.DataSource = q.Skip(count).Take(step).ToList();
            }
            button13.Enabled = (count + step < totalCount) ? true : false; 
        }

        private void btnSearchStudentScore_Click(object sender, EventArgs e)
        {
            ClearAllDataGridView();
            var q = from r in students_scores
                    select r;
            dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = from i in students_scores
                    select i;
            MessageBox.Show("共有 " + q.Count().ToString() + " 位學員");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var q = from i in students_scores
                    select new { i.Name, i.Chi, i.Eng, i.Math };
            dataGridView2.DataSource = q.Take(Top = 3).ToList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            students_scores.Reverse();
            var q = from i in students_scores
                    select new { i.Name, i.Chi, i.Eng, i.Math };
            dataGridView2.DataSource = q.Take(Top = 2).ToList();
            students_scores.Reverse();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var q = students_scores.Where(n => n.Name == "aaa" || n.Name == "bbb" || n.Name == "ccc").Select(n=> new { n.Name, n.Chi, n.Eng, n.Math});
            dataGridView2.DataSource = q.ToList();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var q = students_scores.Where(n => n.Name == "bbb").Select(n => new { n.Name, n.Chi, n.Eng, n.Math });
            dataGridView2.DataSource = q.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            var q = students_scores.Where(n => n.Name != "bbb").Select(n => new { n.Name, n.Chi, n.Eng, n.Math });
            dataGridView2.DataSource = q.ToList();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var q = students_scores.Where(n => n.Math < 60).Select(n => new { n.Name, n.Math });
            dataGridView2.DataSource = q.ToList();
        }
    }
}
