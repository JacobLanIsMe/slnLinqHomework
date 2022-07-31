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
                 new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 65, Math = 66, Gender = "Female" },
                 new Student{ Name = "eee", Class = "CS_101", Chi = 40, Eng = 30, Math = 50, Gender = "Female" },
                 new Student{ Name = "fff", Class = "CS_102", Chi = 100, Eng = 90, Math = 80, Gender = "Female" },
                 new Student{ Name = "ggg", Class = "CS_102", Chi = 30, Eng = 25, Math = 58, Gender = "Female" },
                 new Student{ Name = "hhh", Class = "CS_102", Chi = 97, Eng = 88, Math = 98, Gender = "Female" },
                 new Student{ Name = "iii", Class = "CS_101", Chi = 46, Eng = 78, Math = 69, Gender = "Male" },
                 new Student{ Name = "jjj", Class = "CS_102", Chi = 80, Eng = 75, Math = 77, Gender = "Female" },
                 new Student{ Name = "kkk", Class = "CS_101", Chi = 55, Eng = 47, Math = 88, Gender = "Male" },
                 new Student{ Name = "lll", Class = "CS_102", Chi = 90, Eng = 88, Math = 66, Gender = "Female" },
                 new Student{ Name = "mmm", Class = "CS_102", Chi = 25, Eng = 33, Math = 18, Gender = "Male" },
                 new Student{ Name = "nnn", Class = "CS_101", Chi = 50, Eng = 60, Math = 70, Gender = "Female" },
            };
            unSelectedStudentName = new string[students_scores.Count()];
            unSelectedSubject = new string[] { "Chi", "Eng", "Math" };
            studentNameIndex = new Dictionary<string, int>();
            subjectIndex = new Dictionary<string, int>();
            for (int i = 0; i < students_scores.Count(); i++)
            {
                comboBox1.Items.Add(students_scores[i].Name);
                comboBoxStudent.Items.Add(students_scores[i].Name);
                unSelectedStudentName[i] = students_scores[i].Name;
                studentNameIndex.Add(students_scores[i].Name, i);
            }
            for (int i = 0; i < unSelectedSubject.Count(); i++)
            {
                comboBoxSubject.Items.Add(unSelectedSubject[i]);
                subjectIndex.Add(unSelectedSubject[i], i);
            }
        }
        List<Student> students_scores;
        string[] unSelectedStudentName;
        string[] unSelectedSubject;
        Dictionary<string, int> studentNameIndex;
        Dictionary<string, int> subjectIndex;
        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get; set; }
            public string Gender { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.DataSource = students_scores;
            for (int i = 0; i < unSelectedSubject.Count(); i++)
            {
                chart1.Series.Add(unSelectedSubject[i]);
                chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                chart1.Series[i].XValueMember = "Name";
                chart1.Series[i].YValueMembers = unSelectedSubject[i];
            }
            chart1.ChartAreas[0].AxisY.Maximum = 100;
        }
        private void button36_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text == null) return;
            chart1.Series.Clear();
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
            listBoxStudent.Items.Add(selectedStudent);
            comboBoxStudent.Items.Remove(selectedStudent);
            unSelectedStudentName[studentNameIndex[selectedStudent]] = "";
            comboBoxStudent.Items.Clear();
            foreach (string i in unSelectedStudentName)
            {
                if (i == "") continue;
                comboBoxStudent.Items.Add(i);
            }
        }
        private void listBoxStudent_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxStudent.SelectedItem == null) return;
            string selectedStudent = (string)listBoxStudent.SelectedItem;
            listBoxStudent.Items.Remove(selectedStudent);
            unSelectedStudentName[studentNameIndex[selectedStudent]] = selectedStudent;
            comboBoxStudent.Items.Clear();
            foreach (string i in unSelectedStudentName)
            {
                if (i == "") continue;
                comboBoxStudent.Items.Add(i);
            }
        }
        private void comboBoxSubject_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string selectedSubject = (string)comboBoxSubject.SelectedItem;
            listBoxSubject.Items.Add(selectedSubject);
            comboBoxSubject.Items.Remove(selectedSubject);
            unSelectedSubject[subjectIndex[selectedSubject]] = "";
            comboBoxSubject.Items.Clear();
            foreach (string i in unSelectedSubject)
            {
                if (i == "") continue;
                comboBoxSubject.Items.Add(i);
            }
        }
        private void listBoxSubject_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxSubject.SelectedItem == null) return;
            string selectedSubject = (string)listBoxSubject.SelectedItem;
            listBoxSubject.Items.Remove(selectedSubject);
            unSelectedSubject[subjectIndex[selectedSubject]] = selectedSubject;
            comboBoxSubject.Items.Clear();
            foreach (string i in unSelectedSubject)
            {
                if (i == "") continue;
                comboBoxSubject.Items.Add(i);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            List<string> students = new List<string>();
            List<string> subjects = new List<string>();
            foreach (string i in listBoxStudent.Items) students.Add(i);
            foreach (string i in listBoxSubject.Items) subjects.Add(i);
            chart1.ChartAreas.Clear();
            chart1.Series.Clear();
            chart1.ChartAreas.Add("FirstChart");
            chart1.ChartAreas["FirstChart"].AxisY.TitleFont = new Font("標楷體", 14);
            chart1.ChartAreas["FirstChart"].AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chart1.ChartAreas["FirstChart"].AxisX.LabelStyle.IsStaggered = true;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            if (comboBoxGroupBy.Text == "" || comboBoxGroupBy.Text == "不分群")
            {
                var q = from i in students_scores
                        where students.ToArray().Contains(i.Name)
                        select i;
                if (subjects.Count == 0)
                {
                    foreach (Student i in q)
                    {
                        chart1.Series.Add(i.Name);
                        chart1.ChartAreas[0].AxisY.Title = "分數";
                        chart1.Series[i.Name].Points.AddXY("Chi", i.Chi);
                        chart1.Series[i.Name].Points.AddXY("Eng", i.Eng);
                        chart1.Series[i.Name].Points.AddXY("Math", i.Math);
                        chart1.Series[i.Name].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    }
                }
                else
                {
                    if (students.Count == 0)
                        chart1.DataSource = students_scores;
                    else
                        chart1.DataSource = q.ToList();
                    foreach (string i in subjects)
                    {
                        chart1.Series.Add(i);
                        chart1.ChartAreas[0].AxisY.Title = "分數";
                        chart1.Series[i].XValueMember = "Name";
                        chart1.Series[i].YValueMembers = i;
                        chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                    }
                }
            }
            else
            {
                comboBoxStudent.Items.Clear();
                foreach (string s in listBoxStudent.Items)
                {
                    unSelectedStudentName[studentNameIndex[s]] = s;
                }
                foreach (string i in unSelectedStudentName)
                {
                    if (i == "") continue;
                    comboBoxStudent.Items.Add(i);
                }
                listBoxStudent.Items.Clear();
                if (comboBoxGroupBy.Text == "不及格人數")
                {
                    foreach (string subject in subjects)
                    {
                        var q = (from i in students_scores
                                group i by IsPass(i, subject) into g
                                select new { 是否及格 = g.Key, 人數 = g.Count() }).OrderBy(i => i.是否及格);
                        chart1.ChartAreas[0].AxisY.Maximum = students_scores.Count;
                        chart1.ChartAreas[0].AxisY.Title = "人數";
                        chart1.Series.Add(subject);
                        chart1.Series[subject].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                        foreach (var j in q)
                        {
                            chart1.Series[subject].Points.AddXY(j.是否及格, j.人數);
                        }
                    }
                }
                else if (comboBoxGroupBy.Text == "依成績排序")
                {
                    if (subjects.Count == 1)
                    {
                        if (subjects[0] == "Chi")
                        {
                            var q = students_scores.OrderBy(i => i.Chi);
                            chart1.DataSource = q.ToList();
                        }
                        else if (subjects[0] == "Eng")
                        {
                            var q = students_scores.OrderBy(i => i.Eng);
                            chart1.DataSource = q.ToList();
                        }
                        else
                        {
                            var q = students_scores.OrderBy(i => i.Math);
                            chart1.DataSource = q.ToList();
                        }
                        chart1.Series.Add(subjects[0]);
                        chart1.Series[subjects[0]].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                        chart1.ChartAreas[0].AxisY.Title = "分數";
                        chart1.ChartAreas[0].AxisY.Maximum = 100;
                        chart1.Series[subjects[0]].XValueMember = "Name";
                        chart1.Series[subjects[0]].YValueMembers = subjects[0];
                    }
                    else
                    {
                        MessageBox.Show("一次僅可排序一個科目");
                    }
                    
                }
                else if (comboBoxGroupBy.Text == "依成績分群")
                {
                    foreach (string subject in subjects)
                    {
                        var q = (from i in students_scores
                                 group i by Grade(i, subject) into g
                                 select new { 等級 = g.Key, 人數 = g.Count()}).OrderByDescending(i=>i.等級);
                        chart1.Series.Add(subject);
                        chart1.ChartAreas[0].AxisY.Maximum = students_scores.Count;
                        chart1.ChartAreas[0].AxisY.Title = "人數";
                        chart1.ChartAreas[0].AxisX.TitleFont = new Font("標楷體", 14);
                        chart1.Series[subject].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
                        foreach (var j in q)
                        {
                            chart1.Series[subject].Points.AddXY(j.等級, j.人數);
                        }
                    }
                }
                else if (comboBoxGroupBy.Text == "依班級分群")
                {
                    chart1.ChartAreas["FirstChart"].AxisY.Maximum = 100;
                    chart1.ChartAreas["FirstChart"].AxisY.Title = "平均分數";
                    foreach (string subject in subjects)
                    {
                        chart1.Series.Add(subject);
                        if (subject == "Chi")
                        {
                            var q = from i in students_scores
                                    group i by i.Class into g
                                    select new { Class = g.Key, Avg = g.Average(i => i.Chi) };
                            foreach (var j in q)
                            {
                                chart1.Series[subject].Points.AddXY(j.Class, j.Avg);
                            }
                        }
                        else if (subject == "Eng")
                        {
                            var q = from i in students_scores
                                    group i by i.Class into g
                                    select new { Class = g.Key, Avg = g.Average(i => i.Eng) };
                            foreach (var j in q)
                            {
                                chart1.Series[subject].Points.AddXY(j.Class, j.Avg);
                            }
                        }
                        else
                        {
                            var q = from i in students_scores
                                    group i by i.Class into g
                                    select new { Class = g.Key, Avg = g.Average(i => i.Math) };
                            foreach (var j in q)
                            {
                                chart1.Series[subject].Points.AddXY(j.Class, j.Avg);
                            }
                        }
                    }
                }
                else if (comboBoxGroupBy.Text == "依性別分群")
                {
                    chart1.ChartAreas["FirstChart"].AxisY.Maximum = 100;
                    chart1.ChartAreas["FirstChart"].AxisY.Title = "平均分數";
                    foreach (string subject in subjects)
                    {
                        chart1.Series.Add(subject);
                        if (subject == "Chi")
                        {
                            var q = from i in students_scores
                                    group i by i.Gender into g
                                    select new { Gender = g.Key, Avg = g.Average(i => i.Chi) };
                            foreach (var j in q)
                            {
                                chart1.Series[subject].Points.AddXY(j.Gender, j.Avg);
                            }
                        }
                        else if (subject == "Eng")
                        {
                            var q = from i in students_scores
                                    group i by i.Gender into g
                                    select new { Gender = g.Key, Avg = g.Average(i => i.Eng) };
                            foreach (var j in q)
                            {
                                chart1.Series[subject].Points.AddXY(j.Gender, j.Avg);
                            }
                        }
                        else
                        {
                            var q = from i in students_scores
                                    group i by i.Gender into g
                                    select new { Gender = g.Key, Avg = g.Average(i => i.Math) };
                            foreach (var j in q)
                            {
                                chart1.Series[subject].Points.AddXY(j.Gender, j.Avg);
                            }
                        }
                    }
                }
            }
        }
        private string IsPass(Student i, string subject)
        {
            if (subject == "Chi")
            {
                if (i.Chi >= 60) return "及格";
                else return "不及格";
            }
            else if (subject == "Eng")
            {
                if (i.Eng >= 60) return "及格";
                else return "不及格";
            }
            else
            {
                if (i.Math >= 60) return "及格";
                else return "不及格";
            }
        }
        private string Grade(Student i, string subject)
        {
            if (subject == "Chi")
            {
                if (i.Chi >= 90) return "1.優良";
                else if (i.Chi >= 70) return "2.佳";
                else if (i.Chi >= 60) return "3.待加強";
                else return "4.當掉";
            }
            else if (subject == "Eng")
            {
                if (i.Eng >= 90) return "1.優良";
                else if (i.Eng >= 70) return "2.佳";
                else if (i.Eng >= 60) return "3.待加強";
                else return "4.當掉";
            }
            else
            {
                if (i.Math >= 90) return "1.優良";
                else if (i.Math >= 70) return "2.佳";
                else if (i.Math >= 60) return "3.待加強";
                else return "4.當掉";
            }
        }
    }
}
