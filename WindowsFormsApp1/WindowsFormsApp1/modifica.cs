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
    public partial class modifica : Form
    {
        piatto trovato;
        public modifica()
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
        public piatto ricerca1(string id, string filename, char sep = ';')
        {
            int cont = 0;
            StreamReader sr = new StreamReader(filename);
            string line = "";
            piatto ricercato;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                if (line.Contains(id))
                {
                    string[] voti = line.Split(sep);
                    if (id == voti[0])
                    {


                        string[] voto = line.Split(sep);

                        ricercato.id = voto[0];
                        ricercato.nome = voto[1];
                        ricercato.portata = voto[2];
                        ricercato.ingredienti = voto[3];
                        ricercato.prezzo = decimal.Parse(voto[4]);
                        int verifica = ricercacl(ricercato.id, @"./cancellati.csv");
                        if (verifica == 0)
                        {
                            sr.Close();
                            return ricercato;

                        }
                    }
                }
            }
            sr.Close();
            piatto ntrovato;
            ntrovato.id = "987654321001126319";

            ntrovato.nome = "0";
            ntrovato.portata = "0";
            ntrovato.ingredienti = "0";
            ntrovato.prezzo = 20;


            return ntrovato;
        }
        public int ricercacl(string id, string filename, char sep = ';')
        {
            int cont = 0;
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
                        cont++;
                    }
                    
                }
            }
            sr.Close();
            return cont;
        }
        public struct piatto
        {

            public string id;
            public string nome;
            public string portata;
            public string ingredienti;
            public decimal prezzo;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            trovato = ricerca1(textBox1.Text, @"./aggiungi.csv");
            if (trovato.id != "987654321001126319")
            {
                textBox2.Text = trovato.id;
                textBox3.Text = trovato.nome;
                comboBox1.Text = trovato.portata;
                textBox5.Text = trovato.ingredienti;
                numericUpDown1.Value = Convert.ToDecimal(trovato.prezzo);
            }
            else
            {
                MessageBox.Show("id piatto non trovato");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            piatto modifiche;
            modifiche.id = textBox2.Text;
            modifiche.nome = textBox3.Text;
            modifiche.portata = comboBox1.Text;
            modifiche.ingredienti = textBox5.Text;
            modifiche.prezzo = numericUpDown1.Value;
            if (string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox5.Text)  || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("è obbligatorio inserire tutti i parametri del piatto ");
            }
            else
            {

                if (trovato.id == modifiche.id && trovato.nome == modifiche.nome && trovato.portata == modifiche.portata && trovato.ingredienti == modifiche.ingredienti && trovato.prezzo == modifiche.prezzo)
                {

                }
                if(textBox2.Text.Contains(';') || textBox3.Text.Contains(';') || textBox5.Text.Contains(';') || comboBox1.Text.Contains(';'))
                {
                    MessageBox.Show("si richiede di non inserire il carattere ';'");
                }
                else
                {
                    if (trovato.id != modifiche.id)
                    {
                        scriviAppend(@"./cancellati.csv", trovato.id + ";" + trovato.nome + ";" + trovato.portata + ";" + trovato.ingredienti + ";" + trovato.prezzo + ";" + "£");
                        scriviAppend(@"./aggiungi.csv", modifiche.id + ";" + modifiche.nome + ";" + modifiche.portata + ";" + modifiche.ingredienti + ";" + modifiche.prezzo);
                        this.Hide();
                        modifica Form1 = new modifica();
                        Form1.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("è obbligatorio la modifica dell'id");
                    }
                }
            }
        }
        public static void scriviAppend(string filename, string content)
        {
            var oStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            sw.WriteLine(content);
            sw.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            trovato = ricerca1(textBox1.Text, @"./aggiungi.csv");
            if (trovato.id != "987654321001126319")
            {
                textBox2.Text = trovato.id;
                textBox3.Text = trovato.nome;
                comboBox1.Text = trovato.portata;
                textBox5.Text = trovato.ingredienti;
                numericUpDown1.Value = trovato.prezzo;
            }
            else
            {
                MessageBox.Show("id piatto non trovato");
            }

        }
    }
}
