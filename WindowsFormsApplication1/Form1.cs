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
     //   List<String> usableURLList = new List<string>();
        List<DateTime> y_time = new List<DateTime>();
        List<int> x_rtt = new List<int>();
        DirectoryInfo dinfo = new DirectoryInfo(@"D:\");
        FileInfo[] Files;

        public Form1()
        {   InitializeComponent();  }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

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
           
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {
            /*
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
             */
        }

        private void button5_Click(object sender, EventArgs e)
        {   
            if (dataSetsRadioBtn.Checked || scriptsRadioBtn.Checked)
                refreshListBox3(scriptsRadioBtn.Checked, (string)listBox3.SelectedItem);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {   listBox3.Items.Clear();  }

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
                Match dateTime, rtt;
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
                    }

                return true;
            }
            catch (Exception)
            {   return false;   }

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

        }
        else
            Console.Write("Error: " + job.resultFilename + " could not be loaded into graph.");
    }
        
    public void refreshListBox3(bool type, string itempath)
    {   //true == script, false == bat

        if (type)
            Files = dinfo.GetFiles("*.bat");
        else
            Files = dinfo.GetFiles("*.txt");

            listBox3.Items.Clear();
            foreach (FileInfo file in Files)
            {   listBox3.Items.Add(dinfo.ToString() + file.Name); }
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {

    }

    private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
    {

        Form2 newForm2 = new Form2();
        newForm2.ShowDialog();

    }
    

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Form2 newForm2 = new Form2();
        newForm2.ShowDialog();
    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {

    }

    private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
    {

    }

    private void setSaveDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void scriptsToolStripMenuItem_Click(object sender, EventArgs e)
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

    

