using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProsjekt.SpillKlasser
{
    /// <summary>
    /// FPSEventArgs.cs av Tommy Langhelle
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Laget et nytt event for FPS slik at vi enkelt kunne ha den på en annen panel enn mypanel
    /// Spillet ser litt bedre ut når alt ikke er i samme panel
    /// </summary>
    public class FPSEventArgs
    {
        public double FPS { get; set; }

        public FPSEventArgs(double _fps)
        {
            FPS = _fps;
        }
    }
}
