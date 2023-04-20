using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    public class GameController
    {
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
        public GameController() 
        {
            
        }
        public void ChangeSelectedPlayer()
        {
            if(_currentSelectedPlayer == 4)
            {
                _currentSelectedPlayer = 1;
            } else
            {
                _currentSelectedPlayer++;
            }
        }
    }
}
