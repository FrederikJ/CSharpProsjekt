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
        private List<Canon> listOfCanons = new List<Canon>();
        private List<Bullet> listOfBulletsPoint = new List<Bullet>();

        static GraphicsPath startPlatform = new GraphicsPath();
        static GraphicsPath obstaclePath = new GraphicsPath();
        static GraphicsPath playerPath = new GraphicsPath();
        static GraphicsPath smileyPath = new GraphicsPath();
        static GraphicsPath canonPath = new GraphicsPath();
        static GraphicsPath bulletPath = new GraphicsPath();

        static Region platformRegion;
        static Region obstacleRegion;
        static Region playerRegion;
        static Region smileyRegion;
        static Region canonRegion;
        static Region bulletRegion;

        private Pen redPen = new Pen(Color.Red, 1);
        private SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        private SolidBrush WarningBrush = new SolidBrush(Color.Red);
        private SolidBrush canonBrush = new SolidBrush(Color.Orange);
        private SolidBrush bulletColor = new SolidBrush(Color.Black);

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

            listOfCanons.Add(new Canon(190, this.Height, "up"));
            listOfCanons.Add(new Canon(440, 0, "down"));
            listOfCanons.Add(new Canon(530, this.Height, "up"));
            listOfCanons.Add(new Canon(620, 110, "left"));

            listOfBulletsPoint.Add(new Bullet(200, this.Height - 30, "up"));
            listOfBulletsPoint.Add(new Bullet(450, 30, "down"));
            listOfBulletsPoint.Add(new Bullet(540, this.Height - 30, "up"));
            listOfBulletsPoint.Add(new Bullet(590, 120, "left"));
        }

        public void StopBalls()
        {
            Spiller.going = false;
        }

        void Timer_Tick(object sender, EventArgs e)
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
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
            Spiller = new Spiller(this);
        }

        public void StopSpiller()
        {
            Spiller.going = false;
            timer.Stop();
        }
        public Boolean PauseSpiller()
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

                    for (int i = 0; i < listOfCanons.Count; i++)
                    {
                        canonPath.AddPath(listOfCanons[i].canonPath, true);
                    }

                    foreach (Bullet b in listOfBulletsPoint)
                    {
                        bulletPath.AddPath(b.bulletPath, true);

                    }
                    runnedOnce = true;
                }

                platformRegion = new Region(startPlatform);
                obstacleRegion = new Region(obstaclePath);
                playerRegion = new Region(playerPath);
                smileyRegion = new Region(smileyPath);
                canonRegion = new Region(canonPath);
                bulletRegion = new Region(bulletPath);

                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                e.Graphics.FillRegion(purpleBrush, obstacleRegion);
                e.Graphics.DrawPath(redPen, obstaclePath);

                e.Graphics.FillRegion(purpleBrush, platformRegion);
                e.Graphics.DrawPath(redPen, startPlatform);

                e.Graphics.FillRegion(canonBrush, canonRegion);
                e.Graphics.DrawPath(redPen, canonPath);

                e.Graphics.FillRegion(bulletColor, bulletRegion);

                for (int i = 0; i < listOfSmileys.Count; i++)
                {
                    Smiley smiley = listOfSmileys[i];
                    smiley.Draw(e.Graphics);

                    //smileyPath = smiley.smileyPath();
                    smileyRegion = smiley.GetRegion();

                    /*if (checkCollision(smileyRegion, playerRegion, e))
                    {
                        listOfSmileys.RemoveAt(i);
                    }*/
                }

                if (this.Spiller != null)
                {
                    Spiller.draw(e.Graphics);
                    playerPath = Spiller.PlayerPath();

                    if (CheckCollision(obstacleRegion, playerRegion, e) || CheckCollision(canonRegion, playerRegion, e))
                    {
                        Spiller.Collision();
                    }
                }   
            }
        }
        private Boolean CheckCollision(Region _region1, Region _region2, PaintEventArgs e)
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
