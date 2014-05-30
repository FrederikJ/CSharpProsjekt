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
    /// AboutBox.cs av Tommy Langhelle & Frederik Johnsen
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Denne dukker opp når man trykker oppe i Menu Item listen på toppen av programmet. 
    /// Får man opp et nytt vindu hvor det står litt om spillet og regler, hvordan spillet fungere
    /// og beskrivelse av de forskjellige komponentene
    /// </summary>
    public partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            rtb_Info.Text = "Innlogget som: " + User.Name;
            rtb_Info.Text += "\n\nDette spillet går ut på å samle dottene rundtom på kartet innen tiden er gått ut. Spillet består av 5 levler hvor den siste er heller vrien. Hvis man treffer bakken blir man game over.";
            rtb_Info.Text += "\n\nGul ball (100 poeng): \nDette er de eneste obligatoriske dottene, du går videre til neste level så snart alle gule dotter er samlet inn.";
            rtb_Info.Text += "\n\nRød ball (150 poeng): \nDette er valgfrie dotter. Tyngdekraften blir reversert for hver dott.";
            rtb_Info.Text += "\n\nBlå ball (200 poeng): \nDette er valgfrie dotter.";
            rtb_Info.Text += "\n\nGrønn ball (300 poeng): \nDette er valgfrie dotter.";
            rtb_Info.Text += "\n\nSkytere: \nBlir du truffet av en av de fire skytterne plassert på kartet er det game over.";
            rtb_Info.Text += "\n\nHinder:\nTreffer du et av hindrene blir du returnert til startposisjonen, du blir også fratrekt 75 poeng.";
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}