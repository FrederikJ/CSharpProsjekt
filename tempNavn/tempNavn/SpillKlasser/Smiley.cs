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
       public static GraphicsPath smiley = new GraphicsPath();
       static Region smileyRegion = new Region(smiley);
       SolidBrush color = new SolidBrush(Color.Yellow);

        public int x;
        public int y;
        public int diameter = 30;
        
        public Smiley(int _x, int _y)
        {
            x = _x;
            y = _y;
            smiley.StartFigure();
            smiley.AddEllipse(x, y, diameter, diameter);
            smiley.CloseFigure();
        }

        public SolidBrush getColor()
        {
            return color;
        }
        public Region getRegion()
        {
            return smileyRegion;
        }
       
        public GraphicsPath smileyPath()
        {
            return smiley;
        }
        public void draw(Graphics g)
        {
            g.FillEllipse(color, x, y, diameter, diameter);
        }
    }
}
