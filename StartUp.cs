using System.Media;

namespace Jeopardy
{
    public partial class StartUp : Form
    {
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
        public StartUp()
        {
            InitializeComponent();
            openingSound.SoundLocation = @"C:\Users\Isaia\OneDrive\Desktop\Jeopardy2.0\bin\Sounds\OpeningSound.wav";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            NumberOfPlayers = ((int)numericUpDown1.Value);
            ScoreCap = ((int)numericUpDown2.Value);
            Categories.Add(comboBox1.Text);
            Categories.Add(comboBox2.Text);
            Categories.Add(comboBox3.Text);
            Categories.Add(comboBox4.Text);
            Categories.Add(comboBox5.Text);
            Categories.Add(comboBox6.Text);
            if(checkBox1.Checked == true)
            {
                LosePoints = true;
            }
            Jeopardy gameForm = new Jeopardy(NumberOfPlayers, ScoreCap, Categories, LosePoints);
            openingSound.Play();
            this.Hide();
            gameForm.Show(this);

        }
    }
}