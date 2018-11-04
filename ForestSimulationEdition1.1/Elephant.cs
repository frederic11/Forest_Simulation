using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSimulationEdition1._1
{
    public class Elephant : Animal
    {
        SettingsData settingData = SettingsData.GetInstance();

        public Elephant()
        {
            LifeTime = settingData.ElephantLifeTime;
            StarvationPeriod = settingData.ElephantStarvationPeriod;
        }
    }
}
