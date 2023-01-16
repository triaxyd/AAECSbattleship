using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    class PlayerInfo
    {
        private string playerName;
        private int timeLapse;
        private int playerTries;

        public PlayerInfo(string name)
        {
            playerName = name;
        }

        public string PlayerName
        {
            get { return playerName; }  
            set { playerName = value; }
        }

        public int TimeLapse
        {
            get { return timeLapse; }
            set { timeLapse = value; }
        }

        public int PlayerTries
        {
            get { return playerTries; }
            set { playerTries = value; }
        }

    }
}
