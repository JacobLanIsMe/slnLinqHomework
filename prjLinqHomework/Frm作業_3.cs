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
    public partial class Frm作業_3 : Form
    {
        public Frm作業_3()
        {
            InitializeComponent();
            
        }
        private void Frm作業_3_Load(object sender, EventArgs e)
        {
            students_scores = new List<Student>()
            {
                 new Student{ Name = "aaa", Class = "CS_101", Chi = 65, Eng = 85, Math = 45, Gender = "Male" },
                 new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                 new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                 new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 65, Math = 85, Gender = "Female" },
                 new Student{ Name = "eee", Class = "CS_101", Chi = 40, Eng = 30, Math = 50, Gender = "Female" },
                 new Student{ Name = "fff", Class = "CS_102", Chi = 100, Eng = 90, Math = 80, Gender = "Female" },
            };
            foreach (Student i in students_scores)
            {
                comboBox1.Items.Add(i.Name);
            }
            
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
        string[] subject = { "Chi", "Eng", "Math" };
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.DataSource = students_scores;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            var q = students_scores.Select(i => i.Name).ToList();
            
            
        }
        private void button36_Click(object sender, EventArgs e)
        {
            string subject = comboBox2.Text;
            chart1.DataSource = students_scores;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart1.Series[0].Name = subject;
            chart1.Series[0].XValueMember = "Name";
            chart1.Series[0].YValueMembers = subject;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            string student = comboBox1.Text;
            var q = (students_scores.Where(i => i.Name == student).Select(i => new { i.Chi, i.Eng, i.Math })).ToList();
            chart1.DataSource = q.ToList();
            //chart1.Series.Add(subject);

        }

        
    }
}
