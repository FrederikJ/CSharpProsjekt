using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpProsjekt.SpillKlasser
{
    public class TimeEventArgs : EventArgs
    {
        public int timeLeft { get; set; }

        public TimeEventArgs(int _timeLeft)
        {
            timeLeft = _timeLeft;
        }
    }
}