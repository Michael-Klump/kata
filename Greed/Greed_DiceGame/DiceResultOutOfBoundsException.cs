using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greed_DiceGame
{
    public class DiceResultOutOfBoundsException: Exception
    {
        public DiceResultOutOfBoundsException()
        {
        }

        public DiceResultOutOfBoundsException(string message) : base(message)
        {
        }

        public DiceResultOutOfBoundsException(string message, Exception inner) : base(message, inner)
        {
        }

    }

}
