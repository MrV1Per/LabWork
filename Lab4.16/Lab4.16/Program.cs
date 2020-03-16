using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4._16
{
    class Program
    {

        /// <summary>
        /// Function to find Sum from the assignment
        /// </summary>
        /// <param name="FormulaM">Variable M from assignment</param>
        /// <param name="Transposition">Transposition assignment</param>
        /// <param name="MatrixD">Matrix from assignment</param>
        public static void FindSum(byte FormulaM, byte[] Transposition, byte[,] MatrixD)
        {
            
            byte FinalSum = 0;
            for (byte FormulaI = 1; FormulaI <= FormulaM; FormulaI++)
            {
                FinalSum += TakeNumOfMatrix(FormulaI, Transposition, MatrixD);
            }
            Console.WriteLine($"\nThe sum is -> {FinalSum}");
        }

        /// <summary>
        /// Checks if elements are outside the matrix, and returns a number to search for the sum
        /// </summary>
        /// <param name="FormulaI">Variable i from assignment</param>
        /// <param name="Transposition">Transposition from assignment</param>
        /// <param name="MatrixD">Matrix from assignment</param>
        public static byte TakeNumOfMatrix(byte FormulaI, byte[] Transposition, byte[,] MatrixD)
        {
            byte FormulaJ = FormulaI++, ReceivedNumber = 0;
           

            try
            {
                ReceivedNumber = FindReceivedNumber(FormulaI, FormulaJ, Transposition, MatrixD);
            }
            catch
            {
                if (Transposition[FormulaJ] == 4)
                {
                    Transposition[FormulaJ] = Transposition[1];
                    ReceivedNumber = FindReceivedNumber(FormulaI, FormulaJ, Transposition, MatrixD);
                }
                else
                {
                    Transposition[FormulaI] = Transposition[1];
                    ReceivedNumber = FindReceivedNumber(FormulaI, FormulaJ, Transposition, MatrixD);
                }
            }

            return ReceivedNumber;
        }

        /// <summary>
        /// Function for finding a number in a matrix based on an enumeration
        /// </summary>
        /// <param name="MatrixRowId">Matrix Row Number (Automatically based on movement)</param>
        /// <param name="MatrixColumId">Matrix Column Number (Automatically based on movement)</param>
        /// <param name="Transposition">Transposition from assignment </param>
        /// <param name="MatrixD"> Matrix from assignment</param>
        /// <returns></returns>
        public static byte FindReceivedNumber(byte MatrixRowId, byte MatrixColumId, byte[] Transposition, byte[,] MatrixD)
        {
            byte ReceivedNumber = 0;
            ReceivedNumber = MatrixD[Transposition[MatrixRowId], Transposition[MatrixColumId]];
            Console.WriteLine($"Matrix [{Transposition[MatrixColumId]}][{Transposition[MatrixRowId]}] -> {ReceivedNumber}");
            return ReceivedNumber;
        }


        
        static void Main(string[] args)
        {
            byte[] Transposition = { 2, 3, 1, 4, 2, 3, 1, 4 };
            byte[,] MatrixD ={
                {2, 2, 1, 0},
                {3, 0, 6, 5},
                {2, 5, 1, 2},
                {5, 2, 3, 0}
            };
            byte FormulaM = 4;
            Console.WriteLine($"The task:\nThe permutation P = (p1,p2,p3,p4) of the elements of the set (1,2,3,4) and the  4x4 matrix D = [d(ij)] are specified.\nDetermine the value of the function F(P) = Sum(d(p(i),p(i+1))), P(m+1) = P(1) and print it. \n\nInitial data: m = { FormulaM },\nP = (2,3,1,4)\nD = 2 2 1 0\n    3 0 6 5\n    2 5 1 2\n    5 2 3 0\n\n");
            FindSum(FormulaM, Transposition, MatrixD);

            Console.WriteLine("Program finished work");
            Console.Read();
        }
    }
}
