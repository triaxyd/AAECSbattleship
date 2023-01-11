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
    public partial class gameForm : Form
    {
        char[,] playerTable = new char[10, 10];
        Random random = new Random();

        private int playerShips;
        private int enemyShips;
        private string userName;
        private int timeLapse;
        private int tries;
        public gameForm(string usrInput)
        {
            userName = usrInput;
            InitializeComponent();
        }

        private void gameForm_Load(object sender, EventArgs e)
        {
            timeLapseTimer.Start();
            playerInfo player = new playerInfo(userName);
            userNameLabel.Text = player.PlayerName;
            
            

        }

        private void goToMenu(object sender, EventArgs e)
        {
            timeLapseTimer.Stop();
            this.Close();
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        private void timeLapseTimer_Tick(object sender, EventArgs e)
        {
            timeLapse += 1;
            timeLapseLabel.Text = timeLapse.ToString();
        }

        private void resetGame()
        {
            for (int i=0; i<10; i++)
            {

            }
        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void label93_Click(object sender, EventArgs e)
        {

        }
    }
}
