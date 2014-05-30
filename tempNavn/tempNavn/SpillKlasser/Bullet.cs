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
        public float Diameter { get; set; }
        //Startpunkt
        public int X { get; set; }
        public int Y { get; set; }
        //Fart
        private int dx;
        private int dy;
        //Rettning
        private string direction;

        public bool KeepGoing { get; set; }
        private static SolidBrush bulletColor = new SolidBrush(Color.Black);

        /// <summary>
        /// Konstruktoren, opprette en ny kule
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        public Bullet(int x, int y, string direction)
        {
            Diameter = 5;
            this.X = x;
            this.Y = y;
            dx = 1;
            dy = 1;
            KeepGoing = true;
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
                    Y += -dy;
                    break;
                case "down":
                    Y += dy;
                    break;
                case "left":
                    X += -dx;
                    break;
                case "right":
                    X += dx;
                    break;
                default:
                    break;
            }

            g.FillEllipse(bulletColor, X, Y, Diameter, Diameter);
        }
    }
}
