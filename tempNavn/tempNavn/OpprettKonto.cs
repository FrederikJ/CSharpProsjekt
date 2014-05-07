﻿using System;
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
    public partial class OpprettKonto : Form
    {
        private string navn;
        private string passord;
        private string bekreftPassord;
        private string epost;
        private string bekreftelsesKode;
        
        public OpprettKonto()
        {
            InitializeComponent();
        }

        private void btnOpprett_Click(object sender, EventArgs e)
        {
            navn = tbNavn.Text;
            passord = tbPassord.Text;
            bekreftPassord = tbBekreftPassord.Text;
            epost = tbEpost.Text;
            bekreftelsesKode = LageTilfeldigString.TilfeldigString(10);

            if (passord == bekreftPassord)
            {
                string query = string.Format("Insert into Konto(Navn, Passord, Epost, BekreftelsesKode) values({0}, {1}, {2}, {3}", navn, passord, epost, bekreftelsesKode);
                DbConnect.InsertAll(query);

                string beskjed = "Grattis, du har nu blitt registrert her hos oss SimpleGame.com";
                string emne = "Registrert";

                SendEmail.sendEpost(epost, beskjed, emne);
            }
            else
                lblFeil.Visible = true;
        }
    }
}