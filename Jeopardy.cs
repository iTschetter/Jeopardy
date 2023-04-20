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
    public partial class Jeopardy : Form, IDataSource
    {
        public IDataSource dataSource = new QuestionDataSource();
        public IEnumerable<Question> Questions => dataSource.Questions;
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
        QuestionAnswerForm answerForm;
        public List<string> Categories = new List<string>();
        public Jeopardy()
        {
            InitializeComponent();
        }
        public Jeopardy(int numberOfPlayers, int scoreCap, List<string> categories)
        {
            InitializeComponent();
            answerForm = new QuestionAnswerForm();
            NumberOfPlayers = numberOfPlayers;
            ScoreCap = scoreCap;
            Categories = categories;

            // Fixing Score Board
            switch (NumberOfPlayers)
            {
                case 1:

                    // Centering Player 1
                    label7.Location = new System.Drawing.Point(608, 1242);
                    label3.Location = new System.Drawing.Point(608, 1283);

                    // Hiding Player 2
                    label8.BorderStyle = BorderStyle.None;
                    label8.ForeColor = System.Drawing.Color.Black;
                    label4.ForeColor = System.Drawing.Color.Black;

                    // Hiding Player 3
                    label9.BorderStyle = BorderStyle.None;
                    label9.ForeColor = System.Drawing.Color.Black;
                    label5.ForeColor = System.Drawing.Color.Black;

                    // Hiding Player 4
                    label10.BorderStyle = BorderStyle.None;
                    label10.ForeColor = System.Drawing.Color.Black;
                    label6.ForeColor = System.Drawing.Color.Black;
                    break;
                case 2:

                    // Centering Players 1 and 2, respectively
                    label7.Location = new System.Drawing.Point(456, 1242);
                    label3.Location = new System.Drawing.Point(456, 1283);
                    label8.Location = new System.Drawing.Point(759, 1242);
                    label4.Location = new System.Drawing.Point(759, 1283);

                    // Hiding Player 3
                    label9.BorderStyle = BorderStyle.None;
                    label9.ForeColor = System.Drawing.Color.Black;
                    label5.ForeColor = System.Drawing.Color.Black;

                    // Hiding Player 4
                    label10.BorderStyle = BorderStyle.None;
                    label10.ForeColor = System.Drawing.Color.Black;
                    label6.ForeColor = System.Drawing.Color.Black;

                    break;
                case 3:

                    // Centering Players 1, 2, and 3, respectively
                    label7.Location = new System.Drawing.Point(229, 1242);
                    label3.Location = new System.Drawing.Point(229, 1283);
                    label8.Location = new System.Drawing.Point(608, 1242);
                    label4.Location = new System.Drawing.Point(608, 1283);
                    label9.Location = new System.Drawing.Point(987, 1242);
                    label5.Location = new System.Drawing.Point(987, 1283);

                    // Hiding Player 4
                    label10.BorderStyle = BorderStyle.None;
                    label10.ForeColor = System.Drawing.Color.Black;
                    label6.ForeColor = System.Drawing.Color.Black;

                    break;
                case 4:
                    break;
            }
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
            Categories[0] = "Everything Computers";
            answerForm.UpdateQuestionForm(Categories[0].ToString(), 200);
            answerForm.Show(this);  //Show Form assigning this form as the forms owner
            Hide();
        }
    }
}
