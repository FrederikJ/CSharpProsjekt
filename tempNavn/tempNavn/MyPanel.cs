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
        private Obstacle obstacle;
        private Spiller Spiller;
        private List<Obstacle> listOfObstacles = new List<Obstacle>();

        static GraphicsPath startPlatform = new GraphicsPath();
        static GraphicsPath obstaclePath = new GraphicsPath();
        static GraphicsPath playerPath = new GraphicsPath();
        static Region platformRegion;
        static Region obstacleRegion;
        static Region playerRegion;

        private Pen redPen = new Pen(Color.Red, 1);
        private SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        private SolidBrush WarningBrush = new SolidBrush(Color.Red);

        private Boolean runnedOnce = false;

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public MyPanel()
        {
            //sørger for at grafikken går smooth
            this.SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint,
              true);
            this.UpdateStyles();

            Rectangle start = new Rectangle(0, 25, 30, 5);
            startPlatform.AddRectangle(start);
            startPlatform.CloseFigure();

            listOfObstacles.Add(new Obstacle(500,180,200,70, 50, 180));
            listOfObstacles.Add(new Obstacle(70, 180, 150, 100, 300, -180));
            listOfObstacles.Add(new Obstacle(400, 70));
            listOfObstacles.Add(new Obstacle(620, 70, 30, 130));
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
        protected override void OnPaint(PaintEventArgs e)
        {
            if (runnedOnce == false)
            {
                for (int i = 0; i < listOfObstacles.Count; i++)
                {
                    obstaclePath.AddPath(listOfObstacles[i].obstacle, true);
                }
                runnedOnce = true;
            }

            platformRegion = new Region(startPlatform);
            obstacleRegion = new Region(obstaclePath);
            playerRegion = new Region(playerPath);

            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            e.Graphics.FillRegion(purpleBrush, obstacleRegion);
            e.Graphics.DrawPath(redPen, obstaclePath);

            e.Graphics.FillRegion(purpleBrush, platformRegion);
            e.Graphics.DrawPath(redPen, startPlatform);
             
            if (this.Spiller != null)
            {
                Spiller.draw(e.Graphics);
                playerPath = Spiller.PlayerPath();

                platformRegion.Intersect(playerRegion);

                if(!platformRegion.IsEmpty(e.Graphics))
                {
                    Spiller.collosionPlatform();
                }
           
                obstacleRegion.Intersect(playerRegion);

                if (!obstacleRegion.IsEmpty(e.Graphics))
                {
                    MessageBox.Show("game over");
                    //e.Graphics.FillRegion(WarningBrush, obstacleRegion);
                } 
            }
                
        }
    }
}
