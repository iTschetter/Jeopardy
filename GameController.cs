using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    public class GameController
    {
        // ---------------------- Properties/Fields: ----------------------
        #region Properties/Fields
        ScoreBoard masterScore;
        List<Player> players = new List<Player>();
        
        // Setting up dynamic game environment properties:
        public static int gameFinishedCounter = 30;
        private int _currentRoundCounter = 0;
        public int CurrentRoundCounter
        {
            get { return _currentRoundCounter; }
            set { this._currentRoundCounter = value; }
        }
        private int _currentSelectedPlayer = 0;
        public int CurrentSelectedPlayer
        {
            get { return _currentSelectedPlayer; }
            set { this._currentSelectedPlayer = value; }
        }
        private int _currentPointValue = 200;
        public int CurrentPointValue
        {
            get { return _currentPointValue; }
            set { this._currentPointValue = value; }
        }
        private int _numberOfPlayers;
        public int NumberOfPlayers
        {
            get { return _numberOfPlayers; }
            set { this._numberOfPlayers = value; }
        }
        private bool _losePoints = false;
        public bool LosePoints
        {
            get { return _losePoints; }
            set { this._losePoints = value; }
        }
        private bool _gameFinished = false;
        public bool GameFinished
        {
            get { return _gameFinished; }
            set { this._gameFinished = value; }
        }
        private Jeopardy _jeopardyBoard;
        public Jeopardy JeopardyBoard
        {
            get { return _jeopardyBoard; }
            set { this._jeopardyBoard = value; }
        }
        private GameFinished _thankyouFinish;
        public GameFinished ThankYouFinish
        {
            get { return _thankyouFinish; }
            set { this._thankyouFinish = value; }
        }
        #endregion
        // ---------------------- Constructor(s): ----------------------
        #region Constructor(s)
        public GameController(int ScoreCap, int NumberOfPlayers, bool LosePoints, Jeopardy jeopardyForm, GameFinished thankyouForm) 
        {
            this.JeopardyBoard = jeopardyForm;
            this.ThankYouFinish = thankyouForm;
            this.NumberOfPlayers = NumberOfPlayers;
            this.LosePoints = LosePoints;

            // Initialzing the players and scoreboard
            masterScore = new ScoreBoard(ScoreCap, NumberOfPlayers, LosePoints, jeopardyForm);
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                players.Add(new Player());
            }
        }
        #endregion
        // ---------------------- Methods: ----------------------
        #region Methods
        public void SetUpEnvironment(List<string> categories)
        {
            masterScore.CreateScoreBoard();

            // Setting up category headers on board:
            JeopardyBoard.label11.Text = categories[0];
            JeopardyBoard.label12.Text = categories[1];
            JeopardyBoard.label13.Text = categories[2];
            JeopardyBoard.label14.Text = categories[3];
            JeopardyBoard.label15.Text = categories[4];
            JeopardyBoard.label16.Text = categories[5];
        }
        // Use when Jeopardy.cs handles category setup:
        public void SetUpEnvironment()
        {
            masterScore.CreateScoreBoard();
        }
        public void UpdateEnvironment(bool correctAnswer)
        {

            // Updating Player score values:
            if(correctAnswer == true)
            {
                players[CurrentSelectedPlayer].UpdateScore(CurrentPointValue, false);
            } else if (LosePoints == true && correctAnswer == false)
            {
                players[CurrentSelectedPlayer].UpdateScore(CurrentPointValue, true);
            }

            // Updating Score Board values:
            masterScore.UpdateScoreBoard(CurrentSelectedPlayer, players[CurrentSelectedPlayer].GetScore());


            // Checking if game is finished and if true, closing the environment:
            if (masterScore.ScoreCapReached == true)
            {
                GameFinished = true;
            } else if (CurrentRoundCounter == gameFinishedCounter - 1)
            {
                GameFinished = true;
                masterScore.DetermineWinner();
            }

            // Game Finished Test:
            if(GameFinished == true)
            {
                JeopardyBoard.GameFinished();
            } else
            {
                // Setting up new round:
                NewRound();
            }           

        }
        public void FinalizeMatch()
        {
            if(masterScore.WinningPlayers.Count() > 1)
            {
                if(masterScore.WinningPlayers.Count() == 2)
                {
                    ThankYouFinish.label1.Text = "There was a tie! The Winning Players are " + masterScore.WinningPlayers[0] + " and " + masterScore.WinningPlayers[1];
                    ThankYouFinish.label4.Text = "at " + players[masterScore.WinningPlayers[0] - 1].GetScore().ToString() + " points!";
                } else if (masterScore.WinningPlayers.Count() == 3)
                {
                    ThankYouFinish.label1.Text = "There was a tie! The Winning Players are " + masterScore.WinningPlayers[0] + ", " + masterScore.WinningPlayers[1] + ", and " + masterScore.WinningPlayers[2];
                    ThankYouFinish.label4.Text = "at " + players[masterScore.WinningPlayers[0] - 1].GetScore().ToString() + " points!";
                } else
                {
                    ThankYouFinish.label1.Text = "All players tied!";
                    ThankYouFinish.label4.Text = "With " + players[masterScore.WinningPlayers[0] - 1].GetScore().ToString() + " points!";
                }
            } else
            {
                if (masterScore.ScoreCapReached == true)
                {
                    ThankYouFinish.label1.Text = "Score Cap Reached! The Winner is Player " + masterScore.WinningPlayers[0].ToString();
                    ThankYouFinish.label4.Text = "at " + players[masterScore.WinningPlayers[0] - 1].GetScore().ToString() + " points!";
                }
                else
                {
                    ThankYouFinish.label1.Text = "The Winner is Player " + masterScore.WinningPlayers[0].ToString();
                    ThankYouFinish.label4.Text = "at " + players[masterScore.WinningPlayers[0] - 1].GetScore().ToString() + " points!";
                }
            }
        }
        public void UpdateKeyPointValue(int newCurrentPointValue)
        {
            this.CurrentPointValue = newCurrentPointValue;
        }
        public void NewRound()
        {
            if(_currentSelectedPlayer == NumberOfPlayers - 1)
            {
                _currentSelectedPlayer = 0;
            } else
            {
                _currentSelectedPlayer++;
            }
            CurrentRoundCounter++;
        }
        #endregion
    }
}
