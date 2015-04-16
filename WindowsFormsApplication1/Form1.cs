using System;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using System.Threading.Tasks;
using System.Security.Policy;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {   InitializeComponent();  }
       
        private async void Form1_Load(object sender, EventArgs e)
        {
            await MongoDriverHelper.setupInstance();
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

        private void showForm(int x)
        {
            if (x==2)
            {
                Form2 newForm2 = new Form2();
                newForm2.Show();//Dialog();
            }
            else if (x==3)
            {
                Form3 newForm3 = new Form3();
                newForm3.Show();//Dialog();
            }
        }

        private void mongoDBControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 newForm4 = new Form4();
            newForm4.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 newForm5 = new Form5();
            newForm5.ShowDialog();
        }

        
        }



}

    

