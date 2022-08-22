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
    public partial class nuovoutente : Form
    {
        public nuovoutente()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter sp = new StreamWriter(@"./temp.csv");
            sp.Close();
            scriviAppend(@"./temp.csv", textBox1.Text);
            scriviAppend(@"./temp.csv", textBox2.Text);
            System.IO.File.Delete(@"./credenziali.csv");
            System.IO.File.Move(@"./temp.csv", @"./credenziali.csv");
            StreamWriter sz = new StreamWriter(@"./temp.csv");
            sz.Close();

            System.IO.File.Delete(@"./aggiungi.csv");
            System.IO.File.Move(@"./temp.csv", @"./aggiungi.csv");
            StreamWriter sT = new StreamWriter(@"./temp.csv");
            sT.Close();

            System.IO.File.Delete(@"./cancellati.csv");
            System.IO.File.Move(@"./temp.csv", @"./cancellati.csv");
            StreamWriter sr = new StreamWriter(@"./aggiungi.csv");
            sr.WriteLine("sdfgjklsdhyuifhkd");
            sr.Close();
            StreamWriter so = new StreamWriter(@"./cancellati.csv");
            so.WriteLine("suidfghsdjklfgsdf");
            so.Close();
            this.Hide();
            acc_propieta Form1 = new acc_propieta();
            Form1.ShowDialog();
            this.Close();
        }
        public static void scriviAppend(string filename, string content)
        {
            var oStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            sw.WriteLine(content);
            sw.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login Form1 = new login();
            Form1.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void nuovoutente_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
