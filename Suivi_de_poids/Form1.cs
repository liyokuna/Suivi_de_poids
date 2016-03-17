using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Suivi_de_poids
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            Form_identification b = new Form_identification();
            b.ShowDialog(this);
            ID = b.Id; MDP = b.Mdp;
            
            this.Text = " Suivi de poids -- session : "+ ID;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void mesInformationsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void seDéconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = " Suivi de poids -- session :";
            Form a = new Form_identification();
            a.ShowDialog(this);
        }

        private void nouveauUtilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form a = new Form_inscription();
            a.ShowDialog(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void mesInformationsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
       
            Form Bb = new Form4_information();
            //Form4_information info = new Form4_information();
            //info.ide = ID; info.mdp = MDP;
            Bb.Show(this);
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public string iden { get { return ID; } }
        public string modp { get { return MDP; } }
    }
}
