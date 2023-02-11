using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace battleship
{
    public partial class MenuForm : Form
    {
        private string userName;
        private SoundPlayer mainSound;
        private int counter;
        string difficulty;
        public MenuForm()
        {
            InitializeComponent();
        }

        private void InitializeSound()
        {
            mainSound = new SoundPlayer("mainSound.wav");
        }

        private void menuForm_Load(object sender, EventArgs e)
        {
            InitializeSound();
            mainSound.PlayLooping();
            startLabel.Hide();
            mediumButton.PerformClick();

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            closeMenu();
        }

        private void startingNow()
        {
            playButton.Visible = false;
            statsButton.Visible = false;
            exitButton.Visible = false;
            userNameTextBox.Enabled = false;
            errorMessage.Text = "";
            easyButton.Visible = false;
            mediumButton.Visible = false;
            hardButton.Visible = false;
            startLabel.Show();

        }

        private void closeMenu()
        {
            if (checkName() == 0)
            { 
                startGameTimer.Start();
                startingNow();
            }
            else if (checkName() == 1)
            {
                errorMessage.Text = "PLEASE ENTER A USERNAME.";
            }
            else if (checkName() == 2)
            {
                errorMessage.Text = "USERNAME MUST BE 3-10 CHARACTERS LONG.";
            }
            
        }
        public int checkName()
        {
            if (userNameTextBox.Text.Length >= 3 && userNameTextBox.Text.Length <=15)
            {
                userName = userNameTextBox.Text;
                return 0;
            }
            else if (userNameTextBox.Text.Length == 0) 
            {
                return 1;
            }
            else if (userNameTextBox.Text.Length < 3)
            {
                return 2;
            }
            return -1; 
        }

        private void startGameTimer_Tick(object sender, EventArgs e)
        {
            counter++;
            if (counter == 2 )
            {
                startGameTimer.Stop();
                mainSound.Stop();
                this.Close();
                gameForm gameform = new gameForm(userName, difficulty);
                gameform.Show();
            }
        }

        private void easyButton_Click(object sender, EventArgs e)
        {
            difficulty = "EASY";
            clearButtons();
            easyButton.BackColor = Color.FromArgb(15, 20, 50);
        }

        private void mediumButton_Click(object sender, EventArgs e)
        {
            difficulty = "MEDIUM";
            clearButtons();
            mediumButton.BackColor = Color.FromArgb(15, 20, 50);

        }

        private void hardButton_Click(object sender, EventArgs e)
        {
            difficulty = "HARD";
            clearButtons();
            hardButton.BackColor = Color.FromArgb(15, 20, 50);
        }

        private void clearButtons()
        {
            easyButton.BackColor = Color.FromArgb(40, 40, 70);
            mediumButton.BackColor = Color.FromArgb(40, 40, 70);
            hardButton.BackColor = Color.FromArgb(40, 40, 70);
        }

        private void statsButton_Click(object sender, EventArgs e)
        {
            mainSound.Stop();
            this.Close();
            StatsForm statsForm = new StatsForm();
            statsForm.Show();
        }
    }
}
