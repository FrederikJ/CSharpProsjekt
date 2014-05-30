using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProsjekt.SpillKlasser
{
    /// <summary>
    /// PointEventArgs.cs av Tommy Langhelle
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Laget et nytt event for poeng slik at vi enkelt kunne ha den på en annen panel enn mypanel
    /// Spillet ser mer litt bedre og mer profosjonelt når alt ikke er proppet inn i samme panel
    /// </summary>
    public class PointEventArgs : EventArgs
    {
        public int Points { get; set; }
        public int Level { get; set; }
        public Boolean LevelComplete { get; set; }

        public PointEventArgs(int _points, int _level, Boolean _levelComplete)
        {
            Points = _points;
            Level = _level;
            LevelComplete = _levelComplete;
        }
    }
}
