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
        private Object mySync = new Object();
        private Spiller Spiller;

        private List<Obstacle> listOfObstacles = new List<Obstacle>();
        private List<Smiley> listOfSmileys = new List<Smiley>();

        static GraphicsPath startPlatform = new GraphicsPath();
        static GraphicsPath obstaclePath = new GraphicsPath();
        static GraphicsPath playerPath = new GraphicsPath();
        static GraphicsPath smileyPath = new GraphicsPath();
        static Region platformRegion;
        static Region obstacleRegion;
        static Region playerRegion;
        static Region smileyRegion;

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

            //Må sittes her for at .heigth og .width skal returnere riktig verdi.
            this.Size = new System.Drawing.Size(728, 404);

            Thread thread = new Thread(DrawLoop);
            thread.IsBackground = true;
            thread.Start();

            Rectangle start = new Rectangle(0, 25, 30, 5);
            startPlatform.AddRectangle(start);
            startPlatform.CloseFigure();

            listOfObstacles.Add(new Obstacle(500,180,200,70, 50, 180));
            listOfObstacles.Add(new Obstacle(70, 180, 150, 100, 300, -180));
            listOfObstacles.Add(new Obstacle(400, 70));
            listOfObstacles.Add(new Obstacle(620, 70, 30, 130));
            listOfObstacles.Add(new Obstacle(220, 200, 200, 70, 50, -150));
            listOfObstacles.Add(new Obstacle(400, 310, 100, 30));
            listOfObstacles.Add(new Obstacle(655, 110, 60, 30));
            listOfObstacles.Add(new Obstacle(290, 5, 20, 150));
            listOfObstacles.Add(new Obstacle(5, 110, 220, 20));


            listOfSmileys.Add(new Smiley(110, 280));
            listOfSmileys.Add(new Smiley(450, 250));
            listOfSmileys.Add(new Smiley(560, 213));
            listOfSmileys.Add(new Smiley(510, 65));
            listOfSmileys.Add(new Smiley(660, 75));
            listOfSmileys.Add(new Smiley(660, 145));
            listOfSmileys.Add(new Smiley(360, 65));
            listOfSmileys.Add(new Smiley(130, 140));
        }

        public void StopBalls()
        {
            Spiller.going = false;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lock(mySync)
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

            
        }

        public void AddSpiller()
        {
            timer.Interval = 10;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
            Spiller = new Spiller(this);
        }

         void DrawLoop()
        {
            this.Invalidate();
            Thread.Sleep(17);
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
            lock(mySync)
            {
                if (runnedOnce == false)
                {
                    for (int i = 0; i < listOfObstacles.Count; i++)
                    {
                        obstaclePath.AddPath(listOfObstacles[i].obstacle, true);
                    }
                   /* for (int i = 0; i < listOfSmileys.Count; i++)
                    {
                        //smileyPath.AddPath(listOfObstacles[i].obstacle, true);
                    }*/
                    runnedOnce = true;
                }

                platformRegion = new Region(startPlatform);
                obstacleRegion = new Region(obstaclePath);
                playerRegion = new Region(playerPath);
                smileyRegion = new Region(smileyPath);

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                e.Graphics.FillRegion(purpleBrush, obstacleRegion);
                e.Graphics.DrawPath(redPen, obstaclePath);

                e.Graphics.FillRegion(purpleBrush, platformRegion);
                e.Graphics.DrawPath(redPen, startPlatform);

                for (int i = 0; i < listOfSmileys.Count; i++)
                {
                    Smiley smiley = listOfSmileys[i];
                    smiley.draw(e.Graphics);
                    //smileyPath = smiley.smileyPath();
                    smileyRegion = smiley.getRegion();

                    if (checkCollision(smileyRegion, playerRegion, e))
                    {
                        listOfSmileys.RemoveAt(i);
                    } 
                }
             
                if (this.Spiller != null)
                {
                    Spiller.draw(e.Graphics);
                    playerPath = Spiller.PlayerPath();

                    if(checkCollision(obstacleRegion, playerRegion, e))
                    {
                        MessageBox.Show("game over");
                    }
                }   
            }
            
        }
        private Boolean checkCollision(Region _region1, Region _region2, PaintEventArgs e)
        {
            _region1.Intersect(_region2);

            if(!_region1.IsEmpty(e.Graphics))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
