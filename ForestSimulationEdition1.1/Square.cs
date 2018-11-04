using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ForestSimulationEdition1._1
{
    public class Square
    {
        public Color SquareColor { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public bool IsEmpty { get; set; }
        public bool hasIterationPassed { get; set; }
        public bool hasTried { get; set; }

        public Square(){
            SquareColor = Color.LimeGreen;
            Width = 10;
            Height = 10;
            PositionX = 0;
            PositionY = 0;
            IsEmpty = true;
            hasIterationPassed = false;
            hasTried = false;
            }

        public void IncrementAgeIfSquareContainsAnimal(ref Square mySquare, int tempOtherSquarePositionX, int tempOtherSquarePositionY)
        {
            MaleElephant myMaleElephant = new MaleElephant();
            FemaleElephant myFemaleElephant = new FemaleElephant();
            MaleLion myMaleLion = new MaleLion();
            FemaleLion myFemaleLion = new FemaleLion();
            MaleDeer myMaleDeer = new MaleDeer();
            FemaleDeer myFemaleDeer = new FemaleDeer();

            if (mySquare.GetType() == myMaleElephant.GetType()
                                || mySquare.GetType() == myFemaleElephant.GetType()
                                || mySquare.GetType() == myMaleLion.GetType()
                                || mySquare.GetType() == myFemaleLion.GetType()
                                || mySquare.GetType() == myMaleDeer.GetType()
                                || mySquare.GetType() == myFemaleDeer.GetType())
            {
                Animal animal = (Animal)mySquare;
                animal.Age++;
                if (animal.Age <= animal.LifeTime)
                {
                    mySquare = animal;
                }
                else
                {
                    mySquare = new Square();
                    mySquare.PositionX = tempOtherSquarePositionX;
                    mySquare.PositionY = tempOtherSquarePositionY;
                    mySquare.IsEmpty = true;
                    mySquare.hasIterationPassed = true;
                }
            }
        }

        public void IncrementIterationWithoutEatingIfSquareContainsAnimal(ref Square mySquare, int tempOtherSquarePositionX, int tempOtherSquarePositionY)
        {
            MaleElephant myMaleElephant = new MaleElephant();
            FemaleElephant myFemaleElephant = new FemaleElephant();
            MaleLion myMaleLion = new MaleLion();
            FemaleLion myFemaleLion = new FemaleLion();
            MaleDeer myMaleDeer = new MaleDeer();
            FemaleDeer myFemaleDeer = new FemaleDeer();

            if (mySquare.GetType() == myMaleElephant.GetType()
                                || mySquare.GetType() == myFemaleElephant.GetType()
                                || mySquare.GetType() == myMaleLion.GetType()
                                || mySquare.GetType() == myFemaleLion.GetType()
                                || mySquare.GetType() == myMaleDeer.GetType()
                                || mySquare.GetType() == myFemaleDeer.GetType())
            {
                Animal animal = (Animal)mySquare;
                animal.IterationsWithoutEating++;
                if (animal.IterationsWithoutEating <= animal.StarvationPeriod)
                {
                    mySquare = animal;
                }
                else
                {
                    mySquare = new Square();
                    mySquare.PositionX = tempOtherSquarePositionX;
                    mySquare.PositionY = tempOtherSquarePositionY;
                    mySquare.IsEmpty = true;
                    mySquare.hasIterationPassed = true;
                }
            }
        }

    }
}
