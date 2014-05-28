using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProsjekt.SpillKlasser
{
    class Smiley
    {
       private GraphicsPath smileyPath = new GraphicsPath();
       SolidBrush color;

        public int x;
        public int y;
        public int diameter = 30;
        public int value;

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
                    value = 100;
                    break;
                case 2:
                    color = new SolidBrush(Color.Red);
                    value = 150;
                    break;
                case 3:
                    color = new SolidBrush(Color.Blue);
                    value = 200;
                    break;
                case 4:
                    color = new SolidBrush(Color.Green);
                    value = 300;
                    break;
            }
        }

        public SolidBrush GetColor()
        {
            return color;
        }
        public int GetValue()
        {
            return value;
        }
        public GraphicsPath GetPath()
        {
            return smileyPath;
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(color, x, y, diameter, diameter);
        }
    }
}
