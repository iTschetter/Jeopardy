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
    public partial class Jeopardy : Form, IDataSource
    {
        public IDataSource dataSource = new QuestionDataSource();
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

        public IEnumerable<Question> Questions => dataSource.Questions;

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
            textBox1.Text = (from q in Questions where q.Category == "Questions about bob" select q.Description).First();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Jeopardy_Load(object sender, EventArgs e)
        {

        }

        private void Jeopardy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
