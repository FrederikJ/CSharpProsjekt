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

namespace CSharpProsjekt
{
    /// <summary>
    /// BallSpill.cs av Tommy Langhelle & delvis Frederik Johnsen
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Hoved vinduet/Klassen. Her begynner hele spillet, alle komponentene på programmet starter
    /// her i fra
    /// </summary>
    public partial class Playball : Form
    {
        public Boolean KeepGoing { get; set; }
        private ThreadStart ts;
        private Thread thread;

        private string password;
        private string name;
        private DataTable dt;
        private DbConnect db;

        /// <summary>
        /// Instansiere ting og setter bakgrunnsbildene til riktig størrelse
        /// </summary>
        public Playball()
        {
            InitializeComponent();
            dt = new DataTable();
            db = new DbConnect();
            panelDraw.TimeEndret += new TimeEndringEvent(update_label_tid);
            panelDraw.PointsEndret += new PointEndringEvent(update_label_points);
            panelDraw.FPSEndret += new FPSEndringsEvent(update_label_FPS);
            KeepGoing = false;

            var loginPic = new Bitmap(LoginPanel.BackgroundImage, new Size(728, 404));
            LoginPanel.BackgroundImage = loginPic;

            var panelDrawPic = new Bitmap(panelDraw.BackgroundImage, new Size(728, 404));
            panelDraw.BackgroundImage = panelDrawPic; 

            nyttSpillToolStripMenuItem.Enabled = false;
            loggUtToolStripMenuItem.Enabled = false;
            btn_pause.Enabled = false;
        }

        /// <summary>
        /// Starter tråden som kjøre spillet
        /// </summary>
        private void StartInvalidateThread()
        {
            ts = new ThreadStart(Run);
            thread = new Thread(ts);
            thread.IsBackground = true;
            thread.Start();
        }

        public void Run()
        {
            while (KeepGoing)
            {
                panelDraw.Invalidate();
                Thread.Sleep(17);
            }
        }

        /// <summary>
        /// Starter gamet våres med å klikke på panelet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void panelDraw_Click(object sender, EventArgs e)
        {
            if (KeepGoing == false)
            {
                KeepGoing = true;
                StartInvalidateThread();
                panelDraw.StartGame();
                btn_pause.Enabled = true;
                nyttSpillToolStripMenuItem.Enabled = true;
            }
        }

#region Knapper

        /// <summary>
        /// Henter ut all informasjon om brukeren fra databasen. Så sjekker den passordet
        /// viss det er godkjent, så setter den brukerid, navnet inn i bruker objekt klassen
        /// og top score og level blir satt inn viss de eksistere. 
        /// tømmer tekstboks felene og kjøre metoden LoadLevel slik at du får det opp på skjermen 
        /// når man har logget inn
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            password = tbPassword.Text;
            name = tbName.Text;

            string query = String.Format("SELECT * FROM Konto WHERE Navn = '{0}'", name);
            dt = db.GetAll(query);


            if (dt != null && dt.Rows.Count > 0)
            {
                string queryPassord = Convert.ToString(dt.Rows[0]["Passord"]);
                if (Encryption.Decrypt(password, queryPassord))
                {
                    int brukerID = Convert.ToInt32(dt.Rows[0]["Id"]);
                    string brukerNavn = Convert.ToString(dt.Rows[0]["Navn"]);

                    if(dt.Rows[0]["TopScore"] != null)
                    {
                        int topScore = Convert.ToInt32(dt.Rows[0]["TopScore"]);
                        int level = Convert.ToInt32(dt.Rows[0]["Level"]);
                        User.AddTopScoreLevelToUser(topScore, level);
                    }

                    User.AddUser(brukerID, brukerNavn);

                    loggUtToolStripMenuItem.Enabled = true;
                    opprettBrukerToolStripMenuItem.Enabled = false;

                    tbPassword.Text = null;
                    tbName.Text = null;
                    LoginPanel.Hide();
                    panelDraw.LoadLevel();
                }
                else
                    lblError.Visible = true;
            }
        }

        /// <summary>
        /// Etter man er ferdig med et level, får man opp en boks hvor det står gratulere og en knapp. 
        /// Denne knappen fører deg videre til neste level
        /// </summary>
        private void btn_NextLevel_Click(object sender, EventArgs e)
        {
            panelDraw.StartTimers();
            panelDraw.StartMovementThread();
            panelDraw.LoadLevel();

            tb_LevelFinished.Hide();
            btn_NextLevel.Hide();
        }

        /// <summary>
        /// Pause spillet knapp og fortsette knapp
        /// </summary>
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

#region Toolstrip menu item metoder
        private void topScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopScore box = new TopScore();
            box.Show();
        }

        private void reglerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.Show();
        }

        private void nyttSpillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeepGoing = false;
            panelDraw.ClearPanel();
            panelDraw.NewGame();
            panelDraw.Invalidate();
        }

        private void loggUtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeepGoing = false;
            LoginPanel.Show();
            panelDraw.StopGame();
            nyttSpillToolStripMenuItem.Enabled = false;
            loggUtToolStripMenuItem.Enabled = false;
            opprettBrukerToolStripMenuItem.Enabled = true;
            label_tid.Text = "Gjenstående tid: ";
            label_level.Text = "Level:";
            label_poeng.Text = "Poeng:";
            lblError.Visible = false;
            btn_pause.Enabled = false;
        }

        private void opprettBrukerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateAccount box = new CreateAccount();
            box.Show();
        }
#endregion

#region Delegat metoder
        public void update_label_tid(object sender, TimeEventArgs e)
        {
            label_tid.Text = Convert.ToString("Gjenstående tid: " + e.timeLeft + " sekunder");

            if (e.timeLeft == 0)
                btn_pause.Enabled = false;
        }

        public void update_label_points(object sender, PointEventArgs e)
        {
            label_poeng.Text = Convert.ToString("Poeng: " + e.Points);
            label_level.Text = Convert.ToString("Level: " + e.Level);

            if (e.LevelComplete == true && e.GameComplete == false)
            {
                tb_LevelFinished.Show();
                btn_NextLevel.Show();
            }
            if (e.GameOver)
                btn_pause.Enabled = false;
        }

        public void update_label_FPS(object sender, FPSEventArgs e)
        {
            label_FPS.Text = "FPS: " + e.FPS.ToString("#.##");
        }
#endregion
    }
}