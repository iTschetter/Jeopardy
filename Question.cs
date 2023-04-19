using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeopardy
{
    public class Question
    {
        public string Description { get; set;  } = String.Empty;
        public int PointValue { get; set; }
        public string Category { get; set; } = String.Empty;
    }
    public class QuestionDataSource : IDataSource
    {
        public IEnumerable<Question> Questions =>
            new Question[]
            {
                new Question { Description = "Bob is 12. How old is he?", PointValue = 5000, Category = "Questions about bob" }
            };
    }
}
