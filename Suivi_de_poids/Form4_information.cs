using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Suivi_de_poids
{
    public partial class Form4_information : Form
    {
        OleDbConnection connexion;
        
        public Form4_information()
        {
            InitializeComponent();
            connexion = new OleDbConnection(Suivi_de_poids.Properties.Settings.Default.Conn_Acces);
           
            info();
            List<string> req=new List<string>();
            Form1 main = new Form1();
            ide = main.iden; mdp = main.modp;
            textBox_id.Text = ide; textBox_mdp.Text = mdp;

        }

        private void button_annuler_Click(object sender, EventArgs e)
        {
            string a = "Vous êtes sur le point de fermer la fenêtre. Voulez-vous continuer ?";
            string b = "Avertissement";
            DialogResult resultat = MessageBox.Show(a, b, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultat == System.Windows.Forms.DialogResult.Yes) this.Close();
            else { ((FormClosingEventArgs)e).Cancel = true; }
        }

        private void Valider_Click(object sender, EventArgs e)
        {
            try
            {
                


                connexion.Open();
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM Utilisateur WHERE ID='" + textBox_id.Text + "' AND MDP ='" + textBox_mdp.Text + "';", connexion);

                cmd.ExecuteNonQuery();
                cmd.Clone();
                DialogResult resultat;
                resultat = MessageBox.Show("Bienvenu dans votre session", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (resultat == System.Windows.Forms.DialogResult.OK) connexion.Close(); this.Close();
            }
            catch (Exception ex)
            { MessageBox.Show("L'identifiant ou le mot de passe est incorrect" + ex.ToString()); }
            connexion.Close();
        }
        
        private void info()
        {
            connexion.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Utilisateur WHERE ID='" + textBox_id.Text + "' AND MDP ='" + textBox_mdp.Text + "';", connexion);
            cmd.ExecuteNonQuery();
            cmd.Clone();
        }
    }
}
