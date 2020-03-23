using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Lab7._16
{
    class Program
    {
        static void Main(string[] args)
        {
            //Эта программа поможет найти строку в матрице, в которой все елементы делятся на 3 без остачи
            Console.WriteLine("Hello dear user This program will help you find a row in the matrix \nin which all elements are divided by 3 without remainder");
            byte MatrixSize = byte.Parse(EzInterface("\nEnter size of matrix (Only numbers)"));
            Console.Clear();
            FindLineWithNums(FillMatrix(MatrixSize), MatrixSize);

            Console.ReadLine();
        }

        #region FindLineWithNums
        private static void FindLineWithNums (int[,] IntArray, byte MatrixSize)
        {
            for(byte MatrixRow = 0; MatrixRow < MatrixSize; MatrixRow++)
            {
                byte Num = 0;
                for(byte MatrixColum = 0; MatrixColum <= MatrixSize; MatrixColum++)
                {
                    if (Num == MatrixSize)
                    {
                        Print1Line(IntArray, MatrixSize, MatrixRow);
                    }
                    else if (IntArray[MatrixRow, MatrixColum] % 3 == 0)
                        Num++;
                    else
                        break;
                        
                }
                Num = 0;
            }
        }
        #endregion

        #region FillMatrix
        /// <summary>
        /// Creating and fill a matrix (Создание и заполнение матрицы)
        /// </summary>
        /// <returns>Returns a filled integer matrix (2 dimensional array) (Возврашщает заполненую целочисленнуюматрицу (2 мерный массив))</returns>
        private static int[,] FillMatrix (byte MatrixSize)
        {
            int[,] IntArray = new int[MatrixSize, MatrixSize];

            byte Menu = Convert.ToByte(EzInterface("1          => Fill matrix automatically (Заполнить матрицу автоматичесски)\nAny number => Fill matrix manually (Любая другая кнопка чтобы заполнить матрицу вручную)"));

            bool AutoFill = Menu == 1 ? true : false;
            IntArray = AutoFill ? AutoFillMatrixx(IntArray, MatrixSize) : ManualFillMatrixx(IntArray, MatrixSize);
            return IntArray;
        }
        #endregion

        #region AutoFillMatrixx
        /// <summary>
        /// Automatically fills the matrix (Автоматичесски заполнет матрицу)
        /// </summary>
        /// <param name="IntArray">Array of numbers (Массив чисел)</param>
        /// <param name="MatrixSize">Array size (Размер массива)</param>
        private static int[,] AutoFillMatrixx(int[,] IntArray, byte MatrixSize)
        {
            Console.Clear();
            for (byte MatrixRow = 0; MatrixRow < MatrixSize; MatrixRow++)
            {
                for(byte MatrixColum = 0; MatrixColum < MatrixSize; MatrixColum++)
                {
                    Random rand = new Random();
                    Thread.Sleep(200);
                    IntArray[MatrixRow, MatrixColum] = rand.Next(15);
                    Console.Write($"{IntArray[MatrixRow, MatrixColum]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("If nothing is output to the console, then not a single line satisfies the parameters");
            return IntArray;
        }
        #endregion

        #region ManualFill
        /// <summary>
        /// Manual fills the matrix (Ручное заполнение матрицы)
        /// </summary>
        /// <param name="IntArray">Array of numbers (Массив чисел)</param>
        /// <param name="MatrixSize">Array size (Размер массива)</param>
        /// <returns>Returns a filled array (Возвращает заполненый массив)</returns>
        private static int[,] ManualFillMatrixx(int[,] IntArray, byte MatrixSize)
        {
            Console.WriteLine("Enter the numbers one by one, and press Enter to fill the array \nПоочередно вводите числа, и нажиайте ентер для заполнения массива");
            Console.Clear();
            for (byte MatrixRow = 0; MatrixRow < MatrixSize; MatrixRow++)
            {
                for (byte MatrixColum = 0; MatrixColum < MatrixSize; MatrixColum++)
                {
                    Console.Write($"Matrix [{MatrixRow}][{MatrixColum}] => ");
                    IntArray[MatrixRow, MatrixColum] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
            Console.Clear();
            Console.WriteLine("The resulting matrix:");
            for (byte MatrixRow = 0; MatrixRow < MatrixSize; MatrixRow++)
            {
                for (byte MatrixColum = 0; MatrixColum < MatrixSize; MatrixColum++)
                {
                    Console.Write($"{IntArray[MatrixRow, MatrixColum]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("If nothing is output to the console, then not a single line satisfies the parameters");
            return IntArray;
        }
        #endregion

        #region EzInterface
        /// <summary>
        /// Facilitates user interaction
        /// </summary>
        /// <param name="Massage">Message to be displayed</param>
        /// <returns>Returns the text entered by the user</returns>
        private static string EzInterface(string Massage)
        {
            Console.WriteLine(Massage);
            Massage = Console.ReadLine();
            return Massage;
        }
        #endregion

        #region Print1Line
        private static void Print1Line(int[,] IntArray, byte MatrixSize, byte LineNum)
        {
            Console.Write ($"\nLine {LineNum} => ");
            for (byte i = 0; i < MatrixSize; i++)
            {
                Console.Write($"{IntArray[LineNum, i]} ");
            }
            Console.WriteLine();
        }
        #endregion
    }
}
