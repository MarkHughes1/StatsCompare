using System;
using System.Windows.Forms;
using System.Xml;

namespace StatsCompare
{
    
    public partial class Form1 : Form
    {
        Weight ClassWeight = new Weight();
        XmlDocument doc = new XmlDocument();

        public Form1()
        {
            InitializeComponent();
            ReadWeightsFile();
            ReadWeightsFileForMenuOptions();
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

        private void ReadWeightsFileForMenuOptions()
        {
            //var itemNodes = ;
            var clNodes = doc.SelectNodes("Class");
            foreach (XmlNode ClassNode in clNodes)
            {
                string ClassName = ClassNode.ChildNodes.ToString();
            }
        }

        public void ReadWeightsFile()
        {
            doc.Load(@"D:\GitProjects\StatsCompare\StatsCompare\Weights.xml");
        }

        private void ReadClassAndSpecSpecificWeightData()
        {
            var clNodes = doc.SelectNodes("Class");
            foreach (XmlNode ClassNode in clNodes)
            {
                var PlayerClass = doc.SelectNodes("Warlock");
                foreach (XmlNode node in PlayerClass)
                {
                    var Specialization = node.SelectNodes("Destruction");
                    foreach (XmlNode loc in Specialization)
                    {
                        ClassWeight.Intellect = Convert.ToDouble(loc.SelectSingleNode("Intellect").InnerText);
                        ClassWeight.Strength = Convert.ToDouble(loc.SelectSingleNode("Strength").InnerText);
                        ClassWeight.Stamina = Convert.ToDouble(loc.SelectSingleNode("Stamina").InnerText);
                        ClassWeight.Agility = Convert.ToDouble(loc.SelectSingleNode("Agility").InnerText);
                        ClassWeight.Haste = Convert.ToDouble(loc.SelectSingleNode("Haste").InnerText);
                        ClassWeight.Crit = Convert.ToDouble(loc.SelectSingleNode("Crit").InnerText);
                        ClassWeight.Versatility = Convert.ToDouble(loc.SelectSingleNode("Versatility").InnerText);
                        ClassWeight.Mastery = Convert.ToDouble(loc.SelectSingleNode("Mastery").InnerText);
                    }
                }
            }
        }



        private void btnCompare_Click(object sender, EventArgs e)
        {
           
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
            saveFile.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;
            saveFile.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                // Create the XmlDocument.
                XmlDocument doc = new XmlDocument();

                doc.LoadXml("<Warlock> </Warlock>");
                // Add a price element.
                XmlElement newElem = doc.CreateElement("Destruction");

                newElem.InnerText = "Intellect";
                doc.DocumentElement.AppendChild(newElem);

                // Save the document to a file. White space is
                // preserved (no white space).
                doc.PreserveWhitespace = true;
                doc.Save(saveFile.FileName);
                
            }

        }

        private void classToolStripMenuItem_Click(object sender, EventArgs e)
        {
              }

        private void classToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string classSelection = this.comboBox1.SelectedItem.ToString();

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
