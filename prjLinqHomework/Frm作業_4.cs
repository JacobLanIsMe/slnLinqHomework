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
    public partial class Frm作業_4 : Form
    {
        public Frm作業_4()
        {
            InitializeComponent();
        }
        NorthwindEntities dbContext = new NorthwindEntities();
        class Group
        {
            public string groupName { get; set; }
            public List<int> number { get; set; }
            public int groupCount { get; set; }
        }
        List<Group> groups;
        private void AllClear()
        {
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            treeView1.Nodes.Clear();
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            AllClear();
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            List<int> group1 = new List<int>();
            List<int> group2 = new List<int>();
            List<int> group3 = new List<int>();
            foreach (int i in nums)
            {
                if (i % 3 == 0) group1.Add(i);
                else if (i % 3 == 1) group2.Add(i);
                else group3.Add(i);
            }
            groups = new List<Group>()
            {
                new Group { groupName = "被三整除", groupCount = group1.Count, number = group1 },
                new Group { groupName = "餘數為1", groupCount = group2.Count, number = group2},
                new Group {groupName = "餘數為2", groupCount = group3.Count, number = group3}
            };
            dataGridView1.DataSource = groups;
            treeView1.Nodes.Clear();
            foreach (Group i in groups)
            {
                string s = $"{i.groupName} ({i.groupCount})";
                TreeNode x = treeView1.Nodes.Add(s);
                foreach (int j in i.number)
                {
                    x.Nodes.Add(j.ToString());
                }
            }
        }
        private void button38_Click(object sender, EventArgs e)
        {
            AllClear();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();
            List<long> fileLength = new List<long>();
            foreach (System.IO.FileInfo i in files)
            {
                fileLength.Add(i.Length);
            }
            long medianFileLength = fileLength[(int)(fileLength.Count / 2)];
            var q = from i in files
                    group i by i.Length >= medianFileLength ? "大檔案" : "小檔案" into g
                    select new { 檔案大小分群 = g.Key, MyCount = g.Count(), Avg = $"{g.Average(i=>i.Length):N2}", Info = g };
            dataGridView1.DataSource = q.ToList();
            treeView1.Nodes.Clear();
            foreach (var j in q)
            {
                string s = $"{j.檔案大小分群} ({j.MyCount})";
                TreeNode x = treeView1.Nodes.Add(s);
                foreach (var k in j.Info)
                {
                    x.Nodes.Add(k.Name);
                }
            }
            chart1.ChartAreas.Add("FirstChart");
            chart1.Series.Add("大/小檔案數目");
            foreach (var i in q)
            {
                chart1.Series[0].Points.AddXY(i.檔案大小分群, i.MyCount);
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            }
            chart1.Series[0].IsValueShownAsLabel = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            AllClear();
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");
            System.IO.FileInfo[] files = dir.GetFiles();
            var q = (from i in files
                    group i by i.CreationTime.Year into g
                    select new { Year = g.Key, MyCount = g.Count(), Info = g}).OrderByDescending(i=>i.Year);
            dataGridView1.DataSource = q.ToList();
            treeView1.Nodes.Clear();
            foreach (var j in q)
            {
                string s = $"{j.Year}年 ({j.MyCount})";
                TreeNode x = treeView1.Nodes.Add(s);
                foreach (var k in j.Info)
                {
                    x.Nodes.Add(k.Name);
                }
            }
            chart1.DataSource = q.ToList();
            chart1.ChartAreas.Add("FirstChart");
            chart1.Series.Add("年度");
            chart1.Series[0].XValueMember = "Year";
            chart1.Series[0].YValueMembers = "MyCount";
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            chart1.Series[0].IsValueShownAsLabel = true;
            
        }
        private void button8_Click(object sender, EventArgs e)
        {
            AllClear();
            var q = from i in dbContext.Products.AsEnumerable()
                    group i by PriceGrade(i) into g
                    select new { 價位 = g.Key, 產品數 = g.Count(), 平均單價 = $"{g.Average(i=>i.UnitPrice):c2}", 產品 = g };
            dataGridView1.DataSource = q.ToList();
            foreach (var j in q)
            {
                string s = $"{j.價位} ({j.產品數})";
                TreeNode x = treeView1.Nodes.Add(s);
                foreach (var k in j.產品)
                {
                    x.Nodes.Add(k.ProductName.ToString());
                }
            }
            chart1.ChartAreas.Add("FirstChart");
            chart1.ChartAreas.Add("SecondChart");
            chart1.Series.Add("ForPie");
            chart1.Series.Add("ForColumn");
            chart1.Series["ForColumn"].ChartArea = "SecondChart";
            chart1.ChartAreas["SecondChart"].AxisY.Title = "平均單價";
            chart1.ChartAreas["FirstChart"].Position.Auto = false;
            chart1.ChartAreas["FirstChart"].Position.Height = 50;
            chart1.ChartAreas["FirstChart"].Position.Width = 50;
            chart1.ChartAreas["FirstChart"].Position.X = 0;
            chart1.ChartAreas["FirstChart"].Position.Y = 30;
            chart1.ChartAreas["SecondChart"].Position.Auto = false;
            chart1.ChartAreas["SecondChart"].Position.Height = 70;
            chart1.ChartAreas["SecondChart"].Position.Width = 30;
            chart1.ChartAreas["SecondChart"].Position.X = 50;
            chart1.ChartAreas["SecondChart"].Position.Y = 20;
            
            foreach (var j in q)
            {
                chart1.Series["ForPie"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                chart1.Series["ForPie"].Points.AddXY(j.價位, j.產品數);
                chart1.Series["ForPie"].IsValueShownAsLabel = true;
                chart1.Series["ForColumn"].Points.AddXY(j.價位, j.平均單價);
                chart1.Series["ForColumn"].Color = Color.LightBlue;
            }
        }
        private string PriceGrade(Product i)
        {
            if (i.UnitPrice >= 100) return "高價位";
            else if (i.UnitPrice >= 50) return "中價位";
            else return "低價位";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            AllClear();
            var q = from i in dbContext.Orders
                    group i by i.OrderDate.Value.Year into g
                    select new { Year = g.Key, Count = g.Count(), Info = g};
            dataGridView1.DataSource = q.ToList();
            foreach (var j in q)
            {
                string s = $"{j.Year}年 ({j.Count})";
                TreeNode x = treeView1.Nodes.Add(s);
                foreach (var k in j.Info)
                {
                    x.Nodes.Add(k.OrderID.ToString());
                }
            }
            chart1.ChartAreas.Add("FirstChart");
            chart1.Series.Add("Pie");
            
            foreach (var j in q)
            {
                chart1.Series[0].Points.AddXY(j.Year, j.Count);
                chart1.Series[0].IsValueShownAsLabel = true;
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
            AllClear();
            var q = from i in dbContext.Orders
                    group i by i.OrderDate.Value.Year into g
                    select new
                    {
                        Year = g.Key,
                        YCount = g.Count(),
                        YMonth = g.GroupBy(j => j.OrderDate.Value.Month).Select(j => new {Month = j.Key, MCount = j.Count(), MInfo = j})
                    };
            dataGridView1.DataSource = q.ToList();
            TreeNode node1;
            TreeNode node2;
            foreach (var i in q)
            {
                string s = $"{i.Year}年 ({i.YCount})";
                node1 = treeView1.Nodes.Add(s);
                foreach (var j in i.YMonth)
                {
                    string s1 = $"{j.Month}月 ({j.MCount})";
                    node2 = node1.Nodes.Add(s1);
                    foreach (var k in j.MInfo)
                    {
                        node2.Nodes.Add(k.OrderID.ToString());  
                    }
                }          
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AllClear();
            var q = (from i in dbContext.Order_Details.AsEnumerable()
                     select new { 總銷售金額 = totalPrice(i) }).Sum(i => i.總銷售金額);
            MessageBox.Show($"總銷售金額為 {q:n2} 元");
        }
        private decimal totalPrice(Order_Detail i)
        {
            return i.UnitPrice * Convert.ToDecimal(i.Quantity) * (1 - Convert.ToDecimal(i.Discount));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AllClear();
            var q = (from i in dbContext.Order_Details.AsEnumerable()
                    group i by new { i.Order.Employee.EmployeeID, i.Order.Employee.FirstName, i.Order.Employee.LastName } into g
                    select new
                    {
                        EmployeeID = g.Key.EmployeeID,
                        FullName = $"{g.Key.FirstName} {g.Key.LastName}",
                        銷售員銷售總額 = g.Sum(i => i.UnitPrice * Convert.ToDecimal(i.Quantity) * Convert.ToDecimal(1 - i.Discount))
                    }).OrderByDescending(i => i.銷售員銷售總額).Take(5).Select(i=>new {i.EmployeeID, i.FullName, 銷售員銷售總額 = $"{i.銷售員銷售總額:n2}" }); 

            dataGridView1.DataSource = q.ToList();
            chart1.DataSource = q.ToList();
            chart1.ChartAreas.Add("FirstChart");
            chart1.Series.Add("Top5");
            chart1.Series[0].XValueMember = "FullName";
            chart1.Series[0].YValueMembers = "銷售員銷售總額";
            chart1.ChartAreas[0].AxisY.Title = "銷售額";
            chart1.ChartAreas[0].AxisY.TitleFont = new Font("標楷體", 14);
            chart1.ChartAreas[0].AxisX.Title = "銷售員";
            chart1.ChartAreas[0].AxisX.TitleFont = new Font("標楷體", 14);
            chart1.Series[0].IsVisibleInLegend = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            AllClear();
            var q = (from i in dbContext.Products.AsEnumerable()
                    orderby i.UnitPrice descending
                    select new { 類別名稱 = i.Category.CategoryName, 產品名稱 = i.ProductName, 產品單價 = $"{i.UnitPrice:n2}"}).Take(5);
            dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AllClear();
            var q = dbContext.Products.Where(i => i.UnitPrice > 300);
            if (q.Count() != 0)
            {
                MessageBox.Show("有 " + q.Count() + " 個產品單價大於300");
            }
            else
            {
                MessageBox.Show("沒有任何產品的單價大於300");
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            AllClear();
            var q = from i in dbContext.Order_Details.AsEnumerable()
                    group i by i.Order.OrderDate.Value.Year into g
                    select new
                    {
                        年份 = g.Key,
                        類別 = g.GroupBy(j => j.Product.Category.CategoryName).Select(j => new { 類別 = j.Key, 類別年銷售總額 = j.Sum(i => i.UnitPrice * Convert.ToDecimal(i.Quantity) * Convert.ToDecimal(1 - i.Discount)) }),
                        Info = g
                    };
            var q1 = from i in dbContext.Order_Details.AsEnumerable()
                     group i by i.Order.OrderDate.Value.Year into g
                     select new
                     {
                         Year = g.Key,
                         銷售員 = g.GroupBy(j => new { j.Order.Employee.EmployeeID, j.Order.Employee.FirstName, j.Order.Employee.LastName }).Select(j => new
                         {
                             FullName = $"{j.Key.FirstName} {j.Key.LastName}",
                             銷售員銷售額 = j.Sum(i => i.UnitPrice * Convert.ToDecimal(i.Quantity) * Convert.ToDecimal(1 - i.Discount))
                         })
                     };

            dataGridView1.DataSource = q.ToList();
            dataGridView2.DataSource = q1.ToList();
            chart1.ChartAreas.Add("FirstChart");
            chart1.ChartAreas.Add("SecondChart");
            foreach (var i in q)
            {
                string title = i.年份.ToString() + " for category";
                chart1.Series.Add(title);
                chart1.Series[title].ChartArea = "FirstChart";
                foreach (var j in i.類別)
                {
                    chart1.Series[title].Points.AddXY(j.類別, j.類別年銷售總額);
                }
            }
            chart1.ChartAreas[0].AxisY.Title = "銷售總額";
            chart1.ChartAreas[0].AxisY.TitleFont = new Font("標楷體", 14);
            chart1.ChartAreas[0].AxisX.Title = "類別名稱";
            chart1.ChartAreas[0].AxisX.TitleFont = new Font("標楷體", 14);
            foreach (var i in q1)
            {
                string title = i.Year.ToString() + " for employee";
                chart1.Series.Add(title);
                chart1.Series[title].ChartArea = "SecondChart";
                foreach (var j in i.銷售員)
                {
                    chart1.Series[title].Points.AddXY(j.FullName, j.銷售員銷售額);
                }
            }
            chart1.ChartAreas[1].AxisY.Title = "銷售總額";
            chart1.ChartAreas[1].AxisY.TitleFont = new Font("標楷體", 14);
            chart1.ChartAreas[1].AxisX.Title = "銷售員";
            chart1.ChartAreas[1].AxisX.TitleFont = new Font("標楷體", 14);
            chart1.ChartAreas["FirstChart"].Position.Auto = false;
            chart1.ChartAreas["FirstChart"].Position.Height = 70;
            chart1.ChartAreas["FirstChart"].Position.Width = 50;
            chart1.ChartAreas["FirstChart"].Position.X = 0;
            chart1.ChartAreas["FirstChart"].Position.Y = 20;
            chart1.ChartAreas["SecondChart"].Position.Auto = false;
            chart1.ChartAreas["SecondChart"].Position.Height = 70;
            chart1.ChartAreas["SecondChart"].Position.Width = 50;
            chart1.ChartAreas["SecondChart"].Position.X = 50;
            chart1.ChartAreas["SecondChart"].Position.Y = 20;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AllClear();
            var q = from i in dbContext.Order_Details.AsEnumerable()
                    group i by i.Order.OrderDate.Value.Year into g
                    orderby g.Key
                    select new { Year = g.Key, 當年銷售金額 = g.Sum(i => i.UnitPrice * Convert.ToDecimal(i.Quantity) * Convert.ToDecimal((1 - i.Discount))), Info = g };
            var q1 = from i in dbContext.Order_Details.AsEnumerable()
                    group i by i.Order.OrderDate.Value.Year into g
                    orderby g.Key
                    select new { Year = g.Key+1, 當年銷售金額 = g.Sum(i => i.UnitPrice * Convert.ToDecimal(i.Quantity) * Convert.ToDecimal((1 - i.Discount))), Info = g };
            var q2 = from i in q
                     join j in q1 on i.Year equals j.Year
                     select new { Year = i.Year, 當年銷售金額 = i.當年銷售金額, 年成長率 = ((i.當年銷售金額 - j.當年銷售金額) / j.當年銷售金額)*100 };
            var q3 = q2.Select(i=> new {Year = i.Year, 當年銷售金額 = i.當年銷售金額, 年成長率 = i.年成長率.ToString("0.00")+"%"});

            dataGridView1.DataSource = q.ToList();
            dataGridView2.DataSource = q3.ToList();
            chart1.ChartAreas.Add("FirstChart");
            chart1.Series.Add("年銷售成長率");
            chart1.Series[0].IsVisibleInLegend = false;
            chart1.ChartAreas[0].AxisX.Title = "年度";
            chart1.ChartAreas[0].AxisY.Title = "年銷售成長率 (%)";
            chart1.ChartAreas[0].AxisY.TitleFont = new Font("標楷體", 14);
            chart1.ChartAreas[0].AxisX.TitleFont = new Font("標楷體", 14);
            chart1.ChartAreas[0].Position.Height = 100;
            chart1.ChartAreas[0].Position.Width = 50;
            foreach (var i in q2)
            {
                
                int p = chart1.Series[0].Points.AddXY(i.Year, i.年成長率);
                if (i.年成長率 < 0)
                    chart1.Series[0].Points[p].Color = Color.Green;
                else
                    chart1.Series[0].Points[p].Color = Color.Red;
            }
        }
    }
}
