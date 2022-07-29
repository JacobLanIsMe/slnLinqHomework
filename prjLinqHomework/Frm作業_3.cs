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
                comboBoxStudent.Items.Add(i.Name);
                _studentName.Add(i.Name);
            }
            comboBoxSubject.Items.AddRange(_subject);
            
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
        List<string> _studentName = new List<string>();
        string[] _subject = { "Chi", "Eng", "Math" };
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.DataSource = students_scores;
            for (int i = 0; i < _subject.Length; i++)
            {
                chart1.Series.Add(_subject[i]);
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart1.Series[i].XValueMember = "Name";
                chart1.Series[i].YValueMembers = _subject[i];
            }
            chart1.ChartAreas[0].AxisY.Maximum = 100;
        }
        private void button36_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == null) return;
            string subject = comboBox2.Text;
            chart1.DataSource = students_scores;
            chart1.Series.Clear();
            chart1.Series.Add(subject);
            chart1.Series[0].YValueMembers = subject;
            chart1.Series[0].XValueMember = "Name";
        }

        private void button37_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            string student = comboBox1.Text;
            chart1.Series.Add(student);
            var q = (students_scores.Where(i => i.Name == student).Select(i => new { i.Chi, i.Eng, i.Math })); 
            foreach (var row in q)
            {
                chart1.Series[0].Points.AddXY("Chi", row.Chi);
                chart1.Series[0].Points.AddXY("Eng", row.Eng);
                chart1.Series[0].Points.AddXY("Math", row.Math);
            }
        }

        

        private void comboBoxStudent_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedStudent = (string)comboBoxStudent.SelectedItem;
            comboBoxStudent.Items.Remove(selectedStudent);
            listBoxStudent.Items.Add(selectedStudent);
        }

        private void listBoxStudent_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxStudent.SelectedItem == null) return;
            string selectedStudent = (string)listBoxStudent.SelectedItem;
            listBoxStudent.Items.Remove(selectedStudent);
        }
    }
}
