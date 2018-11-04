using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ForestSimulationEdition1._1
{
    public partial class SettingsScreen : Form
    {
        public SettingsScreen()
        {
            InitializeComponent();
            
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SettingsData settingsData = SettingsData.GetInstance();

            if((int)numericUpDownForestHeight.Value* (int)numericUpDownForestWidth.Value
                < (int)numericUpDownNumberOfRocks.Value
                + (int)numericUpDownNumberOfTrees.Value
                + (int)numericUpDownNumberOfPlants.Value
                + (int)numericUpDownNumberOfMaleElephants.Value
                + (int)numericUpDownNumberOfFemaleElephants.Value
                + (int)numericUpDownNumberOfMaleLions.Value
                + (int)numericUpDownNumberOfFemaleLions.Value
                + (int)numericUpDownNumberOfMaleDeers.Value
                + (int)numericUpDownNumberOfFemaleDeers.Value)
            {
                MessageBox.Show("The numbers of elements inside the forest exceeds its size \n Kindly review your input");
                return;
            }
            settingsData.timerTick = (int)numericUpDownTimerTicks.Value;

            settingsData.forestHeight = (int)numericUpDownForestHeight.Value;
            settingsData.forestWidth = (int)numericUpDownForestWidth.Value;

            settingsData.numberOfRocks = (int)numericUpDownNumberOfRocks.Value;
            settingsData.numberOfTrees = (int)numericUpDownNumberOfTrees.Value;
            settingsData.numberOfPlants = (int)numericUpDownNumberOfPlants.Value;

            settingsData.numberOfMaleElephants = (int)numericUpDownNumberOfMaleElephants.Value;
            settingsData.numberOfFemaleElephants = (int)numericUpDownNumberOfFemaleElephants.Value;
            settingsData.ElephantLifeTime = (int)numericUpDownElephantsLifeTime.Value;
            settingsData.ElephantStarvationPeriod = (int)numericUpDownElephantsStarvationPeriod.Value;
            settingsData.ElephantGestationPeriod = (int)numericUpDownElephantsGestationPeriod.Value;

            settingsData.numberOfMaleLions = (int)numericUpDownNumberOfMaleLions.Value;
            settingsData.numberOffemaleLions = (int)numericUpDownNumberOfFemaleLions.Value;
            settingsData.LionsLifeTime = (int)numericUpDownLionsLifeTime.Value;
            settingsData.LionsStarvationPeriod = (int)numericUpDownLionsStarvationPeriod.Value;
            settingsData.LionsGestationPeriod = (int)numericUpDownLionsGestationPeriod.Value;

            settingsData.numberOfMaleDeers = (int)numericUpDownNumberOfMaleDeers.Value;
            settingsData.numberOfFemaleDeers = (int)numericUpDownNumberOfFemaleDeers.Value;
            settingsData.DeersLifeTime = (int)numericUpDownDeerLifeTime.Value;
            settingsData.DeersStarvationPeriod = (int)numericUpDownDeersStarvationPeriod.Value;
            settingsData.DeersGestationPeriod = (int)numericUpDownDeerGestationPeriod.Value;

            
            this.Close();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
