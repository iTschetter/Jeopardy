using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeopardy
{
    public partial class Jeopardy : Form
    {
        private int _numberOfPlayers = 1;
        private int _scoreCap = 1500;
        public int NumberOfPlayers
        {
            get { return _numberOfPlayers; }
            set { _numberOfPlayers = value; }
        }
        public int ScoreCap
        {
            get { return _scoreCap; }
            set { _scoreCap = value; }
        }
        public List<string> Categories = new List<string>();
        public Jeopardy()
        {
            InitializeComponent();
        }
        public Jeopardy(int numberOfPlayers, int scoreCap, List<string> categories)
        {
            InitializeComponent();
            NumberOfPlayers = numberOfPlayers;
            ScoreCap = scoreCap;
            Categories = categories;
            //pictureBox1.ImageLocation = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/73cd599f-99f9-4d9d-8536-6455717abba1/d5glc73-dde0bc03-512a-417e-bca9-8dd505aea8cf.png/v1/fit/w_150,h_150,strp/blank_jeopardy__board___1986_2_by_wheelgenius_d5glc73-150.png?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9NzA4IiwicGF0aCI6IlwvZlwvNzNjZDU5OWYtOTlmOS00ZDlkLTg1MzYtNjQ1NTcxN2FiYmExXC9kNWdsYzczLWRkZTBiYzAzLTUxMmEtNDE3ZS1iY2E5LThkZDUwNWFlYThjZi5wbmciLCJ3aWR0aCI6Ijw9OTAwIn1dXSwiYXVkIjpbInVybjpzZXJ2aWNlOmltYWdlLm9wZXJhdGlvbnMiXX0.uJwvHMIQVwFncOn0TwauXt-7jjZc4Ro6-K-nH8ko5w4";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
