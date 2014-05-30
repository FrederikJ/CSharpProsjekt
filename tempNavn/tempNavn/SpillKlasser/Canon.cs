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
    /// <summary>
    /// Canon.cs av Frederik Johnsen
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Kanon objekt klassen våres
    /// </summary>
    class Canon
    {
        public GraphicsPath canonPath = new GraphicsPath();
        private static SolidBrush canonColor = new SolidBrush(Color.WhiteSmoke);
        private Point[] canonPoints;
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// Konstruktoren, opprette en ny kanon, bestemme retningen til kanon og sende deg videre rett
        /// med start posisjon
        /// </summary>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="direction"></param>
        public Canon(int startX, int startY, string direction)
        {
            this.X = startX;
            this.Y = startY;

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


#region Tegner kanonene i riktig retning
        /// <summary>
        /// Tegne kanon og adder den til graphicspath i riktig retning
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void PointLeft(int x, int y)
        {
            canonPoints = new Point[3];

            canonPoints[0] = new Point(x, y);
            canonPoints[1] = new Point(x - 30, y + 10);
            canonPoints[2] = new Point(x, y + 20);

            canonPath.StartFigure();
            canonPath.AddLines(canonPoints);
            canonPath.CloseFigure();
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
        }
#endregion

        /// <summary>
        /// Get metode for fargen til kanonene. Slik at det er tilgjengelig globalt
        /// </summary>
        /// <returns></returns>
        public static SolidBrush GetColor()
        {
            return canonColor;
        }
    }
}