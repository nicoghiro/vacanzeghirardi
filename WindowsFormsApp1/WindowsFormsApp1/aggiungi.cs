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
    public partial class aggiungi : Form
    {
        public aggiungi()
        {
            InitializeComponent();
        }

        private void aggiungi_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            home_propri Form1 = new home_propri();
            Form1.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool verifica = ricerca(textBox1.Text, @"./aggiungi.csv", @"./cancellati.csv");
            if (verifica == true)
            {
                scriviAppend(@"./aggiungi.csv", textBox1.Text + ";" + textBox2.Text + ";" + textBox3.Text + ";" + textBox4.Text+";"+numericUpDown1.Value);
            }
            else
            {
                throw new Exception("id gia presente");
            }
        }
        public static void scriviAppend(string filename, string content)
        {
            var oStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            sw.WriteLine(content);
            sw.Close();
        }
        public bool ricerca(string id, string filename, string filename2, char sep = ';')
        {
            bool pippo = true;
            StreamReader sr = new StreamReader(filename);
            string line = "";
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (line.Contains(id))
                {

                    pippo = false;
                    return pippo;
                }
            }
            StreamReader sp = new StreamReader(filename2);
           
            while (!sp.EndOfStream)
            {
                line = sp.ReadLine();
                if (line.Contains(id))
                {
                    pippo = false;
                    return pippo;
                }
            }
            sr.Close();
            sp.Close();
            return pippo;
        }
        
        public struct piatto
        {
           
            public string id;
            public string nome;
            public string portata;
            public string ingredienti;
            public decimal prezzo;
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
