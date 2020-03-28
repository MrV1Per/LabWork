using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
//The program should find comments(oneline, or multiline) in the code
namespace Lab5._16
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            Console.WriteLine("Hello dear User.");
            string path = "Prog.txt";
            string[] inputCode = prog.FileOpen(path);
            bool isExit = true;
            while (isExit)
            {
                Console.Clear();
                Console.WriteLine("This program will help you to find all comments in your code." +
                    "\nPress (1) if you want to change file location (As default will be open cod of this program)" +
                    "\nPress (2) if you want to find 1 line commentaries\nPress (3) if you want to find multiline comentaries" +
                    "\nPress (4) if you want to close this best program 0_0");
                Console.WriteLine("Press (1-4) to sellect actions");
                byte selectMenu = Convert.ToByte(Console.ReadLine());
                /*
                 * Switch-case:
                 * case1 -> Change path to file (Изменить путь к файлу)
                 * case2 -> Show all 1 line comments (Вывести все однострочные коментарии)
                 * case3 -> Show all Multiline comments (Вывести все многострочные коментарии)
                 * case4 -> Close the program (Офнуть программу)
                */
                switch (selectMenu)
                {
                    case 1:
                        //Change file location (Изменить путь к файлу)
                        Console.WriteLine(@"Write full path to file\nExample (C:\Program Files (x86)\Microsoft Visual Studio\MyProgram\Prog.txt)");
                        path = Console.ReadLine();
                        break;
                    case 2:
                        //Find 1 line commentaries (Вывести все однострочные коментарии)
                        Console.WriteLine("\n\nAll 1 line comments :");
                        prog.Find1LineComment(inputCode, path);
                        break;
                    case 3:
                        //Find multiline comentaries (Вывести все многострочные коментарии)
                        Console.WriteLine("\n\nAll multiline comments :");
                        prog.FindMultiLineComment(inputCode, path);
                        break;
                    case 4:
                        //Close best program (Офнуть программу)
                        Console.WriteLine("Program shuts down, press any key");
                        Console.ReadLine();
                        isExit = false;
                        break;
                    default:
                        Console.WriteLine("You entered a wrong number");
                        break;
                }
            }
        }

        /// <summary>
        /// Open and read text from file (Открыть и прочесть весь код из файла)
        /// </summary>
        /// <param name="path">path to file (Путь к файлу)</param>
        /// <returns>We return an array with the read code (Возвращает массив со считаным кодом)</returns>
        private string[] FileOpen(string path)
        {
            Console.WriteLine("You want to see input code? Y|N");
            string showCode = Console.ReadLine();
            List<string> fullCode = new List<string> { };
            try
            {
                using (StreamReader readCode = new StreamReader(path))
                {
                    int i = 0;
                    while (i < File.ReadAllLines(path).Length)
                    {
                        fullCode.Add(readCode.ReadLine());
                        if (showCode.ToUpper() == "Y")
                            Console.WriteLine(fullCode[i]);
                        i++;
                    }

                    Console.WriteLine("File read successfully, Press any key to continue");
                    Console.ReadLine();
                    string[] outCode = fullCode.ToArray<string>();
                    return outCode;
                }
            }
            catch (Exception e)
            {
                //If we have error (Обработка исключения)
                Console.WriteLine($"The file could be note read: {e.Message}");
                string[] error = new string[1] { "ERROR ERROR ERROR ERROR" };
                return error;
            }
        }

        /// <summary>
        /// Find 1 line Comments
        /// </summary>
        /// <param name="inputCode">array with code of program</param>
        /// <param name="path">path to file (Путь к файлу)</param>
        private void Find1LineComment(string[] inputCode, string path)
        {
            for (int i = 0; i < inputCode.Length; i++)
            {
                string line = inputCode[i];
                /*
                 *Checking at the description of functions is displayed without indentation, 
                 * if the line start with /// then we print it to the console, and if with //, 
                 * then we additionaly insert at the begining and at the end
                 * Проеверка чтобы описание функции выводилось без отступов, 
                 * если строка начинается с /// то выводим её в консоль, а если с //, 
                 * то дополнительно делаем отступ вначале и вконце
                 */
                if (line.Trim().StartsWith("///"))
                    Console.WriteLine(line.Trim());
                else if (line.Trim().StartsWith("//"))
                    Console.WriteLine("\n" + line.Trim() + "\n");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        /// <summary>
        /// Find Multiline Comments
        /// </summary>
        /// <param name="inputCode">array with code of program</param>
        /// <param name="path">path to file (Путь к файлу)</param>
        private void FindMultiLineComment(string[] inputCode, string path)
        {
            int i = 0;
            while(i < inputCode.Length)
            {
                string line = inputCode[i];

                 /*
                  * If the line start with (/*), then we print all subsubsequents lines until we get to (* /) 
                  * Если строка начинается с (/*), то выводим все строки пока не дойдем до (* /)
                 */
                if (line.Trim().StartsWith("/*"))
                {
                    Console.WriteLine();
                    while(i < inputCode.Length)
                    {
                        line = inputCode[i];
                        if(line.Trim().StartsWith("*/"))
                        {
                            Console.WriteLine(line.Trim());
                            break;
                        }
                        else
                            Console.WriteLine(line.Trim());
                        i++;
                    }                    
                }
                i++;
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}



