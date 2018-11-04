using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ForestSimulationEdition1._1
{
    public class Forest
    {
        public Color ForestColor { get; set; }
        public int ForestHeight { get; set; }
        public int ForestWidth { get; set; }

        public Forest()
        {
            ForestColor = Color.LightGreen;
            ForestHeight = 35;
            ForestWidth = 70;
        }

        public void CreateEmptyForest(Square mySquare, Square[,] squareMap)
        {
            int positionXX = 0;
            int positionYY = 0;
            int i, j;
            for (i = 0; i < squareMap.GetLength(0); i++)
            {
                for (j = 0; j < squareMap.GetLength(1); j++)
                {
                    squareMap[i, j] = new Square();
                    squareMap[i, j].PositionY += positionYY;
                    squareMap[i, j].PositionX += positionXX;
                    positionXX += mySquare.Width;

                }
                positionYY += mySquare.Height;
                positionXX = 0;
            }
        }

        public void MoveAnimal(Square[,] squareMap)
        {
            MaleElephant myMaleElephant = new MaleElephant();
            FemaleElephant myFemaleElephant = new FemaleElephant();
            MaleLion myMaleLion = new MaleLion();
            FemaleLion myFemaleLion = new FemaleLion();
            MaleDeer myMaleDeer = new MaleDeer();
            FemaleDeer myFemaleDeer = new FemaleDeer();
            Rock myRock = new Rock();
            Tree myTree = new Tree();
            Plant myPlant = new Plant();
            MovementRules myMovementRules = new MovementRules();
            int hasTriedCounter1 = 0;

            foreach(Square mySquare in squareMap)
            {
                mySquare.hasTried = false;
                mySquare.hasIterationPassed = false;
            }

            Random random = new Random();
            int randomJ;
            int randomI;

            for (int i = 0; i < squareMap.GetLength(0); i++)
            {
                for (int j = 0; j < squareMap.GetLength(1); j++)
                {
                    if (!squareMap[i, j].IsEmpty && !squareMap[i, j].hasIterationPassed)
                    {
                        

                        try
                        {
                            if(hasTriedCounter1 > 7)
                            {
                                squareMap[i, j].IncrementAgeIfSquareContainsAnimal(ref squareMap[i, j], squareMap[i, j].PositionX, squareMap[i, j].PositionY);
                                squareMap[i, j].IncrementIterationWithoutEatingIfSquareContainsAnimal(ref squareMap[i, j], squareMap[i, j].PositionX, squareMap[i, j].PositionY);
                                squareMap[i, j].hasIterationPassed = true;
                                foreach (Square mySquare in squareMap)
                                {
                                    mySquare.hasTried = false;
                                }
                                break;
                            }

                            randomI = i;
                            randomJ = j;
                            while (randomI == i && randomJ == j)
                            {
                                randomI = random.Next(i - 1, i + 2);
                                randomJ = random.Next(j - 1, j + 2);

                            }

                            Square tempOriginalSquare = new Square();
                            Square tempOtherSquare = new Square();
                            tempOriginalSquare = squareMap[i, j];
                            tempOtherSquare = squareMap[randomI, randomJ];

                            int tempOriginalPositionX = tempOriginalSquare.PositionX;
                            int tempOriginalPositionY = tempOriginalSquare.PositionY;
                            Color tempOriginalColor = tempOriginalSquare.SquareColor;


                            int tempOtherSquarePositionX = tempOtherSquare.PositionX;
                            int tempOtherSquarePositionY = tempOtherSquare.PositionY;
                            Color tempOtherSquareColor = tempOtherSquare.SquareColor;


                            if (myMovementRules.MoveSquare(ref tempOriginalSquare, ref tempOtherSquare, ref j, ref hasTriedCounter1))
                            {
                                squareMap[randomI, randomJ] = tempOriginalSquare;
                                squareMap[randomI, randomJ].PositionX = tempOtherSquarePositionX;
                                squareMap[randomI, randomJ].PositionY = tempOtherSquarePositionY;
                                squareMap[randomI, randomJ].SquareColor = tempOriginalColor;
                                squareMap[randomI, randomJ].IsEmpty = false;
                                squareMap[randomI, randomJ].hasIterationPassed = true;

                                squareMap[i, j] = new Square();
                                squareMap[i, j].PositionX = tempOriginalPositionX;
                                squareMap[i, j].PositionY = tempOriginalPositionY;
                                squareMap[i, j].SquareColor = Color.LimeGreen;
                                squareMap[i, j].IsEmpty = true;
                                squareMap[i, j].hasIterationPassed = true;

                                squareMap[randomI, randomJ].IncrementAgeIfSquareContainsAnimal(ref squareMap[randomI, randomJ], tempOtherSquarePositionX, tempOtherSquarePositionY);
                                squareMap[randomI, randomJ].IncrementIterationWithoutEatingIfSquareContainsAnimal(ref squareMap[randomI, randomJ], tempOtherSquarePositionX, tempOtherSquarePositionY);

                                if (squareMap[randomI, randomJ].GetType() == myFemaleElephant.GetType())
                                {
                                    foreach(Square mySquare in squareMap)
                                    {
                                        mySquare.hasTried = false;
                                    }
                                    FemaleElephant femaleElephant = (FemaleElephant)squareMap[randomI, randomJ];

                                    if ((femaleElephant.IsNewBorn && femaleElephant.Age > 5
                                        && ((femaleElephant.IterationsBeforeItCanStartReproducing + femaleElephant.Age)
                                        % femaleElephant.GestationPeriod) == 0)
                                        || (!femaleElephant.IsNewBorn && femaleElephant.Age > 0
                                        && (femaleElephant.Age % femaleElephant.GestationPeriod) == 0))
                                    {
                                        int birthGender = random.Next(0, 2);
                                        if (birthGender == 0)
                                        {
                                            MaleElephant maleElephant = femaleElephant.GiveBirth<MaleElephant>();
                                            int newBornI = randomI;
                                            int newBornJ = randomJ;
                                            newBornI = randomI;
                                            newBornJ = randomJ;
                                            int hasTriedCounter = 0;
                                            while (newBornI == randomI && newBornJ == randomJ)
                                            {
                                                newBornI = random.Next(randomI - 1, randomI + 2);
                                                newBornJ = random.Next(randomJ - 1, randomJ + 2);
                                                if (!squareMap[newBornI, newBornJ].IsEmpty)
                                                {
                                                    if (!squareMap[newBornI, newBornJ].hasTried)
                                                    {
                                                        hasTriedCounter += 1;
                                                        squareMap[newBornI, newBornJ].hasTried = true;
                                                    }
                                                    if (hasTriedCounter > 7)
                                                    {
                                                        break;
                                                    }
                                                    newBornI = randomI;
                                                    newBornJ = randomJ;

                                                }
                                            }
                                            if (squareMap[newBornI, newBornJ].IsEmpty)
                                            {
                                                Square tempSquare = squareMap[newBornI, newBornJ];
                                                squareMap[newBornI, newBornJ] = maleElephant;
                                                squareMap[newBornI, newBornJ].PositionX = tempSquare.PositionX;
                                                squareMap[newBornI, newBornJ].PositionY = tempSquare.PositionY;
                                                squareMap[newBornI, newBornJ].SquareColor = Color.Gray;
                                                squareMap[newBornI, newBornJ].IsEmpty = false;
                                                squareMap[newBornI, newBornJ].hasIterationPassed = true;
                                            }
                                        }
                                        if (birthGender == 1)
                                        {
                                            FemaleElephant femaleElephantnew = femaleElephant.GiveBirth<FemaleElephant>();
                                            femaleElephantnew.IsNewBorn = true;
                                            int newBornI = randomI;
                                            int newBornJ = randomJ;
                                            newBornI = randomI;
                                            newBornJ = randomJ;
                                            int hasTriedCounter = 0;
                                            while (newBornI == randomI && newBornJ == randomJ)
                                            {
                                                newBornI = random.Next(randomI - 1, randomI + 2);
                                                newBornJ = random.Next(randomJ - 1, randomJ + 2);
                                                if (!squareMap[newBornI, newBornJ].IsEmpty)
                                                {
                                                    if(!squareMap[newBornI, newBornJ].hasTried)
                                                    {
                                                        hasTriedCounter += 1;
                                                        squareMap[newBornI, newBornJ].hasTried = true;
                                                    }
                                                    if(hasTriedCounter > 7)
                                                    {
                                                        break;
                                                    }
                                                    newBornI = randomI;
                                                    newBornJ = randomJ;
                                                    
                                                }
                                            }
                                            if (squareMap[newBornI, newBornJ].IsEmpty)
                                            {
                                                Square tempSquare = squareMap[newBornI, newBornJ];
                                                squareMap[newBornI, newBornJ] = femaleElephantnew;
                                                squareMap[newBornI, newBornJ].PositionX = tempSquare.PositionX;
                                                squareMap[newBornI, newBornJ].PositionY = tempSquare.PositionY;
                                                squareMap[newBornI, newBornJ].SquareColor = Color.LightGray;
                                                squareMap[newBornI, newBornJ].IsEmpty = false;
                                                squareMap[newBornI, newBornJ].hasIterationPassed = true;
                                            }
                                        }
                                    }
                                }



                                if (squareMap[randomI, randomJ].GetType() == myFemaleLion.GetType())
                                {
                                    foreach (Square mySquare in squareMap)
                                    {
                                        mySquare.hasTried = false;
                                    }
                                    FemaleLion femaleLion = (FemaleLion)squareMap[randomI, randomJ];

                                    if ((femaleLion.IsNewBorn && femaleLion.Age > 5
                                        && ((femaleLion.IterationsBeforeItCanStartReproducing + femaleLion.Age)
                                        % femaleLion.GestationPeriod) == 0)
                                        || (!femaleLion.IsNewBorn && femaleLion.Age > 0
                                        && (femaleLion.Age % femaleLion.GestationPeriod) == 0))
                                    {
                                        int birthGender = random.Next(0, 2);
                                        if (birthGender == 0)
                                        {
                                            MaleLion maleLion = femaleLion.GiveBirth<MaleLion>();
                                            int newBornI = randomI;
                                            int newBornJ = randomJ;
                                            newBornI = randomI;
                                            newBornJ = randomJ;
                                            int hasTriedCounter = 0;
                                            while (newBornI == randomI && newBornJ == randomJ)
                                            {
                                                newBornI = random.Next(randomI - 1, randomI + 2);
                                                newBornJ = random.Next(randomJ - 1, randomJ + 2);
                                                if (!squareMap[newBornI, newBornJ].IsEmpty)
                                                {
                                                    if (!squareMap[newBornI, newBornJ].hasTried)
                                                    {
                                                        hasTriedCounter += 1;
                                                        squareMap[newBornI, newBornJ].hasTried = true;
                                                    }
                                                    if (hasTriedCounter > 7)
                                                    {
                                                        break;
                                                    }
                                                    newBornI = randomI;
                                                    newBornJ = randomJ;

                                                }
                                            }
                                            if (squareMap[newBornI, newBornJ].IsEmpty)
                                            {
                                                Square tempSquare = squareMap[newBornI, newBornJ];
                                                squareMap[newBornI, newBornJ] = maleLion;
                                                squareMap[newBornI, newBornJ].PositionX = tempSquare.PositionX;
                                                squareMap[newBornI, newBornJ].PositionY = tempSquare.PositionY;
                                                squareMap[newBornI, newBornJ].SquareColor = Color.Yellow;
                                                squareMap[newBornI, newBornJ].IsEmpty = false;
                                                squareMap[newBornI, newBornJ].hasIterationPassed = true;
                                            }
                                        }
                                        if (birthGender == 1)
                                        {
                                            FemaleLion femaleLionnew = femaleLion.GiveBirth<FemaleLion>();
                                            femaleLionnew.IsNewBorn = true;
                                            int newBornI = randomI;
                                            int newBornJ = randomJ;
                                            newBornI = randomI;
                                            newBornJ = randomJ;
                                            int hasTriedCounter = 0;
                                            while (newBornI == randomI && newBornJ == randomJ)
                                            {
                                                newBornI = random.Next(randomI - 1, randomI + 2);
                                                newBornJ = random.Next(randomJ - 1, randomJ + 2);
                                                if (!squareMap[newBornI, newBornJ].IsEmpty)
                                                {
                                                    if (!squareMap[newBornI, newBornJ].hasTried)
                                                    {
                                                        hasTriedCounter += 1;
                                                        squareMap[newBornI, newBornJ].hasTried = true;
                                                    }
                                                    if (hasTriedCounter > 7)
                                                    {
                                                        break;
                                                    }
                                                    newBornI = randomI;
                                                    newBornJ = randomJ;

                                                }
                                            }
                                            if (squareMap[newBornI, newBornJ].IsEmpty)
                                            {
                                                Square tempSquare = squareMap[newBornI, newBornJ];
                                                squareMap[newBornI, newBornJ] = femaleLionnew;
                                                squareMap[newBornI, newBornJ].PositionX = tempSquare.PositionX;
                                                squareMap[newBornI, newBornJ].PositionY = tempSquare.PositionY;
                                                squareMap[newBornI, newBornJ].SquareColor = Color.LightYellow ;
                                                squareMap[newBornI, newBornJ].IsEmpty = false;
                                                squareMap[newBornI, newBornJ].hasIterationPassed = true;
                                            }
                                        }
                                    }
                                }




                                if (squareMap[randomI, randomJ].GetType() == myFemaleDeer.GetType())
                                {
                                    foreach (Square mySquare in squareMap)
                                    {
                                        mySquare.hasTried = false;
                                    }
                                    FemaleDeer femaleDeer = (FemaleDeer)squareMap[randomI, randomJ];

                                    if ((femaleDeer.IsNewBorn && femaleDeer.Age > 5
                                        && ((femaleDeer.IterationsBeforeItCanStartReproducing + femaleDeer.Age)
                                        % femaleDeer.GestationPeriod) == 0)
                                        || (!femaleDeer.IsNewBorn && femaleDeer.Age > 0
                                        && (femaleDeer.Age % femaleDeer.GestationPeriod) == 0))
                                    {
                                        int birthGender = random.Next(0, 2);
                                        if (birthGender == 0)
                                        {
                                            MaleDeer maleDeer = femaleDeer.GiveBirth<MaleDeer>();
                                            int newBornI = randomI;
                                            int newBornJ = randomJ;
                                            newBornI = randomI;
                                            newBornJ = randomJ;
                                            int hasTriedCounter = 0;
                                            while (newBornI == randomI && newBornJ == randomJ)
                                            {
                                                newBornI = random.Next(randomI - 1, randomI + 2);
                                                newBornJ = random.Next(randomJ - 1, randomJ + 2);
                                                if (!squareMap[newBornI, newBornJ].IsEmpty)
                                                {
                                                    if (!squareMap[newBornI, newBornJ].hasTried)
                                                    {
                                                        hasTriedCounter += 1;
                                                        squareMap[newBornI, newBornJ].hasTried = true;
                                                    }
                                                    if (hasTriedCounter > 7)
                                                    {
                                                        break;
                                                    }
                                                    newBornI = randomI;
                                                    newBornJ = randomJ;

                                                }
                                            }
                                            if (squareMap[newBornI, newBornJ].IsEmpty)
                                            {
                                                Square tempSquare = squareMap[newBornI, newBornJ];
                                                squareMap[newBornI, newBornJ] = maleDeer;
                                                squareMap[newBornI, newBornJ].PositionX = tempSquare.PositionX;
                                                squareMap[newBornI, newBornJ].PositionY = tempSquare.PositionY;
                                                squareMap[newBornI, newBornJ].SquareColor = Color.Pink;
                                                squareMap[newBornI, newBornJ].IsEmpty = false;
                                                squareMap[newBornI, newBornJ].hasIterationPassed = true;
                                            }
                                        }
                                        if (birthGender == 1)
                                        {
                                            FemaleDeer femaleDeernew = femaleDeer.GiveBirth<FemaleDeer>();
                                            femaleDeernew.IsNewBorn = true;
                                            int newBornI = randomI;
                                            int newBornJ = randomJ;
                                            newBornI = randomI;
                                            newBornJ = randomJ;
                                            int hasTriedCounter = 0;
                                            while (newBornI == randomI && newBornJ == randomJ)
                                            {
                                                newBornI = random.Next(randomI - 1, randomI + 2);
                                                newBornJ = random.Next(randomJ - 1, randomJ + 2);
                                                if (!squareMap[newBornI, newBornJ].IsEmpty)
                                                {
                                                    if (!squareMap[newBornI, newBornJ].hasTried)
                                                    {
                                                        hasTriedCounter += 1;
                                                        squareMap[newBornI, newBornJ].hasTried = true;
                                                    }
                                                    if (hasTriedCounter > 7)
                                                    {
                                                        break;
                                                    }
                                                    newBornI = randomI;
                                                    newBornJ = randomJ;

                                                }
                                            }
                                            if (squareMap[newBornI, newBornJ].IsEmpty)
                                            {
                                                Square tempSquare = squareMap[newBornI, newBornJ];
                                                squareMap[newBornI, newBornJ] = femaleDeernew;
                                                squareMap[newBornI, newBornJ].PositionX = tempSquare.PositionX;
                                                squareMap[newBornI, newBornJ].PositionY = tempSquare.PositionY;
                                                squareMap[newBornI, newBornJ].SquareColor = Color.LightPink;
                                                squareMap[newBornI, newBornJ].IsEmpty = false;
                                                squareMap[newBornI, newBornJ].hasIterationPassed = true;
                                            }
                                        }
                                    }
                                }



                                foreach(Square mySquare in squareMap)
                                {
                                    mySquare.hasTried = false;
                                }



                            }
                        }
                        catch (IndexOutOfRangeException)
                        {
                            if ((i == 0 && j == 0)
                                || (i == squareMap.GetLength(0) - 1 && j == squareMap.GetLength(1) - 1)
                                || (i == 0 && j == squareMap.GetLength(1) - 1)
                                || (i == squareMap.GetLength(0) - 1 && j == 0))
                            {
                                if (hasTriedCounter1 > 2) { break; }
                                j--;
                            }
                            else
                            {
                                if (hasTriedCounter1 > 4) { break; }
                                j--;
                            }
                        }

                    }




                }
            }

           

        }




    }
}
