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
        DirectoryInfo dinfo = new DirectoryInfo(@"C:\");

        public Form3()
        {
            InitializeComponent();
        }

        public void Form3_Load(object sender, EventArgs e )
        {
            backgroundWorker1.DoWork +=backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted +=backgroundWorker1_RunWorkerCompleted;
        }

        private void loadDataSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = dinfo.ToString();
            openFileDialog1.Filter = "converted data (*.bin)|*.bin|raw data (*.raw)|*.raw";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    clearGraph();

                    chart1.Titles.Add(new Title("Loading...", Docking.Top, new Font("Verdana", 12), Color.Black));

                    JobState job = new JobState(openFileDialog1.FileName);
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
            processData(job.resultPath);

             e.Result = job;
        }

        public void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            JobState job = e.Result as JobState;

                int z = 0;

                while (z < x_rtt.Count)
                {
                    this.chart1.Series["Series1"].Points.AddXY(y_time[z], x_rtt[z]);
                    z++;
                }

                chart1.Titles.Clear();
                chart1.Titles.Add(new Title(job.resultPath, Docking.Top, new Font("Verdana", 12), Color.Black));
                this.Text = this.Text + " ---[ " + job.resultPath + " ]";
        }

        private bool processData(string path)
        {
            try
            {
                Match dateTime, rtt;
                string line;

                using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    if (Path.GetExtension(path).Equals(".raw"))
                    {
                        sb.Append(Path.GetDirectoryName(path) + @"\").Append(Path.GetFileNameWithoutExtension(path)).Append(".bin");

                        using (StreamWriter wtr = new StreamWriter(sb.ToString()))
                            using (StreamReader rdr = new StreamReader(fileStream))
                            {
                                while ((line = rdr.ReadLine()) != null)
                                {
                                        if (string.IsNullOrWhiteSpace(line) || line.Contains("Pi") ||
                                                line.Contains("Re") || (line.Contains("Pa")) || line.Contains("Ap"))
                                            continue;

                                        dateTime = RegexObjects.dateTimeObject.Match(line);
                                        rtt = RegexObjects.rttDelayObject.Match(line);

                                        sb.Clear();
                                        sb.Append(dateTime.Groups[1]).Append(" ").Append(dateTime.Groups[2]).Append(" ");

                                        if (dateTime.Success)
                                        {
                                            y_time.Add(DateTime.Parse(sb.ToString()));
                                                wtr.Write(sb.ToString());
                                        }
                                        else if (rtt.Success)
                                        { 
                                            x_rtt.Add(int.Parse(rtt.Groups[5].ToString()));
                                                 wtr.Write(rtt.Groups[5] + Environment.NewLine);
                                        }
                                   
                                }
                            }
                    }
                    else if (Path.GetExtension(path).Equals(".bin"))
                    {
                        using (StreamReader rdr = new StreamReader(fileStream))
                            while ((line = rdr.ReadLine()) != null)
                            {
                                string[] items = line.Split(' ');

                                sb.Clear();
                                sb.Append(items[0]).Append(" ").Append(items[1]);

                           //     MessageBox.Show(sb.ToString());

                                y_time.Add(DateTime.Parse(sb.ToString()));
                                x_rtt.Add(int.Parse(items[2]));
                            }
                    }
                }
                    
                return true;
            }
            catch (Exception)
            { return false; }

        }

        private void clearDataSetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clearGraph();
        }

        private void clearGraph()
        {
            x_rtt.Clear();
            y_time.Clear();
            chart1.Titles.Clear();

            chart1.Series["Series1"].Points.Clear();
            this.Text = "Data Set Visualizer";
        }
    }
}
