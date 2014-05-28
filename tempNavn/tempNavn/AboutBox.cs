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
    public partial class AboutBox : Form
    {
        private string text = "Her skal det komme beskrivelse av regler og annen nyttig informasjon vedrørende spillet";
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