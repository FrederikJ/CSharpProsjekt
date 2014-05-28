using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpProsjekt.LoginKlasser;

namespace CSharpProsjekt
{
    public partial class Login : Form
    {
        private string passord;
        private string navn;
        private DataTable dt;

        DbConnect db = new DbConnect();

        public Login()
        {
            InitializeComponent();
            dt = new DataTable();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            passord = tbPassord.Text;
            navn = tbNavn.Text;

            string query = String.Format("SELECT * FROM Konto WHERE Navn = '{0}'", navn);
            dt = db.GetAll(query);

            if (dt != null && dt.Rows.Count > 0)
            {
                string queryPassord = Convert.ToString(dt.Rows[0]["Passord"]);
                if (passord == queryPassord)
                {
                    int brukerID = Convert.ToInt32(dt.Rows[0]["Id"]);
                    string brukerNavn = Convert.ToString(dt.Rows[0]["Navn"]);
                    string epost = Convert.ToString(dt.Rows[0]["Epost"]);
                    int topScore = Convert.ToInt32(dt.Rows[0]["TopScore"]);
                    int level = Convert.ToInt32(dt.Rows[0]["Level"]);

                    Bruker.AddBruker(brukerID, brukerNavn, topScore, level, epost);

                    BallSpill box = new BallSpill();
                    this.Hide();// this.Close();
                    box.Show();
                }
            }
            else
                lblFeil.Visible = true;
        }

        private void btnOpprett_Click(object sender, EventArgs e)
        {
            OpprettKonto frame = new OpprettKonto();
            frame.Show();
        }

        private void btnMistet_Click(object sender, EventArgs e)
        {
            MistetPassord frame = new MistetPassord();
            frame.Show();
        }
    }
}
