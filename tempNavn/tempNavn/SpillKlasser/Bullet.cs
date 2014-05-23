using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpProsjekt.SpillKlasser
{
    class Bullet
     {
        //Størrelse:
        public float diameter;
        public float x;
        public float y;
        private float dx;
        private float dy;
        
        private string direction;
        public bool keepGoing { get; set; }
        public GraphicsPath bulletPath = new GraphicsPath();
        //private static Region bulletRegion = new Region(bulletPath);
        private static SolidBrush bulletColor = new SolidBrush(Color.Black);
        private Object mySync = new Object();
        
     
        public Bullet(float x, float y, string direction)
        {
            diameter = 5;
            this.x = x;
            this.y = y;
            dx = 1;
            dy = 1;
            keepGoing = true;
            this.direction = direction;
            direction.ToLower();

            ThreadStart ts = new ThreadStart(Run);
            Thread thread = new Thread(ts);
            thread.IsBackground = true;
            thread.Start();
        }

        public void PointLeft(float x, float y)
        {
            bulletPath.StartFigure();
            bulletPath.AddEllipse(x, y, diameter, diameter);
            bulletPath.CloseFigure();

            y = dy;
        }

        public void PointRight(float x, float y)
        {
            bulletPath.StartFigure();
            bulletPath.AddEllipse(x, y, diameter, diameter);
            bulletPath.CloseFigure();

            y = -dy;
        }

        public void PointUp(float x, float y)
        {
            bulletPath.StartFigure();
            bulletPath.AddEllipse(x, y, diameter, diameter);
            bulletPath.CloseFigure();

            x = dx;
        }

        public void PointDown(float x, float y)
        {
            bulletPath.StartFigure();
            bulletPath.AddEllipse(x, y, diameter, diameter);
            bulletPath.CloseFigure();

            x = -dx;
        }

        public void Run()
        {
            while (keepGoing)
            {
                Move();
                Thread.Sleep(10);
            }
    
        }
        public void Move()
        {
            lock (mySync)
            {
                switch (direction)
                {
                    case "up":
                        this.PointUp(x, y);
                        break;
                    case "down":
                        this.PointDown(x, y);
                        break;
                    case "left":
                        this.PointLeft(x, y);
                        break;
                    case "right":
                        this.PointRight(x, y);
                        break;
                    default:
                        break;
                }
                //Size panelSize = parentPanel.ClientRectangle.Size;
                
                /*if (x < 0)
                {
                    x = 0;
                    dx = -dx;
                }

                if (x + diameter >= panelSize.Width)
                {
                    x = panelSize.Width - diameter;
                    dx = -dx;
                }

                if (y < 0)
                {
                    y = 0;
                    dy = -dy;
                }

                if (y + diameter >= panelSize.Height)
                {
                    y = panelSize.Height - diameter;
                    dy = -dy;
                }*/
            }
        }
    }
}
