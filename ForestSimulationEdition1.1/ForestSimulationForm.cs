using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ForestSimulationEdition1._1
{
    public partial class ForestSimulationForm : Form
    {
        Forest myForest;
        Square mySquare;
        Square[,] squareMap;
        Bitmap bmp;
        int counter = 0;
        int counter1;


        public ForestSimulationForm()
        {
            InitializeComponent();
            counter1 = 0;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            if (counter1 <= 1)
            {
                var settingsData = SettingsData.GetInstance();
                timer1.Interval = settingsData.timerTick;
                myForest = new Forest();
                myForest.ForestHeight = settingsData.forestHeight;
                myForest.ForestWidth = settingsData.forestWidth;
                mySquare = new Square();
                squareMap = new Square[myForest.ForestHeight, myForest.ForestWidth];
                Random randomNumber = new Random();


                myForest.CreateEmptyForest(mySquare, squareMap);
                MapObjectCreation.PlaceObjectonMap<MaleElephant>(settingsData.numberOfMaleElephants, randomNumber, squareMap, Color.Gray);
                MapObjectCreation.PlaceObjectonMap<FemaleElephant>(settingsData.numberOfFemaleElephants, randomNumber, squareMap, Color.LightGray);
                MapObjectCreation.PlaceObjectonMap<MaleLion>(settingsData.numberOfMaleLions, randomNumber, squareMap, Color.Yellow);
                MapObjectCreation.PlaceObjectonMap<FemaleLion>(settingsData.numberOffemaleLions, randomNumber, squareMap, Color.LightYellow);
                MapObjectCreation.PlaceObjectonMap<MaleDeer>(settingsData.numberOfMaleDeers, randomNumber, squareMap, Color.Pink);
                MapObjectCreation.PlaceObjectonMap<FemaleDeer>(settingsData.numberOfFemaleDeers, randomNumber, squareMap, Color.LightPink);
                MapObjectCreation.PlaceObjectonMap<Rock>(settingsData.numberOfRocks, randomNumber, squareMap, Color.Black);
                MapObjectCreation.PlaceObjectonMap<Tree>(settingsData.numberOfTrees, randomNumber, squareMap, Color.Fuchsia);
                MapObjectCreation.PlaceObjectonMap<Plant>(settingsData.numberOfPlants, randomNumber, squareMap, Color.Orange);
                
                DrawComplteForest(e.Graphics);


                bmp = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
                if (counter == 0) { pictureBox1.Image = bmp; counter++; }

            }
            counter1++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            myForest.MoveAnimal(squareMap);

            using (Graphics G = Graphics.FromImage(pictureBox1.Image))
            {
                DrawComplteForest(G);
                pictureBox1.Invalidate();
            }
        }



        private void DrawComplteForest(Graphics G)
        {
            var settingsData = SettingsData.GetInstance();
            SolidBrush myBrush = new SolidBrush(myForest.ForestColor);
            G.FillRectangle(myBrush, 0, 0, settingsData.forestWidth * mySquare.Height, settingsData.forestHeight * mySquare.Width);

            foreach (Square mySquare in squareMap)
            {
                SolidBrush myBrush1 = new SolidBrush(mySquare.SquareColor);
                G.FillRectangle(myBrush1, mySquare.PositionX, mySquare.PositionY, mySquare.Height - 2, mySquare.Width - 2);
            }
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            timer1.Start();
            button_Start.Enabled = false;
            button_Pause.Enabled = true;
        }

        private void button_Pause_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button_Start.Enabled = true;
            button_Pause.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button_Start.Enabled = true;
            button_Pause.Enabled = false;
            counter1 = 1;
            pictureBox1.Invalidate();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button_Start.Enabled = false;
            button_Pause.Enabled = false;
            SettingsScreen settings = new SettingsScreen();
            settings.ShowDialog();
        }

        private void ForestSimulationForm_Activated(object sender, EventArgs e)
        {
            
        }

        private void ForestSimulationForm_Enter(object sender, EventArgs e)
        {
            using (Graphics G = Graphics.FromImage(pictureBox1.Image))
            {
                DrawComplteForest(G);
                pictureBox1.Invalidate();
            }
        }

        private void mapKeysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapKeys form = new MapKeys();
            form.Show();
        }
    }
}
