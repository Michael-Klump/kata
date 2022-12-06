using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greed_DiceGame
{
    public class TooManyDiceException: Exception
    {
        public TooManyDiceException()
        {
        }

        public TooManyDiceException(string message) : base(message)
        {
        }

        public TooManyDiceException(string message, Exception inner) : base(message, inner)
        {
        }

    }

}
