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
    public partial class acc_propieta : Form
    {
        public acc_propieta()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login Form1 = new login();
            Form1.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            nuovoutente Form1 = new nuovoutente();
            Form1.ShowDialog();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public static void scrivi(string filename, string content)
        {
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(content);
            sw.Close();
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
                    cont++;
                }
            }
            sr.Close();
            return cont;
        }
        public int login1verifica(string nomeutente, string password, string filename)
        {
            int verifiche = 0;
            int cont = 0;
            StreamReader sr = new StreamReader(filename);
            string line = "";
            while (!sr.EndOfStream)
            {
                
                line = sr.ReadLine();
                if (verifiche == 0)
                {
                    if (nomeutente == line)
                    {
                        verifiche++; 
                    }
                }
                if (verifiche == 1)
                {
                    if (password == line)
                    {
                        verifiche++;
                    }
                    

                }
               
        
               
                
                    
            }
            sr.Close();
            return verifiche;
        }
        public static void scriviAppend(string filename, string content)
        {
            var oStream = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Read);
            StreamWriter sw = new StreamWriter(oStream);
            sw.WriteLine(content);
            sw.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            nuovoutente Form1 = new nuovoutente();
            Form1.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           int verifiche= login1verifica(textBox1.Text, textBox2.Text, "./credenziali.csv");
            if (verifiche == 2)
            {
                this.Hide();
                home_propri Form1 = new home_propri();
                Form1.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("credenziali errate");
            }
        }
    }
}
