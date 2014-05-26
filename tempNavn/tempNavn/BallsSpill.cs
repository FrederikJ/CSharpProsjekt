using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using CSharpProsjekt.SpillKlasser;

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
        private Boolean keepGoing = false;

        public BallSpill()
        {
            InitializeComponent();
            panelDraw.TimeEndret += new TimeEndringEvent(update_label_tid);
            panelDraw.PointsEndret += new PointEndringEvent(update_label_points);
        }

        public void Run()
        {
            while (keepGoing)
            {
                panelDraw.Invalidate();
                Thread.Sleep(17);
                
            }
        }

        //ligger ball til MyPanel
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (keepGoing == false)
            {
                startPlayer();
                keepGoing = true;
                panelDraw.AddSpiller();
                panelDraw.Invalidate();
            }
        }

        private void btn_pause_Click(object sender, EventArgs e)
        {
            if (panelDraw.PauseSpiller() == true)
                btn_pause.Text = "Pause";
            else
            {
                btn_pause.Text = "Fortsett";
            }
        }

        private void startPlayer()
        {
            ThreadStart ts = new ThreadStart(Run);
            Thread thread = new Thread(ts);
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
            panelDraw.LoadLevel();
            tb_finish.Visible = false;
            btn_finish.Visible = false;
        }

        private void reglerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.Show();
        }
        
    }
}