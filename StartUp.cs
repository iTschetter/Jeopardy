using System.Media;

namespace Jeopardy
{
    public partial class StartUp : Form
    {
        // ---------------------- Properties/Fields: ----------------------
        #region properties/fields
        private SoundPlayer openingSound = new SoundPlayer();
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
        private bool _losePoints = false;
        public bool LosePoints
        {
            get { return _losePoints; }
            set { _losePoints = value; }
        }
        public List<string> Categories = new List<string>();
        Jeopardy gameForm;
        #endregion
        // ---------------------- Constructor: ----------------------
        #region constructor
        public StartUp()
        {
            InitializeComponent();
            openingSound.SoundLocation = @"C:\Users\Isaia\OneDrive\Desktop\Jeopardy2.0\bin\Sounds\OpeningSound.wav";
        }
        #endregion
        // ---------------------- Events: ---------------------- 
        #region Events
        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || comboBox4.Text == "" || comboBox4.Text == "" || comboBox5.Text == "" || comboBox6.Text == "")
            {
                MessageBox.Show("Please finish selecting categories before starting match!");
            } else
            {
                NumberOfPlayers = ((int)numericUpDown1.Value);
                ScoreCap = ((int)numericUpDown2.Value);
                Categories.Add(comboBox1.Text);
                Categories.Add(comboBox2.Text);
                Categories.Add(comboBox3.Text);
                Categories.Add(comboBox4.Text);
                Categories.Add(comboBox5.Text);
                Categories.Add(comboBox6.Text);
                if (checkBox1.Checked == true)
                {
                    LosePoints = true;
                }
                gameForm = new Jeopardy(NumberOfPlayers, ScoreCap, Categories, LosePoints);

                openingSound.Play();
                gameForm.Show(this);
                this.Hide();
            }
        }
#endregion
    }
}