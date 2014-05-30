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
    public partial class OpprettKonto : Form
    {
        private string navn;
        private string passord;
        private string bekreftPassord;
        private Boolean userExists = false;
        private DataTable dt;

        DbConnect db = new DbConnect();
        
        //Henter ut alle brukerene fra databasen
        public OpprettKonto()
        {
            dt = new DataTable();
            InitializeComponent();
            string query = "SELECT * FROM Konto";
            dt = db.GetAll(query);

        }

        //Henter ut all informasjonene i tekstboksen forså å kryptere passordet og sjekker at 
        //begge passordene er like og at navnet ikke eksistere fra før i databasen, viss sjekkene blir
        //blir godkjent, så legges det inn en ny bruker i databasen
        private void btnOpprett_Click(object sender, EventArgs e)
        {
            navn = tbNavn.Text;
            passord = Encryption.Encrypt(tbPassord.Text);
            bekreftPassord = Encryption.Encrypt(tbBekreftPassord.Text);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (navn == dt.Rows[i]["Navn"].ToString())
                    userExists = true;
            }

            if (passord == bekreftPassord && userExists == false)
            {
                string query = string.Format("Insert into Konto(Navn, Passord) values('{0}', '{1}', '{2}')", navn, passord);
                db.InsertAll(query);

                this.Close();
            }
            else if (userExists)
            {
                lblFeil.Text = "Brukernavn er allerede brukt";
                lblFeil.Visible = true;
                userExists = false;
            }
                
            else
            {
                lblFeil.Text = "Passordene er ikke like";
                lblFeil.Visible = true;
            }  
        }
    }
}
