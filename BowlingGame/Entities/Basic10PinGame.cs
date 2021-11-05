using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Entities
{
    public class Basic10PinGame : Game
    {
        public Basic10PinGame()
        {
            base.rolls = new int[21];
        }
    }
}
