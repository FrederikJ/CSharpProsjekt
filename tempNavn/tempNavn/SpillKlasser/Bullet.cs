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

            bulletPath.StartFigure();
            bulletPath.AddEllipse(x, y, diameter, diameter);
            bulletPath.CloseFigure();
        }

        public void Draw(Graphics g)
        {
            switch (direction)
            {
                case "up":
                    y = -dy;
                    break;
                case "down":
                    y = dy;
                    break;
                case "left":
                    x = -dx;
                    break;
                case "right":
                    x = dx;
                    break;
                default:
                    break;
            }

            g.FillEllipse(bulletColor, x, y, diameter, diameter);
        }
    }
}
