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
    public partial class Form1 : Form
    {
        List<String> usableURLList = new List<string>();
        List<DateTime> y_time = new List<DateTime>();
        List<int> x_rtt = new List<int>();
        DirectoryInfo dinfo = new DirectoryInfo(@"C:\");
        FileInfo[] Files;

        string resultPath;
        string batPath;
        string batTxt;
        string batconfigStr;

        public Form1()
        {
            InitializeComponent();
        }


        private void setValuesButton_Click(object sender, EventArgs e)
        {

            switch (setValuesButton.Text)
            {
                   
                case ("Validate Script Settings"):

                    if (validateScriptSettings())
                    {
                        batconfigStr = "-U: " + remoteHostTxtBox.Text + " -P: " + packetsPerPingTxtBox.Text + " -I: " + pingIntervalTxtBox.Text + " -D: " + sampleDurationTxtBox.Text;

                        listBox1.Items.Add("Current script settings validated.");
                        setValuesButton.Text = "Generate Batch File";

                        modifyScriptTxtBoxes(false);

                    }
                    else
                    {
                        MessageBox.Show("Errors exist in the configuration.");
                        setValuesButton.Text = "Validate Script Settings";

                        modifyScriptTxtBoxes(true);
                    }

                    break;

                case ("Generate Batch File"):

                    if (!remoteHostTxtBox.Items.Contains(remoteHostTxtBox.Text))
                    {
                        remoteHostTxtBox.Items.Add(remoteHostTxtBox.Text);
                        usableURLList.Add(remoteHostTxtBox.Text);
                    }

                    string common = "C:\\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "-" + remoteHostTxtBox.Text;
                    resultPath = common + "-results.txt";
                    batPath = common + ".bat";

                    batTxt =
                        "@ECHO OFF" + Environment.NewLine +
                        "SET IPADDRESS=" + remoteHostTxtBox.Text + Environment.NewLine + 
                        "SET INTERVAL=" + int.Parse(pingIntervalTxtBox.Text) + Environment.NewLine +
                        "SET PACKETSPERPING=" + int.Parse(packetsPerPingTxtBox.Text) + Environment.NewLine +
                        ":PINGINTERVAL" + Environment.NewLine +
                        @"ECHO Date:%Date% Time:%Time% >>" + resultPath + Environment.NewLine +
                        @"C:\windows\system32\ping %IPADDRESS% -n %PACKETSPERPING% >>" + resultPath + Environment.NewLine +
                        "timeout %INTERVAL%" + Environment.NewLine +
                        "GOTO PINGINTERVAL";

                            try
                            {
                                System.IO.StreamWriter writer = new System.IO.StreamWriter(batPath);
                                writer.WriteLine("REM "+batconfigStr);
                                writer.Write(batTxt);
                                writer.Close();

                                listBox1.Items.Add("---] Success: Batch file created.");
                                setValuesButton.Text = "Start Batch File";

                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Error: Unable to create batch file.");
                                listBox1.Items.Add("---] Error: Unable to create batch file.");
                                setValuesButton.Text = "Generate Batch File";
                            }

                    break;

                case ("Start Batch File"):

                    try
                    {
                        Process newBat = Process.Start(batPath);

                        listBox1.Items.Add("---] Success: Ping test started.");
                        setValuesButton.Text = ("Validate Script Settings");
                        modifyScriptTxtBoxes(true);

                        break;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error: Unable to create start batch file.");
                        listBox1.Items.Add("---] Error: Unable to start batch file.");
                        setValuesButton.Text = ("Start Batch File");

                        break;
                    }

            }
        }

        private void clearAndDeleteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(sampleDurationTxtBox.Text) && string.IsNullOrWhiteSpace(packetsPerPingTxtBox.Text) &&
                     string.IsNullOrWhiteSpace(pingIntervalTxtBox.Text) && remoteHostTxtBox.Text.Equals("www."))
                return;

            setValuesButton.Text = "Validate Script Settings";
            listBox1.Items.Add("Current Settings cleared.");
            modifyScriptTxtBoxes(true);

            sampleDurationTxtBox.Text = ""; 
            packetsPerPingTxtBox.Text = "";  
            pingIntervalTxtBox.Text = "";  
            remoteHostTxtBox.Text = "www."; 

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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

            if (pingTestReply.Status == IPStatus.Success)
            {
       //         Console.WriteLine("true");
                return true;
            }
            else
                return false;
            }
            catch
            { return false; }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void remoteHostTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sampleDurationTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pingIntervalTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void packetsPerPingTxtBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void remoteHostTxtBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = (string)listBox3.SelectedItem;

            if (!string.IsNullOrWhiteSpace(path))
            {
                x_rtt.Clear();
                y_time.Clear();

                if (loadDataSetBtn.Text.Equals("Load to Graph"))
                {
                    Title chart1Title = new Title("Loading....", Docking.Top, new Font("Verdana", 12), Color.Black);
                    chart1.Titles.Clear();
                    chart1.Titles.Add(chart1Title);
                    chart1.Series["Series1"].Points.Clear();

                    JobState job = new JobState(path);
                    backgroundWorker1.RunWorkerAsync(job);
                }
                else if (loadDataSetBtn.Text.Equals("Load to Settings"))
                {
                    try
                    {
                        System.IO.StreamReader reader = new System.IO.StreamReader(path);
                        string line = reader.ReadLine();
                        reader.Close();

                        if (!line.Contains("REM"))
                        {
                            listBox1.Items.Add("Error: Unable to extract script parameters.");
                            setValuesButton.Text = "Validate Script Settings";
                            return;
                        }

                        string[] parameters = line.Split(' ');
                        remoteHostTxtBox.Text = parameters[2];
                        packetsPerPingTxtBox.Text = parameters[4];
                        pingIntervalTxtBox.Text = parameters[6];
                        sampleDurationTxtBox.Text = parameters[8];

                            listBox1.Items.Add("Success: Parameters from script file " + path + " extracted.");
                            setValuesButton.Text = "Validate Script Settings";

                    }
                    catch (Exception)
                    {
                            listBox1.Items.Add("Error: Unable to open the script file.");
                            setValuesButton.Text = "Validate Script Settings";
                    }

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {   
            if (dataSetsRadioBtn.Checked || scriptsRadioBtn.Checked)
                refreshListBox3(scriptsRadioBtn.Checked, (string)listBox3.SelectedItem);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
        }

        private bool validateScriptSettings()
        {
            int i;
            bool sentinel = true; 

            if (!(int.TryParse(pingIntervalTxtBox.Text, out i)) || (string.IsNullOrWhiteSpace(pingIntervalTxtBox.Text)) || i <= 0)
            {
                pingIntervalTxtBox.BackColor = Color.FromArgb(255, 192, 192);
                listBox1.Items.Add("---] Error: Invalid ping interval value.");
                sentinel = false;
            }
            else { pingIntervalTxtBox.BackColor = Color.FromArgb(128, 255, 128); }
            if (!(int.TryParse(packetsPerPingTxtBox.Text, out i)) || (string.IsNullOrWhiteSpace(packetsPerPingTxtBox.Text)) || i <= 0)
            {
                packetsPerPingTxtBox.BackColor = Color.FromArgb(255, 192, 192);
                listBox1.Items.Add("---] Error: Invalid packets per ping value.");
                sentinel = false;
            }
            else { packetsPerPingTxtBox.BackColor = Color.FromArgb(128, 255, 128); }
            if (!(int.TryParse(sampleDurationTxtBox.Text, out i)) || (string.IsNullOrWhiteSpace(sampleDurationTxtBox.Text)) || i <= 0)
            {
                sampleDurationTxtBox.BackColor = Color.FromArgb(255, 192, 192);
                listBox1.Items.Add("---] Error: Invalid packets per ping value.");
                sentinel = false;
            }
            else { sampleDurationTxtBox.BackColor = Color.FromArgb(128, 255, 128); }
            if (string.IsNullOrWhiteSpace(remoteHostTxtBox.Text) || !Connect(remoteHostTxtBox.Text, 80) || i <= 0)
            {
                remoteHostTxtBox.BackColor = Color.FromArgb(255, 192, 192);
                listBox1.Items.Add("---] Error: Remote host unresponsive.");
                sentinel = false;
            }
            else { remoteHostTxtBox.BackColor = Color.FromArgb(128, 255, 128); }

            if (sentinel) return true;
            else return false;
        }

        private void modifyScriptTxtBoxes(bool vector)
        { 
            if (!vector)    
            {
                sampleDurationTxtBox.Enabled = false;
                pingIntervalTxtBox.Enabled = false;
                remoteHostTxtBox.Enabled = false;
                packetsPerPingTxtBox.Enabled = false;
            }
            else 
            {
                sampleDurationTxtBox.BackColor = Color.White; sampleDurationTxtBox.Enabled = true;
                pingIntervalTxtBox.BackColor = Color.White; pingIntervalTxtBox.Enabled = true;
                packetsPerPingTxtBox.BackColor = Color.White; packetsPerPingTxtBox.Enabled = true;
                remoteHostTxtBox.BackColor = Color.White; remoteHostTxtBox.Enabled = true;
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace((string)listBox3.SelectedItem))
            {
                System.IO.File.Delete((string)listBox3.SelectedItem);
                refreshListBox3(scriptsRadioBtn.Checked, (string)listBox3.SelectedItem);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            loadDataSetBtn.Text = "Load to Settings";
            refreshListBox3(scriptsRadioBtn.Checked, (string)listBox3.SelectedItem);
        }

        private void dataSetsRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            loadDataSetBtn.Text = "Load to Graph";
            refreshListBox3(scriptsRadioBtn.Checked, (string)listBox3.SelectedItem);
        }


    private bool processData(string path)
    {
            try
            {
                Match dateTime;
                Match rtt;
                string line;

                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader rdr = new StreamReader(fileStream))
                    {
                        while ((line = rdr.ReadLine()) != null)
                        {

                            if (line.Contains("Pi") || (line.Contains("Re")) || line.Contains("Pa") || line.Contains("Ap") || string.IsNullOrWhiteSpace(line))
                                continue;

                            dateTime = RegexObjects.dateTimeObject.Match(line);
                            rtt = RegexObjects.rttDelayObject.Match(line);

                            if (dateTime.Success)
                            { y_time.Add(Convert.ToDateTime(dateTime.Groups[1].ToString())); }
                            else if (rtt.Success)
                            { x_rtt.Add(int.Parse(rtt.Groups[5].ToString())); }
                        }

                        fileStream.Close();
                        rdr.Dispose();
                    }

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        JobState job = e.Argument as JobState;

        if (processData(job.resultPath))
            job.didLoad = true;
        else
            job.didLoad = false;

        e.Result = job;
    }

    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        JobState job = e.Result as JobState;

        if (job.didLoad)
        { 
            int z = 0;

            Title chart1Title = new Title(job.resultPath, Docking.Top, new Font("Verdana", 12), Color.Black);
            chart1.Titles.Clear();
            chart1.Titles.Add(chart1Title);

                while (z < x_rtt.Count)
                {
                    chart1.Series["Series1"].Points.AddXY(y_time[z], x_rtt[z]);
                    z++;
                }

                listBox1.Items.Add("Success: " + job.resultFilename + " loaded into graph.");
        }
        else
            listBox1.Items.Add("Error: " + job.resultFilename + " could not be loaded into graph.");
    }
        
    public void refreshListBox3(bool type, string itempath)
    {   //true == script, false == bat

        if (type)
            Files = dinfo.GetFiles("*.bat");
        else
            Files = dinfo.GetFiles("*.txt");

            listBox3.Items.Clear();
            foreach (FileInfo file in Files)
            {   listBox3.Items.Add("C:\\" + file.Name); }
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }


    }

    class JobState
    {
        public bool didLoad { get; set; }
        public string resultPath { get; set; }
        public string resultFilename { get; set; }

        public JobState() {}
        
        public JobState(string setpath)
        {
            resultPath = setpath;

            string[] tmpResultFileName = resultPath.Split('\\');
            resultFilename = tmpResultFileName[1];
        }
    }

    public static class RegexObjects
    {
        private static string re1_dateTime = ".*?";	// Non-greedy match on filler
        private static string re2_dateTime = "((?:(?:[0-1][0-9])|(?:[2][0-3])|(?:[0-9])):(?:[0-5][0-9])(?::[0-5][0-9])?(?:\\s?(?:am|AM|pm|PM))?)";	// HourMinuteSec 1

        private static string re1_rtt = ".*?";	// Non-greedy match on filler
        private static string re2_rtt = "(Average)";	// Word 1
        private static string re3_rtt = "(\\s+)";	// White Space 1
        private static string re4_rtt = "(=)";	// Any Single Character 1
        private static string re5_rtt = "(\\s+)";	// White Space 2
        private static string re6_rtt = "(\\d+)";	// Integer Number 1

        private static string regexStringDateTime = re1_dateTime + re2_dateTime;
        private static string regexStringRTT = re1_rtt + re2_rtt + re3_rtt + re4_rtt + re5_rtt + re6_rtt;

        public static Regex dateTimeObject = new Regex(regexStringDateTime, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        public static Regex rttDelayObject = new Regex(regexStringRTT, RegexOptions.IgnoreCase | RegexOptions.Singleline);

    }
}

    

