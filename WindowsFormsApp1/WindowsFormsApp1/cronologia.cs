using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class cronologia : Form
    {
        public cronologia()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            home_propri Form1 = new home_propri();
            Form1.ShowDialog();
            this.Close();
        }

        private void cronologia_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader(@"./registroordini.csv");
            string line = "";
            int x = 300; int ay = 41;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                Label piatto = new Label();
                this.Controls.Add(piatto);
                piatto.Location = new Point(x, ay);
                piatto.Size = new Size(400, 20);
                piatto.Text = line;
                ay = ay + 20;
            }
            sr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sy = new StreamWriter(@"./temp.csv");
            sy.Close();

            System.IO.File.Delete(@"./registroordini.csv");
            System.IO.File.Move(@"./temp.csv", @"./registroordini.csv");
            MessageBox.Show("cancellazzione avvenuta");
            this.Hide();
            cronologia Form1 = new cronologia();
            Form1.ShowDialog();
            this.Close();
        }
    }
}
