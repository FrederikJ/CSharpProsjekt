using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

/*
 * HiN - Vårsemester 2014
 * Programmering 3
 * Obligatorisk Innlevering 4
 * 
 * Skrevet av:
 * Tommy Langhelle
 */

namespace tempNavn.SpillKlasser
{
    class Spiller
    {
        //Størrelse:
        private float diameter = 20.0f;
        //Posisjon:
        private float x = 0.0f;
        private float y = 0.0f;
        //Gravitasjon ( y-retning):
        private float dy = 0.3f;
        //retningsendring(piltaster)
        private float Adx = 1.0f;
        private float Ady = 1.0f;
        private float AdyUP = 2.0f;

        public bool going { get; set; }
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
        #region Tyngdekraft
        public void Tyngdekraft()
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
                //game over
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
    }
}