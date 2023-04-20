﻿using System;
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
        public IDataSource dataSource = new QuestionDataSource();
        public IEnumerable<Question> Questions => dataSource.Questions;
        public QuestionAnswerForm()
        {
            InitializeComponent();
        }
        public void UpdateQuestionForm(string Category, int PointValue)
        {
            label1.Text = (from q in Questions where q.Category == Category && q.PointValue == PointValue select q.Description).First();
        }
    }
}
