using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using CSharpProsjekt.SpillKlasser;
using System.Drawing.Drawing2D;

/*
 * HiN - Vårsemester 2014
 * Programmering 3
 * Obligatorisk Innlevering 4
 * 
 * Skrevet av:
 * Tommy Langhelle
 */

namespace CSharpProsjekt
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

            drawFigures();
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
                Spiller.going = false;
                return false;
            }

            else
            {
                timer.Enabled = true;
                Spiller.going = true;
                return true;
            }

        }

        public void drawFigures()
        {
            int firstPointX;
            int firstPointY;

            firstPointX = 530;
            firstPointY = 25;

            Point[] randomShape = {
            new Point (firstPointX, firstPointY),
            new Point (firstPointX, firstPointY + 70),
            new Point (firstPointX + 100, firstPointY + 70),
            new Point (firstPointX + 100, firstPointY),
            };

            obstacle.StartFigure();
            obstacle.AddCurve(randomShape, 3);
            obstacle.CloseFigure();

            firstPointX = 550;
            firstPointY = 220;

            Rectangle rectangle = new Rectangle(firstPointX, firstPointY, 200, 70);
            obstacle.StartFigure();

            obstacle.AddArc(rectangle, 50, 180);
            obstacle.AddLine(firstPointX + 50, firstPointY + 66, firstPointX + 100, firstPointY + 150);
            obstacle.CloseFigure();

            obstacle.StartFigure();
            obstacle.AddLine(350, 250, 500, 120);
            obstacle.AddLine(450, 220, 350, 190);
            obstacle.CloseFigure();

            obstacle.StartFigure(); 
            obstacle.AddArc(460, 350, 50, 50, 0, -180);
            obstacle.AddLine(450, 250, 520, 250);
            obstacle.CloseFigure();

        }

        static GraphicsPath obstacle = new GraphicsPath();
        static GraphicsPath playerPath = new GraphicsPath();
        static Region obstacleRegion;
        static Region playerRegion;

        Pen redPen = new Pen(Color.Red, 1);
        SolidBrush purpleBrush = new SolidBrush(Color.Purple);
                    
        protected override void OnPaint(PaintEventArgs e)
        {
            obstacleRegion = new Region(obstacle);
            playerRegion = new Region(playerPath);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            
            e.Graphics.FillRegion(purpleBrush, obstacleRegion);
            e.Graphics.DrawPath(redPen, obstacle);
             
            if (this.Spiller != null)
            {
                Spiller.draw(e.Graphics);
                playerPath = Spiller.PlayerPath();

                obstacleRegion.Intersect(playerRegion);

                if (!obstacleRegion.IsEmpty(e.Graphics))
                {
                    MessageBox.Show("game over");
                } 
            }
                
        }
    }
}
