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
    public partial class QuestionAnswerForm : Form, IDataSource
    {
        private SoundPlayer incorrectAnswer = new SoundPlayer();
        private SoundPlayer correctAnswer = new SoundPlayer();
        private string _currentcategory = String.Empty;
        public string CurrentCategory
        {
            get { return _currentcategory; }
            set { _currentcategory = value; }
        }
        private int _currentpointvalue;
        public int CurrentPointValue
        {
            get { return _currentpointvalue; }
            set { _currentpointvalue = value; }
        }
        private bool _answerChecker = false;
        public bool AnswerChecker
        {
            get { return _answerChecker; }
            set { this._answerChecker = value; } 
        }
        private bool _submitButtonLocker = false;
        public bool SubmitButtonLocker
        {
            get { return _submitButtonLocker; }
            set { this._submitButtonLocker = value; }
        }
        public IDataSource dataSource = new QuestionDataSource();
        public IEnumerable<Question> Questions => dataSource.Questions;
        public QuestionAnswerForm()
        {
            InitializeComponent();
            incorrectAnswer.SoundLocation = @"C:\Users\Isaia\OneDrive\Desktop\Jeopardy2.0\bin\Sounds\incorrectAnswer.wav";
            correctAnswer.SoundLocation = @"C:\Users\Isaia\OneDrive\Desktop\Jeopardy2.0\bin\Sounds\correctAnswer.wav";
        }
        public void UpdateQuestionForm(string category, int pointvalue, bool submitButtonLock)
        {
            label3.ForeColor = Color.Blue;
            textBox1.Text = "Your Answer Here";
            this.SubmitButtonLocker = submitButtonLock;
            this.CurrentCategory = category;
            this.CurrentPointValue = pointvalue;
            textBox2.Text = (from q in Questions where q.Category == CurrentCategory && q.PointValue == CurrentPointValue select q.Description).First();
            label3.Text = (from q in Questions where q.Category == CurrentCategory && q.PointValue == CurrentPointValue select q.Answer).First();
            label3.TextAlign = ContentAlignment.MiddleCenter;
        }
        public void Exit()
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Owner.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(SubmitButtonLocker == false)
            {
                if (textBox1.Text.ToLower().ToString() == label3.Text.ToLower().ToString())
                {
                    AnswerChecker = true;
                    correctAnswer.Play();
                }
                else
                {
                    AnswerChecker = false;
                    incorrectAnswer.Play();
                }
                label3.ForeColor = Color.GhostWhite;
                SubmitButtonLocker = true;
            }
        }

        private void QuestionAnswerForm_Load(object sender, EventArgs e)
        {
        }
    }
}
