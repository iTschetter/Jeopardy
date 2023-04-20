using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    public class Player
    {
        private static int ID = 1;
        private int _myId = 1;
        public int MyId
        {
            get { return _myId; }
        }
        private int _score = 0;
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }
        public Player()
        {
            ID++;
            this._myId = ID;
        }
        public void UpdateScore(int valueChange)
        {
            this._score = _score + valueChange;
        }
        public int GetScore()
        {
            return this._score;
        }
    }
}
