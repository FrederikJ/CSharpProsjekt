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
        private Level loadLevel;
        private Spiller Spiller;


        private List<Obstacle> listOfObstacles = new List<Obstacle>();
        private List<Smiley> listOfSmileys = new List<Smiley>();
        private List<Canon> listOfCanons = new List<Canon>();
        private List<Bullet> listOfBullets = new List<Bullet>();

        static GraphicsPath startPlatform = new GraphicsPath();
        static GraphicsPath obstaclePath = new GraphicsPath();
        static GraphicsPath canonPath = new GraphicsPath();

        static Region platformRegion;
        static Region obstacleRegion;
        static Region canonRegion;

        private Pen redPen = new Pen(Color.Red, 1);
        private SolidBrush purpleBrush = new SolidBrush(Color.Purple);
        private SolidBrush bulletBrush = new SolidBrush(Color.Black);

        private Random rnd = new Random();
        private Boolean runnedOnce = false;
        private Boolean levelFinished = false;
        private int smileysRemaining;
        private int timeLeft = 30;
        private int level = 1;
        private int points;

        private System.Windows.Forms.Timer keyboardTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer countdownTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer bulletTimer = new System.Windows.Forms.Timer();
        

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
            LoadLevel();

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
                countdownTimer.Stop();
                ClearLevel();
                StopSpillet();
                MessageBox.Show("Game over!");
            }
        }

        void Interval_Tick(object sender, EventArgs e)
        {
            int i = rnd.Next(0, 4);
            switch(i)
            {
                case 0:
                    listOfBullets.Add(new Bullet(200, 374, "up"));
                    break;
                case 1:
                    listOfBullets.Add(new Bullet(450, 30, "down"));
                    break;
                case 2:
                    listOfBullets.Add(new Bullet(540, 374, "up"));
                    break;
                case 3:
                    listOfBullets.Add(new Bullet(590, 120, "left"));
                    break;
                default:
                    break;
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

            bulletTimer.Interval = rnd.Next(500, 1000);
            bulletTimer.Tick += new EventHandler(Interval_Tick);
            bulletTimer.Start();

            Spiller = new Spiller(this);
        }

        public void StopSpillet()
        {
            Spiller.going = false;
            keyboardTimer.Stop();
            bulletTimer.Stop();
            countdownTimer.Stop();
        }

        public Boolean PauseSpiller()
        {
            if (keyboardTimer.Enabled == true)
            {
                keyboardTimer.Enabled = false;
                bulletTimer.Stop();
                countdownTimer.Stop();
                Spiller.going = false;
                return false;
            }

            else
            {
                keyboardTimer.Enabled = true;
                bulletTimer.Start();
                countdownTimer.Start();
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
                if (smileysRemaining == 0 && timeLeft > 0 && levelFinished == false)
                {
                    level++;
                    countdownTimer.Stop();
                    points = 0;
                    timeLeft = 60;
                    levelFinished = true;

                    points += timeLeft * 2;

                    UpdatePoints();
                    Spiller.ResetPosition();
                    ClearLevel();
                }

                Spiller.draw(g);

                for (int i = 0; i < listOfBullets.Count; i++)
                {
                    Bullet bullet = listOfBullets[i];

                    GraphicsPath bulletPath = new GraphicsPath();
                    bulletPath.StartFigure();
                    bulletPath.AddEllipse(bullet.x, bullet.y, bullet.diameter, bullet.diameter);
                    bulletPath.CloseFigure();

                    bullet.Draw(g);

                    if (CheckCollision(bulletPath, Spiller.GetPath(), e))
                    {
                        MessageBox.Show("Game Over");
                    }
                    if (CheckCollision(bulletPath, obstaclePath, e) || bullet.x > this.Width || bullet.y > this.Height || bullet.x < 0 || bullet.y < 0)
                    {
                        listOfBullets.RemoveAt(i);
                    }
                }

                for (int i = 0; i < listOfSmileys.Count; i++)
                {
                    Smiley smiley = listOfSmileys[i];

                    smiley.Draw(g);

                    if (CheckCollision(smiley.GetPath(), Spiller.GetPath(), e))
                    {
                        listOfSmileys.RemoveAt(i);
                        points += smiley.GetValue();

                        if (smiley.GetValue() == 50)
                            smileysRemaining--;

                        UpdatePoints();
                    }
                }

                if (CheckCollision(obstaclePath, Spiller.GetPath(), e) || CheckCollision(canonPath, Spiller.GetPath(), e))
                {
                    Spiller.ResetPosition();
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

        public void LoadLevel()
        {
            loadLevel = new Level(level);

            listOfObstacles = loadLevel.GetObstacles();
            listOfCanons = loadLevel.GetCanons();
            listOfSmileys = loadLevel.GetSmileys();
            listOfBullets = loadLevel.GetBullets();

            countdownTimer.Start();
        }
        private void ClearLevel()
        {
            listOfObstacles.Clear();
            listOfCanons.Clear();
            listOfSmileys.Clear();
            listOfBullets.Clear();

            obstaclePath.Reset();
            canonPath.Reset();

            obstacleRegion.MakeEmpty();
            canonRegion.MakeEmpty();
        }
        private void UpdatePoints()
        {
            try
            {
                PointEventArgs te = new PointEventArgs(points, level, levelFinished);
                PointsEndret(this, te);
            }
            catch (System.NullReferenceException exp)
            {
                MessageBox.Show(string.Format("error: {0}", exp.ToString()));
            }
        }
        private void StartPlatform()
        {
            Rectangle start = new Rectangle(0, 25, 30, 5);
            startPlatform.AddRectangle(start);
            startPlatform.CloseFigure();
        }
    } 
}
