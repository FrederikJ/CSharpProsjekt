using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

namespace CSharpProsjekt.SpillKlasser
{
    /// <summary>
    /// Spiller.cs av tommy Langhelle
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Her er spiller brikken objekt klasse. Settes gravitasjonen, også lagt inn at gravtasjonen
    /// kan snu seg på røde smileya, snu seg flere ganger også og starter egen tråd for spilleren
    /// </summary>
    class Spiller
    {
        //Størrelse:
        public float diameter { get; set; }
        //Posisjon:
        public float x { get; set; }
        public float y { get; set; }
        //Gravitasjon ( y-retning):
        private float dy = 0.7f;
        //retningsendring(piltaster)
        private float Adx = 1.0f;
        private float AdyDown = 1.0f;
        private float AdyUp = 2.5f;
        
        private Object mySync = new Object();
        private MyPanel parentPanel;

        private Brush Brush = new SolidBrush(Color.Wheat);
        Random rnd = new Random();

        private ThreadStart ts;
        public Thread thread;

        public Boolean GravityReversed { get; set; }
        public bool Going { get; set; }

        public Spiller(MyPanel _parentPanel)
        {
            x = 0.0f;
            y = 2.5f;
            diameter = 20.0f;

            GravityReversed = false;
            parentPanel = _parentPanel;

            //ligger metoden "run" inn i en thread.
            ts = new ThreadStart(Run);
            thread = new Thread(ts);

            Going = true;
            thread.IsBackground = true;
            thread.Start();
        }

        //Bestemmer hastigheten ballene beveger seg i.
        public void Run()
        {
            while(Going)
            {
                Tyngdekraft();
                Thread.Sleep(10);
            }
        }

        //Tegner figuren i graphicspathen også retunere den
        public GraphicsPath GetPath()
        {
           GraphicsPath playerPath = new GraphicsPath();
            
           playerPath.StartFigure();
           playerPath.AddEllipse(x, y, diameter, diameter);
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

                tempAdY = AdyDown;
                AdyDown = AdyUp;
                AdyUp = tempAdY;

                GravityReversed = true;
            }
            else
            {
                dy = 0.7f;

                tempAdY = AdyUp;
                AdyUp = AdyDown;
                AdyDown = tempAdY;

                GravityReversed = false;
            }
            
        }

        #region Tyngdekraft
        public void Tyngdekraft()
        {
            lock (mySync)
            {

                if (!(y < 6 && y > 4 && x < 20 && x >= 0))
                {
                    y += dy;
                    Size panelSize = parentPanel.ClientRectangle.Size;

                    if (x < 0)
                        x = 0;

                    if (x + diameter >= panelSize.Width)
                        x = panelSize.Width - diameter;

                    if (y < 0)
                        y = 0;

                    if (y + diameter >= panelSize.Height)
                    {
                        y = panelSize.Height - diameter;
                    }
                }
            } 
        }
        #endregion

        #region navigasjonsmetoder
        public void MoveRight()
        {
            this.x += Adx;
        }

        public void MoveLeft()
        {
            if(!(y < 5 && x < 2))
                this.x -= this.Adx;
        }

        public void MoveUp()
        {
            this.y -= this.AdyUp;
        }

        public void MoveDown()
        {
            if (!(y < 5 && x < 20))
                this.y += this.AdyDown;
        }
        #endregion

        //Tegner spilleren
        public void draw(Graphics g)
        {
            g.FillEllipse(Brush, x, y, diameter, diameter);
        }

        //Setter spilleren sin posisjon tilbake til start
        public void ResetPosition()
        {
            x = 0;
            y = 2.5f;
        }
    }
}