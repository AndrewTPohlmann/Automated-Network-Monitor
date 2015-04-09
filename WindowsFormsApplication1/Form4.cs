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

         //   MongoDriverHelper.dbs.DropCollectionAsync("sets");
            CreateIndex();

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

       //     MongoDriverHelper.list = MongoDriverHelper.dbs.GetCollection<CurrentJob>("sets");

            try
            { 
                await MongoDriverHelper.list.InsertOneAsync(job); 
                await updateListBoxAsync(); 
            }
            catch (MongoWriteException z)
            {   MessageBox.Show(z.WriteError.Message);  }

        }

        private async void refreshList_Click(object sender, EventArgs e)
        {   await updateListBoxAsync();  }

        private async void CreateIndex()
        {
            CreateIndexOptions indexopts = new CreateIndexOptions();
            indexopts.Unique = true;
            indexopts.Sparse = true;

            await (MongoDriverHelper.dbs.GetCollection<CurrentJob>("sets")).Indexes.CreateOneAsync
                (Builders<CurrentJob>.IndexKeys.Ascending(_ => _.resultPath), indexopts);

        }

        private async Task updateListBoxAsync()
        {
        //    MongoDriverHelper.list = MongoDriverHelper.dbs.GetCollection<CurrentJob>("sets");

            IAsyncCursor<CurrentJob> cursor = await MongoDriverHelper.list.FindAsync<CurrentJob>("{}");

            List<CurrentJob> list1 = await cursor.ToListAsync();

            listBox1.Items.Clear();

            foreach (CurrentJob e in list1)
            {    listBox1.Items.Add(e);  }
            
        }        
        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            job = (CurrentJob)listBox1.SelectedItem;

            toolTip1.SetToolTip(listBox1, job.paramss);
        }        

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentJob nwj = new CurrentJob();

            if ((nwj = (CurrentJob)listBox1.SelectedItem) != null)
            {
                Form3 frm3 = new Form3(nwj);
                frm3.ShowDialog();
            }

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {   }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {   }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {   }

        private async void pictureBox1_Click(object sender, EventArgs e)
        {
            await updateListBoxAsync();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = (new DirectoryInfo(@"C:\")).ToString();
            openFileDialog1.Filter = "raw data (*.raw)|*.raw";
            // openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                job = new CurrentJob(openFileDialog1.FileName);
                backgroundWorker1.RunWorkerAsync(job);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await updateListBoxAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = (new DirectoryInfo(@"C:\")).ToString();
            openFileDialog1.Filter = "raw data (*.raw)|*.raw";
            // openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                job = new CurrentJob(openFileDialog1.FileName);
                backgroundWorker1.RunWorkerAsync(job);
            }
        }




    }
}
