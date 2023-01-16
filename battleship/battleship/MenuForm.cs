﻿using System;
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
            errorMessage.Text = "";
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
            if (counter == 1 )
            {
                startGameTimer.Stop();
                mainSound.Stop();
                this.Close();
                gameForm gameform = new gameForm(userName);
                gameform.Show();
            }
        }
    }
}
