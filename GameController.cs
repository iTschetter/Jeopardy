using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    public class GameController
    {
        List<Player> players = new List<Player>();
        public static int gameFinishedCounter = 30;
        private int _currentGameCounter = 0;
        public int CurrentGameCounter
        {
            get { return _currentGameCounter; }
            set { this._currentGameCounter = value; }
        }
        private int _currentSelectedPlayer = 1;
        public int CurrentSelectedPlayer
        {
            get { return _currentSelectedPlayer; }
            set { this._currentSelectedPlayer = value; }
        }
        private int _numberOfPlayers;
        public int NumberOfPlayers
        {
            get { return _numberOfPlayers; }
            set { this._numberOfPlayers = value; }
        }
        public GameController(int ScoreCap, int NumberOfPlayers, bool LosePoints, Jeopardy neededForm) 
        {
            this.NumberOfPlayers = NumberOfPlayers;

            // Initialzing the players and scoreboard
            ScoreBoard masterScore = new ScoreBoard(ScoreCap, NumberOfPlayers, LosePoints, neededForm);
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                players.Add(new Player());
            }
        }
        public void ChangeSelectedPlayer()
        {
            if(_currentSelectedPlayer == NumberOfPlayers)
            {
                _currentSelectedPlayer = 1;
            } else
            {
                _currentSelectedPlayer++;
            }
        }
    }
}
