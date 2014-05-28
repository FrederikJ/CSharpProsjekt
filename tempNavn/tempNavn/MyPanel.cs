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
        private Boolean firstAttempt = true;
        private Boolean levelFinished = false;
        private Boolean gameOver = false;
        private int smileysRemaining;
        private int timeLeft = 60;
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

            LoadLevel();
        }

        public void StopBalls()
        {
            Spiller.going = false;
        }

        /// <summary>
        /// Metoden blir trigret hvert 10ms av timeren keyboardTimer og sjekker om pil opp, ned, venstre eller høyre er trykt. 
        /// Klassen KeyboardInfo blir brukt, dette er en ferdig klasse funnet på nettet som tilater oss å trykke flere taster ned samtidig. 
        /// </summary>
        void ReadKeyboard_Tick(object sender, EventArgs e)
        {
            var left = KeyboardInfo.GetKeyState(Keys.Left);
            var right = KeyboardInfo.GetKeyState(Keys.Right);
            var up = KeyboardInfo.GetKeyState(Keys.Up);
            var down = KeyboardInfo.GetKeyState(Keys.Down);

            if (left.IsPressed)
            {
                Spiller.MoveLeft();
            }

            if (right.IsPressed)
            {
                Spiller.MoveRight();
            }

            if (up.IsPressed)
            {
                Spiller.MoveUp();
            }

            if (down.IsPressed)
            {
                Spiller.MoveDown();
            } 
        }

        //Timeren countdownTimer trigrer denne metoden hvert sekund. 
        //Metoden oppretter så instans av custom EventArgs TimeEventArgs og sender med int verdien timeLeft(som er resterende sekunder) i delegaten TimeEndret.
        //BallSpill.cs abonnerer på delegaten        
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
                gameOver = true;
            }
        }

        void Interval_Tick(object sender, EventArgs e)
        {
            int i = rnd.Next(0, 4);

            listOfBullets = loadLevel.GetBullets(i);
        }

        public void StartGame()
        {
            if (firstAttempt)
            {
                keyboardTimer.Interval = 10;
                keyboardTimer.Tick += new EventHandler(ReadKeyboard_Tick);
                keyboardTimer.Start();

                countdownTimer.Interval = 1000;
                countdownTimer.Tick += new EventHandler(Countdown_Tick);
                
                bulletTimer.Interval = rnd.Next(500, 1000);
                bulletTimer.Tick += new EventHandler(Interval_Tick);
                
                firstAttempt = false;
            }

            StartTimers();
            points = 0;
            Spiller = new Spiller(this);
        }

        public Boolean PauseGame()
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

        public void StopGame()
        {
            keyboardTimer.Stop();
            bulletTimer.Stop();
            countdownTimer.Stop();
            ClearPanel();
            Spiller = null;
        }

        public void NewGame()
        {
            
            gameOver = false;
            level = 1;

            ClearPanel();
            LoadLevel();
        }

      

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if(gameOver)
            {
                StopGame();
                obstaclePath.AddString("Game Over", new FontFamily("Showcard Gothic"), (int)(FontStyle.Bold | FontStyle.Italic), 120, new Point(5, 100), StringFormat.GenericTypographic);
                obstacleRegion = new Region(obstaclePath);
            }

            //Denne kodesnutten blir bare kjørt en gang for hver level. Obstacles og canons har ingen behov for å bli tegnet i hver OnPaint ettersom de er statisk.
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

            //Fyller regions med farge, og tegner omriss. SmoothingMode sørger for et finere og glattere utseende på tegninger
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.FillRegion(purpleBrush, obstacleRegion);
            g.DrawPath(redPen, obstaclePath);

            g.FillRegion(purpleBrush, platformRegion);
            g.DrawPath(redPen, startPlatform);

            g.FillRegion(Canon.GetColor(), canonRegion);

            if (this.Spiller != null)
            {
                Spiller.draw(g);

                //Sjekker om det er flere gule smileyer igjen og at tiden ikke har gått ut. 
                //levelFinished sørger for at diverse if setninger bare kjører en gang, samt verdien blir sendt videre via en delegat til BallSpill.cs
                if (smileysRemaining == 0 && timeLeft > 0 && levelFinished == false)
                {
                    level++;
                    countdownTimer.Stop();
                    keyboardTimer.Enabled = false;
                    levelFinished = true;

                    points += timeLeft * 2;

                    UpdatePoints();
                    Spiller.ResetPosition();
                    ClearPanel();
                }

                Spiller.draw(g);

                //Sjekker at spillet fortsatt går
                if(levelFinished == false)
                {
                    //kjører igjennom hvert objekt i listOfBullets og printer disse til skjermen. Sjekker også collision mot obstacles og spiller
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
                            gameOver = true;
                        }
                        if (CheckCollision(bulletPath, obstaclePath, e) || bullet.x > this.Width || bullet.y > this.Height || bullet.x < 0 || bullet.y < 0)
                        {
                            listOfBullets.RemoveAt(i);
                        }
                    }
                }
                //Kjører igjennom hvert objekt i listOfSmileys og printer disse til skjermen. Sjekker også collision mot spiller.
                for (int i = 0; i < listOfSmileys.Count; i++)
                {
                    Smiley smiley = listOfSmileys[i];

                    smiley.Draw(g);

                    if (CheckCollision(smiley.GetPath(), Spiller.GetPath(), e))
                    {
                        listOfSmileys.RemoveAt(i);
                        points += smiley.GetValue();

                        //Sjekker om smileyen er gul, for så å fjerne en count fra int variabelen smileysRemaining.
                        if (smiley.GetValue() == 100)
                            smileysRemaining--;

                        if (smiley.GetValue() == 150)
                            Spiller.ReverseGravity();

                        UpdatePoints();
                    }
                }

                //Sender spiller tilbake til start om det blir detected collision mot obstacle eller canon.
                if (CheckCollision(obstaclePath, Spiller.GetPath(), e) || CheckCollision(canonPath, Spiller.GetPath(), e))
                {
                    Spiller.ResetPosition();
                    points -= 75;

                    UpdatePoints();
                }
            }   
        }
        /// <summary>
        /// Sjekker og region1 og region2 kolliderer. Om region1 ikke er tom etter .Intersect har det vert en kollisjon
        /// </summary>
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
        
        /// <summary>
        /// fyller opp loadLevel objektet Level med int level som parameter. 
        /// En Switch case i Level klassen fyller tabeller med riktig info som blir tilgjengelig via get metoder
        /// Tiden blir startet og levelFinished blir satt til false, slik at diverse if setninger i onPaint blir true.
        /// </summary>
        public void LoadLevel()
        {
            StartPlatform();
            loadLevel = new Level(level);

            timeLeft = loadLevel.GetTimeLeft();
            listOfObstacles = loadLevel.GetObstacles();
            listOfCanons = loadLevel.GetCanons();
            listOfSmileys = loadLevel.GetSmileys();

            //Teller antall gule smileyer i listOfSmileys, ettersom alle andre smileyer er valgfrie. smileysRemaining brukes senere for å sjekke om alle gule smileyer er tatt.
            smileysRemaining = 0;
            foreach (Smiley s in listOfSmileys)
                if (s.value == 100)
                    smileysRemaining++;

            runnedOnce = false;
            levelFinished = false;
        }

        /// <summary>
        /// Alle lister med objekter blir tømt, samt graphicsPath og regions. timer for keyboardinput og countdown stoppes.
        /// </summary>
        private void ClearPanel()
        {
            listOfObstacles.Clear();
            listOfCanons.Clear();
            listOfSmileys.Clear();
            listOfBullets.Clear();

            obstaclePath.Reset();
            startPlatform.Reset();
            canonPath.Reset();

            obstacleRegion.MakeEmpty();
            platformRegion.MakeEmpty();
            canonRegion.MakeEmpty();

            keyboardTimer.Enabled = false;
            countdownTimer.Stop();
        }
        public void StartTimers()
        {
            bulletTimer.Start();
            countdownTimer.Start();

            keyboardTimer.Enabled = true;
        }

        /// <summary>
        /// Egendefinert EventArgs PointEventArgs blir tildelt parametere, og sendt inn i delegatet PointsEndret. 
        /// Dette blir abonnert på i BallSpill.cs for å oppdatere panelet i bunn.
        /// </summary>
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
       
        /// <summary>
        /// Oppretter Obstacle i venstre hjørne hvor spilleren begynner oppå.
        /// </summary>
        private void StartPlatform()
        {
            Rectangle start = new Rectangle(0, 25, 30, 5);
            startPlatform.AddRectangle(start);
            startPlatform.CloseFigure();
        }
    } 
}
