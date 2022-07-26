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
            dataGridView2.Columns.Clear();
            dataGridView1.Columns.Clear();
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
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            if (!int.TryParse(comboBox1.Text, out int year)) return;
            step = Convert.ToInt32(textBox1.Text);
            var q1 = GetOrderDetails(year);
            totalCount = q1.Count();
            dataGridView2.DataSource = q1.Take(step).ToList();
            if (step >= totalCount) button13.Enabled = false;
        }
        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
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
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
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
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
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
    }
}
