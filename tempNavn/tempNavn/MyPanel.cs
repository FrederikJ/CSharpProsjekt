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
    public delegate void TimeEndringEvent(Object sender, TimeEventArgs e);
    public delegate void PointEndringEvent(Object sender, PointEventArgs e);

    public partial class MyPanel : Panel
    {
        public event TimeEndringEvent TimeEndret;
        public event PointEndringEvent PointsEndret;

        private Object mySync = new Object();
        private Spiller Spiller;

        private List<Obstacle> listOfObstacles = new List<Obstacle>();
        private List<Smiley> listOfSmileys = new List<Smiley>();
        private List<Canon> listOfCanons = new List<Canon>();

        static GraphicsPath startPlatform = new GraphicsPath();
        static GraphicsPath obstaclePath = new GraphicsPath();
        static GraphicsPath playerPath = new GraphicsPath();
        static GraphicsPath smileyPath = new GraphicsPath();
        static GraphicsPath canonPath = new GraphicsPath();
        static GraphicsPath bulletPath = new GraphicsPath();

        static Region platformRegion;
        static Region obstacleRegion;
        static Region canonRegion;

        private Pen redPen = new Pen(Color.Red, 1);
        private SolidBrush purpleBrush = new SolidBrush(Color.Purple);

        private Boolean runnedOnce = false;
        private int smileysRemaining;

        private int timeLeft = 60;
        private int points;

        private System.Windows.Forms.Timer keyboardTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer countdownTimer = new System.Windows.Forms.Timer();

        public MyPanel()
        {
            //Må sittes her for at .heigth og .width skal returnere riktig verdi.
            this.Size = new System.Drawing.Size(728, 404);

            //sørger for at grafikken går smooth
            this.SetStyle(ControlStyles.DoubleBuffer |
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint,
              true);
            this.UpdateStyles();

            StartPlatform();
            LevelOne();

            foreach(Smiley s in listOfSmileys)
                if (s.value == 50)
                    smileysRemaining++;
        }

        public void StopBalls()
        {
            Spiller.going = false;
        }

        void ReadKeyboard_Tick(object sender, EventArgs e)
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

        void Countdown_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                try
                {
                    TimeEventArgs te = new TimeEventArgs(timeLeft);
                    TimeEndret(this, te);
                }
                catch (System.NullReferenceException exp)
                {
                    MessageBox.Show(string.Format("error: {0}", exp.ToString()));
                }
            }
            else
            {
                MessageBox.Show("Game over!");
            }
        }

        public void AddSpiller()
        {
            keyboardTimer.Interval = 10;
            keyboardTimer.Tick += new EventHandler(ReadKeyboard_Tick);
            keyboardTimer.Start();

            countdownTimer.Interval = 1000;
            countdownTimer.Tick += new EventHandler(Countdown_Tick);
            countdownTimer.Start();

            Spiller = new Spiller(this);
        }

        public void StopSpillet()
        {
            Spiller.going = false;
            keyboardTimer.Stop();
            countdownTimer.Stop();
            
        }

        public Boolean PauseSpiller()
        {
            if (keyboardTimer.Enabled == true)
            {
                keyboardTimer.Enabled = false;
                Spiller.going = false;
                return false;
            }

            else
            {
                keyboardTimer.Enabled = true;
                Spiller.going = true;
                return true;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

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

                platformRegion = new Region(startPlatform);
                obstacleRegion = new Region(obstaclePath);
                canonRegion = new Region(canonPath);

                runnedOnce = true;
            }

            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.FillRegion(purpleBrush, obstacleRegion);
            g.DrawPath(redPen, obstaclePath);

            g.FillRegion(purpleBrush, platformRegion);
            g.DrawPath(redPen, startPlatform);

            g.FillRegion(Canon.GetColor(), canonRegion);

            if (this.Spiller != null)
            {
                if (smileysRemaining == 0)
                {
                    points += timeLeft * 2;
                    //MessageBox.Show("You won!");
                    UpdatePoints();
                    StopSpillet();

                }

                Spiller.draw(g);

                for (int i = 0; i < listOfSmileys.Count; i++)
                {
                    Smiley smiley = listOfSmileys[i];

                       
                    smiley.Draw(g);

                    if (CheckCollision(smiley.GetPath(), Spiller.GetPath(), e))
                    {
                        listOfSmileys.RemoveAt(i);
                        points += smiley.GetValue();

                        if(smiley.GetValue() == 50)
                            smileysRemaining--;

                        UpdatePoints();
                    }
                }
                if (CheckCollision(obstaclePath, Spiller.GetPath(), e) || CheckCollision(canonPath, Spiller.GetPath(), e))
                {
                    Spiller.Collision();
                    points -= 50;

                    UpdatePoints();
                }
            }   
        }
        private Boolean CheckCollision(GraphicsPath path1, GraphicsPath path2, PaintEventArgs e)
        {
            Region region1 = new Region(path1);
            Region region2 = new Region(path2);

            region1.Intersect(region2);

            if (!region1.IsEmpty(e.Graphics))
            {
                return true;
            }
            else
            {
                return false;
            }          
        }
        private void UpdatePoints()
        {
            try
            {
                PointEventArgs te = new PointEventArgs(points);
                PointsEndret(this, te);
            }
            catch (System.NullReferenceException exp)
            {
                MessageBox.Show(string.Format("error: {0}", exp.ToString()));
            }
        }
        private void LevelOne()
        {
            listOfObstacles.Add(new Obstacle(500, 180, 200, 70, 50, 180));
            listOfObstacles.Add(new Obstacle(70, 180, 150, 100, 300, -180));
            listOfObstacles.Add(new Obstacle(400, 70));
            listOfObstacles.Add(new Obstacle(620, 70, 30, 130));
            listOfObstacles.Add(new Obstacle(220, 200, 200, 70, 50, -150));
            listOfObstacles.Add(new Obstacle(400, 310, 100, 30));
            listOfObstacles.Add(new Obstacle(655, 110, 60, 30));
            listOfObstacles.Add(new Obstacle(290, 5, 20, 150));
            listOfObstacles.Add(new Obstacle(5, 110, 220, 20));

            listOfSmileys.Add(new Smiley(110, 280, 1));
           /* listOfSmileys.Add(new Smiley(450, 250, 1));
            listOfSmileys.Add(new Smiley(560, 213, 2));
            listOfSmileys.Add(new Smiley(510, 65, 1));
            listOfSmileys.Add(new Smiley(660, 75, 1));
            listOfSmileys.Add(new Smiley(660, 145, 2));
            listOfSmileys.Add(new Smiley(360, 65, 2));
            listOfSmileys.Add(new Smiley(130, 140, 1));*/
            listOfSmileys.Add(new Smiley(5, 40, 2));

            listOfCanons.Add(new Canon(190, this.Height, "up"));
            listOfCanons.Add(new Canon(440, 0, "down"));
            listOfCanons.Add(new Canon(530, this.Height, "up"));
            listOfCanons.Add(new Canon(620, 110, "left"));
        }
        private void StartPlatform()
        {
            Rectangle start = new Rectangle(0, 25, 30, 5);
            startPlatform.AddRectangle(start);
            startPlatform.CloseFigure();
        }
    }
    
}
