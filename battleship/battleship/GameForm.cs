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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;



namespace battleship
{
    public partial class gameForm : Form
    {

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
        private string userName;
        private int timeLapse,round,playerWins,playerLoses,sumShipSizesPlayer,sumShipSizesEnemy;
        private int waiting=0;

        public gameForm(string usrInput)
        {

            userName = usrInput;
            
            InitializeComponent();
        }

        private void gameForm_Load(object sender, EventArgs e)
        {
            PlayerInfo player = new PlayerInfo(userName);
            userNameLabel.Text = player.PlayerName;
            createTable();
            resetGame();



        }
        private void timeLapseTimer_Tick(object sender, EventArgs e)
        {
            timeLapse += 1;
            timeLapseLabel.Text = timeLapse.ToString();

            if (sumShipSizesPlayer == 0)
            {
                timeLapseTimer.Stop();
                helpLabel.Text = "ENEMY WON!";
            }
            else if(sumShipSizesEnemy == 0)  
            {
                timeLapseTimer.Stop();
                helpLabel.Text = "YOU WON! CONGRATULATIONS " + userName;
            }
            
            

            
        }

        private void waitForEnemy_Tick(object sender, EventArgs e)
        {
            waiting++;
            helpLabel.ForeColor = Color.White;
            helpLabel.BackColor = Color.FromArgb(30,35,65);
            helpLabel.Text = "ENEMY IS CHOOSING...";
            if (waiting > 2)
            {
                waitForEnemy.Stop();
                enemyMoves();
            }
        }





        private void resetGame()
        {
            emptyBoxes();
            setEnemy();
            setPlayer();
            timeLapse = 0;
            timeLapseTimer.Start();
            youLabel.BackColor = Color.FromArgb(30,35,65);
            for (int i=0; i < 4; i++)
            {
                sumShipSizesEnemy += enemyShips[i].Size;
                sumShipSizesPlayer += playerShips[i].Size;
            }
            helpLabel.Text = "YOU PLAY FIRST!";

        }

        private void endGame()
        {
            timeLapseTimer.Stop();
        }

        public void setPlayer()
        {
            playerShips[0] = new Ship("AirCraft", 5);
            playerShips[1] = new Ship("Destroyer", 4);
            playerShips[2] = new Ship("Military", 3);
            playerShips[3] = new Ship("SubMarine", 2);
            randomPickPlayer();
        }

        private void createTable()
        {
            for (int i=0 ; i<10; i++)
            {
                for (int j=0; j<10; j++)
                {
                    setBoxesEnemy[i, j] = ajChars[i].ToString() + numbers[j].ToString();
                    setBoxesPlayer[i, j] = ktChars[i].ToString() + numbers[j].ToString();
                }
            }
        }

        private void emptyBoxes()
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

        private void setEnemy()
        {
            enemyShips[0] = new Ship("AirCraft", 5);
            enemyShips[1] = new Ship("Destroyer", 4);
            enemyShips[2] = new Ship("Military", 3);
            enemyShips[3] = new Ship("SubMarine", 2);
            randomPickEnemy();

        }


        private void randomPickEnemy()
        {

            for (int i = 0; i < enemyShips.Length; i++) //Go through every ship of Enemy
            {
                bool validPosition = false;

                while (!validPosition)
                {
                    enemyShips[i].IsVertical = random.Next(2) == 0; //Random Orientation 
                    if (enemyShips[i].IsVertical)
                    {
                        enemyShips[i].Row = random.Next(10 - enemyShips[i].Size);
                        enemyShips[i].Column = random.Next(10);
                    }
                    else
                    {
                        enemyShips[i].Row = random.Next(10);
                        enemyShips[i].Column = random.Next(10 - enemyShips[i].Size);
                    }

                    validPosition = true;

                    for (int j = 0; j < enemyShips[i].Size; j++)     //Go and set boxes for every ship.
                    {
                        int tempRow = enemyShips[i].IsVertical ? enemyShips[i].Row + j : enemyShips[i].Row;  //if isVertical => temprow increases to increase y axis , else temprow stays the same
                        int tempColumn = enemyShips[i].IsVertical ? enemyShips[i].Column : enemyShips[i].Column + j; //if isVertical => tempcolumn stays the same , else tempcolumn increases for x axis.

                        if (tempRow >= 10 || tempColumn >= 10 || emptyBoxesEnemy[tempRow, tempColumn] == 1)
                        {
                            validPosition = false;
                            break;
                        }
                    }
                }
                for (int j = 0; j < enemyShips[i].Size; j++)
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

        

        private void randomPickPlayer()
        {
            for (int i = 0; i < playerShips.Length; i++) //Go through every ship of Player
            {
                bool validPosition = false;

                while (!validPosition)
                {
                    playerShips[i].IsVertical = random.Next(2) == 0; //Random Orientation 
                    if (playerShips[i].IsVertical)
                    {
                        playerShips[i].Row = random.Next(10 - playerShips[i].Size);
                        playerShips[i].Column = random.Next(10);
                    }
                    else
                    {
                        playerShips[i].Row = random.Next(10);
                        playerShips[i].Column = random.Next(10 - playerShips[i].Size);
                    }

                    validPosition = true;

                    for (int j = 0; j < playerShips[i].Size; j++)     //Go and set boxes for every ship.
                    {
                        int tempRow = playerShips[i].IsVertical ? playerShips[i].Row + j : playerShips[i].Row;  //if is vertical => temprow increases to increase y axis , else temprow stays the same
                        int tempColumn = playerShips[i].IsVertical ? playerShips[i].Column : playerShips[i].Column + j; //if is vertical => tempcolumn stays the same , else tempcolumn increases for x axis.

                        if (tempRow >= 10 || tempColumn >= 10 || emptyBoxesPlayer[tempRow, tempColumn] == 1)
                        {
                            validPosition = false;
                            break;
                        }
                    }
                }
                for (int j=0; j < playerShips[i].Size; j++)
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

        
      

        private void onClick(object sender, EventArgs e)
        {
            
            Button button = (Button)sender; //Gets the button that was clicked
            button.Enabled = false;
            string btnName = button.Name;
            char tempRow = btnName[0];
            int row = 0;
            for (int i = 0; i < 10; i++)
            {
                if (ajChars[i] == tempRow)
                {
                    row = ajChars[i]-65;
                }
            }
            int col = int.Parse(btnName.Substring(1)) - 1;
            previousTriesPlayer[row,col] = 1;
            if (emptyBoxesEnemy[row, col] == 0)
            {
                button.BackColor = Color.FromArgb(100, 50, 50 );
                helpLabel.ForeColor = Color.FromArgb(30, 35, 65);
                helpLabel.BackColor = Color.FromArgb(220, 220, 255);
                helpLabel.Text = "YOU MISSED!";

            }
            else
            {

                button.BackColor = Color.FromArgb(50, 100, 50);
                helpLabel.ForeColor = Color.FromArgb(10, 150, 10);
                helpLabel.BackColor = Color.FromArgb(10, 50, 10);
                helpLabel.Text = "YOU HIT ENEMY SHIP!";
                sumShipSizesEnemy--;
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < enemyShips[i].Size;j++)
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
                                break;
                            }
                        }
                    }
                }
            }
            enemyLabel.BackColor = Color.FromArgb(30, 35, 65);
            youLabel.BackColor = Color.FromArgb(65, 70, 110);
            foreach(Button btn in this.Controls.OfType<Button>())
            {
                btn.Enabled = false;
            }
            waiting = 0;
            waitForEnemy.Start();
        }


        private void enemyMoves()
        {

            enemyLabel.BackColor = Color.FromArgb(30, 35, 65);
            youLabel.BackColor = Color.FromArgb(65,70,110);
            Label lbl = new Label();
            int row = random.Next(0, 10);
            int col = random.Next(0, 10);
            while (previousTriesEnemy[row, col] == 1)
            {
                row = random.Next(0, 10);
                col = random.Next(0, 10);
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
                lbl.Text = "*";

            }
            else
            {
                helpLabel.BackColor = Color.FromArgb(50, 10, 10);
                helpLabel.ForeColor = Color.FromArgb(150, 10, 10);
                helpLabel.Text = "ENEMY HIT YOUR SHIP!";
                sumShipSizesPlayer--;
                lbl.Text = "*";
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
                                break;
                            }
                        }
                    }
                }
            }

            foreach (Button btn in this.Controls.OfType<Button>())
            {
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






