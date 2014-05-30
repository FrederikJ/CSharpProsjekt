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
    /// Smiley.cs av Tommy Langhelle
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Smiley objekt klassen som bestemmer verdien på  hver smiley, lager nye smileyer og tegner dem
    /// </summary>
    class Smiley
    {
       private GraphicsPath smileyPath = new GraphicsPath();
       SolidBrush color;

        public int x;
        public int y;
        public int diameter = 30;
        public int Value { get; set; }

        /// <summary>
        /// Kontruktor, setter også verdien på dem og farge
        /// </summary>
        /// <param name="_x"></param>
        /// <param name="_y"></param>
        /// <param name="_value"></param>
        public Smiley(int _x, int _y, int _value)
        {
            x = _x;
            y = _y;
            smileyPath.StartFigure();
            smileyPath.AddEllipse(x, y, diameter, diameter);
            smileyPath.CloseFigure();

            switch (_value)
            {
                case 1:
                    color = new SolidBrush(Color.Yellow);
                    Value = 100;
                    break;
                case 2:
                    color = new SolidBrush(Color.Red);
                    Value = 150;
                    break;
                case 3:
                    color = new SolidBrush(Color.Blue);
                    Value = 200;
                    break;
                case 4:
                    color = new SolidBrush(Color.Green);
                    Value = 300;
                    break;
            }
        }

        /// <summary>
        /// Henter graphicspathen
        /// </summary>
        /// <returns></returns>
        public GraphicsPath GetPath()
        {
            return smileyPath;
        }

        /// <summary>
        /// Tegner smileyen
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g)
        {
            g.FillEllipse(color, x, y, diameter, diameter);
        }
    }
}
