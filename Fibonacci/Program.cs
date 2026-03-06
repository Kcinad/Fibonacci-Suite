using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Fibonacci
{
    internal class Program
    {
        public static string[] Quebec = { "Choix Invalide", "Combien de chiffres Fibonacci voulez-vous (de 1 à 46) ? : " };

        public const int CELL_SIZE = 10;
        public const string TWO_SPACES = @"  ";
        public const string ONE_SPACE = @" ";
        public static string[] menuOptions = { "Suite de Fibonacci", "Nombre carrées", "Ratio d'or", "Paramètres", "FAQ", "Quit" };
        public enum MenuOptions { FibonacciSuite = 1, SquareNumbers, GoldenRatio, Settings, FAQ, Quit }

        public enum MaxValue { NormalSuite = 46, SquaredSuite = 23, }
        const int MIN_INPUT_VALUE = 1;
        const int INVALID_VALUE = int.MinValue;
        const int MAX_INPUT_VALUE = 46;
        const string TITLE = @" 
   ▄████████  ▄█  ▀█████████▄   ▄██████▄  ███▄▄▄▄      ▄████████  ▄████████  ▄████████  ▄█  
  ███    ███ ███    ███    ███ ███    ███ ███▀▀▀██▄   ███    ███ ███    ███ ███    ███ ███  
  ███    █▀  ███▌   ███    ███ ███    ███ ███   ███   ███    ███ ███    █▀  ███    █▀  ███▌ 
 ▄███▄▄▄     ███▌  ▄███▄▄▄██▀  ███    ███ ███   ███   ███    ███ ███        ███        ███▌ 
▀▀███▀▀▀     ███▌ ▀▀███▀▀▀██▄  ███    ███ ███   ███ ▀███████████ ███        ███        ███▌ 
  ███        ███    ███    ██▄ ███    ███ ███   ███   ███    ███ ███    █▄  ███    █▄  ███  
  ███        ███    ███    ███ ███    ███ ███   ███   ███    ███ ███    ███ ███    ███ ███  
  ███        █▀   ▄█████████▀   ▀██████▀   ▀█   █▀    ███    █▀  ████████▀  ████████▀  █▀   Suite
                                                                                            ";
        static void Main(string[] args)
        {
            bool systemStart = true;

            while (systemStart)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                PrintTitle();
                Console.WriteLine("Bienvenue au Fibonacci-Suite : version C# \n© 2025 Danick Morin");

                Console.WriteLine($"\nChoisissez une option:" +
                    $"\n{(int)MenuOptions.FibonacciSuite}: Suite de Fibonnaci" +
                    $"\n{(int)MenuOptions.SquareNumbers}: Nombre carrees" +
                    $"\n{(int)MenuOptions.GoldenRatio}: Ratio d'or" +
                    $"\n{(int)MenuOptions.Settings}: Parametres" +
                    $"\n{(int)MenuOptions.FAQ}: FAQ");
                int input = AskChoice("Votre choix: ", int.MinValue, int.MaxValue);

                switch (input)
                {
                    case (int)MenuOptions.FibonacciSuite:
                        {
                            input = AskSuiteNewSize(MIN_INPUT_VALUE, (int)MaxValue.NormalSuite);
                            PrintFibonacciSuite(CalculateFibonacciSuite(input), true);
                            if (input == 1)
                            {
                                PrintValidMessage($"Voici le premier chiffre de fibonacci!", true);
                            }
                            else
                            {
                                PrintValidMessage($"Voici les {input} premiers chiffres de fibonacci!", true);
                            }
                            Console.WriteLine("Appuyer sur n'importe quel touche pour continuer");
                            Console.ReadKey();
                            break;
                        }
                    case (int)MenuOptions.SquareNumbers:
                        {
                            input = AskSuiteNewSize(MIN_INPUT_VALUE, (int)MaxValue.SquaredSuite);
                            PrintFibonacciSuite(CalculateSquareNumber(input), true);
                            if (input == 1)
                            {
                                PrintValidMessage($"Voici le premier chiffre carre de fibonacci!", true);
                            }
                            else
                            {
                                PrintValidMessage($"Voici les {input} premiers chiffres carres de fibonacci!", true);
                            }
                            Console.WriteLine("Appuyer sur n'importe quel touche pour continuer");
                            Console.ReadKey();
                            break;
                        }

                }
            }
        }
        static void PrintTitle()
        {
            Console.Clear();
            Console.WriteLine(TITLE);
        }

        //MENU FUNCTIONNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN
        private static int AskSuiteNewSize(int minValue, int maxValue)
        {
            Console.Clear();
            PrintTitle();
            return AskChoice($"Combien de chiffres Fibonacci voulez-vous (de {minValue} à {maxValue}) ? : ", minValue, maxValue);
        }

        static void PrintFibonacciSuite(int[] fibonacciSuite, bool isOrdered)
        {
            for (int i = 1; i < fibonacciSuite.Length; i++)
            {
                int fibonacciNumber = fibonacciSuite[i - 1];
                Console.WriteLine($"{i}- {fibonacciNumber}");
            }
        }

        private static void MakeBoardCellGivenSize(string cellElement, int globalSizeWanted)
        {
            for (int i = 0; i < cellElement.Length; i++)
            {
                if (i > globalSizeWanted - 4)
                {

                }
                Console.Write(cellElement[i]);
            }

            for (int i = cellElement.Length; i < globalSizeWanted; i++)
            {
                Console.Write(" ");
            }
        }

        private static void PrintFibonacciSuite2(int[] fibonacciSuite, bool isOrdered)
        {
            if (fibonacciSuite.Length == 0)
            {
                PrintValidMessage("I cannot do that, sorry. Try again. \n secret 1 found out of 13", true);
                return;
            }

            Console.Write("");
            Console.ForegroundColor = ConsoleColor.Blue;
            for (int i = 0; i < fibonacciSuite.Length; i++)
            {

                string caca = $"{fibonacciSuite[i] + TWO_SPACES}";
                if (caca.Length > 1000)
                {
                    for (int j = 0; j < i; j++)
                    {
                        MakeBoardCellGivenSize((fibonacciSuite[i] + TWO_SPACES), CELL_SIZE);
                    }
                }
                MakeBoardCellGivenSize((i + TWO_SPACES), CELL_SIZE);

            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
        }

        static int AskChoice(string message, int lowestOption, int highestOption)
        {
            int userInput = 0;

            while (true)
            {
                Console.Write(message);
                string caca2 = Console.ReadLine();
                if (caca2.Trim().ToLower() == "pyramide")
                {
                    PrintFibonacciSuite2(CalculateFibonacciSuite(13), true);
                }
                bool isValidNumber = int.TryParse(caca2, out userInput);
                if (isValidNumber && IsValidRange(userInput, lowestOption, highestOption))
                {
                    return userInput;
                }

                if (userInput.ToString() == "0" && caca2 != "")
                {
                    PrintValidMessage("I can't do that bro. secret 2/13. ", true);
                }
                else
                {
                    PrintValidMessage("Invalid choice, try again.", false);
                }
            }
        }

        static bool IsValidRange(int number, int lowerRange, int higherRange)
        {
            if (number >= lowerRange && number <= higherRange)
            {
                return true;
            }
            return false;
        }

        // CALCATING FUNCTIONSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS
        //Palpatine???


        static void PrintSuiteInTable(int[] fibonacciSuite)
        {
            for (int i = 1; i < fibonacciSuite.Length; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine($"{fibonacciSuite.Length}");

        }

        static bool VerifyLength(string capsule)
        {
            return false;
        }

        static int[] CalculateFibonacciSuite(int range)
        {
            int[] fibonacciSuite = new int[range + 1];

            int firstNumber = 0;
            int secondNumber = 1;
            int result = 0;
            for (int i = 0; i < fibonacciSuite.Length; i++)
            {
                result = firstNumber + secondNumber;
                fibonacciSuite[i] = secondNumber;
                firstNumber = secondNumber;
                secondNumber = result;
            }
            return fibonacciSuite;
        }

        static bool IsInRange(int value, int range)
        {
            if (value > 0 && value < range)
            {
                return true;
            }
            return false;
        }


        static int[] CalculateSquareNumber(int range)
        {
            int[] fibonacciSuite = CalculateFibonacciSuite(range);

            for (int i = 0; i < fibonacciSuite.Length - 1; i++)
            {
                int squaredNumber = fibonacciSuite[i] * fibonacciSuite[i];
                fibonacciSuite[i] = squaredNumber;
            }

            return fibonacciSuite;
        }

        private static void CalculateGoldenRatio()
        {

        }



        //ERROR AND MESSAGES FUNCTIONS :P
        private static void PrintValidMessage(string errorMessage, bool isValid)
        {
            if (!isValid)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errorMessage);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(errorMessage);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
