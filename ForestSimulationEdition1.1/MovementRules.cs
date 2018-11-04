using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForestSimulationEdition1._1
{
    class MovementRules
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
        Square myEmptySquare = new Square();

        public bool MoveSquare(ref Square originalSquare, ref Square otherSquare, ref int retry, ref int hasTriedCounter)
        {
            Type originalSquareType = originalSquare.GetType();
            Type otherSquareType = otherSquare.GetType();
            Type maleElephantType = myMaleElephant.GetType();
            Type femaleElephantType = myFemaleElephant.GetType();
            Type maleLionType = myMaleLion.GetType();
            Type femaleLionType = myFemaleLion.GetType();
            Type maleDeerType = myMaleDeer.GetType();
            Type femaleDeerType = myFemaleDeer.GetType();
            Type rockType = myRock.GetType();
            Type treeType = myTree.GetType();
            Type plantType = myPlant.GetType();
            Type emptySqaureType = myEmptySquare.GetType();

            if (originalSquareType == rockType
                || originalSquareType == treeType
                || originalSquareType == plantType)
                return false;

            if ((originalSquareType == maleElephantType
                || originalSquareType == femaleElephantType
                || originalSquareType == maleLionType
                || originalSquareType == femaleLionType
                || originalSquareType == maleDeerType
                || originalSquareType == femaleDeerType)
                && (otherSquareType == emptySqaureType))
                return true;

            if ((originalSquareType == maleElephantType
                || originalSquareType == femaleElephantType
                || originalSquareType == maleLionType
                || originalSquareType == femaleLionType
                || originalSquareType == maleDeerType
                || originalSquareType == femaleLionType)
                && (otherSquareType == rockType))
            {
                retry--;
                if (otherSquare.hasTried == false) { hasTriedCounter += 1; }
                otherSquare.hasTried = true;
                return false;
            }

            if ((originalSquareType == maleElephantType
                || originalSquareType == femaleElephantType)
                && (otherSquareType == treeType))
            {
                callEatMethodOnAnimal(ref originalSquare);
                return true;
            }

            if ((originalSquareType == maleLionType
                || originalSquareType == femaleLionType
                || originalSquareType == maleDeerType
                || originalSquareType == femaleLionType)
                && (otherSquareType == treeType))
            {
                retry--;
                if(otherSquare.hasTried == false) { hasTriedCounter += 1; }
                otherSquare.hasTried = true;
                return false;
            }

            if ((originalSquareType == maleElephantType
                || originalSquareType == femaleElephantType
                || originalSquareType == maleLionType
                || originalSquareType == femaleLionType)
                && (otherSquareType == treeType))
            {
                return true;
            }

            if ((originalSquareType == maleDeerType
                || originalSquareType == femaleDeerType)
                && (otherSquareType == plantType))
            {
                callEatMethodOnAnimal(ref originalSquare);
                return true;
            }

            if ((originalSquareType == maleElephantType
                || originalSquareType == femaleElephantType
                || originalSquareType == maleLionType
                || originalSquareType == femaleLionType
                || originalSquareType == maleDeerType
                || originalSquareType == femaleLionType)
                && (otherSquareType == maleElephantType
                ||  otherSquareType == femaleElephantType))
            {
                retry--;
                if (otherSquare.hasTried == false) { hasTriedCounter += 1; }
                otherSquare.hasTried = true;
                return false;
            }

            if ((originalSquareType == maleElephantType
                || originalSquareType == femaleElephantType)
                && (otherSquareType == maleLionType
                || otherSquareType == femaleLionType))
            {
                return true;
            }

            if (( originalSquareType == maleLionType
                || originalSquareType == femaleLionType
                || originalSquareType == maleDeerType
                || originalSquareType == femaleLionType)
                && (otherSquareType == maleLionType
                || otherSquareType == femaleLionType))
            {
                retry--;
                if (otherSquare.hasTried == false) { hasTriedCounter += 1; }
                otherSquare.hasTried = true;
                return false;
            }

            if ((originalSquareType == maleElephantType
                || originalSquareType == femaleElephantType)
                && (otherSquareType == maleDeerType
                || otherSquareType == femaleDeerType))
            {
                return true;
            }

            if ((originalSquareType == maleLionType
                || originalSquareType == femaleLionType)
                && (otherSquareType == maleDeerType
                || otherSquareType == femaleDeerType))
            {
                callEatMethodOnAnimal(ref originalSquare);
                return true;
            }

            if ((originalSquareType == maleLionType
                || originalSquareType == femaleLionType)
                && (otherSquareType == maleDeerType
                || otherSquareType == femaleDeerType))
            {
                retry--;
                if (otherSquare.hasTried == false) { hasTriedCounter += 1; }
                otherSquare.hasTried = true;
                return false;
            }
            
            return false;
        }

        public void callEatMethodOnAnimal(ref Square animal)
        {
            Animal originalAnimal = (Animal)animal;
            originalAnimal.Eat();
            animal = originalAnimal;
        }
    }
}
