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
    public partial class eliminazione : Form
    {
        piatto trovato;
        public eliminazione()
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            trovato = ricerca1(textBox1.Text, @"./aggiungi.csv");
            if (trovato.id != "987654321001126319")
            {
                DialogResult dialogResult = MessageBox.Show("sei sicuro di voler eliminare il piatto?", "eliminazione", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    scriviAppend(@"./cancellati.csv", trovato.id + ";" + trovato.nome + ";" + trovato.portata + ";" + trovato.ingredienti + ";" + trovato.prezzo + ";" + "$");
                    MessageBox.Show("piatto cancellato");
                    this.Hide();
                    eliminazione Form1 = new eliminazione();
                    Form1.ShowDialog();
                    this.Close();
                }
                else if(dialogResult == DialogResult.No)
                {

                }
            }
            else
            {
                MessageBox.Show("id piatto non trovato");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                
                
            
        }
        public static void scriviAppend(string filename, string content)
        {
            var oStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            sw.WriteLine(content);
            sw.Close();
        }

        
    }
}
