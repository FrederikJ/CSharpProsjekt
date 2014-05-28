using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CSharpProsjekt.SpillKlasser;
using CSharpProsjekt.LoginKlasser;

/*
 * HiN - VÃ¥rsemester 2014
 * Programmering 3
 * Karaktergivende prosjekt
 * 
 * Skrevet av:
 * Tommy Langhelle og Frederik Johnsen
 */

namespace CSharpProsjekt
{
    public partial class BallSpill : Form
    {
        #region Variables
        public Boolean keepGoing { get; set; }
        private ThreadStart ts;
        private Thread thread;

        private string passord;
        private string navn;
        private DataTable dt;
        private DbConnect db = new DbConnect();
        #endregion

        public BallSpill()
        {
            InitializeComponent();
            dt = new DataTable();
            panelDraw.TimeEndret += new TimeEndringEvent(update_label_tid);
            panelDraw.PointsEndret += new PointEndringEvent(update_label_points);
            keepGoing = false;
        }

        private void StartInvalidateThread()
        {
            ts = new ThreadStart(Run);
            thread = new Thread(ts);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Run()
        {
            while (keepGoing)
            {
                panelDraw.Invalidate();
                Thread.Sleep(17);
                
            }
        }

        private void panelDraw_Click(object sender, EventArgs e)
        {
            if (keepGoing == false)
            {
                keepGoing = true;
                StartInvalidateThread();
                panelDraw.StartGame();
                panelDraw.Invalidate();
            }
        }

        #region Buttons

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

                    Bruker.AddBruker(brukerID, brukerNavn, epost);
                    LoginPanel.Hide();
                }
            }
            else
                lblFeil.Visible = true;
        }

        private void btn_NextLevel_Click(object sender, EventArgs e)
        {
            panelDraw.StartTimers();
            panelDraw.LoadLevel();

            tb_LevelFinished.Hide();
            btn_NextLevel.Hide();
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            if (panelDraw.PauseGame() == true)
                btn_pause.Text = "Pause";
            else
            {
                btn_pause.Text = "Fortsett";
            }
        }
        #endregion

        #region Toolstrip
        private void topScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopScore box = new TopScore();
            box.Show();
        }

        private void hjelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.Show();
        }

        private void nyttSpillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            keepGoing = false;
            panelDraw.NewGame();
            panelDraw.Invalidate();

        }
        #endregion

        #region Delegat abonnenter
        public void update_label_tid(object sender, TimeEventArgs e)
        {
            label_tid.Text = Convert.ToString("Gjenstående tid: " + e.timeLeft + " sekunder");

        }

        public void update_label_points(object sender, PointEventArgs e)
        {
            label_poeng.Text = Convert.ToString("Poeng: " + e.points);
            label_level.Text = Convert.ToString("Level: " + e.level);

            if (e.levelComplete == true)
            {
                tb_LevelFinished.Show();
                btn_NextLevel.Show();
            }
        }
        #endregion
    }
}