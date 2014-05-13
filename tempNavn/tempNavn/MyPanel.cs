using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using tempNavn;

/*
 * HiN - Vårsemester 2014
 * Programmering 3
 * Obligatorisk Innlevering 4
 * 
 * Skrevet av:
 * Tommy Langhelle
 */

namespace tempNavn
{
    public partial class MyPanel : Panel
    {
        private Ball ball;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public MyPanel()
        {
            //sørger for at grafikken går smooth
            this.SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint,
              true);
            this.UpdateStyles();

            timer.Interval = 20;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        public void StopBalls()
        {    
            ball.going = false;
        }

        void timer_Tick(object sender, EventArgs e)
        {

           var left = KeyboardInfo.GetKeyState(Keys.Left);
           var right = KeyboardInfo.GetKeyState(Keys.Right);
           var up = KeyboardInfo.GetKeyState(Keys.Up);
           var down = KeyboardInfo.GetKeyState(Keys.Down);

            if (left.IsPressed)
            {
                ball.MoveLeft();
                this.Invalidate();
            }

            if (right.IsPressed)
            {
                ball.MoveRight();
                this.Invalidate();
            }

            if (up.IsPressed)
            {
                ball.MoveUp();
                this.Invalidate();
            }

            if (down.IsPressed)
            {
                ball.MoveDown();
                this.Invalidate();
            }
        }

        public void AddBall()
        {
            ball = new Ball(this);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            
            if(this.ball != null)
                ball.draw(e.Graphics);
        }
    }
}
