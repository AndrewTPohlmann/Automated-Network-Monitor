using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Collections.Generic;



namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int maxscriptforms = 0;
        int maxgraphforms = 0;

        public Form1()
        {   InitializeComponent();  }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            showForm(2);

        }    
        private void dataSetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showForm(3);
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

    private void label1_Click(object sender, EventArgs e)
    {

    }
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
    private void toolStripMenuItem1_Click(object sender, EventArgs e)
    {

    }

    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
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

        private void showForm(int x)
        {
            if (x==2 && maxscriptforms < 3)
            {
                Form2 newForm2 = new Form2();
                newForm2.Show();//Dialog();

                maxscriptforms++;
            }
            else if (x==3 && maxgraphforms < 3)
            {
                Form3 newForm3 = new Form3();
                newForm3.Show();//Dialog();

                maxgraphforms++;
            }
        }

        }
        public class JobState
        {
            public string resultPath { get; set; }
            public string resultFilename { get; set; }

            public JobState() { }

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
        private static string re2_dateTime = "((?:[0]?[1-9]|[1][012])[-:\\/.](?:(?:[0-2]?\\d{1})|(?:[3][01]{1}))[-:\\/.](?:(?:[1]{1}\\d{1}\\d{1}\\d{1})|(?:[2]{1}\\d{3})))(?![\\d])";	// MMDDYYYY 1
        private static string re3_dateTime = ".*?";	// Non-greedy match on filler
        private static string re4_dateTime = "((?:(?:[0-1][0-9])|(?:[2][0-3])|(?:[0-9])):(?:[0-5][0-9])(?::[0-5][0-9])?(?:\\s?(?:am|AM|pm|PM))?)";	// HourMinuteSec 1

        private static string re1_rtt = ".*?";	// Non-greedy match on filler
        private static string re2_rtt = "(Average)";	// Word 1
        private static string re3_rtt = "(\\s+)";	// White Space 1
        private static string re4_rtt = "(=)";	// Any Single Character 1
        private static string re5_rtt = "(\\s+)";	// White Space 2
        private static string re6_rtt = "(\\d+)";	// Integer Number 1

        private static string regexStringDateTime = re1_dateTime + re2_dateTime + re3_dateTime + re4_dateTime;
        private static string regexStringRTT = re1_rtt + re2_rtt + re3_rtt + re4_rtt + re5_rtt + re6_rtt;

        public static Regex dateTimeObject = new Regex(regexStringDateTime, RegexOptions.IgnoreCase | RegexOptions.Singleline);
        public static Regex rttDelayObject = new Regex(regexStringRTT, RegexOptions.IgnoreCase | RegexOptions.Singleline);

    }

}

    

