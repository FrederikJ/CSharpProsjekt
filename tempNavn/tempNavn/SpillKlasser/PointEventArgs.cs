using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProsjekt.SpillKlasser
{
    public class PointEventArgs : EventArgs
    {
        public int points { get; set; }

        public PointEventArgs(int _points)
        {
            points = _points;
        }
    }    
}
