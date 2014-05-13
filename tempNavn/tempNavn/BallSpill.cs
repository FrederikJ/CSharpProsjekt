using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

/*
 * HiN - V�rsemester 2014
 * Programmering 3
 * Obligatorisk Innlevering 4
 * 
 * Skrevet av:
 * Tommy Langhelle
 */

namespace BasicBouncingBall
{
    public partial class BallSpill : Form
    {
        private Boolean keepGoing = false;

        public BallSpill()
        {
            InitializeComponent();
            panelDraw.AddBall();
        }

        public void Run()
        {
            while (keepGoing)
            {
                panelDraw.Invalidate();
                Thread.Sleep(10);
            }
        }

        //ligger ball til MyPanel
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (keepGoing == false)
            { 
                startBall();  
                keepGoing = true;
                panelDraw.AddBall();
                panelDraw.Invalidate();
            }
        }
        private void startBall()
        {
            ThreadStart ts = new ThreadStart(Run);
            Thread thread = new Thread(ts);
            thread.IsBackground = true;
            thread.Start();
        }   
        //kj�rer metoden stopBalls i MyPanel
    }
}