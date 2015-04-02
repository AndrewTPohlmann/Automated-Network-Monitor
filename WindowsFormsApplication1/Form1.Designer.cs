namespace WindowsFormsApplication1
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.loadDataSetBtn = new System.Windows.Forms.Button();
            this.refreshDataListBtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.deleteData = new System.Windows.Forms.Button();
            this.scriptsRadioBtn = new System.Windows.Forms.RadioButton();
            this.dataSetsRadioBtn = new System.Windows.Forms.RadioButton();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.systemMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataSetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.systemMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 54);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(822, 521);
            this.chart1.TabIndex = 24;
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // loadDataSetBtn
            // 
            this.loadDataSetBtn.Location = new System.Drawing.Point(972, 277);
            this.loadDataSetBtn.Name = "loadDataSetBtn";
            this.loadDataSetBtn.Size = new System.Drawing.Size(120, 22);
            this.loadDataSetBtn.TabIndex = 26;
            this.loadDataSetBtn.Text = "Load to Graph";
            this.loadDataSetBtn.UseVisualStyleBackColor = true;
            this.loadDataSetBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // refreshDataListBtn
            // 
            this.refreshDataListBtn.Location = new System.Drawing.Point(972, 245);
            this.refreshDataListBtn.Name = "refreshDataListBtn";
            this.refreshDataListBtn.Size = new System.Drawing.Size(120, 23);
            this.refreshDataListBtn.TabIndex = 27;
            this.refreshDataListBtn.Text = "Refresh";
            this.refreshDataListBtn.UseVisualStyleBackColor = true;
            this.refreshDataListBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1098, 277);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(89, 22);
            this.button4.TabIndex = 28;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(862, 18);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(325, 212);
            this.listBox3.TabIndex = 25;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // deleteData
            // 
            this.deleteData.Location = new System.Drawing.Point(1098, 245);
            this.deleteData.Name = "deleteData";
            this.deleteData.Size = new System.Drawing.Size(89, 23);
            this.deleteData.TabIndex = 29;
            this.deleteData.Text = "Delete";
            this.deleteData.UseVisualStyleBackColor = true;
            this.deleteData.Click += new System.EventHandler(this.button2_Click);
            // 
            // scriptsRadioBtn
            // 
            this.scriptsRadioBtn.AutoSize = true;
            this.scriptsRadioBtn.Location = new System.Drawing.Point(862, 245);
            this.scriptsRadioBtn.Name = "scriptsRadioBtn";
            this.scriptsRadioBtn.Size = new System.Drawing.Size(57, 17);
            this.scriptsRadioBtn.TabIndex = 30;
            this.scriptsRadioBtn.TabStop = true;
            this.scriptsRadioBtn.Text = "Scripts";
            this.scriptsRadioBtn.UseVisualStyleBackColor = true;
            this.scriptsRadioBtn.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // dataSetsRadioBtn
            // 
            this.dataSetsRadioBtn.AutoSize = true;
            this.dataSetsRadioBtn.Location = new System.Drawing.Point(862, 268);
            this.dataSetsRadioBtn.Name = "dataSetsRadioBtn";
            this.dataSetsRadioBtn.Size = new System.Drawing.Size(72, 17);
            this.dataSetsRadioBtn.TabIndex = 31;
            this.dataSetsRadioBtn.TabStop = true;
            this.dataSetsRadioBtn.Text = "Data Sets";
            this.dataSetsRadioBtn.UseVisualStyleBackColor = true;
            this.dataSetsRadioBtn.CheckedChanged += new System.EventHandler(this.dataSetsRadioBtn_CheckedChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // systemMenuStrip
            // 
            this.systemMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.scriptsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.systemMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.systemMenuStrip.Name = "systemMenuStrip";
            this.systemMenuStrip.Size = new System.Drawing.Size(1228, 24);
            this.systemMenuStrip.TabIndex = 35;
            this.systemMenuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // scriptsToolStripMenuItem
            // 
            this.scriptsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.dataSetsToolStripMenuItem});
            this.scriptsToolStripMenuItem.Name = "scriptsToolStripMenuItem";
            this.scriptsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.scriptsToolStripMenuItem.Text = "Actions";
            this.scriptsToolStripMenuItem.Click += new System.EventHandler(this.scriptsToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem1
            // 
            this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
            this.loadToolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.loadToolStripMenuItem1.Text = "Script Generator";
            this.loadToolStripMenuItem1.Click += new System.EventHandler(this.loadToolStripMenuItem1_Click);
            // 
            // dataSetsToolStripMenuItem
            // 
            this.dataSetsToolStripMenuItem.Name = "dataSetsToolStripMenuItem";
            this.dataSetsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.dataSetsToolStripMenuItem.Text = "Data Set Visualizer";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 839);
            this.Controls.Add(this.dataSetsRadioBtn);
            this.Controls.Add(this.scriptsRadioBtn);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.deleteData);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.refreshDataListBtn);
            this.Controls.Add(this.loadDataSetBtn);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.systemMenuStrip);
            this.Name = "Form1";
            this.Text = "Automated Network Monitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.systemMenuStrip.ResumeLayout(false);
            this.systemMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button loadDataSetBtn;
        private System.Windows.Forms.Button refreshDataListBtn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button deleteData;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.RadioButton scriptsRadioBtn;
        private System.Windows.Forms.RadioButton dataSetsRadioBtn;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip systemMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataSetsToolStripMenuItem;
    }
}

