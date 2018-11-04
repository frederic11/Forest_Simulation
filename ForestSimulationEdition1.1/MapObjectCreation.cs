using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ForestSimulationEdition1._1
{
    static class MapObjectCreation
    {
        public static void PlaceObjectonMap<T>(int NumberOfObjects, Random randomNumber, Square[,] squareMap, Color color) where T : Square, new()
        {
            for (int i = 0; i < NumberOfObjects; i++)
            {
                T myObject = new T();
                myObject.SquareColor = color;
                int randomX = randomNumber.Next(0, squareMap.GetLength(0));
                int randomY = randomNumber.Next(0, squareMap.GetLength(1));
                myObject.PositionX = squareMap[randomX, randomY].PositionX;
                myObject.PositionY = squareMap[randomX, randomY].PositionY;
                myObject.IsEmpty = false;

                if (squareMap[randomX, randomY].IsEmpty)
                {
                    squareMap[randomX, randomY] = myObject;
                }
                else
                {
                    i--;
                }
            }
        }
    }
}
