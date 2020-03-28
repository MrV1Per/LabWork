using System;

namespace Lab4._16
{
    class Program
    {
        /// <summary>
        /// Function to find Sum from the assignment
        /// </summary>
        /// <param name="formulaM">Variable M from assignment</param>
        /// <param name="transposition">Transposition assignment</param>
        /// <param name="matrixD">Matrix from assignment</param>
        public void FindSum(byte formulaM, byte[] transposition, byte[,] matrixD)
        {  
            byte finalSum = 0;
            for (byte formulaI = 1; formulaI <= formulaM; formulaI++)
            {
                finalSum += TakeNumOfMatrix(formulaI, transposition, matrixD);
            }
            Console.WriteLine($"\nThe sum is -> {finalSum}");
        }

        /// <summary>
        /// Checks if elements are outside the matrix, and returns a number to search for the sum
        /// </summary>
        /// <param name="formulaI">Variable i from assignment</param>
        /// <param name="transposition">Transposition from assignment</param>
        /// <param name="matrixD">Matrix from assignment</param>
        public byte TakeNumOfMatrix(byte formulaI, byte[] transposition, byte[,] matrixD)
        {
            byte formulaJ = formulaI++, receivedNumber = 0;
            try
            {
                receivedNumber = FindReceivedNumber(formulaI, formulaJ, transposition, matrixD);
            }
            catch
            {
                if (transposition[formulaJ] == 4)
                {
                    transposition[formulaJ] = transposition[1];
                    receivedNumber = FindReceivedNumber(formulaI, formulaJ, transposition, matrixD);
                }
                else
                {
                    transposition[formulaI] = transposition[1];
                    receivedNumber = FindReceivedNumber(formulaI, formulaJ, transposition, matrixD);
                }
            }
            return receivedNumber;
        }

        /// <summary>
        /// Function for finding a number in a matrix based on an enumeration
        /// </summary>
        /// <param name="matrixRowId">Matrix Row Number (Automatically based on movement)</param>
        /// <param name="matrixColumId">Matrix Column Number (Automatically based on movement)</param>
        /// <param name="transposition">Transposition from assignment </param>
        /// <param name="matrixD"> Matrix from assignment</param>
        /// <returns></returns>
        public byte FindReceivedNumber(byte matrixRowId, byte matrixColumId, byte[] transposition, byte[,] matrixD)
        {
            byte receivedNumber = 0;
            receivedNumber = matrixD[transposition[matrixRowId], transposition[matrixColumId]];
            Console.WriteLine($"Matrix [{transposition[matrixColumId]}][{transposition[matrixRowId]}] -> {receivedNumber}");
            return receivedNumber;
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            byte[] transposition = { 2, 3, 1, 4, 2, 3, 1, 4 };
            byte[,] matrixD ={
                {2, 2, 1, 0},
                {3, 0, 6, 5},
                {2, 5, 1, 2},
                {5, 2, 3, 0}
            };
            byte formulaM = 4;
            Console.WriteLine($"The task:\nThe permutation P = (p1,p2,p3,p4) of the elements of the set (1,2,3,4) and the  4x4 matrix " +
                $"D = [d(ij)] are specified.\nDetermine the value of the function F(P) = Sum(d(p(i),p(i+1))), P(m+1) = P(1) and print it. " +
                $"\n\nInitial data: m = { formulaM },\nP = (2,3,1,4)\nD = 2 2 1 0\n    3 0 6 5\n    2 5 1 2\n    5 2 3 0\n\n");
            prog.FindSum(formulaM, transposition, matrixD);

            Console.WriteLine("Program finished work");
            Console.Read();
        }
    }
}
