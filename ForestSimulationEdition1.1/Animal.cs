using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSimulationEdition1._1
{
    public class Animal : Square
    {
        public int LifeTime { get; set; }
        public int StarvationPeriod { get; set; }
        public int Age { get; set; }
        public int IterationsWithoutEating { get; set; }

        public Animal()
        {
            LifeTime = 30;
            StarvationPeriod = 10;
            Age = 0;
            IterationsWithoutEating = 0;
        }

        public void Eat()
        {
            IterationsWithoutEating = 0;
        }
    }
}
