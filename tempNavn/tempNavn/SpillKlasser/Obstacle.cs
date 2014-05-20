using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProsjekt.SpillKlasser
{
    class Obstacle
    {
        public GraphicsPath obstacle = new GraphicsPath();

        public Obstacle(int _x, int _y, int _Width, int _height, int _startAngle, int _sweepAngle)
        {
            obstacle.StartFigure();
            obstacle.AddArc(_x, _y, _Width, _height, _startAngle, _sweepAngle);
            obstacle.AddLine(_x + 50, _y+ 66, _x + 100, _y + 150);
            obstacle.CloseFigure();
        }
        public Obstacle(int _x, int _y)
        {
            Point[] shape = {
            new Point (_x, _y),
            new Point (_x, _y + 70),
            new Point (_x + 100, _y + 70),
            new Point (_x + 100, _y),
            };
            obstacle.StartFigure();
            obstacle.AddCurve(shape, 3);
            obstacle.CloseFigure();
        }
        public Obstacle(int _x, int _y, int _Width, int _height)
        {
            Rectangle rectangle = new Rectangle(_x, _y, _Width, _height);
            obstacle.AddRectangle(rectangle);
            obstacle.CloseFigure();
        }
    }  
}
