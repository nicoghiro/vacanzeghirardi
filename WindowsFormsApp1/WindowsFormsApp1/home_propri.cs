using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class home_propri : Form
    {
        public home_propri()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            aggiungi Form1 = new aggiungi();
            Form1.ShowDialog();
            this.Close();
        }

        private void home_propri_Load(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ricerca Form1 = new ricerca();
            Form1.ShowDialog();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            login Form1 = new login();
            Form1.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            modifica Form1 = new modifica();
            Form1.ShowDialog();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            eliminazione Form1 = new eliminazione();
            Form1.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            formatta Form1 = new formatta();
            Form1.ShowDialog();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            recupero Form1 = new recupero();
            Form1.ShowDialog();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            visualizza Form1 = new visualizza();
            Form1.ShowDialog();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
           
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            ricompatta Form1 = new ricompatta();
            Form1.ShowDialog();
            this.Close();
        }
    }
}
