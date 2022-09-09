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
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("è obbligatorio inserire tutti i parametri del piatto ");
            }
            else { 
                if(textBox1.Text.Contains(';')|| textBox2.Text.Contains(';')|| comboBox1.Text.Contains(';')|| textBox4.Text.Contains(';') || textBox3.Text.Contains(';') || textBox5.Text.Contains(';') || textBox6.Text.Contains(';'))
                {
                    MessageBox.Show("si richiede di non inserire il carattere ';'");
                }
                else { 
            bool verifica = ricerca(textBox1.Text, @"./aggiungi.csv", @"./cancellati.csv");
            if (verifica == true)
            {
                scriviAppend(@"./aggiungi.csv", textBox1.Text + ";" + textBox2.Text + ";" + comboBox1.Text + ";" + textBox4.Text+";"+textBox3.Text + ";" + textBox5.Text + ";" + textBox6.Text + ";" + numericUpDown1.Value);
                    MessageBox.Show("piatto aggiunto");
                    this.Hide();
                    aggiungi Form1 = new aggiungi();
                    Form1.ShowDialog();
                    this.Close();

                }
                else
            {
                MessageBox.Show("id gia presente");
                    
                }
            }
        }}
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
                    string[] voto = line.Split(sep);
                    if (id == voto[0])
                    {
                        pippo = false;
                        sr.Close();
                       
                        return pippo;
                    }

                    
                }
            }
            StreamReader sp = new StreamReader(filename2);
           
            while (!sp.EndOfStream)
            {
                line = sp.ReadLine();
                if (line.Contains(id))
                {
                    string[] voto = line.Split(sep);
                    if (id == voto[0])
                    {
                        pippo = false;
                        sr.Close();
                        sp.Close();
                        return pippo;
                    }


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
            public string ingredienti1;
                public string ingredienti2;
            public string ingredienti3;
            public string ingredienti4;
            public decimal prezzo;
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
