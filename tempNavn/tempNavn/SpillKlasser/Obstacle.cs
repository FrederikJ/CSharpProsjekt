using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProsjekt.SpillKlasser
{
    /// <summary>
    /// Obstacle.cs av Frederik Johnsen & Tommy Langhelle
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Her lager vi nye hindere og adder dem til graphicspathen som bare er til og hente ut
    /// </summary>
    class Obstacle
    {
        public GraphicsPath obstacle = new GraphicsPath();

        #region Konstruktorer
        public Obstacle(int x, int y, int width, int height, int startAngle, int sweepAngle)
        {
            obstacle.StartFigure();
            obstacle.AddArc(x, y, width, height, startAngle, sweepAngle);
            obstacle.AddLine(x + 50, y+ 66, x + 100, y + 150);
            obstacle.CloseFigure();
        }
        public Obstacle(int x, int y, int curve)
        {
            Point[] shape = {
            new Point (x, y),
            new Point (x, y + 70),
            new Point (x + 100, y + 70),
            new Point (x + 100, y),
            };
            obstacle.StartFigure();
            obstacle.AddCurve(shape, curve);
            obstacle.CloseFigure();
        }
        public Obstacle(int x, int y, int width, int height)
        {
            Rectangle rectangle = new Rectangle(x, y, width, height);
            obstacle.StartFigure();
            obstacle.AddRectangle(rectangle);
            obstacle.CloseFigure();
        }
        public Obstacle(int x, int y, int x1, int y1, int x2, int y2, int x3, int y3)
        {
            obstacle.StartFigure();
            obstacle.AddBezier(x, y, x1, y1, x2, y2, x3, y3);
            obstacle.CloseFigure();
        }
        public Obstacle(int x, int y)
        {
            Point[] shape = {
            new Point (x, y),
            new Point (x + 20, y + 10),
            new Point (x - 104, y + 70),
            new Point (x - 84, y + 80)
            };
            Point[] shape1 = {
            new Point (x, y + 160),
            new Point (x + 20, y + 170),
            new Point (x - 104, y - 70),
            new Point (x - 84, y - 80)
            };

            obstacle.StartFigure();
            obstacle.AddPolygon(shape);
            obstacle.AddPolygon(shape1);
            obstacle.CloseFigure();
        }
        public Obstacle(int x, int y, int x1, int y1, string polygon)
        {
            Point[] shape = {
            new Point (x, y),
            new Point (x + 20, y + 10),
            new Point (x1, y1),
            new Point (x1 + 20, y1 - 10)
            };

            obstacle.StartFigure();
            obstacle.AddPolygon(shape);
            obstacle.CloseFigure();
        }
        #endregion
    }  
}
