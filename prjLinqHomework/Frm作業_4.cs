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
        private void button8_Click(object sender, EventArgs e)
        {
            var q = from i in dbContext.Products.AsEnumerable()
                    group i by PriceGrade(i) into g
                    select new { 價位 = g.Key, 產品數 = g.Count(), 平均單價 = $"{g.Average(i=>i.UnitPrice):c2}", 產品 = g };
            dataGridView1.DataSource = q.ToList();
            treeView1.Nodes.Clear();
            foreach (var j in q)
            {
                string s = $"{j.價位} ({j.產品數})";
                TreeNode x = treeView1.Nodes.Add(s);
                foreach (var k in j.產品)
                {
                    x.Nodes.Add(k.ProductName.ToString());
                }
            }
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
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
            var q = from i in dbContext.Orders
                    group i by i.OrderDate.Value.Year into g
                    select new { Year = g.Key, Count = g.Count(), Info = g};
            dataGridView1.DataSource = q.ToList();
            treeView1.Nodes.Clear();
            foreach (var j in q)
            {
                string s = $"{j.Year} ({j.Count})";
                TreeNode x = treeView1.Nodes.Add(s);
                foreach (var k in j.Info)
                {
                    x.Nodes.Add(k.OrderID.ToString());
                }
            }
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.ChartAreas.Add("FirstChart");
            chart1.Series.Add("Pie");
            
            foreach (var j in q)
            {
                chart1.Series[0].Points.AddXY(j.Year, j.Count);
                chart1.Series[0].IsValueShownAsLabel = true;
                chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            }
        }
    }
}
