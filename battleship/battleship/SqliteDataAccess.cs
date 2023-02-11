using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    public class SqliteDataAccess
    {
        
        public static List<PlayerInfo> LoadPlayers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<PlayerInfo>("SELECT * FROM Player", new DynamicParameters());
                return output.ToList();
            }
        } 

        public static void AddPlayer(PlayerInfo player)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("INSERT INTO Player(PlayerName, PlayerDifficulty, PlayerWins, PlayerLoses, AverageRounds) values (@PlayerName,@PlayerDifficulty,@PlayerWins,@PlayerLoses,@AverageRounds)", player);
            }
            
        }
        

        private static string LoadConnectionString(string id="Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString; //gets the connection string
        } 
    }
}
