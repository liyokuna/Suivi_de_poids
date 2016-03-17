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
    public partial class Form_identification : Form
        
    {
        //private Form1 a;
        OleDbConnection connexion;
        
        public Form_identification()
        {
            InitializeComponent();
            connexion = new OleDbConnection(Suivi_de_poids.Properties.Settings.Default.Conn_Acces);
            Créationdumdp();
        }
        public void Créationdumdp()
        {
            textBox_mdp.MaxLength = 6; // la longueur maximale est de 6,comme mon nom
            textBox_mdp.PasswordChar = '+';// tout le caractère saisie sera changé en +
            textBox_mdp.CharacterCasing = CharacterCasing.Lower;// convertit tous les caratères en miniscule
            textBox_mdp.TextAlign = HorizontalAlignment.Center; // alignement du caractère au centre de la textbox
        }
        
        public void ChargementSQl (int id)
        {
            string req;
            //connexion.Open();
            req=" SELECT Requete from requete where %id ="+id;
            OleDbCommand cmd = new OleDbCommand(req);
            
            //connexion.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string a = "Vous êtes sur le point de fermer la fenêtre. Voulez-vous continuer ?";
            string b = "Avertissement";
            DialogResult resultat = MessageBox.Show(a, b, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resultat == System.Windows.Forms.DialogResult.Yes) this.Close();
            else { ((FormClosingEventArgs)e).Cancel = true; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form inscription = new Form_inscription();
            this.Hide();
            inscription.ShowDialog(this);
           
        }
        private bool ChampVide () // vérifier si le cham est vide ou pas
        {
            bool retour = false;
            if (textBox_id.Text.Trim().Length == 0 && textBox_mdp.Text.Trim().Length == 0) retour = true; // champ est vide
            return retour;
        }
        private void button_val_Click(object sender, EventArgs e)
        {

            if(!(ChampVide()== false))
            {
               MessageBox.Show("Veuillez saisir les informations manquantes");
               
            }
            else
            {
                
                 try
                {
                    connexion.Open();
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM Utilisateur WHERE ID='" + textBox_id.Text + "' AND MDP ='" + textBox_mdp.Text + "';" , connexion);
                    cmd.ExecuteNonQuery();
                    cmd.Clone();
                   
                    DialogResult resultat;
                    resultat = MessageBox.Show("Bienvenu dans votre session", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (resultat == System.Windows.Forms.DialogResult.OK) connexion.Close(); this.Close();// a.ID = textBox_id.Text; a.MDP = textBox_mdp.Text;
                   
                }
                catch (Exception ex)
                { MessageBox.Show(" -- L'identifiant ou le mot de passe est incorrect -- "+ ex.ToString()); }

            }
            connexion.Close();
            
        }
       public string Id
        {
           get {return textBox_id.Text;}
        }
        public string Mdp
        {
           get {return textBox_mdp.Text;}
        }


        private void textBox_mdp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                button_val_Click(sender,e);
            }
        }
            
        }
    }

