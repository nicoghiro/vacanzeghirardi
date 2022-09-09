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
    public partial class aggiungi_cliente : Form
    {
        piatto[] menù;
        public aggiungi_cliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            cliente Form1 = new cliente();
            Form1.ShowDialog();
            this.Close();
        }

        private void aggiungi_cliente_Load(object sender, EventArgs e)
        {
            menù = ricerca1(@"./aggiungi.csv");
            int cont4 = 0;
            int x = 300; int ay = 41;
            int py = 148;
            int sy = 270;
            int dy = 375;
            int ox = 680; int oy = 115;
            while (cont4 < menù.Length)
            {
                if (menù[cont4].portata == "antipasto" || menù[cont4].portata == "primo" || menù[cont4].portata == "secondo" || menù[cont4].portata == "dolce")
                {
                    if (menù[cont4].portata == "antipasto")
                    {

                        menù[cont4].testo = new Label();
                        this.Controls.Add(menù[cont4].testo);
                        menù[cont4].testo.Location = new Point(x, ay);
                        menù[cont4].testo.Size = new Size(400, 20);
                        menù[cont4].testo.Name = Convert.ToString(cont4);
                        ay = ay + 20;
                        menù[cont4].testo.Text = menù[cont4].id + " " + menù[cont4].nome + " " + menù[cont4].ingredienti1 + " " + menù[cont4].ingredienti2 + " " + menù[cont4].ingredienti3 + " " + menù[cont4].ingredienti4 + " " + menù[cont4].prezzo + " €";
                       menù[cont4].testo.Click += new EventHandler(label_Click);
                        
                    }
                    if (menù[cont4].portata == "primo")
                    {

                        menù[cont4].testo = new Label();
                        this.Controls.Add(menù[cont4].testo);
                        menù[cont4].testo.Location = new Point(x, py);
                        menù[cont4].testo.Size = new Size(400, 20);
                        menù[cont4].testo.Name = Convert.ToString(cont4);
                        py = py + 20;
                        menù[cont4].testo.Text = menù[cont4].id + " " + menù[cont4].nome + " " + menù[cont4].ingredienti1 + " " + menù[cont4].ingredienti2 + " " + menù[cont4].ingredienti3 + " " + menù[cont4].ingredienti4 + " " + menù[cont4].prezzo + " €";
                       menù[cont4].testo.Click += new EventHandler(label_Click);

                    }
                    if (menù[cont4].portata == "secondo")
                    {

                        menù[cont4].testo = new Label();
                        this.Controls.Add(menù[cont4].testo);
                        menù[cont4].testo.Location = new Point(x, sy);
                        menù[cont4].testo.Size = new Size(400, 20);
                        menù[cont4].testo.Name = Convert.ToString(cont4);
                        sy = sy + 20;
                        menù[cont4].testo.Text = menù[cont4].id + " " + menù[cont4].nome + " " + menù[cont4].ingredienti1 + " " + menù[cont4].ingredienti2 + " " + menù[cont4].ingredienti3 + " " + menù[cont4].ingredienti4 + " " + menù[cont4].prezzo + " €";
                      menù[cont4].testo.Click += new EventHandler(label_Click);

                    }
                    if (menù[cont4].portata == "dolce")
                    {

                        menù[cont4].testo = new Label();
                        this.Controls.Add(menù[cont4].testo);
                        menù[cont4].testo.Location = new Point(x, dy);
                        menù[cont4].testo.Size = new Size(400,20);
                        menù[cont4].testo.Name = Convert.ToString(cont4);
                        dy = dy + 20;
                        menù[cont4].testo.Text = menù[cont4].id + " " + menù[cont4].nome + " " + menù[cont4].ingredienti1 + " " + menù[cont4].ingredienti2 + " " + menù[cont4].ingredienti3 + " " + menù[cont4].ingredienti4 + " " + menù[cont4].prezzo + " €";
                        menù[cont4].testo.Click += new EventHandler(label_Click);

                    }
                }
                else
                {
                    menù[cont4].testo = new Label();
                    this.Controls.Add(menù[cont4].testo);
                    menù[cont4].testo.Location = new Point(ox, oy);
                    menù[cont4].testo.Size = new Size(400, 20);
                    menù[cont4].testo.Name = Convert.ToString(cont4);
                    oy = oy + 20;
                    menù[cont4].testo.Text = menù[cont4].id + " " + menù[cont4].nome + " " + menù[cont4].ingredienti1 + " " + menù[cont4].ingredienti2 + " " + menù[cont4].ingredienti3 + " " + menù[cont4].ingredienti4 + " " + menù[cont4].prezzo + " €";
                   menù[cont4].testo.Click += new EventHandler(label_Click);
                }



                cont4++;
            }
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
        public piatto[] ricerca1(string filename, char sep = ';')
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
                    piatti[cont2].ingredienti1 = voti[3];
                    piatti[cont2].ingredienti2 = voti[4];
                    piatti[cont2].ingredienti3 = voti[5];
                    piatti[cont2].ingredienti4 = voti[6];
                    piatti[cont2].prezzo = decimal.Parse(voti[7]);
                    cont2++;
                }
            }

            sp.Close();


            return piatti;
        }
        public void label_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            int point = Identifica(menù, label);
            MessageBox.Show("piatto ordinato");
           
            scriviAppend(@"./ordine.csv", menù[point].id + ";" + menù[point].nome + ";" + menù[point].portata + ";" + menù[point].ingredienti1 + ";" + menù[point].ingredienti2 + ";" + menù[point].ingredienti3 + ";" + menù[point].ingredienti4 + ";" + menù[point].prezzo);
            scriviAppend(@"./registroordini.csv", menù[point].id + ";" + menù[point].nome + ";" + menù[point].portata + ";" + menù[point].ingredienti1 + ";" + menù[point].ingredienti2 + ";" + menù[point].ingredienti3 + ";" + menù[point].ingredienti4 + ";" + menù[point].prezzo);
            
        }
        public static int Identifica(piatto[] piatti, Label label)
        {
            int i = 0;
            while (i < piatti.Length)
            {
                if (piatti[i].testo.Name == label.Name)
                {
                    return i;
                    
                }
                i++;
            }
            return i;
        }
        public static void scriviAppend(string filename, string content)
        {
            var oStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            sw.WriteLine(content);
            sw.Close();
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
            public string carattere;
            public Label testo;

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
                        ricercato.ingredienti1 = voto[3];
                        ricercato.ingredienti2 = voto[4];
                        ricercato.ingredienti3 = voto[5];
                        ricercato.ingredienti4 = voto[6];
                        ricercato.prezzo = decimal.Parse(voto[7]);
                        ricercato.carattere = "0";
                         ricercato.testo = new Label();
                        int verifica = ricerca(ricercato.id, @"./cancellati.csv");
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
            ntrovato.ingredienti1 = "0";
            ntrovato.ingredienti2 = "0";
            ntrovato.ingredienti3 = "0";
            ntrovato.ingredienti4 = "0";
            ntrovato.prezzo = 20;
            ntrovato.carattere = "0";
            ntrovato.testo = new Label();

            return ntrovato;
        }
        public int ricerca(string id, string filename, char sep = ';')
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

        

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

