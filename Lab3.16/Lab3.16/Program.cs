using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._16
{
    class Program
    {
        /// <summary>
        /// To search for the factorial of a given variable
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        private static double fact(int N)
        {
            if (N < 0)
                return 0;
            if (N == 0)
                return 1;
            else
                return N * fact(N - 1);
        }

        /// <summary>
        /// To find Step of increase variable X
        /// </summary>
        /// <param name="Lover">Lover limit of variable X</param>
        /// <param name="Upper">Upper limit of variable X</param>
        /// <returns></returns>
        private static float FindStep(float Lover, int Upper)
        {
            float Step = (Upper - Lover) / 10;
            return Step;
        }

        /// <summary>
        /// To find Sum of given expression
        /// </summary>
        /// <param name="Lover">Lover limit of variable X</param>
        /// <param name="Upper">Upper limit of variable X</param>
        private static void FindSum(float Lover, int Upper)
        {
            int FormulaN = 10, FormulaK = 1;
            float FormulaX = Lover, Step = FindStep(Lover, Upper);

            double FinalSum = 0;
           
                 Console.WriteLine($"\n|Number of iteration|         Value         |");
            while (FormulaN > 0)
            {

                FinalSum += Math.Pow(-1, FormulaK) * (Math.Pow(1 + FormulaX, 2 * FormulaK) / fact(FormulaK));

                if(FormulaX <= Upper)
                {
                    FormulaX += Step;
                }
                Console.WriteLine($"|-------------------|-----------------------|\n|  {FormulaK} iteration      -> {FinalSum}");
                FormulaK++;
                FormulaN--;
            }
            Console.WriteLine($"\n\nThe final sum is       -> {FinalSum} \nWithout exponent -> {FinalSum.ToString("F0")}");
            

        }
        static void Main(string[] args)
        {
            float LoverLimit = -1.05f;
            int UpperLimit = 362;

            Console.WriteLine($"Hello dear user, this program was created to help you to find sum for the interval \nfrom - {LoverLimit},  to - {UpperLimit}, \nwith step - {FindStep(LoverLimit, UpperLimit)}");
            FindSum(LoverLimit, UpperLimit);


            Console.ReadKey();
         
        }
    }
}










