using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSimulationEdition1._1
{
    public class SettingsData
    {
        public static SettingsData instance;
        
        private SettingsData()
        {
            timerTick = 1000;

            forestHeight = 35;
            forestWidth = 70;

            numberOfMaleElephants = 10;
            numberOfFemaleElephants = 10;
            numberOfMaleLions = 10;
            numberOffemaleLions = 10;
            numberOfMaleDeers = 10;
            numberOfFemaleDeers = 10;

            ElephantLifeTime = 30;
            ElephantStarvationPeriod = 10;
            ElephantGestationPeriod = 5;

            LionsLifeTime = 30;
            LionsStarvationPeriod = 10;
            LionsGestationPeriod = 5;

            DeersLifeTime = 30;
            DeersStarvationPeriod = 10;
            DeersGestationPeriod = 5;

            numberOfRocks = 10;
            numberOfTrees = 10;
            numberOfPlants = 10;
        }

        public static SettingsData GetInstance()
        {
            if (instance == null)
            {
                instance = new SettingsData();
            }
            return instance;
        }

        public int timerTick { get; set; }
        public int forestHeight { get; set; }
        public int forestWidth { get; set; }
        public int numberOfMaleElephants { get; set; }
        public int numberOfFemaleElephants { get; set; }
        public int ElephantLifeTime { get; set; }
        public int ElephantStarvationPeriod { get; set; }
        public int ElephantGestationPeriod { get; set; }
        public int numberOfMaleLions { get; set; }
        public int numberOffemaleLions { get; set; }
        public int LionsLifeTime { get; set; }
        public int LionsStarvationPeriod { get; set; }
        public int LionsGestationPeriod { get; set; }
        public int numberOfMaleDeers { get; set; }
        public int numberOfFemaleDeers { get; set; }
        public int DeersLifeTime { get; set; }
        public int DeersStarvationPeriod { get; set; }
        public int DeersGestationPeriod { get; set; }
        public int numberOfRocks { get; set; }
        public int numberOfTrees { get; set; }
        public int numberOfPlants { get; set; }
    }
}
