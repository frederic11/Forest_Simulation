using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSimulationEdition1._1
{
    public interface IFemaleAnimal
    {
        int GestationPeriod { get; set; }
        bool IsNewBorn { get; set; }
        int  IterationsBeforeItCanStartReproducing { get; set; }

        T GiveBirth<T>() where T: new();

    }
}
