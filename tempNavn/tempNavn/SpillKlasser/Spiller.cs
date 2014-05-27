using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Drawing2D;

/*
 * HiN - Vårsemester 2014
 * Programmering 3
 * Obligatorisk Innlevering 4
 * 
 * Skrevet av:
 * Tommy Langhelle
 */

namespace CSharpProsjekt.SpillKlasser
{
    class Spiller
    {
        //Størrelse:
        private float diameter = 20.0f;
        //Posisjon:
        private float x = 0.0f;
        private float y = 2.5f;
        //Gravitasjon ( y-retning):
        private float dy = 0.7f;
        //retningsendring(piltaster)
        private float Adx = 1.0f;
        private float AdyDown = 1.0f;
        private float AdyUp = 2.5f;
        private Boolean gravityReversed = false;

        public bool going { get; set; }

        private Object mySync = new Object();

        private Brush Brush = new SolidBrush(Color.Red);
        Random rnd = new Random();

        private MyPanel parentPanel;

        private ThreadStart ts;
        private Thread thread;

        public Spiller(MyPanel _parentPanel)
        {
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
            while (going)
            {
                Tyngdekraft();
                Thread.Sleep(10);
            }
        }
        public void Pause()
        {
            if (going == true)
                going = false;

            else
            {
                going = true;
            }

        }
        public GraphicsPath GetPath()
        {
           GraphicsPath playerPath = new GraphicsPath();
            
           playerPath.StartFigure();
           playerPath.AddEllipse(x, y, diameter, diameter);
           playerPath.CloseFigure();

           return playerPath;
        }

        public void ReverseGravity()
        {
            float tempAdY;

            if(gravityReversed == false)
            {
                dy = -0.7f;

                tempAdY = AdyDown;
                AdyDown = AdyUp;
                AdyUp = tempAdY;

                gravityReversed = true;
            }
            else
            {
                dy = 0.7f;

                tempAdY = AdyUp;
                AdyUp = AdyDown;
                AdyDown = tempAdY;

                gravityReversed = false;
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

        public void draw(Graphics g)
        {
            g.FillEllipse(Brush, x, y, diameter, diameter);
        }

        public void ResetPosition()
        {
            x = 0;
            y = 2.5f;
        }
    }
}