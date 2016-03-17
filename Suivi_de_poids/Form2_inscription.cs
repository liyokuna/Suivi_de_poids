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
    public partial class Form_inscription : Form
    {
        List<string> nom= new List<string>();
        OleDbConnection connexion;
        
        public void Créationdumdp()
        {
            textBox_mdp.MaxLength = 6; // la longueur maximale est de 6,comme mon nom
            textBox_mdp.PasswordChar = '+';// tout le caractère saisie sera changé en +
            textBox_mdp.CharacterCasing = CharacterCasing.Lower;// convertit tous les caratères en miniscule
            textBox_mdp.TextAlign = HorizontalAlignment.Center; // alignement du caractère au centre de la textbox
        }
        public void ChargementSQl(int id)
        {
            string req;
            //connexion.Open();
            req = " SELECT Requete from requete where %id =" + id;
            OleDbCommand cmd = new OleDbCommand(req);

            //connexion.Close();
        }
        private bool ChampVide() // vérifier si le cham est vide ou pas
        {
            bool retour = false;
            if (textBox_id.Text.Trim().Length == 0 && textBox_mdp.Text.Trim().Length == 0 && textBox1.Text.Trim().Length == 0 && textBox3.Text.Trim().Length == 0 && textBox5.Text.Trim().Length == 0 && textBox2.Text.Trim().Length == 0)
                retour = true; // champ est vide
            return retour;
        }
        public Form_inscription()
        {
            InitializeComponent();
            nom.Add("Masculin");
            nom.Add("Féminin");
            listBox1.DataSource=nom;
            Créationdumdp();
            textBox2.CharacterCasing = CharacterCasing.Upper;
            connexion = new OleDbConnection(Suivi_de_poids.Properties.Settings.Default.Conn_Acces);
           
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            string a = "Vous êtes sur le point de fermer la fenêtre. Voulez-vous continuer ?";
            string b = "Avertissement";
            DialogResult resultat= MessageBox.Show(a, b, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultat == System.Windows.Forms.DialogResult.Yes)
            {
                connexion.Close(); this.Hide(); 
            Form c = new Form_identification();
            c.ShowDialog(this); this.Close();
            }
            else { ((FormClosingEventArgs)e).Cancel = true; }

        }

        private void Valider_Click(object sender, EventArgs e)
        {
            
            if (!(ChampVide() == false)) MessageBox.Show("Veuillez saisir toutes les informations demandées");
            else
            {
                try
                {
                    DateTime heure = DateTime.Now;
                    //string format = "yyyy-MM-dd HH:MM:ss";
                    connexion.Open();
                    OleDbCommand cmd = new OleDbCommand("INSERT INTO Utilisateur (Nom,Prénom,ID,MDP,Taille,Naissance,Genre) VALUES ('" + textBox2.Text + "','"
                        + textBox1.Text + "','" + textBox_id.Text + "','" + textBox_mdp.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','"  + listBox1.SelectedIndex.ToString() + "')", connexion);
                    
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                    DialogResult resultat;
                    resultat = MessageBox.Show("Les informations ont été bien prises en compte", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    if (resultat == System.Windows.Forms.DialogResult.OK) connexion.Close(); this.Hide(); Form c = new Form_identification();
                    c.ShowDialog(); this.Close();
                }
                catch (Exception ex)
                { MessageBox.Show("Problème de connexion avec la base de donnée"+ex.ToString()); }

            }
            connexion.Close();
        }

    }
}
