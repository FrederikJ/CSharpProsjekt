using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpProsjekt.SpillKlasser
{
    class Bullet
     {
        //Størrelse:
        public float diameter { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        private int originalX;
        private int originalY;
        private int dx;
        private int dy;
        private string direction;

        public bool keepGoing { get; set; }
        private static SolidBrush bulletColor = new SolidBrush(Color.Black);

        public Bullet(int x, int y, string direction)
        {
            diameter = 5;
            originalX = x;
            originalY = y;
            this.x = x;
            this.y = y;
            dx = 1;
            dy = 1;
            keepGoing = true;
            this.direction = direction;
            direction.ToLower();
        }
        public void ResetPosition()
        {
            x = originalX;
            y = originalY;
        }

        public void Draw(Graphics g)
        {
            switch (direction)
            {
                case "up":
                    y += -dy;
                    break;
                case "down":
                    y += dy;
                    break;
                case "left":
                    x += -dx;
                    break;
                case "right":
                    x += dx;
                    break;
                default:
                    break;
            }

            g.FillEllipse(bulletColor, x, y, diameter, diameter);
        }
    }
}
