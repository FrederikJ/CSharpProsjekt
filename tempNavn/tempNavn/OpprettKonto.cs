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
    public partial class OpprettKonto : Form
    {
        private string navn;
        private string passord;
        private string bekreftPassord;
        private string epost;
        private string bekreftelsesKode;
        private Boolean userExists = false;
        private DataTable dt;

        DbConnect db = new DbConnect();
        
        public OpprettKonto()
        {
            dt = new DataTable();
            InitializeComponent();
            string query = "SELECT * FROM Konto";
            dt = db.GetAll(query);

        }

        private void btnOpprett_Click(object sender, EventArgs e)
        {
            navn = tbNavn.Text;
            passord = Encryption.Encrypt(tbPassord.Text);
            bekreftPassord = Encryption.Encrypt(tbBekreftPassord.Text);
            epost = tbEpost.Text;
            bekreftelsesKode = LageTilfeldigString.TilfeldigString(10);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (navn == dt.Rows[i]["Navn"].ToString())
                    userExists = true;
            }

            if (passord == bekreftPassord && userExists == false)
            {
                string query = string.Format("Insert into Konto(Navn, Passord, Epost) values('{0}', '{1}', '{2}')", navn, passord, epost);
                db.InsertAll(query);

                /*string beskjed = "Grattis, du har nu blitt registrert her hos oss SimpleGame.com";
                string emne = "Registrert";

                SendEmail.sendEpost(epost, beskjed, emne);*/
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
