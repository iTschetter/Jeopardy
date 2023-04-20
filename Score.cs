using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace Jeopardy
{
    public class Score
    {
        private bool _losePointsOnWrong = false;
        public bool LosePointsOnWrong
        {
            get { return _losePointsOnWrong; }
            set { _losePointsOnWrong = value; }
        }
        List<Player> players = new List<Player>();
        public Score(int NumberOfPlayers, bool LosePoints) 
        {
            _losePointsOnWrong = LosePoints;
            for(int i=0;i<NumberOfPlayers; i++) 
            {
                players.Add(new Player());
            }
        }
        public void CreateScoreBoard(int NumberOfPlayers)
        {
            
        }
    }
}
