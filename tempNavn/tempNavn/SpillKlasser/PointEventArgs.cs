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
        public int level { get; set; }
        public Boolean levelComplete { get; set; }

        public PointEventArgs(int _points, int _level, Boolean _levelComplete)
        {
            points = _points;
            level = _level;
            levelComplete = _levelComplete;

        }
    }
}
