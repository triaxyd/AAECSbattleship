using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    public class PlayerInfo
    {
        public string PlayerName { get; set; }
        public string PlayerDifficulty { get; set; }
        public int PlayerWins { get; set; }
        public int PlayerLoses { get; set; }
        public int AverageRounds { get; set; }

        public PlayerInfo() //default constructor
        {

        }
        public PlayerInfo(string name, string difficulty)
        {
            PlayerName = name;
            PlayerDifficulty = difficulty;
            PlayerWins = 0;
            PlayerLoses = 0;
            AverageRounds = 0;
        }

        

    }
}
