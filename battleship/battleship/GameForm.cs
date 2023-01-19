using battleship;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;



namespace battleship
{
    
    public partial class gameForm : Form
    {
        PlayerInfo player;
        char[] ajChars = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        char[] ktChars = { 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T' };
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        string[,] setBoxesPlayer = new string[10, 10];
        string[,] setBoxesEnemy = new string[10, 10];
        int[,] emptyBoxesPlayer = new int[10, 10];
        int[,] emptyBoxesEnemy = new int[10, 10];
        int[,] previousTriesEnemy = new int[10, 10];
        int[,] previousTriesPlayer = new int[10, 10];
        Ship[] playerShips = new Ship[4];
        Ship[] enemyShips = new Ship[4];



        Random random = new Random();

        bool gameOver;
        private string userName,usrDifficulty;
        private int timeLapse,round,sumShipSizesPlayer,sumShipSizesEnemy,enemyHits,playerHits,waiting,numOfSunkPlayer,numOfSunkEnemy,enemyMissedTries,randomForDifficulty;

        public gameForm(string usrInput, string difficulty)
        {
            userName = usrInput;
            usrDifficulty = difficulty;
            InitializeComponent();
        }

        private void gameForm_Load(object sender, EventArgs e)  //(game form load), create player object, set player wins and loses to 0, create the game table and reset game. 
        {

            player = new PlayerInfo(userName,usrDifficulty);
            userNameLabel.Text = player.playerName;
            difficultyLabel.Text = player.playerDifficulty;
            if (player.playerDifficulty == "Easy")
            {
                randomForDifficulty = 5;
            }
            else if (player.playerDifficulty == "Medium")
            {
                randomForDifficulty = 4;
            }
            else
            {
                randomForDifficulty = 3;
            }
            createTable();
            resetGame();
        }

        private void createTable()  //set the game table in 2d arrays for player and enemy
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    setBoxesPlayer[i, j] = ktChars[i].ToString() + numbers[j].ToString();
                    setBoxesEnemy[i, j] = ajChars[i].ToString() + numbers[j].ToString();
                }
            }
        }


        private void timeLapseTimer_Tick(object sender, EventArgs e)    //(game timer), display time,round, check if number of ships is 0 => endgame() and increase counter.
        {
            timeLapse += 1;
            timeLapseLabel.Text = timeLapse.ToString();
            roundLabel.Text = round.ToString();

            if (sumShipSizesPlayer == 0)
            {
                helpLabel.ForeColor = Color.FromArgb(220, 220, 250);
                helpLabel.BackColor = Color.FromArgb(100, 50, 50);
                youLabel.BackColor = Color.FromArgb(30, 35, 65);
                youLabel.ForeColor = Color.FromArgb(220, 220, 250);
                enemyLabel.BackColor = Color.FromArgb(30, 35, 65);
                enemyLabel.ForeColor = Color.FromArgb(220, 220, 255);
                helpLabel.Text = "ENEMY WON!";
                player.playerLoses++;
                endGame();
                

           
            }
            else if(sumShipSizesEnemy == 0)  
            { 
                helpLabel.ForeColor = Color.FromArgb(220,220,250);
                helpLabel.BackColor = Color.FromArgb(50,100,50);
                youLabel.BackColor = Color.FromArgb(30, 35, 65); 
                youLabel.ForeColor = Color.FromArgb(220, 220, 250);
                enemyLabel.BackColor = Color.FromArgb(30, 35, 65);
                enemyLabel.ForeColor = Color.FromArgb(220, 220, 255);
                helpLabel.Text = "YOU WON! CONGRATULATIONS " + player.playerName;
                player.playerWins++;
                endGame();
            }  
        }


        private void leaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
        }

        private void waitForEnemy_Tick(object sender, EventArgs e)  //(timer that starts when user picks a button) , when waiting%2==0 => enemyMoves()- enemy plays automatically 
        {
            waiting++;
            helpLabel.ForeColor = Color.White;
            helpLabel.BackColor = Color.FromArgb(30,35,65);
            helpLabel.Text = "ENEMY IS CHOOSING...";
            if (waiting % 2 ==0 && gameOver == false)
            {
                waitForEnemy.Stop();
                enemyMoves();
            }
        }



        private void resetGame()    //reset the game, set all game variables to starting values, display the buttons and labels needed and start game timer.
        {
            gameOver = false;
            round = 0;
            timeLapse = 0;
            playerHits = 0;
            enemyHits = 0;
            sumShipSizesEnemy = 0;
            sumShipSizesPlayer = 0;
            numOfSunkEnemy = 0;
            numOfSunkPlayer = 0;
            enemyMissedTries = 0;
            timeLapseTimer.Start();

            foreach (Button btn in this.Controls.OfType<Button>())
            {
                btn.Visible = true;
                btn.Enabled = true;
                btn.BackColor = Color.FromArgb(220,220,255);
            }
            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                lbl.Visible = true;
                if (lbl.Name == "txtStatsPlayerLabel" || lbl.Name == "txtStatsEnemy" || lbl.Name =="pressEnterLabel" 
                    || lbl.Name =="pressEscLabel" || lbl.Name == "txtStatsPlayerLabel" 
                    || lbl.Name =="txtStatsEnemyLabel" || lbl.Name == "txtYourHitsLabel" || lbl.Name == "yourHitsLabel" 
                    || lbl.Name =="txtYourShipsSunkLabel" || lbl.Name == "yourShipsSunkLabel" || lbl.Name == "txtEnemyHitsLabel"|| lbl.Name == "enemyHitsLabel" 
                    || lbl.Name =="txtEnemyShipsSunkLabel" || lbl.Name == "enemyShipsSunkLabel" || lbl.Name =="txtPlayerWinsLabel" || lbl.Name=="playerWinsLabel" 
                    || lbl.Name =="txtEnemyWinsLabel" || lbl.Name == "enemyWinsLabel")
                {
                    lbl.Visible = false;
                }
                for (int i=0; i < 10; i++)
                {
                    for (int j=0; j < 10; j++)
                    {
                        if (lbl.Name == setBoxesPlayer[i, j])
                        {
                            lbl.BackColor = Color.FromArgb(220, 220, 255);
                            lbl.Text = "";
                        }
                        if(lbl.Name == "youLabel")
                        {
                            lbl.BackColor = Color.FromArgb(30, 35, 65);
                        }
                        if(lbl.Name == "helpLabel")
                        {
                            lbl.BackColor = Color.FromArgb(30, 35, 65);
                        }
                        if(lbl.Name == "enemyLabel")
                        {
                            lbl.BackColor = Color.FromArgb(65, 70, 110);
                        }
                        
                    }
                }
            }
            emptyBoxes();
            setPlayer(); 
            setEnemy();

            for (int i=0; i < 4; i++)
            {
                sumShipSizesPlayer += playerShips[i].Size;
                sumShipSizesEnemy += enemyShips[i].Size;
            }
            youLabel.BackColor = Color.FromArgb(30,35,65);
            helpLabel.Text = "YOU PLAY FIRST!";

        }


        private void gameForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (gameOver == true && e.KeyCode == Keys.Enter)
            {
                resetGame();
            }

            if( gameOver == true && e.KeyCode == Keys.Escape)
            {
                this.Close();
                MenuForm menuForm = new MenuForm();
                menuForm.Show();
            }
        }

        private void endGame()  //(when game ends) stop timers and display the end menu, user presses buttons to proceed
        {
            gameOver = true;
            timeLapseTimer.Stop();
            waitForEnemy.Stop();
            foreach(Button btn in this.Controls.OfType<Button>())
            {
                btn.Visible = false;
            }
            foreach (Label lbl in this.Controls.OfType<Label>())
            {
                lbl.Visible = false;
                if (lbl.Name == "txtUserNameLabel" || lbl.Name =="userNameLabel" 
                    || lbl.Name =="difficultyLabel" || lbl.Name =="txtDifficultyLabel" 
                    || lbl.Name == "txtTimeLapseLabel" || lbl.Name== "timeLapseLabel" 
                    || lbl.Name == "txtRoundLabel" || lbl.Name == "roundLabel" 
                    || lbl.Name == "youLabel" || lbl.Name == "helpLabel" || lbl.Name == "enemyLabel"
                    || lbl.Name == "pressEnterLabel" || lbl.Name == "pressEscLabel" || lbl.Name == "txtStatsPlayerLabel" || lbl.Name =="txtStatsEnemyLabel"
                    || lbl.Name =="txtYourHitsLabel" || lbl.Name =="yourHitsLabel" || lbl.Name =="txtYourShipsSunkLabel" || lbl.Name =="yourShipsSunkLabel" || lbl.Name =="txtEnemyHitsLabel"
                    || lbl.Name =="enemyHitsLabel" || lbl.Name =="txtEnemyShipsSunkLabel" || lbl.Name =="enemyShipsSunkLabel" || lbl.Name == "txtPlayerWinsLabel" || lbl.Name == "playerWinsLabel"
                    || lbl.Name == "txtEnemyWinsLabel" || lbl.Name == "enemyWinsLabel")
                {
                    lbl.Visible = true;
                }
            }
            for (int i=0; i<4; i++) //Increase sunk ships Label
            {
                if (enemyShips[i].isSunk)
                {
                    numOfSunkPlayer++;
                }
                if (playerShips[i].isSunk)
                {
                    numOfSunkEnemy++;
                }
            }
            yourShipsSunkLabel.Text = numOfSunkPlayer.ToString();
            enemyShipsSunkLabel.Text = numOfSunkEnemy.ToString();
            yourHitsLabel.Text = playerHits.ToString();
            enemyHitsLabel.Text = enemyHits.ToString();
            playerWinsLabel.Text = player.playerWins.ToString();
            enemyWinsLabel.Text = player.playerLoses.ToString();
        }


        private void emptyBoxes()   //(reset the arrays) ,set the values of occupied boxes and previous selections to 0.
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    emptyBoxesEnemy[i, j] = 0;
                    emptyBoxesPlayer[i, j] = 0;
                    previousTriesEnemy[i, j] = 0;
                    previousTriesPlayer[i, j] = 0;
                }
            }
        }



        public void setPlayer() //(set the player) , create 4 ship objects of Ship class and randomPick their Positions
        {
            playerShips[0] = new Ship("AirCraft", 5);
            playerShips[1] = new Ship("Destroyer", 4);
            playerShips[2] = new Ship("Military", 3);
            playerShips[3] = new Ship("SubMarine", 2);

            randomPickPlayer();
        }

        private void setEnemy() //(set the enemy) , create 4 ship objects of Ship class and place them to enemyShips array, then call randomPick()
        {
            enemyShips[0] = new Ship("AirCraft", 5);
            enemyShips[1] = new Ship("Destroyer", 4);
            enemyShips[2] = new Ship("Military", 3);
            enemyShips[3] = new Ship("SubMarine", 2);
            randomPickEnemy();

        }

        

        private void randomPickEnemy()  //(Random Pick of ship positions for enemy)
        {

            for (int i = 0; i < enemyShips.Length; i++) //Go through every ship of enemyShips
            {
                bool validPosition = false;

                while (!validPosition)
                {
                    enemyShips[i].IsVertical = random.Next(2) == 0; //Random Orientation 
                    if (enemyShips[i].IsVertical)
                    {
                        enemyShips[i].Row = random.Next(10 - enemyShips[i].Size);   //Dont go out of bounds
                        enemyShips[i].Column = random.Next(10);
                    }
                    else
                    {
                        enemyShips[i].Row = random.Next(10);
                        enemyShips[i].Column = random.Next(10 - enemyShips[i].Size);    //Dont go out of bounds
                    }

                    validPosition = true;

                    for (int j = 0; j < enemyShips[i].Size; j++)     //Go and set boxes for every ship.
                    {
                        int tempRow = enemyShips[i].IsVertical ? enemyShips[i].Row + j : enemyShips[i].Row;  //if isVertical => temprow increase for y axis , else temprow stays the same
                        int tempColumn = enemyShips[i].IsVertical ? enemyShips[i].Column : enemyShips[i].Column + j; //if isVertical => tempcolumn stays the same , else tempcolumn increases for x axis.

                        if (tempRow >= 10 || tempColumn >= 10 || emptyBoxesEnemy[tempRow, tempColumn] == 1) //if out of bounds or there already is a ship in tempRow tempColumn coordinates => break
                        {
                            validPosition = false;
                            break;
                        }
                    }
                }
                for (int j = 0; j < enemyShips[i].Size; j++)    //go and place a part of the ship in each box and paint it with its color
                {
                    int tempRow = enemyShips[i].IsVertical ? enemyShips[i].Row + j : enemyShips[i].Row;
                    int tempColumn = enemyShips[i].IsVertical ? enemyShips[i].Column : enemyShips[i].Column + j;
                    emptyBoxesEnemy[tempRow, tempColumn] = 1;
                    /*foreach (Button btn in this.Controls.OfType<Button>())    //Color Enemy Ships
                    {
                        if (setBoxesEnemy[tempRow, tempColumn] == btn.Name) 
                        {
                            btn.BackColor = enemyShips[i].Color;

                        }
                    }*/
                }
            }
        }

        
        private void randomPickPlayer() //(Random pick of ship positions for player)
        {
            for (int i = 0; i < playerShips.Length; i++) //Go through every ship of playerShips
            {
                bool validPosition = false;

                while (!validPosition)
                {
                    playerShips[i].IsVertical = random.Next(2) == 0; //Random Orientation 
                    if (playerShips[i].IsVertical)
                    {
                        playerShips[i].Row = random.Next(10 - playerShips[i].Size); //Dont go out of bounds
                        playerShips[i].Column = random.Next(10);
                    }
                    else
                    {
                        playerShips[i].Row = random.Next(10);
                        playerShips[i].Column = random.Next(10 - playerShips[i].Size);  //Dont go out of bounds
                    }

                    validPosition = true;

                    for (int j = 0; j < playerShips[i].Size; j++)     //Go and set boxes for every ship.
                    {
                        int tempRow = playerShips[i].IsVertical ? playerShips[i].Row + j : playerShips[i].Row;  //if is vertical => temprow increases for y axis , else temprow stays the same
                        int tempColumn = playerShips[i].IsVertical ? playerShips[i].Column : playerShips[i].Column + j; //if is vertical => tempcolumn stays the same , else tempcolumn increases for x axis.

                        if (tempRow >= 10 || tempColumn >= 10 || emptyBoxesPlayer[tempRow, tempColumn] == 1)    //if out of bounds or there already is a ship in tempRow tempColumn coordinates => break
                        {
                            validPosition = false;
                            break;
                        }
                    }
                }
                for (int j=0; j < playerShips[i].Size; j++) //go and place a part of the ship in each box and paint it with its color
                {
                    int tempRow = playerShips[i].IsVertical ? playerShips[i].Row + j : playerShips[i].Row;
                    int tempColumn = playerShips[i].IsVertical ? playerShips[i].Column : playerShips[i].Column + j;
                    emptyBoxesPlayer[tempRow, tempColumn] = 1;
                    foreach(Label lbl in this.Controls.OfType<Label>())
                    {
                        if (setBoxesPlayer[tempRow, tempColumn] == lbl.Name)
                        {
                            lbl.BackColor = playerShips[i].Color;
                            
                        }
                    }
                }
            }    
        }

        
      

        private void onClick(object sender, EventArgs e)    //(when user clicks on boxes)
        {
            round++;
            Button button = (Button)sender; //Gets the button that was clicked
            button.Enabled = false; //Disable the button that was clicked
            string btnName = button.Name;
            char tempRow = btnName[0];
            int row = 0;
            for (int i = 0; i < 10; i++)    //get the buttons coordinates for row and col
            {
                if (ajChars[i] == tempRow)
                {
                    row = ajChars[i]-65;    //A-J in ASCII => 065-074
                }
            }
            int col = int.Parse(btnName.Substring(1)) - 1;
            previousTriesPlayer[row,col] = 1;   //box in row,col coordinates was set
            if (emptyBoxesEnemy[row, col] == 0) //if it doesn't have a ship, user misses
            {
                button.BackColor = Color.FromArgb(100, 50, 50 );
                helpLabel.ForeColor = Color.FromArgb(30, 35, 65);
                helpLabel.BackColor = Color.FromArgb(220, 220, 255);
                helpLabel.Text = "YOU MISSED!";

            }
            else   //else user gets a shot
            {

                button.BackColor = Color.FromArgb(50, 100, 50);
                helpLabel.ForeColor = Color.FromArgb(10, 150, 10);
                helpLabel.BackColor = Color.FromArgb(10, 50, 10);
                helpLabel.Text = "YOU HIT ENEMY SHIP!";
                playerHits++;
                sumShipSizesEnemy--;
                for (int i = 0; i < 4; i++)     //check if a ship has sunk
                {
                    for (int j = 0; j < enemyShips[i].Size; j++)
                    {
                        if (enemyShips[i].IsVertical)
                        {
                            if (enemyShips[i].Row + j == row && enemyShips[i].Column == col)
                            {
                                enemyShips[i].Hits++;
                                if (enemyShips[i].Hits >= enemyShips[i].Size)
                                {
                                    helpLabel.ForeColor = Color.FromArgb(10, 200, 10);
                                    helpLabel.BackColor = Color.FromArgb(10, 100, 10);
                                    helpLabel.Text = "YOU SUNK ENEMYS " + enemyShips[i].Name.ToUpper();
                                    enemyShips[i].isSunk = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (enemyShips[i].Row == row && enemyShips[i].Column + j == col)
                            {
                                enemyShips[i].Hits++;
                                if (enemyShips[i].Hits >= enemyShips[i].Size)
                                {
                                    helpLabel.ForeColor = Color.FromArgb(10, 200, 10);
                                    helpLabel.BackColor = Color.FromArgb(10, 100, 10);
                                    helpLabel.Text = "YOU SUNK ENEMYS " + enemyShips[i].Name.ToUpper();
                                    enemyShips[i].isSunk = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            
            enemyLabel.BackColor = Color.FromArgb(30, 35, 65);
            youLabel.BackColor = Color.FromArgb(65, 70, 110);
            waiting = 0;
            foreach(Button btn in this.Controls.OfType<Button>())
            {
                btn.Enabled = false;
            }
            if (gameOver == false)
            {
                waitForEnemy.Start();
            }
            
        }



        private void enemyMoves()   //(Auto user Pick)
        {
            enemyLabel.BackColor = Color.FromArgb(30, 35, 65);
            youLabel.BackColor = Color.FromArgb(65,70,110);
            Label lbl = new Label();
            int row=0;
            int col=0;
            if (enemyMissedTries == randomForDifficulty)  //(Buffer for enemy) :)
            {
                enemyMissedTries = 0;
                int rndShip = random.Next(4);
                Ship tempShip = playerShips[rndShip];
                int tempRnd = random.Next(tempShip.Size);
                if (tempShip.IsVertical)
                {
                    row = tempShip.Row + tempRnd;
                    col = tempShip.Column;
                }
                else
                {
                    row = tempShip.Row;
                    col = tempShip.Column + tempRnd;
                }
                while (previousTriesEnemy[row, col] == 1)
                {
                    rndShip = random.Next(4);
                    tempShip = playerShips[rndShip];
                    tempRnd = random.Next(tempShip.Size);
                    if (tempShip.IsVertical)
                    {
                        row = tempShip.Row + tempRnd;
                        col = tempShip.Column;
                    }
                    else
                    {
                        row = tempShip.Row;
                        col = tempShip.Column + tempRnd;
                    }
                }



            }
            else
            {
                row = random.Next(0, 10);
                col = random.Next(0, 10);
                while (previousTriesEnemy[row, col] == 1)
                {
                    row = random.Next(0, 10);
                    col = random.Next(0, 10);
                }
            }
            
            foreach(Label tempLbl in this.Controls.OfType<Label>())
            {
                if (tempLbl.Name == setBoxesPlayer[row, col])
                {
                    lbl = tempLbl;
                }
            }
            previousTriesEnemy[row, col] = 1;

            
            if (emptyBoxesPlayer[row, col] == 0)
            {

                helpLabel.ForeColor = Color.FromArgb(30, 35, 65);
                helpLabel.BackColor = Color.FromArgb(220, 220, 255);
                helpLabel.Text = "ENEMY MISSED!";
                enemyMissedTries++;
                lbl.Text = "^";

            }
            else
            {
                helpLabel.BackColor = Color.FromArgb(50, 10, 10);
                helpLabel.ForeColor = Color.FromArgb(150, 10, 10);
                helpLabel.Text = "ONE OF YOUR SHIP GOT A HIT!";
                enemyMissedTries = 0;
                enemyHits++;
                sumShipSizesPlayer--;
                lbl.Text = "^";
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < playerShips[i].Size; j++)
                {
                    if (playerShips[i].IsVertical)
                    {
                        if (playerShips[i].Row + j == row && playerShips[i].Column == col)
                        {
                            playerShips[i].Hits++;
                            if (playerShips[i].Hits >= playerShips[i].Size)
                            {
                                helpLabel.ForeColor = Color.FromArgb(200, 10, 10);
                                helpLabel.BackColor = Color.FromArgb(100, 10, 10);
                                helpLabel.Text = "WARNING! ENEMY SUNK YOUR " + playerShips[i].Name.ToUpper();
                                playerShips[i].isSunk = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        if (playerShips[i].Row == row && playerShips[i].Column + j == col)
                        {
                            playerShips[i].Hits++;
                            if (playerShips[i].Hits >= playerShips[i].Size)
                            {
                                helpLabel.ForeColor = Color.FromArgb(200, 10, 10);
                                helpLabel.BackColor = Color.FromArgb(100, 10, 10);
                                helpLabel.Text = "WARNING! ENEMY SUNK YOUR " + playerShips[i].Name.ToUpper();
                                playerShips[i].isSunk = true;
                                break;
                            }
                        }
                    }
                }
            }

            foreach (Button btn in this.Controls.OfType<Button>())
            {
                if (btn.Name == "leaveButton")
                {
                    btn.Enabled = true;
                }
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (setBoxesEnemy[i, j] == btn.Name && previousTriesPlayer[i, j] == 1)
                        {
                            btn.Enabled = false;   
                        }
                        else if(setBoxesEnemy[i, j] == btn.Name && previousTriesPlayer[i, j] ==0)
                        {
                            btn.Enabled = true;
                        }
                        

                    }
                }
            }
            youLabel.BackColor = Color.FromArgb(30, 35, 65);
            enemyLabel.BackColor = Color.FromArgb(65, 70, 110);
        }



    }
}






