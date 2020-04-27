using System;
using System.Collections.Generic;


namespace Lab9._16
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> createdStackNumbers = new Stack<int>();
            Program prog = new Program();
            createdStackNumbers = prog.CreateStack();
            prog.PrintStackFromBack(createdStackNumbers);
        }

        /// <summary>
        /// Function to create stack from the entered numbers
        /// </summary>
        /// <returns>Return stack with input numbers</returns>
        private Stack<int> CreateStack()
        {
            int pushNumber = 0;
            byte counter = 1;
            Stack<int> unsignedNumbers = new Stack<int>();
            Console.WriteLine("Enter unsigned number, after u enter signed number stack will be created");
            while (pushNumber >= 0)
            {
                try
                {
                    Console.Write($"Number {counter} -> ");
                    pushNumber = Convert.ToInt32(Console.ReadLine());
                    unsignedNumbers.Push(pushNumber);
                    counter++;
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Wrong number");
                }
                catch (OverflowException e)
                {
                    Console.WriteLine("Big number");
                }
            }
            Console.WriteLine("U entered unsigned numbers, press any key to show Stack");
            Console.ReadLine();
            unsignedNumbers.Pop();

            return unsignedNumbers;
        }

        /// <summary>
        /// Printing numbers in stack brom back to front
        /// </summary>
        /// <param name="inputStack">Stack to be deduced</param>
        private void PrintStackFromBack(Stack<int> inputStack)
        {
            Console.Clear();
            byte counter = 1;
            while (inputStack.Count > 0)
            {
                Console.WriteLine($"{counter} -> {inputStack.Pop()}");
                counter++;
            }
            Console.ReadLine();
        }
    }
}

