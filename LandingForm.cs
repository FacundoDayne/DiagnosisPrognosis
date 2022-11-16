using System.Drawing;

namespace DiagnosisPrognosis
{
    public partial class LandingForm : Form
    {
        public static string DatabasePath;
        public LandingForm()
        {
            InitializeComponent();
        }

        private void LandingForm_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                DatabasePath = openFileDialog1.FileName;
            }
            label1.Text = SQLCommands.getSymptom(1).ToString();
        }
    }
}