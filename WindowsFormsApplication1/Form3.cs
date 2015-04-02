using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {

        List<DateTime> y_time = new List<DateTime>();
        List<int> x_rtt = new List<int>();
        DirectoryInfo dinfo = new DirectoryInfo(@"D:\");

        BackgroundWorker uibackgroundworker;

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(BackgroundWorker x)
        {
            InitializeComponent();
            uibackgroundworker = x;
        }

        public void Form3_Load(object sender, EventArgs e )
        {
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }

        private void loadDataSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = dinfo.ToString();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string file = openFileDialog1.FileName;

                    x_rtt.Clear();
                    y_time.Clear();

                    Title chart1Title = new Title("Loading....", Docking.Top, new Font("Verdana", 12), Color.Black);
                    chart1.Titles.Clear();
                    chart1.Titles.Add(chart1Title);
                    chart1.Series["Series1"].Points.Clear();

                    Console.Write("\nMade it here");

                    JobState job = new JobState(file);
                    backgroundWorker1.RunWorkerAsync(job);

                }
         }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            JobState job = e.Argument as JobState;

            if (processData(job.resultPath))
                job.didLoad = true;
            else
                job.didLoad = false;

            /*
            int z = 0;

                    Title chart1Title = new Title(job.resultPath, Docking.Top, new Font("Verdana", 12), Color.Black);
                    this.chart1.Titles.Clear();
                    this.chart1.Titles.Add(chart1Title);

                    while (z < x_rtt.Count)
                    {
                        this.chart1.Series["Series1"].Points.AddXY(y_time[z], x_rtt[z]);
                        z++;
                    }

            */
            e.Result = job;
        }

        public void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            JobState job = e.Result as JobState;

            Console.Write("WRAAA");


                int z = 0;

                Title chart1Title = new Title(job.resultPath, Docking.Top, new Font("Verdana", 12), Color.Black);
               this.chart1.Titles.Clear();
                this.chart1.Titles.Add(chart1Title);

                while (z < x_rtt.Count)
                {
                    this.chart1.Series["Series1"].Points.AddXY(y_time[z], x_rtt[z]);
                    z++;
                }

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

                        if (string.IsNullOrWhiteSpace(line) || line.Contains("Pi") ||
                            (line.Contains("Re")) || line.Contains("Pa") || line.Contains("Ap"))
                            continue;

                        //      Console.Write(line + "\n");

                        dateTime = RegexObjects.dateTimeObject.Match(line);
                        rtt = RegexObjects.rttDelayObject.Match(line);

                        //        Console.Write("\n" + dateTime.ToString() + " " + rtt.ToString());

                        if (dateTime.Success)
                        { y_time.Add(Convert.ToDateTime(dateTime.Groups[1].ToString())); }
                        else if (rtt.Success)
                        { x_rtt.Add(int.Parse(rtt.Groups[5].ToString())); }

                        Console.Write("\n" + dateTime.Groups[1].ToString() + " " + rtt.Groups[5].ToString());
                    }
                }

                return true;
            }
            catch (Exception)
            { return false; }

        }

    
    }
}
