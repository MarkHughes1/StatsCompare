using System;
using System.IO;
using System.Windows.Forms;

namespace StatsCompare
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        
        private void SetWeights(Weight ClassWeight)
        {
            ClassWeight.Intellect   = Convert.ToDouble(this.numInt.Value);
            ClassWeight.Strength    = Convert.ToDouble(this.numStrength.Value);
            ClassWeight.Stamina     = Convert.ToDouble(this.numStamina.Value);
            ClassWeight.Agility     = Convert.ToDouble(this.numAgility.Value);
            ClassWeight.Haste       = Convert.ToDouble(this.numHaste.Value);
            ClassWeight.Crit        = Convert.ToDouble(this.numCrit.Value);
            ClassWeight.Versatility = Convert.ToDouble(this.numVersatility.Value);
            ClassWeight.Mastery     = Convert.ToDouble(this.numMastery.Value);
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            Weight ClassWeight = new Weight();

            SetWeights(ClassWeight);
            
            Item ItemOne = new Item();
            Item ItemTwo = new Item();
            
            ItemOne.Intellect = Convert.ToDouble(this.numInt1.Value) * ClassWeight.Intellect;
            ItemOne.Strength = Convert.ToDouble(this.numStrength1.Value) * ClassWeight.Strength;
            ItemOne.Stamina = Convert.ToDouble(this.numStamina1.Value) * ClassWeight.Stamina;
            ItemOne.Agility = Convert.ToDouble(this.numAgility1.Value) * ClassWeight.Agility;

            ItemOne.Haste = Convert.ToDouble(this.numHaste1.Value) * ClassWeight.Haste;
            ItemOne.Crit = Convert.ToDouble(this.numCrit1.Value) * ClassWeight.Crit;
            ItemOne.Versatility = Convert.ToDouble(this.numVersatility1.Value) * ClassWeight.Versatility;
            ItemOne.Mastery = Convert.ToDouble(this.numMastery1.Value) * ClassWeight.Mastery;

            ItemTwo.Intellect = Convert.ToDouble(this.numInt2.Value) * ClassWeight.Intellect;
            ItemTwo.Strength = Convert.ToDouble(this.numStrength2.Value) * ClassWeight.Strength;
            ItemTwo.Stamina = Convert.ToDouble(this.numStamina2.Value) * ClassWeight.Stamina; ;
            ItemTwo.Agility = Convert.ToDouble(this.numAgility2.Value) * ClassWeight.Agility;

            ItemTwo.Haste = Convert.ToDouble(this.numHaste2.Value) * ClassWeight.Haste;
            ItemTwo.Crit = Convert.ToDouble(this.numCrit2.Value) * ClassWeight.Crit;
            ItemTwo.Versatility = Convert.ToDouble(this.numVersatility2.Value) * ClassWeight.Versatility;
            ItemTwo.Mastery = Convert.ToDouble(this.numMastery2.Value) * ClassWeight.Mastery;
            
            textScore1.Text = ItemOne.GetScore().ToString();
            textScore2.Text = ItemTwo.GetScore().ToString();

        }

        private void btnSaveWeights_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;
            saveFile.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            StreamWriter myStream;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = new StreamWriter(saveFile.OpenFile())) != null)
                {
                    // write stream data
                    myStream.WriteLine("");

                    myStream.Close();
                }
            }

        }
    }

    class Item
    {
        public double Intellect     = 0.0;
        public double Strength      = 0.0;
        public double Stamina       = 0.0;
        public double Agility       = 0.0;
        public double Haste         = 0.0;
        public double Crit          = 0.0;
        public double Versatility   = 0.0;
        public double Mastery       = 0.0;

        public double GetScore()
        {
            double result = 0.0;
            result = Intellect + Strength + Stamina + Agility + Haste + Crit + Versatility + Mastery;
            return result;
        }

    }
    class Weight
    {
        public double Intellect     = 0.0;
        public double Strength      = 0.0;
        public double Stamina       = 0.0;
        public double Agility       = 0.0;
        public double Haste         = 0.0;
        public double Crit          = 0.0;
        public double Versatility   = 0.0;
        public double Mastery       = 0.0;
    }


}
