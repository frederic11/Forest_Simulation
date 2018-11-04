using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSimulationEdition1._1
{
    public class FemaleLion: Lion, IFemaleAnimal
    {
        SettingsData settingsData = SettingsData.GetInstance();
        public int GestationPeriod { get; set; }
        public bool IsNewBorn { get; set; }
        public int IterationsBeforeItCanStartReproducing { get; set; }

        public FemaleLion()
        {
            GestationPeriod = settingsData.LionsGestationPeriod;
            IsNewBorn = false;
            IterationsBeforeItCanStartReproducing = 5;
        }

        public T GiveBirth<T>() where T : new()
        {
            return new T();
        }
    }
}
