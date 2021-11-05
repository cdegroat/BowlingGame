using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Entities
{
    public class Custom10PinGame : Game
    {
        public Custom10PinGame(int size)
        {
            base.rolls = new int[size];
        }
    }
}
