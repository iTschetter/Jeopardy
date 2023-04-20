using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeopardy
{
    public partial class Jeopardy : Form, IDataSource
    {
        private SoundPlayer newRound = new SoundPlayer();
        //Initializing the game environment
        GameController masterKey;

        // Setting up the data source
        public IDataSource dataSource = new QuestionDataSource();
        public IEnumerable<Question> Questions => dataSource.Questions;

        // Setting up the child form
        QuestionAnswerForm answerForm;
        public List<string> Categories = new List<string>();
        public Jeopardy()
        {
            InitializeComponent();
        }
        public Jeopardy(int numberOfPlayers, int scoreCap, List<string> categories, bool losePoints)
        {
            InitializeComponent();

            // Setting up needed form for communication:
            answerForm = new QuestionAnswerForm();
            answerForm.VisibleChanged += new EventHandler(this.answerForm_VisibleChanged);
            Categories = categories;

            // Setting up game environment:
            masterKey = new GameController(scoreCap, numberOfPlayers, losePoints, this);
            masterKey.SetUpEnvironment();
            newRound.SoundLocation = @"C:\Users\Isaia\OneDrive\Desktop\Jeopardy2.0\bin\Sounds\newRound.wav";

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
            answerForm.Exit();
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            masterKey.UpdateKeyPointValue(200);

            Categories[0] = "Everything Computers";
            answerForm.UpdateQuestionForm(Categories[0].ToString(), 200);
            answerForm.Show(this);  //Show Form assigning this form as the forms owner
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.BackColor = System.Drawing.Color.Black;
            Hide();
        }
        private void answerForm_VisibleChanged(object sender, EventArgs e)
        {
            if(answerForm.Visible == false)
            {
                masterKey.UpdateEnvironment(answerForm.AnswerChecker);
                newRound.Play();
            }
        }
    }
}
