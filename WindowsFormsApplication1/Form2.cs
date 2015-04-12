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

        string processargs;

        public Form2()
        {   InitializeComponent();  }

        private void Form2_Load(object sender, EventArgs e)
        {
            startDatePicker.MinDate = DateTime.Now;
            endDatePicker.MinDate = DateTime.Now.AddDays(1);
            remoteHostTxtBox.Items.Add("www.utexas.edu");
            remoteHostTxtBox.Items.Add("www.nus.edu");
            remoteHostTxtBox.Items.Add("www.ox.ac.uk");
        }

        private void setValuesButton_Click(object sender, EventArgs e)
        {
            switch (setValuesButton.Text)
            {
                case ("Validate Parameters"):

                    if (validateURL())
                    {
                        setValuesButton.Text = "Generate Task Files";
                        backButton.Visible = true;
                        lockScriptSettings(true);

                    }
                    else
                    {
                        MessageBox.Show("The remote host did not respond.");

                        setValuesButton.Text = "Validate Parameters";
                        remoteHostTxtBox.BackColor = Color.White;
                        backButton.Visible = false;
                        lockScriptSettings(false);
                    }

                    break;

                case ("Generate Task Files"):

                    int jobnum = (new Random()).Next(101); 

                    string common = ((new DirectoryInfo(@"C:\")).ToString() + remoteHostTxtBox.Text + "-" + DateTime.Now.ToString("dd-MM-yyyy_HH-mm"));
                    string resultPath = common + "-results.raw";
                    string batPath = common + ".bat";

                    string batxt =
                        "@ECHO OFF" + Environment.NewLine +
                        "SET IPADDRESS=" + remoteHostTxtBox.Text + Environment.NewLine +
                        "SET PACKETSPERPING=" + int.Parse(packetsPerPingNumeric.Text) + Environment.NewLine +
                        @"ECHO Date:%Date% Time:%Time% >>" + resultPath + Environment.NewLine +
                        @"C:\windows\system32\ping %IPADDRESS% -n %PACKETSPERPING% >>" + resultPath;

                    string processparams = 
                         @"-taskname PingTask" + jobnum + " -target " + remoteHostTxtBox.Text + 
                                " -packets " + int.Parse(packetsPerPingNumeric.Text) + " -interval " + pingIntervalNumeric.Text + 
                                " -start " + startDatePicker.Value.ToString("MM/dd/yyyy")  + " -end " + endDatePicker.Value.ToString("MM/dd/yyyy");

                    processargs = 
                        @"/CREATE /SC minute /MO " + pingIntervalNumeric.Text + " /TN PingTask" + jobnum + "_" + 
                        remoteHostTxtBox.Text + " /SD " + startDatePicker.Value.ToString("MM/dd/yyyy") + " /ST 00:00:00"  + " /ED " + 
                                endDatePicker.Value.ToString("MM/dd/yyyy") + " /ET 01:00:00 /TR " + batPath;

                        Console.WriteLine(processargs);

                        lblTaskName.Text = "PingTask" + jobnum;

                        using (StreamWriter batwtr = new System.IO.StreamWriter(batPath))
                        using (StreamWriter resultwtr = new System.IO.StreamWriter(resultPath))
                        {
                            try
                            {
                                batwtr.WriteLine("REM " + processparams);
                                batwtr.Write(batxt);

                                resultwtr.WriteLine("Params: " + processparams + Environment.NewLine);
                                setValuesButton.Text = "Execute Ping Task";

                                if (autoExecutePingTasksToolStripMenuItem.Checked)
                                {   setValuesButton.PerformClick(); }

                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Error: Unable to create batch file.");

                                setValuesButton.Text = "Generate Task Files";
                            }
                        }

                        backButton.Visible = true;

                    break;

                case ("Execute Ping Task"):

                    try
                    { 
                        Process newBat = Process.Start("schtasks", processargs);

                        resetScriptProcess();
                        lockScriptSettings(false);

                        break;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error: Unable to create start batch file.");

                        setValuesButton.Text = ("Generate Task Files");

                        break;
                    }

            }
        } 
        
        private void loadExistingFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = (new DirectoryInfo(@"C:\")).ToString();
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

                            if (!line.Contains("REM")) return;

                            string[] parameters = line.Split(' ');

                            resetScriptProcess();

                            lblTaskName.Text = parameters[2];
                            remoteHostTxtBox.Text = parameters[4];
                            packetsPerPingNumeric.Value = int.Parse(parameters[6]);
                            pingIntervalNumeric.Value = int.Parse(parameters[8]);
                            startDatePicker.Value = DateTime.Parse(parameters[10]);
                            endDatePicker.Value = DateTime.Parse(parameters[12]);

                        }
                        catch (Exception)
                        {}

                }

            }
        }

        private bool validateURL()
        {
            bool ispingable = true;

            if (string.IsNullOrWhiteSpace(remoteHostTxtBox.Text) || !testURL(remoteHostTxtBox.Text, 80) )
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
                lblTaskName.Enabled = false;
            }
            else
            {
                pingIntervalNumeric.Enabled = true;
                packetsPerPingNumeric.Enabled = true;
                remoteHostTxtBox.Enabled = true;
                startDatePicker.Enabled = true;    
                endDatePicker.Enabled = true;
                lblTaskName.Enabled = true;
            }   
        }

        private void resetScriptProcess()
        {
            lockScriptSettings(false);
            lblTaskName.Text = "";
            
            setValuesButton.Text = "Validate Parameters";
        }

        public bool testURL(string host, int port)
        {
            int timeout = 10;
            string data = "aaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);

            try
            {
                PingReply pingTestReply = new Ping().Send(host, timeout, buffer);

                if (pingTestReply.Status == IPStatus.Success) return true;    
                else return false;
            }
            catch
            { return false; }

        }
        private void backButton_Click(object sender, EventArgs e)
        {
            lockScriptSettings(false);
            setValuesButton.Text = "Validate Parameters";
        } 

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {   this.Close();   }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {   Application.Exit(); }
        
        private void autoExecutePingTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {    autoExecutePingTasksToolStripMenuItem.Checked = !(autoExecutePingTasksToolStripMenuItem.Checked);  }

        private void button2_Click(object sender, EventArgs e)
        {   this.Close();   }
 
       

    }
}