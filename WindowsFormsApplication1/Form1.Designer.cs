﻿namespace WindowsFormsApplication1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pingIntervalTxtBox = new System.Windows.Forms.TextBox();
            this.setValuesButton = new System.Windows.Forms.Button();
            this.clearValuesButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.packetsPerPingTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sampleDurationTxtBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.remoteHostTxtBox = new System.Windows.Forms.ComboBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.loadDataSetBtn = new System.Windows.Forms.Button();
            this.refreshDataListBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Set Ping Interval (m)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Set Remote Host";
            // 
            // pingIntervalTxtBox
            // 
            this.pingIntervalTxtBox.Location = new System.Drawing.Point(139, 99);
            this.pingIntervalTxtBox.Name = "pingIntervalTxtBox";
            this.pingIntervalTxtBox.Size = new System.Drawing.Size(56, 20);
            this.pingIntervalTxtBox.TabIndex = 3;
            this.pingIntervalTxtBox.TextChanged += new System.EventHandler(this.pingIntervalTxtBox_TextChanged);
            // 
            // setValuesButton
            // 
            this.setValuesButton.Location = new System.Drawing.Point(16, 258);
            this.setValuesButton.Name = "setValuesButton";
            this.setValuesButton.Size = new System.Drawing.Size(150, 42);
            this.setValuesButton.TabIndex = 5;
            this.setValuesButton.Text = "Validate Script Settings";
            this.setValuesButton.UseVisualStyleBackColor = true;
            this.setValuesButton.Click += new System.EventHandler(this.setValuesButton_Click);
            // 
            // clearValuesButton
            // 
            this.clearValuesButton.Location = new System.Drawing.Point(173, 258);
            this.clearValuesButton.Name = "clearValuesButton";
            this.clearValuesButton.Size = new System.Drawing.Size(150, 42);
            this.clearValuesButton.TabIndex = 6;
            this.clearValuesButton.Text = "Clear Settings";
            this.clearValuesButton.UseVisualStyleBackColor = true;
            this.clearValuesButton.Click += new System.EventHandler(this.clearAndDeleteButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(341, 42);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(493, 212);
            this.listBox1.TabIndex = 7;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(447, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 40);
            this.button1.TabIndex = 8;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Set Packets per Ping";
            // 
            // packetsPerPingTxtBox
            // 
            this.packetsPerPingTxtBox.BackColor = System.Drawing.Color.White;
            this.packetsPerPingTxtBox.Location = new System.Drawing.Point(139, 46);
            this.packetsPerPingTxtBox.Name = "packetsPerPingTxtBox";
            this.packetsPerPingTxtBox.Size = new System.Drawing.Size(56, 20);
            this.packetsPerPingTxtBox.TabIndex = 11;
            this.packetsPerPingTxtBox.TextChanged += new System.EventHandler(this.packetsPerPingTxtBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(203, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "// Numbers only";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(203, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "// Numbers only";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(139, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "// Fully formed URLs only //";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Set Sample Duration (h)";
            // 
            // sampleDurationTxtBox
            // 
            this.sampleDurationTxtBox.Location = new System.Drawing.Point(141, 151);
            this.sampleDurationTxtBox.Name = "sampleDurationTxtBox";
            this.sampleDurationTxtBox.Size = new System.Drawing.Size(56, 20);
            this.sampleDurationTxtBox.TabIndex = 18;
            this.sampleDurationTxtBox.TextChanged += new System.EventHandler(this.sampleDurationTxtBox_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(203, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "// Numbers only";
            // 
            // remoteHostTxtBox
            // 
            this.remoteHostTxtBox.FormattingEnabled = true;
            this.remoteHostTxtBox.Location = new System.Drawing.Point(139, 192);
            this.remoteHostTxtBox.Name = "remoteHostTxtBox";
            this.remoteHostTxtBox.Size = new System.Drawing.Size(171, 21);
            this.remoteHostTxtBox.TabIndex = 20;
            this.remoteHostTxtBox.Text = "http://www.";
            this.remoteHostTxtBox.SelectedIndexChanged += new System.EventHandler(this.remoteHostTxtBox_SelectedIndexChanged);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(864, 42);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(325, 134);
            this.listBox2.TabIndex = 21;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(864, 182);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 29);
            this.button2.TabIndex = 22;
            this.button2.Text = "Kill Ping Process";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(341, 260);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 40);
            this.button3.TabIndex = 23;
            this.button3.Text = "Clear Log";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 306);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(822, 381);
            this.chart1.TabIndex = 24;
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(864, 220);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(325, 134);
            this.listBox3.TabIndex = 25;
            // 
            // loadDataSetBtn
            // 
            this.loadDataSetBtn.Location = new System.Drawing.Point(864, 360);
            this.loadDataSetBtn.Name = "loadDataSetBtn";
            this.loadDataSetBtn.Size = new System.Drawing.Size(100, 29);
            this.loadDataSetBtn.TabIndex = 26;
            this.loadDataSetBtn.Text = "Load Data Set";
            this.loadDataSetBtn.UseVisualStyleBackColor = true;
            this.loadDataSetBtn.Click += new System.EventHandler(this.button4_Click);
            // 
            // refreshDataListBtn
            // 
            this.refreshDataListBtn.Location = new System.Drawing.Point(970, 360);
            this.refreshDataListBtn.Name = "refreshDataListBtn";
            this.refreshDataListBtn.Size = new System.Drawing.Size(124, 29);
            this.refreshDataListBtn.TabIndex = 27;
            this.refreshDataListBtn.Text = "Refresh Data Sets";
            this.refreshDataListBtn.UseVisualStyleBackColor = true;
            this.refreshDataListBtn.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 839);
            this.Controls.Add(this.refreshDataListBtn);
            this.Controls.Add(this.loadDataSetBtn);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.remoteHostTxtBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.sampleDurationTxtBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.packetsPerPingTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.clearValuesButton);
            this.Controls.Add(this.setValuesButton);
            this.Controls.Add(this.pingIntervalTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pingIntervalTxtBox;
        private System.Windows.Forms.Button setValuesButton;
        private System.Windows.Forms.Button clearValuesButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox packetsPerPingTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox sampleDurationTxtBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox remoteHostTxtBox;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Button loadDataSetBtn;
        private System.Windows.Forms.Button refreshDataListBtn;
    }
}
