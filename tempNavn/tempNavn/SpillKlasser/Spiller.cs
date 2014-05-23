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
        private float y = 0.0f;
        //Gravitasjon ( y-retning):
        private float dy = 0.7f;
        //retningsendring(piltaster)
        private float Adx = 1.0f;
        private float Ady = 1.0f;
        private float AdyUP = 2.5f;
        //private Boolean stopGravity = false;

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

        #region Tyngdekraft
        public void Tyngdekraft()
        {
            lock (mySync)
            {
                while (y == 0.0f && x == 0.0f)
                {
                    y = 0.0f;
                    x = 0.0f;
                }

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
        #endregion

        #region navigasjonsmetoder
        public void MoveRight()
        {
            this.x += Adx;
        }

        public void MoveLeft()
        {
            this.x -= this.Adx;
        }

        public void MoveUp()
        {
            this.y -= this.AdyUP;
        }

        public void MoveDown()
        {
            this.y += this.Ady;
        }
        #endregion

        public void draw(Graphics g)
        {
            g.FillEllipse(Brush, x, y, diameter, diameter);
        }
        public void Collision()
        {
            x = 1;
            y = 1;
        }

    }
}