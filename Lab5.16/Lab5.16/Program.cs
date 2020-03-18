﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab5._16
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello dear User.");
            string Path = "Prog.txt";
            string[] InputCode = FileOpen(Path);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("This program will help you to find all comments in your code.\nPress (1) if you want to change file location (As default will be open cod of this program)\nPress (2) if you want to find 1 line commentaries\nPress (3) if you want to find multiline comentaries\nPress (4) if you wan to close this best program 0_0");
                Console.WriteLine("Press (1-4) to sellect actions");
                byte SelectMenu = Convert.ToByte(Console.ReadLine());
                /*
                 * Switch-case:
                 * case1 -> Change path to file (Изменить путь к файлу)
                 * case2 -> Show all 1 line comments (Вывести все однострочные коментарии)
                 * case3 -> Show all Multiline comments (Вывести все многострочные коментарии)
                 * case4 -> Close the program (Офнуть программу)
                */
                switch (SelectMenu)
                {
                    case 1:
                        //Change file location (Изменить путь к файлу)
                        Console.WriteLine(@"Write full path to file\nExample (C:\Program Files (x86)\Microsoft Visual Studio\MyProgram\Prog.txt)");
                        Path = Console.ReadLine();
                        break;
                    case 2:
                        //Find 1 line commentaries (Вывести все однострочные коментарии)
                        Console.WriteLine("\n\nAll 1 line comments :");
                        Find1LineComment(InputCode, Path);

                        break;
                    case 3:
                        //Find multiline comentaries (Вывести все многострочные коментарии)
                        Console.WriteLine("\n\nAll multiline comments :");
                        FindMultiLineComment(InputCode, Path);
                        break;
                    case 4:
                        //Close best program (Офнуть программу)
                        Console.WriteLine("Program shuts down, press any key");
                        Console.ReadLine();
                        return;
                    default:
                        Console.WriteLine("You entered a wrong number");
                        break;
                }
            }


        }

        /// <summary>
        /// Open and read text from file (Открыть и прочесть весь код из файла)
        /// </summary>
        /// <param name="Path">Path to file (Путь к файлу)</param>
        /// <returns>We return an array with the read code (Возвращает массив со считаным кодом)</returns>
        private static string[] FileOpen(string Path)
        {
            Console.WriteLine("You want to see input code? Y|N");
            string ShowCode = Console.ReadLine();
            List<string> FullCode = new List<string> { };
            try
            {
                using (StreamReader ReadCode = new StreamReader(Path))
                {

                    int i = 0;
                    while (i < File.ReadAllLines(Path).Length)
                    {
                        FullCode.Add(ReadCode.ReadLine());
                        if (ShowCode.ToUpper() == "Y")
                        {
                            Console.WriteLine(FullCode[i]);
                        }
                        i++;
                    }

                    Console.WriteLine("File read successfully, Press any key to continue");
                    Console.ReadLine();
                    string[] OutCode = FullCode.ToArray<string>();
                    return OutCode;
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


        private static void Find1LineComment(string[] InputCode, string Path)
        {
            for (int i = 0; i < InputCode.Length; i++)
            {
                string line = InputCode[i];
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



        private static void FindMultiLineComment(string[] InputCode, string Path)
        {
            int i = 0;
            while(i < InputCode.Length)
            {
                string line = InputCode[i];

                 /*
                  * If the line start with (/*), then we print all subsubsequents lines until we get to (* /) 
                  * Если строка начинается с (/*), то выводим все строки пока не дойдем до (* /)
                 */
                if (line.Trim().StartsWith("/*"))
                {
                    Console.WriteLine("");
                    while(i < InputCode.Length)
                    {
                        line = InputCode[i];
                        if(line.Trim().StartsWith("*/"))
                        {
                            Console.WriteLine(line.Trim());
                            break;
                        }
                        else
                        {
                            Console.WriteLine(line.Trim());
                        }
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



