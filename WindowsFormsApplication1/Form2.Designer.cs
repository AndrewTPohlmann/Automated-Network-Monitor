namespace WindowsFormsApplication1
{
    partial class Form2
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
            this.packetsPerPingNumeric = new System.Windows.Forms.NumericUpDown();
            this.remoteHostTxtBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.setValuesButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pingIntervalNumeric = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTaskName = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.step1 = new System.Windows.Forms.Label();
            this.step2 = new System.Windows.Forms.Label();
            this.step3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptActionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadExistingFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoExecutePingTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.packetsPerPingNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pingIntervalNumeric)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // packetsPerPingNumeric
            // 
            this.packetsPerPingNumeric.Location = new System.Drawing.Point(124, 46);
            this.packetsPerPingNumeric.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.packetsPerPingNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.packetsPerPingNumeric.Name = "packetsPerPingNumeric";
            this.packetsPerPingNumeric.Size = new System.Drawing.Size(53, 20);
            this.packetsPerPingNumeric.TabIndex = 44;
            this.packetsPerPingNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // remoteHostTxtBox
            // 
            this.remoteHostTxtBox.BackColor = System.Drawing.SystemColors.Window;
            this.remoteHostTxtBox.FormattingEnabled = true;
            this.remoteHostTxtBox.Location = new System.Drawing.Point(122, 162);
            this.remoteHostTxtBox.Name = "remoteHostTxtBox";
            this.remoteHostTxtBox.Size = new System.Drawing.Size(165, 21);
            this.remoteHostTxtBox.TabIndex = 43;
            this.remoteHostTxtBox.Text = "www.google.com";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 41;
            this.label8.Text = "End Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Packets per Ping";
            // 
            // setValuesButton
            // 
            this.setValuesButton.Location = new System.Drawing.Point(185, 230);
            this.setValuesButton.Name = "setValuesButton";
            this.setValuesButton.Size = new System.Drawing.Size(164, 27);
            this.setValuesButton.TabIndex = 37;
            this.setValuesButton.Text = "Validate Parameters";
            this.setValuesButton.UseVisualStyleBackColor = true;
            this.setValuesButton.Click += new System.EventHandler(this.setValuesButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Set Remote Host";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Ping Interval ";
            // 
            // pingIntervalNumeric
            // 
            this.pingIntervalNumeric.Location = new System.Drawing.Point(124, 75);
            this.pingIntervalNumeric.Maximum = new decimal(new int[] {
            1439,
            0,
            0,
            0});
            this.pingIntervalNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pingIntervalNumeric.Name = "pingIntervalNumeric";
            this.pingIntervalNumeric.Size = new System.Drawing.Size(55, 20);
            this.pingIntervalNumeric.TabIndex = 46;
            this.pingIntervalNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(12, 230);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(66, 27);
            this.button2.TabIndex = 48;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "5 Packets Maximum";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(186, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Up to 1439 Minutes (24H)";
            // 
            // endDatePicker
            // 
            this.endDatePicker.CustomFormat = "MM/dd/yyyy";
            this.endDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endDatePicker.Location = new System.Drawing.Point(124, 135);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(106, 20);
            this.endDatePicker.TabIndex = 52;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTaskName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.startDatePicker);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.endDatePicker);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.pingIntervalNumeric);
            this.groupBox1.Controls.Add(this.remoteHostTxtBox);
            this.groupBox1.Controls.Add(this.packetsPerPingNumeric);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 192);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            // 
            // lblTaskName
            // 
            this.lblTaskName.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTaskName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTaskName.Location = new System.Drawing.Point(122, 20);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(108, 15);
            this.lblTaskName.TabIndex = 56;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(25, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 55;
            this.label7.Text = "Ping Task Name";
            // 
            // startDatePicker
            // 
            this.startDatePicker.CustomFormat = "MM/dd/yyyy";
            this.startDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startDatePicker.Location = new System.Drawing.Point(124, 106);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(106, 20);
            this.startDatePicker.TabIndex = 54;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 53;
            this.label6.Text = "Start Date";
            // 
            // step1
            // 
            this.step1.AutoSize = true;
            this.step1.ForeColor = System.Drawing.Color.Black;
            this.step1.Location = new System.Drawing.Point(6, 11);
            this.step1.Name = "step1";
            this.step1.Size = new System.Drawing.Size(51, 13);
            this.step1.TabIndex = 55;
            this.step1.Text = "Validated";
            // 
            // step2
            // 
            this.step2.AutoSize = true;
            this.step2.Location = new System.Drawing.Point(57, 11);
            this.step2.Name = "step2";
            this.step2.Size = new System.Drawing.Size(57, 13);
            this.step2.TabIndex = 56;
            this.step2.Text = "Generated";
            // 
            // step3
            // 
            this.step3.AutoSize = true;
            this.step3.Location = new System.Drawing.Point(112, 11);
            this.step3.Name = "step3";
            this.step3.Size = new System.Drawing.Size(46, 13);
            this.step3.TabIndex = 57;
            this.step3.Text = "Execute";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.step1);
            this.groupBox2.Controls.Add(this.step3);
            this.groupBox2.Controls.Add(this.step2);
            this.groupBox2.Location = new System.Drawing.Point(185, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(164, 34);
            this.groupBox2.TabIndex = 58;
            this.groupBox2.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.scriptActionsToolStripMenuItem,
            this.scriptSettingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(359, 24);
            this.menuStrip1.TabIndex = 59;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.backToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // scriptActionsToolStripMenuItem
            // 
            this.scriptActionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadExistingFileToolStripMenuItem});
            this.scriptActionsToolStripMenuItem.Name = "scriptActionsToolStripMenuItem";
            this.scriptActionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.scriptActionsToolStripMenuItem.Text = "Actions";
            // 
            // loadExistingFileToolStripMenuItem
            // 
            this.loadExistingFileToolStripMenuItem.Name = "loadExistingFileToolStripMenuItem";
            this.loadExistingFileToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.loadExistingFileToolStripMenuItem.Text = "Load Existing .Bat";
            this.loadExistingFileToolStripMenuItem.Click += new System.EventHandler(this.loadExistingFileToolStripMenuItem_Click);
            // 
            // scriptSettingsToolStripMenuItem
            // 
            this.scriptSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoExecutePingTasksToolStripMenuItem});
            this.scriptSettingsToolStripMenuItem.Name = "scriptSettingsToolStripMenuItem";
            this.scriptSettingsToolStripMenuItem.Size = new System.Drawing.Size(116, 20);
            this.scriptSettingsToolStripMenuItem.Text = "Generator Settings";
            // 
            // autoExecutePingTasksToolStripMenuItem
            // 
            this.autoExecutePingTasksToolStripMenuItem.Name = "autoExecutePingTasksToolStripMenuItem";
            this.autoExecutePingTasksToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.autoExecutePingTasksToolStripMenuItem.Text = "Auto-Execute Task ";
            this.autoExecutePingTasksToolStripMenuItem.Click += new System.EventHandler(this.autoExecutePingTasksToolStripMenuItem_Click);
            // 
            // backButton
            // 
            this.backButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backButton.Location = new System.Drawing.Point(151, 230);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(38, 27);
            this.backButton.TabIndex = 60;
            this.backButton.Text = "<";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Visible = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(359, 302);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.setValuesButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Script Generator";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.packetsPerPingNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pingIntervalNumeric)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown packetsPerPingNumeric;
        private System.Windows.Forms.ComboBox remoteHostTxtBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button setValuesButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown pingIntervalNumeric;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label step1;
        private System.Windows.Forms.Label step2;
        private System.Windows.Forms.Label step3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptActionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadExistingFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoExecutePingTasksToolStripMenuItem;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.Label label7;
    }
}