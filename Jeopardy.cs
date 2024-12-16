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
        // ---------------------- Properties/Fields: ----------------------
        #region Properties/Fields
        private SoundPlayer newRound = new SoundPlayer();
        private SoundPlayer FinishedGame = new SoundPlayer();
        //Initializing the game environment
        GameController masterKey;

        // Setting up the data source
        public IDataSource dataSource = new QuestionDataSource();
        public IEnumerable<Question> Questions => dataSource.Questions;

        // Setting up the child forms:
        QuestionAnswerForm answerForm;
        GameFinished thankyouForm;

        // Preparing category information:
        public List<string> Categories = new List<string>();
        #endregion
        // ---------------------- Constructors: ----------------------
        #region Constructors
        public Jeopardy()
        {
            InitializeComponent();
        }
        public Jeopardy(int numberOfPlayers, int scoreCap, List<string> categories, bool losePoints)
        {
            InitializeComponent();

            // Setting up needed forms for communication:
            answerForm = new QuestionAnswerForm();
            answerForm.VisibleChanged += new EventHandler(this.answerForm_VisibleChanged);
            answerForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.answerForm_FormClosing);
            thankyouForm = new GameFinished();
            thankyouForm.button2.Click += new EventHandler(this.thankyouForm_Button2_Click);
            thankyouForm.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.thankyouForm_FormClosing);


            Categories = categories;


            // Setting up game environment:
            masterKey = new GameController(scoreCap, numberOfPlayers, losePoints, this, thankyouForm);
            masterKey.SetUpEnvironment(Categories);
            newRound.SoundLocation = @"Sounds\newRound.wav";
            FinishedGame.SoundLocation = @"Sounds\gameFinished.wav";
        }
        #endregion
        // ---------------------- Method(s): ----------------------
        #region Method(s)
        public void GameFinished()
        {
            masterKey.FinalizeMatch();
            FinishedGame.Play();
            thankyouForm.Show(this);
            Hide();
        }
        #endregion
        // ---------------------- Events: ----------------------
        #region Events
        private void answerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            //thankyouForm.Close();
            //this.Close();
        }
        private void thankyouForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            //answerForm.Close();
            //this.Close();
        }
        private void thankyouForm_Button2_Click(object sender, EventArgs e)
        {
            answerForm.Close();
            thankyouForm.Close();
            this.Close();
        }
        private void Jeopardy_FormClosed(object sender, FormClosedEventArgs e)
        {
            answerForm.Exit();
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(200);
            answerForm.UpdateQuestionForm(Categories[0].ToString(), 200, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.BackColor = System.Drawing.Color.Black;
            button1.Enabled = false;
            Hide();
        }
        private void answerForm_VisibleChanged(object sender, EventArgs e)
        {
            // Performing switch back to Jeopardy Board:
            if(answerForm.Visible == false)
            {
                masterKey.UpdateEnvironment(answerForm.AnswerChecker);
                if(masterKey.GameFinished == false)
                {
                    newRound.Play();
                } else
                {
                    FinishedGame.Play();
                }
            } else if (answerForm.Visible == true)
            {
                answerForm.textBox1.Select();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(200);
            answerForm.UpdateQuestionForm(Categories[1].ToString(), 200, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.BackColor = System.Drawing.Color.Black;
            button2.Enabled = false;
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(200);
            answerForm.UpdateQuestionForm(Categories[2].ToString(), 200, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.BackColor = System.Drawing.Color.Black;
            button3.Enabled = false;
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(200);
            answerForm.UpdateQuestionForm(Categories[4].ToString(), 200, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;
            button5.BackColor = System.Drawing.Color.Black;
            button5.Enabled = false;
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(200);
            answerForm.UpdateQuestionForm(Categories[3].ToString(), 200, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.BackColor = System.Drawing.Color.Black;
            button4.Enabled = false;
            Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(200);
            answerForm.UpdateQuestionForm(Categories[5].ToString(), 200, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button6.FlatStyle = FlatStyle.Flat;
            button6.FlatAppearance.BorderSize = 0;
            button6.BackColor = System.Drawing.Color.Black;
            button6.Enabled = false;
            Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(400);
            answerForm.UpdateQuestionForm(Categories[0].ToString(), 400, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button7.FlatStyle = FlatStyle.Flat;
            button7.FlatAppearance.BorderSize = 0;
            button7.BackColor = System.Drawing.Color.Black;
            button7.Enabled = false;
            Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(400);
            answerForm.UpdateQuestionForm(Categories[1].ToString(), 400, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button8.FlatStyle = FlatStyle.Flat;
            button8.FlatAppearance.BorderSize = 0;
            button8.BackColor = System.Drawing.Color.Black;
            button8.Enabled = false;
            Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(400);
            answerForm.UpdateQuestionForm(Categories[2].ToString(), 400, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button9.FlatStyle = FlatStyle.Flat;
            button9.FlatAppearance.BorderSize = 0;
            button9.BackColor = System.Drawing.Color.Black;
            button9.Enabled = false;
            Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(400);
            answerForm.UpdateQuestionForm(Categories[3].ToString(), 400, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button10.FlatStyle = FlatStyle.Flat;
            button10.FlatAppearance.BorderSize = 0;
            button10.BackColor = System.Drawing.Color.Black;
            button10.Enabled = false;
            Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(400);
            answerForm.UpdateQuestionForm(Categories[4].ToString(), 400, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button11.FlatStyle = FlatStyle.Flat;
            button11.FlatAppearance.BorderSize = 0;
            button11.BackColor = System.Drawing.Color.Black;
            button11.Enabled = false;
            Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(400);
            answerForm.UpdateQuestionForm(Categories[5].ToString(), 400, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button12.FlatStyle = FlatStyle.Flat;
            button12.FlatAppearance.BorderSize = 0;
            button12.BackColor = System.Drawing.Color.Black;
            button12.Enabled = false;
            Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(600);
            answerForm.UpdateQuestionForm(Categories[0].ToString(), 600, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button13.FlatStyle = FlatStyle.Flat;
            button13.FlatAppearance.BorderSize = 0;
            button13.BackColor = System.Drawing.Color.Black;
            button13.Enabled = false;
            Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(600);
            answerForm.UpdateQuestionForm(Categories[1].ToString(), 600, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button14.FlatStyle = FlatStyle.Flat;
            button14.FlatAppearance.BorderSize = 0;
            button14.BackColor = System.Drawing.Color.Black;
            button14.Enabled = false;
            Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(600);
            answerForm.UpdateQuestionForm(Categories[2].ToString(), 600, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button15.FlatStyle = FlatStyle.Flat;
            button15.FlatAppearance.BorderSize = 0;
            button15.BackColor = System.Drawing.Color.Black;
            button15.Enabled = false;
            Hide();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(600);
            answerForm.UpdateQuestionForm(Categories[3].ToString(), 600, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button16.FlatStyle = FlatStyle.Flat;
            button16.FlatAppearance.BorderSize = 0;
            button16.BackColor = System.Drawing.Color.Black;
            button16.Enabled = false;
            Hide();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(600);
            answerForm.UpdateQuestionForm(Categories[4].ToString(), 600, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button17.FlatStyle = FlatStyle.Flat;
            button17.FlatAppearance.BorderSize = 0;
            button17.BackColor = System.Drawing.Color.Black;
            button17.Enabled = false;
            Hide();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(600);
            answerForm.UpdateQuestionForm(Categories[5].ToString(), 600, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button18.FlatStyle = FlatStyle.Flat;
            button18.FlatAppearance.BorderSize = 0;
            button18.BackColor = System.Drawing.Color.Black;
            button18.Enabled = false;
            Hide();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(800);
            answerForm.UpdateQuestionForm(Categories[0].ToString(), 800, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button19.FlatStyle = FlatStyle.Flat;
            button19.FlatAppearance.BorderSize = 0;
            button19.BackColor = System.Drawing.Color.Black;
            button19.Enabled = false;
            Hide();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(800);
            answerForm.UpdateQuestionForm(Categories[1].ToString(), 800, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button20.FlatStyle = FlatStyle.Flat;
            button20.FlatAppearance.BorderSize = 0;
            button20.BackColor = System.Drawing.Color.Black;
            button20.Enabled = false;
            Hide();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(800);
            answerForm.UpdateQuestionForm(Categories[2].ToString(), 800, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button21.FlatStyle = FlatStyle.Flat;
            button21.FlatAppearance.BorderSize = 0;
            button21.BackColor = System.Drawing.Color.Black;
            button21.Enabled = false;
            Hide();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(800);
            answerForm.UpdateQuestionForm(Categories[3].ToString(), 800, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button22.FlatStyle = FlatStyle.Flat;
            button22.FlatAppearance.BorderSize = 0;
            button22.BackColor = System.Drawing.Color.Black;
            button22.Enabled = false;
            Hide();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(800);
            answerForm.UpdateQuestionForm(Categories[4].ToString(), 800, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button23.FlatStyle = FlatStyle.Flat;
            button23.FlatAppearance.BorderSize = 0;
            button23.BackColor = System.Drawing.Color.Black;
            button23.Enabled = false;
            Hide();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(800);
            answerForm.UpdateQuestionForm(Categories[5].ToString(), 800, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button24.FlatStyle = FlatStyle.Flat;
            button24.FlatAppearance.BorderSize = 0;
            button24.BackColor = System.Drawing.Color.Black;
            button24.Enabled = false;
            Hide();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(1000);
            answerForm.UpdateQuestionForm(Categories[0].ToString(), 1000, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button25.FlatStyle = FlatStyle.Flat;
            button25.FlatAppearance.BorderSize = 0;
            button25.BackColor = System.Drawing.Color.Black;
            button25.Enabled = false;
            Hide();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(1000);
            answerForm.UpdateQuestionForm(Categories[1].ToString(), 1000, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button26.FlatStyle = FlatStyle.Flat;
            button26.FlatAppearance.BorderSize = 0;
            button26.BackColor = System.Drawing.Color.Black;
            button26.Enabled = false;
            Hide();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(1000);
            answerForm.UpdateQuestionForm(Categories[2].ToString(), 1000, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button27.FlatStyle = FlatStyle.Flat;
            button27.FlatAppearance.BorderSize = 0;
            button27.BackColor = System.Drawing.Color.Black;
            button27.Enabled = false;
            Hide();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(1000);
            answerForm.UpdateQuestionForm(Categories[3].ToString(), 1000, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button28.FlatStyle = FlatStyle.Flat;
            button28.FlatAppearance.BorderSize = 0;
            button28.BackColor = System.Drawing.Color.Black;
            button28.Enabled = false;
            Hide();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(1000);
            answerForm.UpdateQuestionForm(Categories[4].ToString(), 1000, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button29.FlatStyle = FlatStyle.Flat;
            button29.FlatAppearance.BorderSize = 0;
            button29.BackColor = System.Drawing.Color.Black;
            button29.Enabled = false;
            Hide();
        }

        private void button30_Click(object sender, EventArgs e)
        {
            // Setting up QuestionAnswer Form environment:
            masterKey.UpdateKeyPointValue(1000);
            answerForm.UpdateQuestionForm(Categories[5].ToString(), 1000, false);

            // Performing switch to QuestionAnswer Form:
            answerForm.Show(this);
            button30.FlatStyle = FlatStyle.Flat;
            button30.FlatAppearance.BorderSize = 0;
            button30.BackColor = System.Drawing.Color.Black;
            button30.Enabled = false;
            Hide();
        }
        #endregion
    }
}
