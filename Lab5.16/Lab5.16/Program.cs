using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 


//Its lab Work 5.16  
//Lab was write on C#
//The task:
//To compose a program that reads the text of another program line by line (enter it from the keyboard in the amount of 10 lines), detects comments and prints them.
namespace Lab4._16
{
    class Program
    {

        static void Main(string[] args)
        {
            //Read the all strings to mass
            string[] lines = File.ReadAllLines("Prog.txt");

            for (int i = 0; i <= lines.Length - 1; i++)
            {
                string line = lines[i];
                // if string startig with // we will write this string
                if (line.Trim().StartsWith("//"))
                {
                    Console.WriteLine(line, "\n");
                }
            }
            Console.WriteLine("\n\nExit? Y - to exit | Another button to continue");
            String Exit = Console.ReadLine();

            if (Exit.ToUpper() == "Y")
            {
                return;
            }
            else
            {
                Console.WriteLine("You dont have a choice 0_0");
                Console.ReadLine();
            }
        }
    }
}
