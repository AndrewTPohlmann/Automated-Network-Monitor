using System;
using System.Windows.Forms;
using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using WindowsFormsApplication1;
using System.Threading.Tasks;



namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        CurrentJob job;

        public Form4()
        {   InitializeComponent();  }

        private async void Form4_Load(object sender, EventArgs e)
        {
           // MongoDriverHelper.dbs.DropCollectionAsync("sets");
            await updateListBoxAsync();

            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }

        private void backToolStripMenuItem_Click(object sender, EventArgs e)
        {   this.Close();   }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {   Application.Exit(); }

        public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            job = e.Argument as CurrentJob;

            TransformData.processData(job.resultPath, job);

            e.Result = job;
        }


        public async void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            job = e.Result as CurrentJob;

            try
            { 
                await MongoDriverHelper.collection.InsertOneAsync(job); 
                await updateListBoxAsync(); 
            }
            catch (MongoWriteException z)
            {   MessageBox.Show(z.WriteError.Message);  }

        }

        private async Task refreshList_Click(object sender, EventArgs e)
        {   await updateListBoxAsync();  }


        private async Task updateListBoxAsync()
        {
            await MongoDriverHelper.updatelistOfJobs();

            dataGridView1.Rows.Clear();

            string[] tmp, paramss;

                foreach (CurrentJob e in MongoDriverHelper.listofjobs)
                { 
                     tmp = e.paramss.Split(' ');
                     paramss = new string[] {   tmp[2], tmp[4], tmp[6],tmp[8],tmp[10], tmp[12], e.x_rtt.Count.ToString() };

                     dataGridView1.Rows.Add(paramss);
                }
            
        }        

        private async Task loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await MongoDriverHelper.updatelistOfJobs();

            job = MongoDriverHelper.listofjobs[dataGridView1.SelectedCells[0].RowIndex];

            if (job != null)
            {
                Form3 frm3 = new Form3(job);
                frm3.ShowDialog();
            }

        }

        private async void button1_Click(object sender, EventArgs e)
        {   await updateListBoxAsync(); }


        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = (new DirectoryInfo(@"C:\")).ToString();
            openFileDialog1.Filter = "raw data (*.raw)|*.raw";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                job = new CurrentJob(openFileDialog1.FileName);
                backgroundWorker1.RunWorkerAsync(job);
            }
        }



        private async void button3_Click(object sender, EventArgs e)
        {
            await MongoDriverHelper.updatelistOfJobs();

            if (MongoDriverHelper.listofjobs.Count != 0)
            {
                job = MongoDriverHelper.listofjobs[dataGridView1.SelectedCells[0].RowIndex];

                    Form3 frm3 = new Form3(job);
                    frm3.Show();
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {

            await MongoDriverHelper.updatelistOfJobs();

            if (MongoDriverHelper.listofjobs.Count != 0)
            {
                job = MongoDriverHelper.listofjobs[dataGridView1.SelectedCells[0].RowIndex];

                await MongoDriverHelper.collection.DeleteOneAsync<CurrentJob>(x => x.Id == job.Id);
                await updateListBoxAsync(); 
            }

               
        }

        private void button5_Click(object sender, EventArgs e)
        {   this.Close();   }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



    }
}
