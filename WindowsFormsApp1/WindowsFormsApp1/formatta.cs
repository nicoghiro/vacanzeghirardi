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
    public partial class formatta : Form
    {
        public formatta()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            home_propri Form1 = new home_propri();
            Form1.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter sp = new StreamWriter(@"./temp.csv");
            sp.Close();
            
            System.IO.File.Delete(@"./aggiungi.csv");
            System.IO.File.Move(@"./temp.csv", @"./aggiungi.csv");
            StreamWriter sT = new StreamWriter(@"./temp.csv");
            sT.Close();

            System.IO.File.Delete(@"./cancellati.csv");
            System.IO.File.Move(@"./temp.csv", @"./cancellati.csv");
        }
    }
}
