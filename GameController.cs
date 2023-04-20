using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    public class GameController
    {
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
        // Constructors and Methods:
        public GameController(int ScoreCap, int NumberOfPlayers, bool LosePoints, Jeopardy neededForm) 
        {
            this.NumberOfPlayers = NumberOfPlayers;
            this.LosePoints = LosePoints;

            // Initialzing the players and scoreboard
            masterScore = new ScoreBoard(ScoreCap, NumberOfPlayers, LosePoints, neededForm);
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                players.Add(new Player());
            }
        }
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
            }
            if(GameFinished == true)
            {
                CloseEnvironment();
            }            

            // Setting up new round:
            NewRound();
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
        public void CloseEnvironment()
        {

        }
    }
}
