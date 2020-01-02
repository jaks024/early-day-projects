using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace Dice_Rolls
{
    class Program
    {
        static string[] patterns = new string[6] { "4", "35", "147", "0268", "02468", "023568" };

        static void Main(string[] args)
        {
            while (true)
            {
                //for custom input uncomment below
                /*
                Console.Write(Shape(CustomInput()));
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                    Console.Clear();
                else
                    Console.Clear();
                */

                Console.Write("Input amount of times to roll: ");
                int numbOfTimes = 0;
                try
                {
                    numbOfTimes = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("\r" + e.Message + "\t(wait for 2 second)");
                    System.Threading.Thread.Sleep(2000);
                    Console.Clear();
                }
                Random rand = new Random();
                for (int i = 0; i < numbOfTimes; i++)
                {
                    string pattern = patterns[rand.Next(0, 6)];
                    int[] inputIndex = new int[pattern.Length];

                    for (int x = 0; x < inputIndex.Length; x++)
                    {
                        inputIndex[x] = int.Parse(pattern[x].ToString());
                    }
                    Console.Write(Shape(inputIndex));
                    Console.WriteLine("Number rolled: " + pattern.Length);
                }

                //uncomment below to reset every time
                /*
                Console.WriteLine("\nPress any key to reset");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                    Console.Clear();
                else
                    Console.Clear();
                    */
            }
        }

        static int[] CustomInput()
        {
            Console.Write("Enter a number between 1 to 9: ");
            int input = int.Parse(Console.ReadLine());
            if (input > 9 || input < 1)
                throw new IndexOutOfRangeException("Input out of range.");
            int[] inputIndex = new int[input.ToString().Length];
            for (int i = 0; i < inputIndex.Length; i++)
            {
                inputIndex[i] = int.Parse(input.ToString()[i].ToString()) - 1;
            }
            return inputIndex;
        }

        static string Shape(params int[] code)
        {
            string[] filtered = new string[9];
            for (int i = 0; i < filtered.Length; i++)
            {
                filtered[i] = " ";
            }
            for (int i = 0; i < code.Length; i++)
            {
                filtered[code[i]] = "o";
            }
            string shape = string.Format(" ___________ \n" + "|           |\n" +
                                             "|  {0}  {1}  {2}  |\n" + "|  {3}  {4}  {5}  |\n" +
                                             "|  {6}  {7}  {8}  |\n" + "|___________|\n", filtered);
            return shape;
        }
    }
}
