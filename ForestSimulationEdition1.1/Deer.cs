using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSimulationEdition1._1
{
    public class Deer: Animal
    {
        SettingsData settingsData = SettingsData.GetInstance();

        public Deer()
        {
            LifeTime = settingsData.DeersLifeTime;
            StarvationPeriod = settingsData.DeersStarvationPeriod;
        }
    }
}
