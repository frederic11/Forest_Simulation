using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSimulationEdition1._1
{
    public class Lion : Animal
    {
        SettingsData settingsData = SettingsData.GetInstance();
        public Lion()
        {
            LifeTime = settingsData.LionsLifeTime;
            StarvationPeriod = settingsData.LionsStarvationPeriod;
        }
    }
}
