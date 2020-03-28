using System;

namespace Lab3._16
{
    class Program
    {

        /// <summary>
        /// To search for the factorial of a given variable
        /// </summary>
        /// <param name="inputNum">The factorial number of which is to be calculated</param>
        /// <returns></returns>
        private double Fact(int inputNum)
        {
            if (inputNum < 0)
                return 0;
            if (inputNum == 0)
                return 1;
            else
                return inputNum * Fact(inputNum - 1);
        }
        /// <summary>
        /// To find Step of increase variable X
        /// </summary>
        /// <param name="lover">Lover limit of variable X</param>
        /// <param name="upper">Upper limit of variable X</param>
        /// <returns></returns>
        private float FindStep(float lover, int upper)
        {
            float step = (upper - lover) / 10;
            return step;
        }
        /// <summary>
        /// To find Sum of given expression
        /// </summary>
        /// <param name="lover">Lover limit of variable X</param>
        /// <param name="upper">Upper limit of variable X</param>
        private void FindSum(float lover, int upper)
        {
            Program prog = new Program();
            int formulaN = 10, formulaK = 1;
            float formulaX = lover, step = prog.FindStep(lover, upper);
            double finalSum = 0;
           
                 Console.WriteLine($"\n|Number of iteration|         Value         |");
            while (formulaN > 0)
            {
                finalSum += Math.Pow(-1, formulaK) * (Math.Pow(1 + formulaX, 2 * formulaK) / prog.Fact(formulaK));
                if(formulaX <= upper)
                {
                    formulaX += step;
                }
                Console.WriteLine($"|-------------------|-----------------------|\n|  {formulaK} iteration      -> {finalSum}");
                formulaK++;
                formulaN--;
            }
            Console.WriteLine($"\n\nThe final sum is  -> {finalSum} \nWithout exponent  -> {finalSum.ToString("F0")}");
        }
        static void Main(string[] args)
        {
            Program prog = new Program();
            float loverLimit = -1.05f;
            int upperLimit = 362;

            Console.WriteLine($"Hello dear user, this program was created to help you to find sum for the interval " +
                $"\nfrom - {loverLimit},  to - {upperLimit}, " +
                $"\nwith step - {prog.FindStep(loverLimit, upperLimit)}");
            prog.FindSum(loverLimit, upperLimit);
            Console.ReadKey();
        }
    }
}










