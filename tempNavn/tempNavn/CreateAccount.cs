using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpProsjekt.LoginKlasser;

namespace CSharpProsjekt
{
    /// <summary>
    /// OpprettKonto.cs av Frederik Johnsen
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Opprett bruker klasse
    /// </summary>
    public partial class CreateAccount : Form
    {
        private string name;
        private string password;
        private string confirmPassword;
        private Boolean userExists = false;
        private DataTable dt;

        DbConnect db = new DbConnect();
        
        //Henter ut alle brukerene fra databasen
        public CreateAccount()
        {
            dt = new DataTable();
            InitializeComponent();
            string query = "SELECT * FROM Konto";
            dt = db.GetAll(query);

        }

        //Henter ut all informasjonene i tekstboksen forså å kryptere passordet og sjekker at 
        //begge passordene er like og at navnet ikke eksistere fra før i databasen, viss sjekkene blir
        //blir godkjent, så legges det inn en ny bruker i databasen
        private void btnCreate_Click(object sender, EventArgs e)
        {
            name = tbName.Text;
            password = Encryption.Encrypt(tbPassword.Text);
            confirmPassword = Encryption.Encrypt(tbConfirmPassword.Text);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (name == dt.Rows[i]["Navn"].ToString())
                    userExists = true;
            }

            if (password == confirmPassword && userExists == false)
            {
                string query = string.Format("Insert into Konto(Navn, Passord) values('{0}', '{1}', '{2}')", name, password);
                db.InsertAll(query);

                this.Close();
            }
            else if (userExists)
            {
                lblError.Text = "Brukernavn er allerede brukt";
                lblError.Visible = true;
                userExists = false;
            }
                
            else
            {
                lblError.Text = "Passordene er ikke like";
                lblError.Visible = true;
            }  
        }
    }
}
