using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Net;
using System;

namespace Lab2_DiscreteMathematics
{
    class Lab
    {
        // relations properties
        static bool reflexive   = false,
                    irreflexive = false;

        static bool symmetric,
                    antisymmetric,
                    asymmetric;

        static bool transitive;

        static bool connected;

        public static void ShowTaskMenu()
        {
            int[,] matrix = new int[5, 5];
            ArrayHandler.TwoDimensional.FillRandom(matrix, 0, 2);
            ArrayHandler.TwoDimensional.ConsoleOutput(matrix);
            CheckReflexivity(ref matrix);
        }

        private static void CheckReflexivity(ref int[,] relationMatrix)
        {
            int rankOfMatrix = relationMatrix.GetLength(0);
            int sumOfvaluesOnMainDiagonal = 0;

            for (int i = 0, j = 0; i < rankOfMatrix; ++i, ++j)
                sumOfvaluesOnMainDiagonal += relationMatrix[i, j];

            if (sumOfvaluesOnMainDiagonal == 0)
            {
                Console.WriteLine("антирефлексивность");
                reflexive   = false;
                irreflexive = true;
            }

            if (sumOfvaluesOnMainDiagonal == rankOfMatrix)
            {
                Console.WriteLine("рефлексивность");
                reflexive   = true;
                irreflexive = false;
            }
        }

    }
}
