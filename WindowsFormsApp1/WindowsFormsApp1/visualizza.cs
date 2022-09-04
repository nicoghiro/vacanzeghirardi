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
    public partial class visualizza : Form
    {
        piatto[] menù;
        public visualizza()
        {
            InitializeComponent();
        }

        private void visualizza_Load(object sender, EventArgs e)
        {
            menù=ricerca1(@"./aggiungi.csv");
            int cont4 = 0;
            int x = 300; int ay = 41;
             int py = 148;
            int sy =270;
            int dy = 375;
            int ox = 680;int oy = 115;
            while (cont4 < menù.Length)
            {
                if(menù[cont4].portata == "antipasto" || menù[cont4].portata == "primo"|| menù[cont4].portata == "secondo"|| menù[cont4].portata == "dolce"){
                    if (menù[cont4].portata == "antipasto")
                    {

                        menù[cont4].testo = new Label();
                        this.Controls.Add(menù[cont4].testo);
                        menù[cont4].testo.Location = new Point(x, ay);
                        menù[cont4].testo.Size = new Size(400, 15);
                        menù[cont4].testo.Name = Convert.ToString(cont4);
                        ay = ay + 15;
                        menù[cont4].testo.Text = menù[cont4].id + " " + menù[cont4].nome + " " + menù[cont4].ingredienti + " " + menù[cont4].prezzo + " €";


                    }
                    if (menù[cont4].portata == "primo")
                    {

                        menù[cont4].testo = new Label();
                        this.Controls.Add(menù[cont4].testo);
                        menù[cont4].testo.Location = new Point(x, py);
                        menù[cont4].testo.Size = new Size(400, 15);
                        menù[cont4].testo.Name = Convert.ToString(cont4);
                        py = py + 15;
                        menù[cont4].testo.Text = menù[cont4].id + " " + menù[cont4].nome + " " + menù[cont4].ingredienti + " " + menù[cont4].prezzo + " €";


                    }
                    if (menù[cont4].portata == "secondo")
                    {

                        menù[cont4].testo = new Label();
                        this.Controls.Add(menù[cont4].testo);
                        menù[cont4].testo.Location = new Point(x, sy);
                        menù[cont4].testo.Size = new Size(400, 15);
                        menù[cont4].testo.Name = Convert.ToString(cont4);
                        sy = sy + 15;
                        menù[cont4].testo.Text = menù[cont4].id + " " + menù[cont4].nome + " " + menù[cont4].ingredienti + " " + menù[cont4].prezzo + " €";


                    }
                    if (menù[cont4].portata == "dolce")
                    {

                        menù[cont4].testo = new Label();
                        this.Controls.Add(menù[cont4].testo);
                        menù[cont4].testo.Location = new Point(x, dy);
                        menù[cont4].testo.Size = new Size(400, 15);
                        menù[cont4].testo.Name = Convert.ToString(cont4);
                        dy = dy + 15;
                        menù[cont4].testo.Text = menù[cont4].id + " " + menù[cont4].nome + " " + menù[cont4].ingredienti + " " + menù[cont4].prezzo + " €";


                    }
                }
                else
                {
                    menù[cont4].testo = new Label();
                    this.Controls.Add(menù[cont4].testo);
                    menù[cont4].testo.Location = new Point(ox, oy);
                    menù[cont4].testo.Size = new Size(400, 15);
                    menù[cont4].testo.Name = Convert.ToString(cont4);
                    oy = oy + 15;
                    menù[cont4].testo.Text = menù[cont4].id + " " + menù[cont4].nome + " " + menù[cont4].ingredienti + " " + menù[cont4].prezzo + " €";
                }


              
                cont4++;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            home_propri Form1 = new home_propri();
            Form1.ShowDialog();
            this.Close();
        }
        public int ricercacl(string id, string filename, char sep = ';')
        {
            int cont = 0;
            StreamReader sr = new StreamReader(@"./cancellati.csv");
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
        public piatto[] ricerca1( string filename, char sep = ';')
        {
            int cont = 0;
            int cont1 = 0;
            StreamReader sr = new StreamReader(@"./aggiungi.csv");
            string line = "";
            
            int verifica;
            line = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();

                string[] voti = line.Split(sep); 
                 verifica = ricercacl(voti[0], @"./cancellati.csv");
                if (verifica == 0)
                {
                    cont1++;
                }
            }
            piatto[] piatti = new piatto[cont1];
            sr.Close();
            StreamReader sp = new StreamReader(@"./aggiungi.csv");
            int cont2 = 0;
            line = sp.ReadLine();
            while (!sp.EndOfStream)
            {
                line = sp.ReadLine();
               

                string[] voti = line.Split(sep);
                verifica = ricercacl(voti[0], @"./cancellati.csv");
                if (verifica == 0)
                {
                    piatti[cont2].id = voti[0];
                    piatti[cont2].nome = voti[1];
                    piatti[cont2].portata = voti[2];
                    piatti[cont2].ingredienti = voti[3];
                    piatti[cont2].prezzo = decimal.Parse(voti[4]);
                    cont2++;
                }
            }

            sp.Close();


            return piatti;
        }
      
        public struct piatto
        {

            public string id;
            public string nome;
            public string portata;
            public string ingredienti;
            public decimal prezzo;
            public string carattere;
            public Label testo;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
