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
    class Canon
    {
        public GraphicsPath canonPath = new GraphicsPath();
        private static GraphicsPath bulletPath = new GraphicsPath();
        private static Region bulletRegion = new Region(bulletPath);
        private static SolidBrush canonColor = new SolidBrush(Color.Orange);
        private static SolidBrush bulletColor = new SolidBrush(Color.Black);
        
        private Point[] canonPoints;
        private Object mySync = new Object();
        private ThreadStart ts;
        private Thread thread;
        private int dx = 0;
        private int dy = 0;
        private static float diameter = 5.0f;

        public static int X { get; set; }
        public static int Y { get; set; }
        public bool going { get; set; }

        public Canon(int startX, int startY, string direction)
        {
            X = startX;
            Y = startY;

            direction.ToLower();

            switch(direction)
            {
                case "up":
                    this.PointUp(startX, startY);
                    break;
                case "down":
                    this.PointDown(startX, startY);
                    break;
                case "left":
                    this.PointLeft(startX, startY);
                    break;
                case "right":
                    this.PointRight(startX, startY);
                    break;
                default:
                    break;
            }
        }

        public void PointLeft(int x, int y)
        {
            canonPoints = new Point[3];

            canonPoints[0] = new Point(x, y);
            canonPoints[1] = new Point(x - 30, y + 10);
            canonPoints[2] = new Point(x, y + 20);

            canonPath.StartFigure();
            canonPath.AddLines(canonPoints);
            canonPath.CloseFigure();

            X = canonPoints[1].X;
            Y = canonPoints[1].Y;
            dx = -2;

            this.ThreadStart();
        }

        public void PointRight(int x, int y)
        {
            canonPoints = new Point[3];

            canonPoints[0] = new Point(x, y);
            canonPoints[1] = new Point(x + 30, y + 10);
            canonPoints[2] = new Point(x, y + 20);

            canonPath.StartFigure();
            canonPath.AddLines(canonPoints);
            canonPath.CloseFigure();

            X = canonPoints[1].X;
            Y = canonPoints[1].Y;
            dx = 2;

            this.ThreadStart();
        }

        public void PointUp(int x, int y)
        {
            canonPoints = new Point[3];

            canonPoints[0] = new Point(x, y);
            canonPoints[1] = new Point(x + 10, y - 30);
            canonPoints[2] = new Point(x + 20, y);

            canonPath.StartFigure();
            canonPath.AddLines(canonPoints);
            canonPath.CloseFigure();

            X = canonPoints[1].X;
            Y = canonPoints[1].Y;
            dy = -2;

            this.ThreadStart();
        }

        public void PointDown(int x, int y)
        {
            canonPoints = new Point[3];

            canonPoints[0] = new Point(x, y);
            canonPoints[1] = new Point(x + 10, y + 30);
            canonPoints[2] = new Point(x + 20, y);

            canonPath.StartFigure();
            canonPath.AddLines(canonPoints);
            canonPath.CloseFigure();

            X = canonPoints[1].X;
            Y = canonPoints[1].Y;
            dy = 2;

            this.ThreadStart();
        }
            
        public static SolidBrush GetColor()
        {
            return canonColor;
        }

        public GraphicsPath GetPath()
        {
            return canonPath;
        }

        public static void Draw(Graphics g)
        {
            g.FillEllipse(bulletColor, float.Parse(X.ToString()), float.Parse(Y.ToString()), diameter, diameter);
        }

        //Bestemmer hastigheten ballene beveger seg i.
        public void Run()
        {
            while (going)
            {
                try
                {
                    lock (mySync)
                    {
                        X += dx;
                        Y += dy;
                        Thread.Sleep(50);
                    }
                }
                catch(ThreadStartException ex)
                {
                    ex.ToString();
                }
            }
        }

        public static GraphicsPath GetBulletPath()
        {
            bulletPath.StartFigure();
            bulletPath.AddEllipse(X, Y, diameter, diameter);
            bulletPath.CloseFigure();

            return bulletPath;
        }

        public void ThreadStart()
        {
            ts = new ThreadStart(Run);
            thread = new Thread(ts);

            going = true;
            thread.IsBackground = true;
            thread.Start();
        }
    }
}