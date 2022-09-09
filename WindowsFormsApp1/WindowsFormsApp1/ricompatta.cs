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
    public partial class ricompatta : Form
    {
        piatto[] menù;
        public ricompatta()
        {
            InitializeComponent();
        }

        private void ricompatta_Load(object sender, EventArgs e)
        {

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

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            home_propri Form1 = new home_propri();
            Form1.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menù = ricerca1(@"./aggiungi.csv");
            StreamWriter sp = new StreamWriter(@"./temp.csv");
            sp.Close();

            System.IO.File.Delete(@"./aggiungi.csv");
            System.IO.File.Move(@"./temp.csv", @"./aggiungi.csv");
            StreamWriter sr = new StreamWriter(@"./aggiungi.csv");
            
            sr.WriteLine("sdfgjklsdhyuifhkd");
            sr.Close();
            StreamWriter sT = new StreamWriter(@"./temp.csv");
            sT.Close();

            System.IO.File.Delete(@"./cancellati.csv");
            System.IO.File.Move(@"./temp.csv", @"./cancellati.csv");
            StreamWriter so = new StreamWriter(@"./cancellati.csv");
            so.WriteLine("suidfghsdjklfgsdf");
            so.Close();
            for (int cont = 0; cont < menù.Length; cont++)
            {
                scriviAppend(@"./aggiungi.csv", menù[cont].id + ";" + menù[cont].nome + ";" + menù[cont].portata + ";" + menù[cont].ingredienti1 + ";" + menù[cont].ingredienti2 + ";" + menù[cont].ingredienti3 + ";" + menù[cont].ingredienti4 + ";" + menù[cont].prezzo);
            }
            MessageBox.Show("il file è stato ricompattato");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            home_propri Form1 = new home_propri();
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
    }
}
