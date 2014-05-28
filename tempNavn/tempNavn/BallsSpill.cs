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
 * Obligatorisk Innlevering 4
 * 
 * Skrevet av:
 * Tommy Langhelle
 */

namespace CSharpProsjekt
{
    public partial class BallSpill : Form
    {
        public Boolean keepGoing { get; set; }
        private ThreadStart ts;
        private Thread thread;

        public BallSpill()
        {
            InitializeComponent();
            panelDraw.TimeEndret += new TimeEndringEvent(update_label_tid);
            panelDraw.PointsEndret += new PointEndringEvent(update_label_points);
            keepGoing = false;
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

        private void btn_pause_Click(object sender, EventArgs e)
        {
            if (panelDraw.PauseGame() == true)
                btn_pause.Text = "Pause";
            else
            {
                btn_pause.Text = "Fortsett";
            }
        }

        private void StartInvalidateThread()
        {
            ts = new ThreadStart(Run);
            thread = new Thread(ts);
            thread.IsBackground = true;
            thread.Start();
        }

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
                tb_finish.Text = "Gratulerer, du har fullført dette nivået!";
                tb_finish.Visible = true;
                btn_finish.Visible = true;
            }
        }

        private void btn_finish_Click(object sender, EventArgs e)
        {
            panelDraw.StartTimers();
            panelDraw.LoadLevel();
            tb_finish.Visible = false;
            btn_finish.Visible = false;
        }

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

        private void loggUtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login box = new Login();
            this.Close();
            panelDraw.StopGame();
            box.Show();
        }

        private void glemtPassordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MistetPassord box = new MistetPassord();
            box.Show();
        }

        private void opprettBrukerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpprettKonto box = new OpprettKonto();
            box.Show();
        }
    }
}