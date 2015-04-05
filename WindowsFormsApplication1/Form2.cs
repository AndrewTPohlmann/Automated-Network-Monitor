using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net.NetworkInformation;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        List<String> usableURLList = new List<string>();
        DirectoryInfo dinfo = new DirectoryInfo(@"C:\");

        string resultPath;
        string batPath;
        string batTxt;
        string batconfigStr;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            startDatePicker.MinDate = DateTime.Now;
            endDatePicker.MinDate = DateTime.Now.AddDays(1);
            remoteHostTxtBox.Items.Add("www.utexas.edu");
            remoteHostTxtBox.Items.Add("www.nus.edu");
            remoteHostTxtBox.Items.Add("www.ox.ac.uk");
            remoteHostTxtBox.Items.Add("www.ust.hk");

        }

        private void setValuesButton_Click(object sender, EventArgs e)
        {

            switch (setValuesButton.Text)
            {
                case ("Validate Script Settings"):

                    if (validateURL())
                    {
                        batconfigStr = "-U: " + remoteHostTxtBox.Text + " -P: " + packetsPerPingNumeric.Text + " -I: " + pingIntervalNumeric.Text + " -D: " + endDatePicker.Value.ToString("MM/dd/yyyy"); 

                        setValuesButton.Text = "Generate Batch File";
                        backButton.Visible = true;
                        step1.ForeColor = Color.Green;
                        lockScriptSettings(true);

                    }
                    else
                    {
                        MessageBox.Show("The remote host's URL cannot be pinged.");

                        setValuesButton.Text = "Validate Script Settings";
                        step1.ForeColor = Color.Black;
                        remoteHostTxtBox.BackColor = Color.White;
                        backButton.Visible = false;
                        lockScriptSettings(false);
                    }

                    break;

                case ("Generate Batch File"):

                    if (!remoteHostTxtBox.Items.Contains(remoteHostTxtBox.Text))
                    {
                        remoteHostTxtBox.Items.Add(remoteHostTxtBox.Text);
                        usableURLList.Add(remoteHostTxtBox.Text);
                    }

                    string common = dinfo.ToString() + remoteHostTxtBox.Text + "-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm");
                    resultPath = common + "-results.raw";
                    batPath = common + ".bat";

                    batTxt =
                        "@ECHO OFF" + Environment.NewLine +
                        "SET IPADDRESS=" + remoteHostTxtBox.Text + Environment.NewLine +
                        "SET PACKETSPERPING=" + int.Parse(packetsPerPingNumeric.Text) + Environment.NewLine +
                        @"ECHO Date:%Date% Time:%Time% >>" + resultPath + Environment.NewLine +
                        @"C:\windows\system32\ping %IPADDRESS% -n %PACKETSPERPING% >>" + resultPath; 

                        using (StreamWriter writer = new System.IO.StreamWriter(batPath))
                            try
                            {
                                writer.WriteLine("REM " + batconfigStr);
                                writer.Write(batTxt);

                                step2.ForeColor = Color.Green;
                                step3.ForeColor = Color.Blue;
                                setValuesButton.Text = "Start Ping Task";

                                if (autoExecutePingTasksToolStripMenuItem.Checked) 
                                    setValuesButton.PerformClick();
                                
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Error: Unable to create batch file.");

                                step2.ForeColor = step3.ForeColor = Color.Black;
                                setValuesButton.Text = "Generate Batch File";
                            }
                        

                        backButton.Visible = true;

                    break;

                case ("Start Ping Task"):

                    try
                    { 
                        Random rnd = new Random();

                        String args = @"/CREATE /SC minute /MO " + pingIntervalNumeric.Text + " /TN PingTask" + rnd.Next(101) + "_" + 
                            remoteHostTxtBox.Text + " /SD " + startDatePicker.Value.ToString("MM/dd/yyyy")  + " /ED " + endDatePicker.Value.ToString("MM/dd/yyyy") + " /TR " + batPath;     

                        Console.WriteLine(args);

                        Process newBat = Process.Start("schtasks", args);

                        resetScriptProcess();
                        lockScriptSettings(false);

                            if (autoCleToolStripMenuItem.Checked)
                            {   clearScriptSettings();  }

                        break;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error: Unable to create start batch file.");

                        step3.ForeColor = Color.Black;
                        setValuesButton.Text = ("Start Batch File");

                        break;
                    }

            }
        } 
        
        private void loadExistingFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = dinfo.ToString();
            openFileDialog1.Filter = "batch files (*.bat)|*.bat";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;

                using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader rdr = new StreamReader(fileStream))
                    {
                        try
                        {
                            string line = rdr.ReadLine();

                            if (!line.Contains("REM"))
                            {
                                //       listBox1.Items.Add("Error: Unable to extract script parameters.");
                                //       setValuesButton.Text = "Validate Script Settings";
                                return;
                            }

                            string[] parameters = line.Split(' ');
                            string[] form2args = new string[] { parameters[2], parameters[4], parameters[6], parameters[8] };

                            pingIntervalNumeric.Value = int.Parse(form2args[2]);
                            packetsPerPingNumeric.Value = int.Parse(form2args[1]);
                            remoteHostTxtBox.Text = form2args[0];
                            endDatePicker.Value = DateTime.Parse(form2args[3]);

                            resetScriptProcess();
                            lockScriptSettings(false);

                        }
                        catch (Exception)
                        {
                            //                         listBox1.Items.Add("Error: Unable to open the script file.");
                            //                         setValuesButton.Text = "Validate Script Settings";
                        }

                }

            }
        }

        private bool validateURL()
        {
            bool ispingable = true;

            if (string.IsNullOrWhiteSpace(remoteHostTxtBox.Text) || !Connect(remoteHostTxtBox.Text, 80) )
            {
                remoteHostTxtBox.BackColor = Color.FromArgb(255, 192, 192);
                ispingable = false;
            }
            else { remoteHostTxtBox.BackColor = Color.White; }

            return ispingable;
        
        }
        
        private void lockScriptSettings(bool locked)
        {
            if (locked)
            {
                pingIntervalNumeric.Enabled = false;
                packetsPerPingNumeric.Enabled = false;
                remoteHostTxtBox.Enabled = false;
                startDatePicker.Enabled = false;    
                endDatePicker.Enabled = false;
            }
            else
            {
                pingIntervalNumeric.Enabled = true;
                packetsPerPingNumeric.Enabled = true;
                remoteHostTxtBox.Enabled = true;
                startDatePicker.Enabled = true;    
                endDatePicker.Enabled = true;
            }   
        }

        private void clearScriptSettings() 
        {
            packetsPerPingNumeric.Value = 1;
            pingIntervalNumeric.Value = 1;
            endDatePicker.MinDate = DateTime.Now.AddDays(1);
            remoteHostTxtBox.Text = "";

        }

        private void resetScriptProcess()
        {
            step1.ForeColor = step2.ForeColor = step3.ForeColor = Color.Black;
            lockScriptSettings(false);
            setValuesButton.Text = "Validate Script Settings";
        }

        public static Boolean Connect(string host, int port)
        {

            Ping pingTest = new Ping();
            int timeout = 10;
            string data = "aaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            try
            {
                PingReply pingTestReply = pingTest.Send(host, timeout, buffer);

                if (pingTestReply.Status == IPStatus.Success) return true;    
                else return false;
            }
            catch
            { return false; }

        }
        private void backButton_Click(object sender, EventArgs e)
        {
            resetScriptProcess();

        } 

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void autoExecutePingTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoExecutePingTasksToolStripMenuItem.Checked = !(autoExecutePingTasksToolStripMenuItem.Checked);
        }

        private void autoCleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            autoCleToolStripMenuItem.Checked = !(autoCleToolStripMenuItem.Checked);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        private void pingIntervalNumeric_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void scriptActionsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void startDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }
       

    }
}