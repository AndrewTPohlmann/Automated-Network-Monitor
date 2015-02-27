using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<String> usableURLList = new List<string>();
        List<Process> runningBats = new List<Process>();
        //List<String> usableConfig = new List<string>();

        string batPath;
        string batTxt;
        string resultFilename;
        Process newBat;
        string batPID;
        string str;
        bool isValid;

        DateTime tstamp;
        Int16 orderNum;

        public Form1()
        {
            InitializeComponent();
        }


        private void setValuesButton_Click(object sender, EventArgs e)
        {
            int i;
            isValid = true;

            switch (setValuesButton.Text.ToString())
            {

                case ("Validate Script Settings"):

                    if (!(int.TryParse(pingIntervalTxtBox.Text, out i)) || (string.IsNullOrWhiteSpace(pingIntervalTxtBox.Text)) || i <= 0)
                    {
                        pingIntervalTxtBox.BackColor = Color.FromArgb(255, 192, 192);
                        isValid = false;
                    }
                    else { pingIntervalTxtBox.BackColor = Color.FromArgb(128, 255, 128); }
                    if (!(int.TryParse(packetsPerPingTxtBox.Text, out i)) || (string.IsNullOrWhiteSpace(packetsPerPingTxtBox.Text)) || i <= 0)
                    {
                        packetsPerPingTxtBox.BackColor = Color.FromArgb(255, 192, 192);
                        isValid = false;
                    }
                    else { packetsPerPingTxtBox.BackColor = Color.FromArgb(128, 255, 128); }
                    if (!(int.TryParse(sampleDurationTxtBox.Text, out i)) || (string.IsNullOrWhiteSpace(sampleDurationTxtBox.Text)) || i <= 0)
                    {
                        sampleDurationTxtBox.BackColor = Color.FromArgb(255, 192, 192);
                        isValid = false;
                    }
                    else { sampleDurationTxtBox.BackColor = Color.FromArgb(128, 255, 128); }
                    if (string.IsNullOrWhiteSpace(remoteHostTxtBox.Text) || !Connect(remoteHostTxtBox.Text, 80) || i <= 0)
                    {
                        remoteHostTxtBox.BackColor = Color.FromArgb(255, 192, 192);
                        isValid = false;
                    }
                    else { remoteHostTxtBox.BackColor = Color.FromArgb(128, 255, 128); }

                    tstamp = DateTime.Now;

                    if (isValid == true)
                    {
                        str = "-U: " + remoteHostTxtBox.Text + " -P:" + packetsPerPingTxtBox.Text + " -I:" + pingIntervalTxtBox.Text + " -D:" + sampleDurationTxtBox.Text;

                        listBox1.Items.Add("Order #" + orderNum + " - " + tstamp.ToString() + ": Script settings validated.");
                        listBox1.Items.Add("---] Config: " + str);
                        setValuesButton.Text = "Generate Batch File";
                    }
                    else
                    {

                        listBox1.Items.Add("Error: " + " Script settings could not be validated.");
                        MessageBox.Show("Errors exist in the configuration.");
                        setValuesButton.Text = "Validate Script Settings";

                        sampleDurationTxtBox.BackColor = Color.White; sampleDurationTxtBox.Enabled = true;
                        pingIntervalTxtBox.BackColor = Color.White; pingIntervalTxtBox.Enabled = true;
                        packetsPerPingTxtBox.BackColor = Color.White; packetsPerPingTxtBox.Enabled = true;
                        remoteHostTxtBox.BackColor = Color.White; remoteHostTxtBox.Enabled = true;
                        isValid = true;
                    }

                    break;

                case ("Generate Batch File"):

                    sampleDurationTxtBox.Enabled = false;
                    pingIntervalTxtBox.Enabled = false;
                    remoteHostTxtBox.Enabled = false;
                    packetsPerPingTxtBox.Enabled = false;

                    str = "-U: " + remoteHostTxtBox.Text + " -P:" + packetsPerPingTxtBox.Text + " -I:" + pingIntervalTxtBox.Text + " -D:" + sampleDurationTxtBox.Text;

                    int ind = remoteHostTxtBox.FindString(str, -1);
                    if (ind == -1)
                    {
                        remoteHostTxtBox.Items.Add(remoteHostTxtBox.Text);
                        usableURLList.Add(remoteHostTxtBox.Text);
                    }

                    string[] split = remoteHostTxtBox.Text.ToString().Split('.');
                    resultFilename = "C:\\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "-results.txt";
                    batPath = "C:\\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "-" + split[1] + ".bat";

                    batTxt =
                        "@ECHO OFF" + Environment.NewLine +
                        "SET IPADDRESS=" + split[1].ToString() + "." + split[2].ToString() + Environment.NewLine +
                        "SET INTERVAL=" + int.Parse(pingIntervalTxtBox.Text) + Environment.NewLine +
                        "SET PACKETSPERPING=" + int.Parse(packetsPerPingTxtBox.Text) + Environment.NewLine +
                        ":PINGINTERVAL" + Environment.NewLine +
                        @"ECHO Date:%Date% Time:%Time% >>" + resultFilename + Environment.NewLine +
                        @"C:\windows\system32\ping %IPADDRESS% -n %PACKETSPERPING% >>" + resultFilename + Environment.NewLine +
                        "timeout %INTERVAL%" + Environment.NewLine +
                        "GOTO PINGINTERVAL";

                    try
                    {
                        System.IO.StreamWriter writer = new System.IO.StreamWriter(batPath);
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
                        newBat = Process.Start(batPath);
         
                        batPID = "PID: " + newBat.Id + " " + batPath;

                        listBox1.Items.Add("---] Success: Batch File Process (" + newBat.Id + ") started.");
                        listBox2.Items.Add(batPID);

                        setValuesButton.Text = ("Validate Script Settings");

                        orderNum++;
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
            tstamp = DateTime.Now;
  
            setValuesButton.Text = "Validate Script Settings";
            listBox1.Items.Add("Current Settings cleared.");
            sampleDurationTxtBox.Text = ""; sampleDurationTxtBox.BackColor = Color.White; sampleDurationTxtBox.Enabled = true;
            packetsPerPingTxtBox.Text = "";  packetsPerPingTxtBox.BackColor = Color.White; packetsPerPingTxtBox.Enabled = true;
            pingIntervalTxtBox.Text = "";  pingIntervalTxtBox.BackColor = Color.White; pingIntervalTxtBox.Enabled = true;
            remoteHostTxtBox.Text = "http://www.";  remoteHostTxtBox.BackColor = Color.White; remoteHostTxtBox.Enabled = true;

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
            WebHeaderCollection headers = null;
            HttpWebResponse response = null;    

            try
            {
               
                HttpWebRequest request = WebRequest.Create(host) as HttpWebRequest;
                request.Method = "HEAD";
                response = request.GetResponse() as HttpWebResponse;
                headers = response.Headers;

                response.Close();
                return true;
                 
            }
            catch (Exception)
            {
                if (response == null)
                    return false;

                response.Close();
                return false;
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void hostPic_Click(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void remoteHostTxtBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void validateSettings()
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string procString = (string) listBox2.SelectedItem;

            if (!string.IsNullOrWhiteSpace(procString))
            {
                string[] splita = procString.Split(' ');
                int pid = Int32.Parse(splita[1]);

                Process proc = Process.GetProcessById(pid);
                proc.Kill();

                listBox1.Items.Add("Success: Batch File Process with PID:" + pid + " terminated.");
                listBox2.Items.Remove(procString);

                listBox3.Items.Add(resultFilename);

     //           Console.WriteLine(splita[0] + " " + splita[1] + " " + splita[2]);
            }

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
            string[] tmpResultFileName;

            if (!string.IsNullOrWhiteSpace(path))
            {
                tmpResultFileName = path.Split('\\');

                string re1_dateTime = ".*?";	// Non-greedy match on filler
                string re2_dateTime = "((?:(?:[0-1][0-9])|(?:[2][0-3])|(?:[0-9])):(?:[0-5][0-9])(?::[0-5][0-9])?(?:\\s?(?:am|AM|pm|PM))?)";	// HourMinuteSec 1
                

                string re1_rtt = ".*?";	// Non-greedy match on filler
                string re2_rtt = "(Average)";	// Word 1
                string re3_rtt = "(\\s+)";	// White Space 1
                string re4_rtt = "(=)";	// Any Single Character 1
                string re5_rtt = "(\\s+)";	// White Space 2
                string re6_rtt = "(\\d+)";	// Integer Number 1
                

                Regex r_dateTime = new Regex(re1_dateTime + re2_dateTime, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                Regex r_rtt = new Regex(re1_rtt + re2_rtt + re3_rtt + re4_rtt + re5_rtt + re6_rtt, RegexOptions.IgnoreCase | RegexOptions.Singleline);

                string line;

                List<int> x_rtt = new List<int>();
                List<DateTime> y_time = new List<DateTime>();

                try
                { 
                    using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (StreamReader rdr = new StreamReader(fileStream))
                        {

                            while ((line = rdr.ReadLine()) != null)
                            {

                                Match dateTime = r_dateTime.Match(line);
                                Match rtt = r_rtt.Match(line);

                                if (dateTime.Success)
                                {
                                    DateTime time1 = Convert.ToDateTime(dateTime.Groups[1].ToString());
                                    y_time.Add(time1);
                         //           Console.Write("(" + time1.ToString() + ")" + "\n");
                                }
                                else if (rtt.Success)
                                {

                                    int rttval = int.Parse(rtt.Groups[5].ToString());
                                    x_rtt.Add(rttval);
                         //           Console.Write("(" + rttval + ")" + "\n");
                                }
                            }
                        }
                  //      Console.Write("x: " + x_rtt.Count);
               //         Console.Write("\ny: " + y_time.Count);

                        chart1.Titles.Clear();   // Unnecessary if you have already clear
                        Title chart1Title = new Title(path, Docking.Top, new Font("Verdana", 12), Color.Black);
                        chart1.Titles.Add(chart1Title);
                        chart1.Series["Series1"].Points.Clear();

                        int z=0;
                        while (z < x_rtt.Count)
                        {
                            chart1.Series["Series1"].Points.AddXY( y_time[z], x_rtt[z]);
                            z++;
                        }
                  }

                    listBox1.Items.Add("Success: "+ tmpResultFileName[1] + " loaded.");
                }
                catch (Exception)
                {
                    listBox1.Items.Add("Error: " + tmpResultFileName[1] + " could not be loaded.");
                }

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DirectoryInfo dinfo = new DirectoryInfo(@"C:\");
            FileInfo[] Files = dinfo.GetFiles("*.txt");

            foreach (FileInfo file in Files) { 

                if (!(listBox3.Items.Contains("C:\\" + file.Name.ToString())))         
                    listBox3.Items.Add("C:\\" + file.Name);  
           }


        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
        }
    }

}
