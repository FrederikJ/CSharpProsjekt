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
        //private string text = "Her skal det komme beskrivelse av regler og annen nyttig informasjon vedrørende spillet";
        public AboutBox()
        {
            InitializeComponent();
            labelInfo.Text = Bruker.Navn;// text;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}