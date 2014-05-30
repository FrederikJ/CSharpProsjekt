using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace CSharpProsjekt.SpillKlasser
{
    /// <summary>
    /// Spiller.cs av tommy Langhelle
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Her er spiller brikken objekt klasse. Settes gravitasjonen, også lagt inn at gravtasjonen
    /// kan snu seg på røde smileya, snu seg flere ganger også og starter egen tråd for spilleren
    /// </summary>
    class Player
    {
        //Størrelse:
        public float Diameter { get; set; }
        //Posisjon:
        public float X { get; set; }
        public float Y { get; set; }

        public Boolean GravityReversed { get; set; }
        public bool going;

        //Gravitasjon ( y-retning):
        private float dy = 0.7f;
        //retningsendring(piltaster)
        private float aDx = 1.0f;
        private float aDyDown = 1.0f;
        private float aDyUp = 2.5f;
        
        private Object mySync = new Object();
        private MyPanel parentPanel;

        private Brush brush = new SolidBrush(Color.Wheat);
        private Random rnd = new Random();

        private ThreadStart ts;
        private Thread thread;

        public Player(MyPanel _parentPanel)
        {
            X = 0.0f;
            Y = 2.5f;
            Diameter = 20.0f;

            GravityReversed = false;
            parentPanel = _parentPanel;

            //ligger metoden "run" inn i en thread.
            ts = new ThreadStart(Run);
            thread = new Thread(ts);

            going = true;
            thread.IsBackground = true;
            thread.Start();
        }

        //Bestemmer hastigheten ballene beveger seg i.
        public void Run()
        {
            while(going)
            {
                Gravity();
                Thread.Sleep(10);
            }
        }

        //Tegner figuren i graphicspathen også retunere den
        public GraphicsPath GetPath()
        {
           GraphicsPath playerPath = new GraphicsPath();
            
           playerPath.StartFigure();
           playerPath.AddEllipse(X, Y, Diameter, Diameter);
           playerPath.CloseFigure();

           return playerPath;
        }

        //Reversere den nåværende gravitasjonen
        public void ReverseGravity()
        {
            float tempAdY;

            if(GravityReversed == false)
            {
                dy = -0.7f;

                tempAdY = aDyDown;
                aDyDown = aDyUp;
                aDyUp = tempAdY;

                GravityReversed = true;
            }
            else
            {
                dy = 0.7f;

                tempAdY = aDyUp;
                aDyUp = aDyDown;
                aDyDown = tempAdY;

                GravityReversed = false;
            }
            
        }

        //Tegner spilleren
        public void Draw(Graphics g)
        {
            g.FillEllipse(brush, X, Y, Diameter, Diameter);
        }

        //Setter spilleren sin posisjon tilbake til start
        public void ResetPosition()
        {
            X = 0;
            Y = 2.5f;
        }

#region Thread metods
        /// <summary>
        /// Vi opprettet disse for puse knappen. Prøvde først med å bare sette going er false, men da kjørte threaden Run metoden ferdig, så selv om 
        /// vi satt going til true, så var metoden allerede ferdig å den kjørte ikke igjen, så vi fan løsningen med å terminere og starte tråden igjen
        /// </summary>
        public void ThreadStop()
        {
            thread.Abort();
        }

        public void ThreadStart()
        {
            ts = new ThreadStart(Run);
            thread = new Thread(ts);
            thread.IsBackground = true;
            thread.Start();
        }
#endregion

#region Tyngdekraft
        public void Gravity()
        {
            lock (mySync)
            {

                if (!(Y < 6 && Y > 4 && X < 20 && X >= 0))
                {
                    Y += dy;
                    Size panelSize = parentPanel.ClientRectangle.Size;

                    if (X < 0)
                        X = 0;

                    if (X + Diameter >= panelSize.Width)
                        X = panelSize.Width - Diameter;

                    if (Y < 0)
                        Y = 0;

                    if (Y + Diameter >= panelSize.Height)
                    {
                        Y = panelSize.Height - Diameter;
                    }
                }
            }
        }
#endregion

#region Navigasjons metoder
        public void MoveRight()
        {
            this.X += aDx;
        }

        public void MoveLeft()
        {
            if (!(Y < 5 && X < 2))
                this.X -= this.aDx;
        }

        public void MoveUp()
        {
            this.Y -= this.aDyUp;
        }

        public void MoveDown()
        {
            if (!(Y < 5 && X < 20))
                this.Y += this.aDyDown;
        }
#endregion
    }
}