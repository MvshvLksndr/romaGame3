using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roma
{
    public class Player
    {
        public List<int> dices { get; set; }
        public int PlayerID { get; set; }
        public int DiceCount;
        public int BetValue;
        public int BetCount;
        public Player() 
        {
            DiceCount = 1;
        }
    }
}
