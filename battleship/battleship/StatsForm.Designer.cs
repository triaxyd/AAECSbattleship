namespace battleship
{
    partial class StatsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.exitButton = new System.Windows.Forms.Button();
            this.topLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserNameLabel = new System.Windows.Forms.Label();
            this.txtDifficultyLabel = new System.Windows.Forms.Label();
            this.txtWinsLabel = new System.Windows.Forms.Label();
            this.txtLosesLabel = new System.Windows.Forms.Label();
            this.txtRoundsLabel = new System.Windows.Forms.Label();
            this.username1 = new System.Windows.Forms.Label();
            this.difficulty1 = new System.Windows.Forms.Label();
            this.loses1 = new System.Windows.Forms.Label();
            this.wins1 = new System.Windows.Forms.Label();
            this.rounds1 = new System.Windows.Forms.Label();
            this.rounds2 = new System.Windows.Forms.Label();
            this.loses2 = new System.Windows.Forms.Label();
            this.wins2 = new System.Windows.Forms.Label();
            this.difficulty2 = new System.Windows.Forms.Label();
            this.username2 = new System.Windows.Forms.Label();
            this.rounds3 = new System.Windows.Forms.Label();
            this.loses3 = new System.Windows.Forms.Label();
            this.wins3 = new System.Windows.Forms.Label();
            this.difficulty3 = new System.Windows.Forms.Label();
            this.username3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.FlatAppearance.BorderSize = 2;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(60)))));
            this.exitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(65)))));
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(1014, 645);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(174, 43);
            this.exitButton.TabIndex = 0;
            this.exitButton.Text = "MENU";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // topLabel
            // 
            this.topLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(90)))));
            this.topLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.topLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLabel.Location = new System.Drawing.Point(0, 0);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(1200, 109);
            this.topLabel.TabIndex = 1;
            this.topLabel.Text = "TOP 3 PLAYERS BASED ON WINS";
            this.topLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 205);
            this.label1.Margin = new System.Windows.Forms.Padding(20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 77);
            this.label1.TabIndex = 2;
            this.label1.Text = "1.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 322);
            this.label2.Margin = new System.Windows.Forms.Padding(20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 77);
            this.label2.TabIndex = 3;
            this.label2.Text = "2.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 439);
            this.label3.Margin = new System.Windows.Forms.Padding(20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 77);
            this.label3.TabIndex = 4;
            this.label3.Text = "3.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUserNameLabel
            // 
            this.txtUserNameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtUserNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserNameLabel.Location = new System.Drawing.Point(136, 142);
            this.txtUserNameLabel.Name = "txtUserNameLabel";
            this.txtUserNameLabel.Size = new System.Drawing.Size(185, 43);
            this.txtUserNameLabel.TabIndex = 5;
            this.txtUserNameLabel.Text = "USERNAME";
            this.txtUserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDifficultyLabel
            // 
            this.txtDifficultyLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtDifficultyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDifficultyLabel.Location = new System.Drawing.Point(327, 142);
            this.txtDifficultyLabel.Name = "txtDifficultyLabel";
            this.txtDifficultyLabel.Size = new System.Drawing.Size(185, 43);
            this.txtDifficultyLabel.TabIndex = 6;
            this.txtDifficultyLabel.Text = "DIFFICULTY";
            this.txtDifficultyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtWinsLabel
            // 
            this.txtWinsLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtWinsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWinsLabel.Location = new System.Drawing.Point(518, 142);
            this.txtWinsLabel.Name = "txtWinsLabel";
            this.txtWinsLabel.Size = new System.Drawing.Size(185, 43);
            this.txtWinsLabel.TabIndex = 7;
            this.txtWinsLabel.Text = "WINS";
            this.txtWinsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLosesLabel
            // 
            this.txtLosesLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtLosesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLosesLabel.Location = new System.Drawing.Point(709, 142);
            this.txtLosesLabel.Name = "txtLosesLabel";
            this.txtLosesLabel.Size = new System.Drawing.Size(185, 43);
            this.txtLosesLabel.TabIndex = 8;
            this.txtLosesLabel.Text = "LOSES";
            this.txtLosesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRoundsLabel
            // 
            this.txtRoundsLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtRoundsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoundsLabel.Location = new System.Drawing.Point(900, 142);
            this.txtRoundsLabel.Name = "txtRoundsLabel";
            this.txtRoundsLabel.Size = new System.Drawing.Size(185, 43);
            this.txtRoundsLabel.TabIndex = 9;
            this.txtRoundsLabel.Text = "ROUNDS";
            this.txtRoundsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // username1
            // 
            this.username1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.username1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username1.Location = new System.Drawing.Point(136, 224);
            this.username1.Name = "username1";
            this.username1.Size = new System.Drawing.Size(185, 43);
            this.username1.TabIndex = 10;
            this.username1.Text = "username1";
            this.username1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // difficulty1
            // 
            this.difficulty1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.difficulty1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficulty1.Location = new System.Drawing.Point(327, 224);
            this.difficulty1.Name = "difficulty1";
            this.difficulty1.Size = new System.Drawing.Size(185, 43);
            this.difficulty1.TabIndex = 11;
            this.difficulty1.Text = "difficulty1";
            this.difficulty1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loses1
            // 
            this.loses1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loses1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loses1.Location = new System.Drawing.Point(709, 224);
            this.loses1.Name = "loses1";
            this.loses1.Size = new System.Drawing.Size(185, 43);
            this.loses1.TabIndex = 13;
            this.loses1.Text = "loses1";
            this.loses1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wins1
            // 
            this.wins1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wins1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wins1.Location = new System.Drawing.Point(518, 224);
            this.wins1.Name = "wins1";
            this.wins1.Size = new System.Drawing.Size(185, 43);
            this.wins1.TabIndex = 12;
            this.wins1.Text = "wins1";
            this.wins1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rounds1
            // 
            this.rounds1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rounds1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rounds1.Location = new System.Drawing.Point(900, 224);
            this.rounds1.Name = "rounds1";
            this.rounds1.Size = new System.Drawing.Size(185, 43);
            this.rounds1.TabIndex = 14;
            this.rounds1.Text = "rounds1";
            this.rounds1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rounds2
            // 
            this.rounds2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rounds2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rounds2.Location = new System.Drawing.Point(900, 341);
            this.rounds2.Name = "rounds2";
            this.rounds2.Size = new System.Drawing.Size(185, 43);
            this.rounds2.TabIndex = 19;
            this.rounds2.Text = "rounds2";
            this.rounds2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loses2
            // 
            this.loses2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loses2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loses2.Location = new System.Drawing.Point(709, 341);
            this.loses2.Name = "loses2";
            this.loses2.Size = new System.Drawing.Size(185, 43);
            this.loses2.TabIndex = 18;
            this.loses2.Text = "loses2";
            this.loses2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wins2
            // 
            this.wins2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wins2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wins2.Location = new System.Drawing.Point(518, 341);
            this.wins2.Name = "wins2";
            this.wins2.Size = new System.Drawing.Size(185, 43);
            this.wins2.TabIndex = 17;
            this.wins2.Text = "wins2";
            this.wins2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // difficulty2
            // 
            this.difficulty2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.difficulty2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficulty2.Location = new System.Drawing.Point(327, 341);
            this.difficulty2.Name = "difficulty2";
            this.difficulty2.Size = new System.Drawing.Size(185, 43);
            this.difficulty2.TabIndex = 16;
            this.difficulty2.Text = "difficulty2";
            this.difficulty2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // username2
            // 
            this.username2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.username2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username2.Location = new System.Drawing.Point(136, 341);
            this.username2.Name = "username2";
            this.username2.Size = new System.Drawing.Size(185, 43);
            this.username2.TabIndex = 15;
            this.username2.Text = "username2";
            this.username2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rounds3
            // 
            this.rounds3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rounds3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rounds3.Location = new System.Drawing.Point(900, 458);
            this.rounds3.Name = "rounds3";
            this.rounds3.Size = new System.Drawing.Size(185, 43);
            this.rounds3.TabIndex = 24;
            this.rounds3.Text = "rounds3";
            this.rounds3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loses3
            // 
            this.loses3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loses3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loses3.Location = new System.Drawing.Point(709, 458);
            this.loses3.Name = "loses3";
            this.loses3.Size = new System.Drawing.Size(185, 43);
            this.loses3.TabIndex = 23;
            this.loses3.Text = "loses3";
            this.loses3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wins3
            // 
            this.wins3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wins3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wins3.Location = new System.Drawing.Point(518, 458);
            this.wins3.Name = "wins3";
            this.wins3.Size = new System.Drawing.Size(185, 43);
            this.wins3.TabIndex = 22;
            this.wins3.Text = "wins3";
            this.wins3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // difficulty3
            // 
            this.difficulty3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.difficulty3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.difficulty3.Location = new System.Drawing.Point(327, 458);
            this.difficulty3.Name = "difficulty3";
            this.difficulty3.Size = new System.Drawing.Size(185, 43);
            this.difficulty3.TabIndex = 21;
            this.difficulty3.Text = "difficulty3";
            this.difficulty3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // username3
            // 
            this.username3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.username3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username3.Location = new System.Drawing.Point(136, 458);
            this.username3.Name = "username3";
            this.username3.Size = new System.Drawing.Size(185, 43);
            this.username3.TabIndex = 20;
            this.username3.Text = "username3";
            this.username3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StatsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.rounds3);
            this.Controls.Add(this.loses3);
            this.Controls.Add(this.wins3);
            this.Controls.Add(this.difficulty3);
            this.Controls.Add(this.username3);
            this.Controls.Add(this.rounds2);
            this.Controls.Add(this.loses2);
            this.Controls.Add(this.wins2);
            this.Controls.Add(this.difficulty2);
            this.Controls.Add(this.username2);
            this.Controls.Add(this.rounds1);
            this.Controls.Add(this.loses1);
            this.Controls.Add(this.wins1);
            this.Controls.Add(this.difficulty1);
            this.Controls.Add(this.username1);
            this.Controls.Add(this.txtRoundsLabel);
            this.Controls.Add(this.txtLosesLabel);
            this.Controls.Add(this.txtWinsLabel);
            this.Controls.Add(this.txtDifficultyLabel);
            this.Controls.Add(this.txtUserNameLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.topLabel);
            this.Controls.Add(this.exitButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(255)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StatsForm";
            this.Opacity = 0.95D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatsForm";
            this.Load += new System.EventHandler(this.StatsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtUserNameLabel;
        private System.Windows.Forms.Label txtDifficultyLabel;
        private System.Windows.Forms.Label txtWinsLabel;
        private System.Windows.Forms.Label txtLosesLabel;
        private System.Windows.Forms.Label txtRoundsLabel;
        private System.Windows.Forms.Label username1;
        private System.Windows.Forms.Label difficulty1;
        private System.Windows.Forms.Label loses1;
        private System.Windows.Forms.Label wins1;
        private System.Windows.Forms.Label rounds1;
        private System.Windows.Forms.Label rounds2;
        private System.Windows.Forms.Label loses2;
        private System.Windows.Forms.Label wins2;
        private System.Windows.Forms.Label difficulty2;
        private System.Windows.Forms.Label username2;
        private System.Windows.Forms.Label rounds3;
        private System.Windows.Forms.Label loses3;
        private System.Windows.Forms.Label wins3;
        private System.Windows.Forms.Label difficulty3;
        private System.Windows.Forms.Label username3;
    }
}