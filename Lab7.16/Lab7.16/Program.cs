using System;
using System.Threading;

namespace Lab7._16
{
    class Program
    {
        static void Main(string[] args)
        {
            //Эта программа поможет найти строку в матрице, в которой все елементы делятся на 3 без остачи
            Console.WriteLine("Hello dear user This program will help you find a row in the matrix " +
                "\nin which all elements are divided by 3 without remainder");
            byte matrixSize = byte.Parse(EzInterface("\nEnter size of matrix (Only numbers)"));
            Console.Clear();
            FindLineWithNums(FillMatrix(matrixSize), matrixSize);

            Console.ReadLine();
        }

        #region FindLineWithNums
        private static void FindLineWithNums(int[,] intArray, byte matrixSize)
        {
            for (byte matrixRow = 0; matrixRow < matrixSize; matrixRow++)
            {
                byte num = 0;
                for (byte matrixColum = 0; matrixColum <= matrixSize; matrixColum++)
                {
                    if (num == matrixSize)
                    {
                        Print1Line(intArray, matrixSize, matrixRow);
                    }
                    else if (intArray[matrixRow, matrixColum] % 3 == 0)
                        num++;
                    else
                        break;

                }
                num = 0;
            }
        }
        #endregion

        #region FillMatrix
        /// <summary>
        /// Creating and fill a matrix (Создание и заполнение матрицы)
        /// </summary>
        /// <returns>Returns a filled integer matrix (2 dimensional array) 
        /// (Возврашщает заполненую целочисленнуюматрицу (2 мерный массив))</returns>
        private static int[,] FillMatrix(byte matrixSize)
        {
            int[,] intArray = new int[matrixSize, matrixSize];

            byte menu = Convert.ToByte(EzInterface("1          => Fill matrix automatically (Заполнить матрицу автоматичесски)" +
                "\nAny number => Fill matrix manually (Любая другая кнопка чтобы заполнить матрицу вручную)"));

            bool autoFill = menu == 1 ? true : false;
            intArray = autoFill ? AutoFillMatrixx(intArray, matrixSize) : ManualFillMatrixx(intArray, matrixSize);
            return intArray;
        }
        #endregion

        #region AutoFillMatrixx
        /// <summary>
        /// Automatically fills the matrix (Автоматичесски заполнет матрицу)
        /// </summary>
        /// <param name="intArray">Array of numbers (Массив чисел)</param>
        /// <param name="matrixSize">Array size (Размер массива)</param>
        private static int[,] AutoFillMatrixx(int[,] intArray, byte matrixSize)
        {
            Console.Clear();
            for (byte matrixRow = 0; matrixRow < matrixSize; matrixRow++)
            {
                for (byte matrixColum = 0; matrixColum < matrixSize; matrixColum++)
                {
                    Random rand = new Random();
                    Thread.Sleep(200);
                    intArray[matrixRow, matrixColum] = rand.Next(15);
                    Console.Write($"{intArray[matrixRow, matrixColum]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("If nothing is output to the console, then not a single line satisfies the parameters");
            return intArray;
        }
        #endregion

        #region ManualFill
        /// <summary>
        /// Manual fills the matrix (Ручное заполнение матрицы)
        /// </summary>
        /// <param name="intArray">Array of numbers (Массив чисел)</param>
        /// <param name="matrixSize">Array size (Размер массива)</param>
        /// <returns>Returns a filled array (Возвращает заполненый массив)</returns>
        private static int[,] ManualFillMatrixx(int[,] intArray, byte matrixSize)
        {
            Console.WriteLine("Enter the numbers one by one, and press Enter to fill the array " +
                "\nПоочередно вводите числа, и нажиайте ентер для заполнения массива");
            Console.Clear();
            for (byte matrixRow = 0; matrixRow < matrixSize; matrixRow++)
            {
                for (byte matrixColum = 0; matrixColum < matrixSize; matrixColum++)
                {
                    Console.Write($"Matrix [{matrixRow}][{matrixColum}] => ");
                    intArray[matrixRow, matrixColum] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
            Console.Clear();
            Console.WriteLine("The resulting matrix:");
            for (byte matrixRow = 0; matrixRow < matrixSize; matrixRow++)
            {
                for (byte matrixColum = 0; matrixColum < matrixSize; matrixColum++)
                {
                    Console.Write($"{intArray[matrixRow, matrixColum]} \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine("If nothing is output to the console, then not a single line satisfies the parameters");
            return intArray;
        }
        #endregion

        #region EzInterface
        /// <summary>
        /// Facilitates user interaction
        /// </summary>
        /// <param name="massage">Message to be displayed</param>
        /// <returns>Returns the text entered by the user</returns>
        private static string EzInterface(string massage)
        {
            Console.WriteLine(massage);
            massage = Console.ReadLine();
            return massage;
        }
        #endregion

        #region Print1Line
        private static void Print1Line(int[,] intArray, byte matrixSize, byte lineNum)
        {
            Console.Write($"\nLine {lineNum} => ");
            for (byte i = 0; i < matrixSize; i++)
            {
                Console.Write($"{intArray[lineNum, i]} ");
            }
            Console.WriteLine();
        }
        #endregion
    }
}
//Добрый день, на парах вы всегда рассказывали про знакомых в сфере програмирования, 
//я хотел узнать, есть ли знакомые, которым нужны сотрудники без опыта)
//Как видно, пишу на С#, не против выучить что-то ещё
//Достаточно быстро воспринимаю информацию, мне не надо посторять по несколько раз одно и то-же
//На большую ЗП по началу не претендую, хочу набраться опыта.
//Привязки к какому-то городу впринципе нету
//Из минусов, не владею слепой печатью, если это важно, и нету опыта работы в данной сфере
