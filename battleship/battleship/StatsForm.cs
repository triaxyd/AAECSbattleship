using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleship
{
    public partial class StatsForm : Form
    {
        List<PlayerInfo> players = SqliteDataAccess.LoadPlayers();  //load players as a list

        public StatsForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        private void StatsForm_Load(object sender, EventArgs e)     //show top 3 players by wins
        {
            List<PlayerInfo> topPlayersByWins = players.OrderByDescending(p => p.PlayerWins).Take(3).ToList();  //Order players take the first 3 and create a new list topPlayersByWins
            username1.Text =topPlayersByWins[0].PlayerName;
            difficulty1.Text = topPlayersByWins[0].PlayerDifficulty;
            wins1.Text = topPlayersByWins[0].PlayerWins.ToString();
            loses1.Text = topPlayersByWins[0].PlayerLoses.ToString();
            rounds1.Text = topPlayersByWins[0].AverageRounds.ToString();
            username2.Text = topPlayersByWins[1].PlayerName;
            difficulty2.Text = topPlayersByWins[1].PlayerDifficulty;
            wins2.Text = topPlayersByWins[1].PlayerWins.ToString();
            loses2.Text = topPlayersByWins[1].PlayerLoses.ToString();
            rounds2.Text = topPlayersByWins[1].AverageRounds.ToString();
            username3.Text = topPlayersByWins[2].PlayerName;
            difficulty3.Text = topPlayersByWins[2].PlayerDifficulty;
            wins3.Text = topPlayersByWins[2].PlayerWins.ToString();
            loses3.Text = topPlayersByWins[2].PlayerLoses.ToString();
            rounds3.Text = topPlayersByWins[2].AverageRounds.ToString();

        }
    }
}
