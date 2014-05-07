using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tempNavn.Klasser;

namespace tempNavn
{
    public partial class MistetPassord : Form
    {
        private string email;
        private string navn;
        private string passord;
        private DataTable dt;

        public MistetPassord()
        {
            InitializeComponent();
            dt = new DataTable();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            email = tbEmail.Text;

            string query = string.Format("Select * from Konto where Epost = '{0}'", email);
            dt = DbConnect.GetAll(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                if (email == Convert.ToString(dt.Rows[0]["Epost"]))
                {
                    passord = Convert.ToString(dt.Rows[0]["Passord"]);
                    navn = Convert.ToString(dt.Rows[0]["Navn"]);

                    string beskjed = string.Format("Hei {0}, ditt passord er {1}. Håpe du like spille, å ha en hyggelig dag videre", navn, passord);
                    string emne = "Mistet passord";

                    SendEmail.sendEpost(email, beskjed, emne);
                }
            }
            else
                lblFeil.Visible = true;
        }
    }
}
