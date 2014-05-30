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
    /// TopScore.cs av Frederik Johnsen
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Topscore vinduet vår. Henter ut de ti brukere med størt topscore som har en topscore, 
    /// en buker kan ikke ha flere plasser i topscore listen
    /// </summary>
    public partial class TopScore : Form
    {
        private DbConnect db = new DbConnect();
        private DataTable topScore;
        private BindingSource bindingSource = new BindingSource();

        public TopScore()
        {
            string query = "SELECT * FROM Konto WHERE TopScore IS NOT null ORDER BY TopScore DESC LIMIT 0, 10";
            InitializeComponent();
            topScore = db.GetAll(query);
            bindingSource.DataSource = topScore;
            dgvScore.DataSource = bindingSource;
            dgvScore.Columns["Id"].Visible = false;
            dgvScore.Columns["Passord"].Visible = false;
            dgvScore.AllowUserToAddRows = false;
        }

        void dgvScore_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.dgvScore.Rows[e.RowIndex].Cells[0].Value = (e.RowIndex + 1).ToString();
        }
    }
}