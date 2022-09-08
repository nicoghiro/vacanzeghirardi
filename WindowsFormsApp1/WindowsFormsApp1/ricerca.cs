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
    public partial class ricerca : Form
    {
        public ricerca()
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
            }sr.Close();
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
                    if (id == voto[0]) { 
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
            piatto trovato = ricerca1(textBox1.Text, @"./aggiungi.csv");
            if(trovato.id!= "987654321001126319")
            {
                label3.Text = trovato.id;
                label4.Text = trovato.nome;
                label5.Text = trovato.portata;
                label6.Text = trovato.ingredienti;
                label7.Text = Convert.ToString(trovato.prezzo+"€");
            }
            else
            {
                MessageBox.Show("id piatto non trovato");
            }
        }
    }
}
