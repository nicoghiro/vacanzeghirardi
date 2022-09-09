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
    public partial class recupero : Form
    {
        piattocanc[] semirecu;
        public recupero()
        {
            InitializeComponent();
            int x = 70; int y = 50;
            int cont4 = 0;
             semirecu = creaarray(@"./cancellati.csv", ';');
            while (cont4 < semirecu.Length)
            {
                if (semirecu[cont4].carattere != "£")
                {
                    semirecu[cont4].testo = new Label();
                    this.Controls.Add(semirecu[cont4].testo);
                    semirecu[cont4].testo.Location = new Point(x, y);
                    semirecu[cont4].testo.Size = new Size(600, 20);
                    semirecu[cont4].testo.Name = Convert.ToString(cont4);
                    y = y + 20;
                    semirecu[cont4].testo.Text = semirecu[cont4].id + " " + semirecu[cont4].nome + " " + semirecu[cont4].portata + " " + semirecu[cont4].ingredienti1 + " " + semirecu[cont4].ingredienti2 + " " + semirecu[cont4].ingredienti3 + " " + semirecu[cont4].ingredienti4 + " " + semirecu[cont4].prezzo+"€";
                    semirecu[cont4].testo.Click += new EventHandler(label_Click);
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
        public piattocanc[] creaarray(string filename, char sep)
        {
            int cont = 0;
            int cont1 = 0;
            StreamReader sr = new StreamReader(filename);
            string line = "";
            line = sr.ReadLine();
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] voto = line.Split(sep);
                
                cont = ricercacl(voto[0], @"./cancellati.csv", ';');
                if (cont == 1)
                {
                    if (voto[8] != "£") { 
                    cont1++;}
                }


            }
            piattocanc[] recupera = new piattocanc[cont1];
            sr.Close();
            StreamReader sp = new StreamReader(filename);
            string line1 = "";
            int cont2 = 0;
            line1 = sp.ReadLine();
            while (!sp.EndOfStream)
            {
                line1 = sp.ReadLine();
                string[] voti = line1.Split(sep);
                cont = ricercacl(voti[0], @"./cancellati.csv", ';');
                
                
                    if (cont == 1)
                {
                        if (voti[8] != "£")
                        {
                            recupera[cont2].id = voti[0];
                            recupera[cont2].nome = voti[1];
                            recupera[cont2].portata = voti[2];
                            recupera[cont2].ingredienti1 = voti[3];
                        recupera[cont2].ingredienti2 = voti[4];
                        recupera[cont2].ingredienti3 = voti[5];
                        recupera[cont2].ingredienti4 = voti[6];
                        recupera[cont2].prezzo = Convert.ToDecimal(voti[7]);
                            recupera[cont2].carattere = voti[8];
                            cont2++;
                        }

                }


            }
            sp.Close();
            return recupera;
        }
        public struct piattocanc
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

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void label_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("sei sicuro di voler recuperare il piatto?","recupero" , MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes) { 
            Label label = sender as Label;
            int point = Identifica(semirecu, label);
            Random random = new Random();
            int nuovoid = random.Next(1, 100000);
            scriviAppend(@"./aggiungi.csv", nuovoid + ";" + semirecu[point].nome + ";" + semirecu[point].portata + ";" + semirecu[point].ingredienti1 + ";" + semirecu[point].ingredienti2 + ";" + semirecu[point].ingredienti3 + ";" + semirecu[point].ingredienti4 + ";" + semirecu[point].prezzo);
            scriviAppend(@"./cancellati.csv", semirecu[point].id + ";" + semirecu[point].nome + ";" + semirecu[point].portata + ";" + semirecu[point].ingredienti1 + ";" + semirecu[point].ingredienti2 + ";" + semirecu[point].ingredienti3 + ";" + semirecu[point].ingredienti4 + ";" + semirecu[point].prezzo+";"+"$");
            this.Hide();
            recupero Form1 = new recupero();
            Form1.ShowDialog();
            this.Close();
            }
            else if(dialogResult == DialogResult.No)
            {

            }

        }
        public static int Identifica(piattocanc[]piatti, Label label)
        {
            int i=0;
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
    }
}
