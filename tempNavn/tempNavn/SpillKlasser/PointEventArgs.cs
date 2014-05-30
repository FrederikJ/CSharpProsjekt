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
    /// Laget et nytt event for poeng slik at vi enkelt kunne ha den på en annen panel enn myPanel
    /// Spillet ser litt bedre ut når alt ikke er i samme panel
    /// </summary>
    public class PointEventArgs : EventArgs
    {
        public int Points { get; set; }
        public int Level { get; set; }
        public Boolean LevelComplete { get; set; }
        public Boolean GameComplete { get; set; }

        public PointEventArgs(int _points, int _level, Boolean _levelComplete, Boolean _gameComplete)
        {
            Points = _points;
            Level = _level;
            LevelComplete = _levelComplete;
            GameComplete = _gameComplete;
        }
    }
}
