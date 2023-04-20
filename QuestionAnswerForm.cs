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
    public partial class QuestionAnswerForm : Form, IDataSource
    {
        public TextBox userAnswerBox
        {
            get
            {
                return textBox1;
            }
        }
        public Label answerBox
        {
            get
            {
                return label3;
            }
        }
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
        public IDataSource dataSource = new QuestionDataSource();
        public IEnumerable<Question> Questions => dataSource.Questions;
        public QuestionAnswerForm()
        {
            InitializeComponent();
        }
        public void UpdateQuestionForm(string category, int pointvalue)
        {
            this.CurrentCategory = category;
            this.CurrentPointValue = pointvalue;
            label1.Text = (from q in Questions where q.Category == CurrentCategory && q.PointValue == CurrentPointValue select q.Description).First();
            label1.TextAlign = ContentAlignment.MiddleCenter;
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
    }
}
