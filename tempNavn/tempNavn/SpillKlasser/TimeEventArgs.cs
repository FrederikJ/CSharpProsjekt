using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProsjekt.SpillKlasser
{
    /// <summary>
    /// TimeEventArgs.cs av Tommy Langhelle
    /// Programmering 3 - C# Prosjekt
    /// 
    /// Laget et nytt event for tid slik at vi enkelt kunne ha den på en annen panel enn mypanel
    /// Spillet ser mer litt bedre og mer profosjonelt når alt ikke er proppet inn i samme panel
    /// </summary>
    public class TimeEventArgs : EventArgs
    {
        public int timeLeft { get; set; }

        public TimeEventArgs(int _timeLeft)
        {
            timeLeft = _timeLeft;
        }
    }
}
