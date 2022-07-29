
namespace prjLinqHomework
{
    partial class Frm作業_3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button36 = new System.Windows.Forms.Button();
            this.button37 = new System.Windows.Forms.Button();
            this.button33 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBoxStudent = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxSubject = new System.Windows.Forms.ListBox();
            this.listBoxGroupBy = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBoxStudent = new System.Windows.Forms.ComboBox();
            this.comboBoxSubject = new System.Windows.Forms.ComboBox();
            this.comboBoxGroupBy = new System.Windows.Forms.ComboBox();
            this.contextMenuStripStudent = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button36
            // 
            this.button36.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button36.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button36.Location = new System.Drawing.Point(44, 142);
            this.button36.Margin = new System.Windows.Forms.Padding(4);
            this.button36.Name = "button36";
            this.button36.Size = new System.Drawing.Size(333, 67);
            this.button36.TabIndex = 149;
            this.button36.Text = "各科成績排名";
            this.button36.UseVisualStyleBackColor = false;
            this.button36.Click += new System.EventHandler(this.button36_Click);
            // 
            // button37
            // 
            this.button37.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button37.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button37.Location = new System.Drawing.Point(44, 249);
            this.button37.Margin = new System.Windows.Forms.Padding(4);
            this.button37.Name = "button37";
            this.button37.Size = new System.Drawing.Size(333, 67);
            this.button37.TabIndex = 148;
            this.button37.Text = "每個學生個人成績";
            this.button37.UseVisualStyleBackColor = false;
            this.button37.Click += new System.EventHandler(this.button37_Click);
            // 
            // button33
            // 
            this.button33.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button33.Location = new System.Drawing.Point(44, 600);
            this.button33.Margin = new System.Windows.Forms.Padding(4);
            this.button33.Name = "button33";
            this.button33.Size = new System.Drawing.Size(333, 67);
            this.button33.TabIndex = 147;
            this.button33.Text = "自己分群";
            this.button33.UseVisualStyleBackColor = false;
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(456, 29);
            this.chart1.Margin = new System.Windows.Forms.Padding(4);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(488, 315);
            this.chart1.TabIndex = 150;
            this.chart1.Text = "chart1";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(217, 324);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 151;
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Chi",
            "Eng",
            "Math"});
            this.comboBox2.Location = new System.Drawing.Point(217, 217);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(160, 24);
            this.comboBox2.TabIndex = 152;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button1.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(44, 54);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(333, 67);
            this.button1.TabIndex = 153;
            this.button1.Text = "搜尋 班級所有學生的成績";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBoxStudent
            // 
            this.listBoxStudent.FormattingEnabled = true;
            this.listBoxStudent.ItemHeight = 16;
            this.listBoxStudent.Location = new System.Drawing.Point(44, 452);
            this.listBoxStudent.Name = "listBoxStudent";
            this.listBoxStudent.Size = new System.Drawing.Size(83, 84);
            this.listBoxStudent.TabIndex = 154;
            this.listBoxStudent.DoubleClick += new System.EventHandler(this.listBoxStudent_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 155;
            this.label1.Text = "學生";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(156, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 156;
            this.label2.Text = "科目";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 157;
            this.label3.Text = "分群方法";
            // 
            // listBoxSubject
            // 
            this.listBoxSubject.FormattingEnabled = true;
            this.listBoxSubject.ItemHeight = 16;
            this.listBoxSubject.Location = new System.Drawing.Point(150, 452);
            this.listBoxSubject.Name = "listBoxSubject";
            this.listBoxSubject.Size = new System.Drawing.Size(83, 84);
            this.listBoxSubject.TabIndex = 158;
            // 
            // listBoxGroupBy
            // 
            this.listBoxGroupBy.FormattingEnabled = true;
            this.listBoxGroupBy.ItemHeight = 16;
            this.listBoxGroupBy.Location = new System.Drawing.Point(262, 452);
            this.listBoxGroupBy.Name = "listBoxGroupBy";
            this.listBoxGroupBy.Size = new System.Drawing.Size(83, 84);
            this.listBoxGroupBy.TabIndex = 159;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(262, 542);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 31);
            this.button2.TabIndex = 160;
            this.button2.Text = "開始比對";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBoxStudent
            // 
            this.comboBoxStudent.FormattingEnabled = true;
            this.comboBoxStudent.Location = new System.Drawing.Point(44, 391);
            this.comboBoxStudent.Name = "comboBoxStudent";
            this.comboBoxStudent.Size = new System.Drawing.Size(83, 24);
            this.comboBoxStudent.TabIndex = 161;
            this.comboBoxStudent.SelectionChangeCommitted += new System.EventHandler(this.comboBoxStudent_SelectionChangeCommitted);
            // 
            // comboBoxSubject
            // 
            this.comboBoxSubject.FormattingEnabled = true;
            this.comboBoxSubject.Location = new System.Drawing.Point(150, 390);
            this.comboBoxSubject.Name = "comboBoxSubject";
            this.comboBoxSubject.Size = new System.Drawing.Size(83, 24);
            this.comboBoxSubject.TabIndex = 162;
            // 
            // comboBoxGroupBy
            // 
            this.comboBoxGroupBy.FormattingEnabled = true;
            this.comboBoxGroupBy.Location = new System.Drawing.Point(262, 391);
            this.comboBoxGroupBy.Name = "comboBoxGroupBy";
            this.comboBoxGroupBy.Size = new System.Drawing.Size(83, 24);
            this.comboBoxGroupBy.TabIndex = 163;
            // 
            // contextMenuStripStudent
            // 
            this.contextMenuStripStudent.Name = "contextMenuStripStudent";
            this.contextMenuStripStudent.Size = new System.Drawing.Size(61, 4);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(44, 543);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 16);
            this.label4.TabIndex = 164;
            this.label4.Text = "Double click to remove selected item";
            // 
            // Frm作業_3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1367, 793);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxGroupBy);
            this.Controls.Add(this.comboBoxSubject);
            this.Controls.Add(this.comboBoxStudent);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBoxGroupBy);
            this.Controls.Add(this.listBoxSubject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBoxStudent);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button36);
            this.Controls.Add(this.button37);
            this.Controls.Add(this.button33);
            this.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Frm作業_3";
            this.Text = "Frm作業_3";
            this.Load += new System.EventHandler(this.Frm作業_3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button36;
        private System.Windows.Forms.Button button37;
        private System.Windows.Forms.Button button33;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBoxStudent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listBoxSubject;
        private System.Windows.Forms.ListBox listBoxGroupBy;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBoxStudent;
        private System.Windows.Forms.ComboBox comboBoxSubject;
        private System.Windows.Forms.ComboBox comboBoxGroupBy;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripStudent;
        private System.Windows.Forms.Label label4;
    }
}