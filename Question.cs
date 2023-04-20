using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jeopardy
{
    public class Question
    {
        public string Description { get; set;  } = String.Empty;
        public int PointValue { get; set; }
        public string Category { get; set; } = String.Empty;
        public string Answer { get; set; } = String.Empty;
    }
    public class QuestionDataSource : IDataSource
    {
        public IEnumerable<Question> Questions =>
            new Question[]
            {
                // Everything Computers
                new Question { Description = "When was the first computer invented?", Answer = "What is 1943", PointValue=200, Category="Everything Computers"},
                new Question { Description = "What was the name of the first computer? (not abbreviated)", Answer = "What is Electronic Numerical Integrator and Computer", PointValue=600, Category="Everything Computers"},
                new Question { Description="Who is known as the father of computers? (first and last name)", Answer="Who is Charles Babbage", PointValue=400, Category="Everything Computers"},
                //new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "What was the first computer system that used color display?", Answer="What is Apple 1", PointValue=800, Category="Everything Computers"},
                new Question { Description = "Popular computer brands like Apple, Dell and Microsoft started their offices from which place? (What is a ______)", Answer="What is a garage", PointValue=1000, Category="Everything Computers"},

                // OOP Trivia
                new Question { Description = "What is the mechanism that binds together code and the data it manipulates, and it is a protective shield that prevents the data from being accessed by the code outside this shield", Answer="What is encapsulation", PointValue=200, Category="OOP Trivia"},
                new Question { Description = "What concept's main goal is to handle complexity by hiding unnecessary details from the user", Answer="What is abstraction", PointValue=400, Category="OOP Trivia"},
                new Question { Description = "What concept allows a child class to reuse and/or modify the behavior of a parent class?", Answer="What is inheritance", PointValue=600, Category="OOP Trivia"}
                /*new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},

                // 2a
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},

                // 2b
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},

                // 3a
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},

                //3b
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},

                // 4a
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},

                // 4b
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},

                // 5a
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},

                // 5b
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""},
                new Question { Description = "", Answer="W is", PointValue=, Category=""}*/
            };
    }
}
