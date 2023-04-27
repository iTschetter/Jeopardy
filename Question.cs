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
        // ---------------------- Properties: ----------------------'
        #region Properties
        public string Description { get; set;  } = String.Empty;
        public int PointValue { get; set; }
        public string Category { get; set; } = String.Empty;
        public string Answer { get; set; } = String.Empty;
    }
    #endregion
    public class QuestionDataSource : Question, IDataSource
    {
        // ---------------------- Questions: ----------------------
        #region Questions
        public IEnumerable<Question> Questions =>
            new Question[]
            {
                // Fix the ordering of the point values based on the difficulty of the questions!!

                // 1a: Everything Computers
                new Question { Description = "During this year, the first computer invented.", Answer = "What is 1943", PointValue=200, Category="Everything Computers"},
                new Question { Description = "This computer was known to be the first computer. (not abbreviated)", Answer = "What is Electronic Numerical Integrator and Computer", PointValue=600, Category="Everything Computers"},
                new Question { Description="This man is known as the father of computers. (first and last name)", Answer="Who is Charles Babbage", PointValue=400, Category="Everything Computers"},
                new Question { Description = "This was known as the first computer system that used color display.", Answer="What is Apple 1", PointValue=800, Category="Everything Computers"},
                new Question { Description = "Popular computer brands like Apple, Dell and Microsoft started their offices from this place. (What is a ______)", Answer="What is a garage", PointValue=1000, Category="Everything Computers"},

                // 1b: OOP Trivia
                new Question { Description = "This concept is known as the mechanism that binds together code and the data it manipulates, and it is a protective shield that prevents the data from being accessed by the code outside this shield.", Answer="What is encapsulation", PointValue=200, Category="OOP Trivia"},
                new Question { Description = "This concept's main goal is to handle complexity by hiding unnecessary details from the user.", Answer="What is abstraction", PointValue=400, Category="OOP Trivia"},
                new Question { Description = "This concept allows a child class to reuse and/or modify the behavior of a parent class.", Answer="What is inheritance", PointValue=600, Category="OOP Trivia"},
                new Question { Description = "This is known as a set or category of things having some property or attribute in common and differentiated from others by kind, type, or quality.", Answer="What is a class", PointValue=800, Category="OOP Trivia"},
                new Question { Description = "This special method of a class will automatically invoke when an instance of the class is created.", Answer="What is a constructor", PointValue=1000, Category="OOP Trivia"},
                
                // 2a: Everything Cars
                new Question { Description = "This man is often credited with creating the world's first car. (first and last name)", Answer="Who is Karl Benz", PointValue=200, Category="Everything Cars"},
                new Question { Description = "This common mammel can be seen on the Porsche logo.", Answer="What is a Horse", PointValue=400, Category="Everything Cars"},
                new Question { Description = "This company owns Bugatti, Lamborghini. Audi, Porsche, and Ducati.", Answer="What is Volkswagen", PointValue=600, Category="Everything Cars"},
                new Question { Description = "Audi's logo has this many rings. (What is _ rings) -- Using digits", Answer="What is 4 rings", PointValue=800, Category="Everything Cars"},
                new Question { Description = "This car manufacturer was the first company to produce more than 10 million units in a year.", Answer="What is Toyota", PointValue=1000, Category="Everything Cars"},

                // 2b: Food and its History
                new Question { Description = "This country is responsible for giving us pizza and pasta.", Answer="What is Italy", PointValue=200, Category="Food and its History"},
                new Question { Description = "This European nation was said to invent hot dogs.", Answer="What is Germany", PointValue=400, Category="Food and its History"},
                new Question { Description = "Russia notoriously known for this kind of alcohol.", Answer="What is vodka", PointValue=600, Category="Food and its History"},
                new Question { Description = "This country invented tea.", Answer="What is China", PointValue=800, Category="Food and its History"},
                new Question { Description = "This country produces the most coffee in the world.", Answer="What is Brazil", PointValue=1000, Category="Food and its History"},

                // 3a: Human Health
                new Question { Description = "This organ has four chambers.", Answer="What is the heart", PointValue=200, Category="Human Health"},
                new Question { Description = "This is your body’s largest organ.", Answer="What is the skin", PointValue=400, Category="Human Health"},
                new Question { Description = "These kinds of cells are found in the brain.", Answer="What are neurons", PointValue=600, Category="Human Health"},
                new Question { Description = "This element is said to keep bones strong.", Answer="What is calcium", PointValue=800, Category="Human Health"},
                new Question { Description = "Babies are born without this bone.", Answer="What is the knee cap", PointValue=1000, Category="Human Health"},

                //3b: World History
                new Question { Description = "Egyptian kings/rulers were known by this name.", Answer="What is Pharaoh", PointValue=200, Category="World History"},
                new Question { Description = "Julius Caesar was involved with with this queen.", Answer="Who is Cleopatra", PointValue=400, Category="World History"},
                new Question { Description = "This religion dominated the Middle Ages.", Answer="What is Catholicism", PointValue=600, Category="World History"},
                new Question { Description = "In this year, World War I begin.", Answer="What is 1914", PointValue=800, Category="World History"},
                new Question { Description = "John F. Kennedy was assassinated in this city.", Answer="What is Dallas", PointValue=1000, Category="World History"},

                // 4a: World Geography
                new Question { Description = "This American state is the largest (by area).", Answer="What is Alaska", PointValue=200, Category="World Geography"},
                new Question { Description = "This is the smallest country in the world.", Answer="What is Vatican City", PointValue=400, Category="World Geography"},
                new Question { Description = "This continent is the largest in the world.", Answer="What is Asia", PointValue=600, Category="World Geography"},
                new Question { Description = "This is the name of the world’s longest river.", Answer="What is The Nile", PointValue=800, Category="World Geography"},
                new Question { Description = "This city in India is where you would find the Taj Mahal.", Answer="What is Agra", PointValue=1000, Category="World Geography"},

                // 4b: The World of Music
                new Question { Description = "This singer was the very first American Idol winner.", Answer="Who is Kelly Clarkson", PointValue=200, Category="The World of Music"},
                new Question { Description = "John Lennon was a part of this band.", Answer="What is the Beatles", PointValue=400, Category="The World of Music"},
                new Question { Description = "This singer sang “All I want for Christmas is you”.", Answer="Who is Mariah Carey", PointValue=600, Category="The World of Music"},
                new Question { Description = "This artist was nicknamed the “king of the Rock and Roll”. (Answer with stagename)", Answer="Who is Elvis Presley", PointValue=800, Category="The World of Music"},
                new Question { Description = "This artist is known for writing 'No Women, No Cry' and for infamously being from Jamaica", Answer="Who is Bob Marley", PointValue=1000, Category="The World of Music"},

                // 5a: Impossible Trivia
                new Question { Description = "This word is known for always being spelt wrong.", Answer="What is wrong", PointValue=200, Category="Impossible Trivia"},
                new Question { Description = "This becomes of a white hat when you drop it in the Black sea.", Answer="What is wet", PointValue=400, Category="Impossible Trivia"},
                new Question { Description = "This is something that we can break, but we can never hold it.", Answer="What is a promise", PointValue=600, Category="Impossible Trivia"},
                new Question { Description = "This is known as something that can travel all over the world while still staying in a corner.", Answer="What is a stamp", PointValue=800, Category="Impossible Trivia"},
                new Question { Description = "This is known to have a tail and a head, but never a body.", Answer="What is a coin", PointValue=1000, Category="Impossible Trivia"},

                // 5b: Category: NULL
                new Question { Description = "This is known to be the largest fresh water lake in the world.", Answer="What is Lake Superior", PointValue=200, Category="Category: NULL"},
                new Question { Description = "This Japanese art involves paper folding", Answer="What is Origami", PointValue=400, Category="Category: NULL"},
                new Question { Description = "This dog's name was popularized from the cartoon 'Mickey Mouse.'", Answer="Who is Pluto", PointValue=600, Category="Category: NULL"},
                new Question { Description = "This popular horror author penned the novel 'The Stand.'", Answer="Who is Stephen King", PointValue=800, Category="Category: NULL"},
                new Question { Description = "In one of the most popular Dr. Seuss books, Sam-I-Am won't eat this dish.", Answer="What is green eggs and ham", PointValue=1000, Category="Category: NULL"},

                // 6a: Entertainment Arts
                new Question { Description = "This district in New York is famous for hosting multiple touring musicals.", Answer = "What is Broadway", PointValue=200, Category="Entertainment Arts"},
                new Question { Description = "The 'Oprah Winfrey Show' ran for this many seasons. (In numerical form.)", Answer = "What is 25 seasons", PointValue=400, Category="Entertainment Arts"},
                new Question { Description = "This year was when the Academy Awards was started.", Answer = "What is 1929", PointValue=600, Category="Entertainment Arts"},
                new Question { Description = "BBC's non-abbreviated form is this.", Answer = "What is British Broadcasting Coporation", PointValue=800, Category="Entertainment Arts"},
                new Question { Description = "This man was the first Saturday Night Live’s first celebrity host.", Answer = "Who is George Carlin", PointValue=1000, Category="Entertainment Arts"},

                // 6b: Ridiculous Trivia
                new Question { Description = "This household object's speed is measured in 'Mickeys.'", Answer = "What is a computer mouse", PointValue=200, Category="Ridiculous Trivia"},
                new Question { Description = "This part of the human body is where the zygomatic bone is found", Answer = "What is the facial cheek", PointValue=400, Category="Ridiculous Trivia"},
                new Question { Description = "This man was known for claiming he could 'drive the devil away with a fart.'", Answer = "Who is Martin Luther", PointValue=600, Category="Ridiculous Trivia"},
                new Question { Description = "The liquor Cointreau is known for being this flavor.", Answer = "What is Orange", PointValue=800, Category="Ridiculous Trivia"},
                new Question { Description = "This is what you call a group of unicorns.", Answer = "What is a blessing", PointValue=1000, Category="Ridiculous Trivia"}
            };
        #endregion
    }
}
