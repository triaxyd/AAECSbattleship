using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    class PlayerInfo
    {
        public string playerName { get; set; }
        public string playerDifficulty { get; set; }
        public int playerWins { get; set; }
        public int playerLoses { get; set; }

        public PlayerInfo(string name, string difficulty)
        {
            playerName = name;
            playerDifficulty = difficulty;
            playerWins = 0;
            playerLoses = 0;
        }

        

    }
}
