using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSimulationEdition1._1
{
    public class FemaleDeer: Deer, IFemaleAnimal
    {
        SettingsData settingsData = SettingsData.GetInstance();
        public int GestationPeriod { get; set; }
        public bool IsNewBorn { get; set; }
        public int IterationsBeforeItCanStartReproducing { get; set; }

        public FemaleDeer()
        {
            GestationPeriod = settingsData.DeersGestationPeriod;
            IsNewBorn = false;
            IterationsBeforeItCanStartReproducing = 5;
        }

        public T GiveBirth<T>() where T : new()
        {
            return new T();
        }
    }
}
