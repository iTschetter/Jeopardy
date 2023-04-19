using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    public class Player
    {
        private static int ID = 0;
        private int myId = 0;
        public int MyId
        {
            get { return myId; }
        }
        public Player()
        {
            ID++;
            this.myId = ID;
        }
    }
}
