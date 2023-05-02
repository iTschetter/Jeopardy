using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace Jeopardy
{
    public class ScoreBoard
    {
        // ---------------------- Properties/Fields: ----------------------
        #region Properties/Fields
        public Jeopardy myJeopardy;
        private bool _losePointsOnWrong = false;
        public bool LosePointsOnWrong
        {
            get { return _losePointsOnWrong; }
            set { this._losePointsOnWrong = value; }
        }
        private int _scoreCap = 10000;
        public int ScoreCap
        {
            get { return _scoreCap; }
            set { this._scoreCap = value; }
        }
        private int _numberOfPlayers = 1;
        public int NumberOfPlayers
        {
            get { return _numberOfPlayers; }
            set { this._numberOfPlayers = value; }
        }
        private bool _scoreCapReached = false;
        public bool ScoreCapReached
        {
            get { return _scoreCapReached; }
            set { this._scoreCapReached = value; }
        }
        private int _winningPlayer = 5;
        public int WinningPlayer
        {
            get { return _winningPlayer; }
            set { this._winningPlayer = value; }
        }
        private int _winningScore = 0;
        public int WinningScore
        {
            get { return _winningScore; }
            set { this._winningScore = value; }
        }
        public List<int> WinningPlayers = new List<int>();
        List<Player> players = new List<Player>();
        #endregion
        // ---------------------- Constructor: ----------------------
        #region Constructor
        public ScoreBoard(int ScoreCap, int NumberOfPlayers, bool LosePoints, Jeopardy neededForm) 
        {
            this.ScoreCap = ScoreCap;
            myJeopardy = neededForm;
            this.LosePointsOnWrong = LosePoints;
            this.NumberOfPlayers = NumberOfPlayers;
            for(int i=0;i<NumberOfPlayers; i++) 
            {
                players.Add(new Player(0));
            }
            LosePointsOnWrong = LosePoints;
        }
        #endregion
        // ---------------------- Methods: ----------------------
        #region Methods
        public void CreateScoreBoard()
        {
            // Fixing Score Board
            switch (NumberOfPlayers)
            {
                case 1:

                    // Centering Player 1
                    myJeopardy.label7.Location = new System.Drawing.Point(608, 1242);
                    myJeopardy.label3.Location = new System.Drawing.Point(608, 1283);

                    // Hiding Player 2
                    myJeopardy.label8.BorderStyle = BorderStyle.None;
                    myJeopardy.label8.ForeColor = System.Drawing.Color.Black;
                    myJeopardy.label4.ForeColor = System.Drawing.Color.Black;

                    // Hiding Player 3
                    myJeopardy.label9.BorderStyle = BorderStyle.None;
                    myJeopardy.label9.ForeColor = System.Drawing.Color.Black;
                    myJeopardy.label5.ForeColor = System.Drawing.Color.Black;

                    // Hiding Player 4
                    myJeopardy.label10.BorderStyle = BorderStyle.None;
                    myJeopardy.label10.ForeColor = System.Drawing.Color.Black;
                    myJeopardy.label6.ForeColor = System.Drawing.Color.Black;
                    break;
                case 2:

                    // Centering Players 1 and 2, respectively
                    myJeopardy.label7.Location = new System.Drawing.Point(456, 1242);
                    myJeopardy.label3.Location = new System.Drawing.Point(456, 1283);
                    myJeopardy.label8.Location = new System.Drawing.Point(759, 1242);
                    myJeopardy.label4.Location = new System.Drawing.Point(759, 1283);

                    // Hiding Player 3
                    myJeopardy.label9.BorderStyle = BorderStyle.None;
                    myJeopardy.label9.ForeColor = System.Drawing.Color.Black;
                    myJeopardy.label5.ForeColor = System.Drawing.Color.Black;

                    // Hiding Player 4
                    myJeopardy.label10.BorderStyle = BorderStyle.None;
                    myJeopardy.label10.ForeColor = System.Drawing.Color.Black;
                    myJeopardy.label6.ForeColor = System.Drawing.Color.Black;

                    break;
                case 3:

                    // Centering Players 1, 2, and 3, respectively
                    myJeopardy.label7.Location = new System.Drawing.Point(229, 1242);
                    myJeopardy.label3.Location = new System.Drawing.Point(229, 1283);
                    myJeopardy.label8.Location = new System.Drawing.Point(608, 1242);
                    myJeopardy.label4.Location = new System.Drawing.Point(608, 1283);
                    myJeopardy.label9.Location = new System.Drawing.Point(987, 1242);
                    myJeopardy.label5.Location = new System.Drawing.Point(987, 1283);

                    // Hiding Player 4
                    myJeopardy.label10.BorderStyle = BorderStyle.None;
                    myJeopardy.label10.ForeColor = System.Drawing.Color.Black;
                    myJeopardy.label6.ForeColor = System.Drawing.Color.Black;

                    break;
                case 4:
                    break;
            }
        }
        public void UpdateScoreBoard(int currentlySelectedPlayer, int scoreValue)
        {
            if (scoreValue >= ScoreCap)
            {
                ScoreCapReached = true;
                WinningPlayer = currentlySelectedPlayer + 1;
            }

            if(currentlySelectedPlayer+1 == 1)
            {
                myJeopardy.label3.Text = scoreValue.ToString();
            } else if (currentlySelectedPlayer+1 == 2)
            {
                myJeopardy.label4.Text = scoreValue.ToString();
            } else if (currentlySelectedPlayer+1 == 3)
            {
                myJeopardy.label5.Text = scoreValue.ToString();
            } else
            {
                myJeopardy.label6.Text = scoreValue.ToString();
            }
        }
        public void DetermineWinner()
        {
            int i = 0;
            WinningScore = 0;
            for (i = 0; i < players.Count(); i++)
            {
                if (WinningScore < players[i].GetScore())
                {
                    WinningScore = players[i].GetScore();
                    WinningPlayers.Clear();
                    WinningPlayers.Add(i + 1);
                } else if (WinningScore == players[i].GetScore())
                {
                    WinningPlayers.Add(i + 1);
                }
            }
        }
        #endregion
    }
}
