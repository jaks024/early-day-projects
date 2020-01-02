using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
namespace ImageToASCII
{
    class MainASCII
    {
        static int detailX = 3;
        static int detailY = 0;
        static string symbols = "/.+@$*&;8o~";
        static List<string> characters = new List<string>();
        static bool inASCII = false;
        static bool inChange = false;
        static int sizeMultiplier = 75;
        static bool blackMirror = false;
        static void Main(string[] args)
        {
            if (blackMirror)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
            }
            while (true)
            {
                if (!inASCII)
                {
                    PrintOptions();
                    ReadOptionInput();
                }
                else
                {
                    ImageToASCIIOption();
                }
            }
        }

        static void PrintOptions()
        {
            Console.WriteLine("Option Menu Portal:\nASCII Conversion [A]\tChange Characters [C]\tChange Size Multiplier[M]");
            Console.WriteLine("Note: when in menu, [B] to return to main menu");
        }

        static void ReadOptionInput()
        {
            string input = Console.ReadLine();
            switch (input.ToUpper())
            {
                case "A":       //to image to ASCII conversion 
                    {
                        inASCII = !inChange;
                        Console.Clear();
                        Console.WriteLine("Covnert ASCII");
                        ImageToASCIIOption();
                        break;
                    }
                case "C":       //change ASCII characters
                    {
                        inChange = !inASCII;
                        Console.Clear();
                        Console.WriteLine("Change characters");
                        ToChangeASCIIOption();
                        break;
                    }
                case "M":       //change ASCII size
                    {
                        Console.Clear();
                        Console.WriteLine("Change multiplier. Current is: " + sizeMultiplier + ". Recommend an increase or decrease of 25");
                        try
                        {
                            sizeMultiplier = int.Parse(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Value cannot be accepted, no changes are made.");
                        }
                        break;
                    }
                case "B":       //Back from selection
                    {
                        Console.WriteLine("Back from selection");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("command invalid. re enter command");
                        break;
                    }
            }
            Console.ReadKey();
            Console.Clear();
        }

        static void ToChangeASCIIOption()
        {
            int input = 11;  
            while (input == 11 && input < 12)
            {
                Console.WriteLine("         0,1,2,3,4,5,6,7,8,9,10");
                string pSym = "";
                for(int i = 0; i < input; i++)
                {
                    pSym += symbols[i] + " ";
                }
                Console.WriteLine("Symbols: " + pSym);
                Console.WriteLine("Enter which one to repalce from 0 to " + (symbols.Length - 1));
                input = GetReplacement();
            }

            if (input >= 12)
            {
                inChange = false;
                return;
            }

            Console.WriteLine(string.Format("Enter the symbol that you want to repalce {0}: '{1}' with", input, symbols[input]));

            string replace = Console.ReadLine();
            string newSymbol = "";
            for (int i = 0; i < symbols.Length; i++)
            {
                if (i != input)
                {
                    newSymbol += symbols[i];
                }
                else
                {
                    newSymbol += replace;
                }
            }
            symbols = newSymbol;

        }

        static int GetReplacement()
        {
            try
            {
                string line = Console.ReadLine();
                if (line.ToLower() == "b")
                {
                    return 12;
                }
                int input = int.Parse(line);
                return input;
            }
            catch
            {
                Console.WriteLine("The entered inputs are in invalid format, please try again");
                Console.ReadKey();
                Console.Clear();
                return 12;
            }
        }

        #region ASCII

        static void ImageToASCIIOption()
        {
            Console.WriteLine("Enter the image name to convert (example.png): ");
            string input = Console.ReadLine();
            if (input.ToUpper() == "B")
            {
                inASCII = false;
                return;
            }
            if (GetImage(input) != null)
            {
                Bitmap bmp = new Bitmap(GetImage(input));
                detailX = bmp.Width / (sizeMultiplier * bmp.Width / bmp.Height);
                detailY = detailX * 2;
                ReadAllPixels(bmp);
                ConstructImage();
            }
            Console.ReadKey();
            characters.Clear();
            Console.Clear();
        }

        static void ReadAllPixels(Bitmap bmp)
        {
            if(detailX == 0)
            {
                detailX = 2;
                detailY = detailX * 2;
            }
            for(int y = 0; y < bmp.Height; y+=detailY)
            {
                for (int x = 0; x < bmp.Width; x+=detailX)
                {
                    characters.Add(PixelToSymbol(bmp.GetPixel(x, y)).ToString());
                }
                characters.Add("\n");
            }
        }

        static char PixelToSymbol(Color rgb)
        {
            float symbolIndex = (rgb.R + rgb.G + rgb.B + rgb.A) / 150;
            char c = symbols[(int)symbolIndex + 1];
            return c;
        }

        static void ConstructImage()
        {
            string toPrint = "";
            for (int i = 0; i < characters.Count; i++)
            {
                toPrint += characters[i];
            }
            Console.WriteLine(toPrint);
        }

        static Image GetImage(string name)
        {     
            try
            {
                Image img = Image.FromFile(Path.GetFullPath(name)); //testing image should be in bin/Debug
                return img;
            }
            catch
            {
                FileNotFoundException ex = new FileNotFoundException();
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        #endregion
    }
}
