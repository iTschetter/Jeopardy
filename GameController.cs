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
        public GameController() 
        {
            
        }
    }
}
