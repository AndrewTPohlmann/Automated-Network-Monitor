using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.Threading;

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
        string str;
        bool isValid;
        bool isGenerated;

        DateTime tstamp;
        Int16 orderNum;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void setValuesButton_Click(object sender, EventArgs e)
        {
            int i;
            isValid = true;
            isGenerated = false;

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
                    resultFilename = "c:\\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "-results.txt";
                    batPath = @"C:\" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "-" + split[1] + ".bat";

                    Console.WriteLine(split[1]);

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
                        Process newBat = Process.Start(batPath);

                        string batPID = "PID:" + newBat.Id + ":->" + batPath;

                        listBox2.Items.Add(batPID);
                        listBox1.Items.Add("---] Success: Batch File Process (" + newBat.Id + ") started.");

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
            string processID = (string) listBox2.SelectedItem;

            if (!string.IsNullOrWhiteSpace(processID))
            {
                string[] splita = processID.Split(':');
                int pid = Int32.Parse(splita[1]);

                Process proc = Process.GetProcessById(pid);
                proc.Kill();

                listBox1.Items.Add("Success: Batch File Process with PID:" + pid + " terminated.");
                listBox2.Items.Remove(processID);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }

}
