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
        private Spiller Spiller;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public MyPanel()
        {
            //sørger for at grafikken går smooth
            this.SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint,
              true);
            this.UpdateStyles();

            
        }

        public void StopBalls()
        {    
            Spiller.going = false;
        }

        void timer_Tick(object sender, EventArgs e)
        {

           var left = KeyboardInfo.GetKeyState(Keys.Left);
           var right = KeyboardInfo.GetKeyState(Keys.Right);
           var up = KeyboardInfo.GetKeyState(Keys.Up);
           var down = KeyboardInfo.GetKeyState(Keys.Down);

            if (left.IsPressed)
            {
                Spiller.MoveLeft();
                this.Invalidate();
            }

            if (right.IsPressed)
            {
                Spiller.MoveRight();
                this.Invalidate();
            }

            if (up.IsPressed)
            {
                Spiller.MoveUp();
                this.Invalidate();
            }

            if (down.IsPressed)
            {
                Spiller.MoveDown();
                this.Invalidate();
            }
        }

        public void AddSpiller()
        {
            timer.Interval = 20;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            Spiller = new Spiller(this);
        }
        public void StopSpiller()
        {
            Spiller.going = false;
            timer.Stop();
        }
        public Boolean pauseSpiller()
        {
            if (timer.Enabled == true)
            {
                timer.Enabled = false;
                return false;
            }

            else
            {
                timer.Enabled = true;
                return true;
            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            if (this.Spiller != null)
                Spiller.draw(e.Graphics);
        }
    }
}
