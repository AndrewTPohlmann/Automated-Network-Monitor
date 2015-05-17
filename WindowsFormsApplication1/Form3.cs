using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MongoDB.Bson;
using System.Threading.Tasks;


namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        CurrentJob job;

        public Form3()
        {   InitializeComponent();  }

        public Form3(CurrentJob j)
        {   InitializeComponent(); job = j;  }

        public void Form3_Load(object sender, EventArgs e)
        {
            
            backgroundWorker1.DoWork +=backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted +=backgroundWorker1_RunWorkerCompleted;

            clearGraph();
            loadGraph();

        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {   this.Close();   }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {   Application.Exit(); }

        public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
                CurrentJob job = e.Argument as CurrentJob;
                TransformData.processData(job.resultPath, job);
                e.Result = job;

        }

        public void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            CurrentJob job = e.Result as CurrentJob;

            int z = 0;

            while (z < job.x_rtt.Count)
            {
                chart1.Series["Series1"].Points.AddXY(job.y_time[z], job.x_rtt[z]);
                z++;
            }

            chart1.Titles.Clear();
            chart1.Titles.Add(new Title(job.resultPath, Docking.Top, new Font("Verdana", 12), Color.Black));
            this.Text = this.Text + " ---[ " + job.resultPath + " ]";
             
        }

        private void clearGraph()
        {       
            chart1.Titles.Clear();
            chart1.Series["Series1"].Points.Clear();
            this.Text = "Data Set Visualizer";
             
        }

        private void loadGraph()
        {
            chart1.Titles.Add(new Title("Loading...", Docking.Top, new Font("Verdana", 12), Color.Black));
            backgroundWorker1.RunWorkerAsync(job);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

    }
}
