using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CSharpProsjekt.SpillKlasser
{
    /// <summary>
    /// Bullet.cs av Frederik Johnsen
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Kule objekt klassen våres. 
    /// </summary>
    class Bullet
     {
        //Størrelse:
        public float diameter { get; set; }
        //Startpunkt
        public int x { get; set; }
        public int y { get; set; }
        //Fart
        private int dx;
        private int dy;
        //Rettning
        private string direction;

        public bool keepGoing { get; set; }
        private static SolidBrush bulletColor = new SolidBrush(Color.Black);

        /// <summary>
        /// Konstruktoren, opprette en ny kule
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        public Bullet(int x, int y, string direction)
        {
            diameter = 5;
            this.x = x;
            this.y = y;
            dx = 1;
            dy = 1;
            keepGoing = true;
            this.direction = direction;
            direction.ToLower();
        }

        /// <summary>
        /// Velge hvilken retning den går også sette fart på den nårværende posisjonen til ballen
        /// </summary>
        /// <param name="g"></param>
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
