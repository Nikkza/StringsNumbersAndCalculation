using System;
using System.Globalization;
using System.Linq;

namespace StringsNumbersAndCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var calcString = Console.ReadLine();
                var sum = CalculateString(calcString);
                Console.WriteLine(sum);
            }
        }

        static string CalculateString(string calcI)
        {
            double sum = 0;
            var results = GetNumbersFromString(calcI);
            var op = results.Where(x => x == '*' || x == '-' || x == '+' || x == '/').FirstOrDefault();
            var split = results.Split(op);
            switch (op.ToString())
            {
                case "*":
                    sum = Converter(split[0]) * Converter(split[1]);
                    break;
                case "-":
                    sum = Converter(split[0]) - Converter(split[1]);
                    break;
                case "+":
                    sum = Converter(split[0]) + Converter(split[1]);
                    break;
                case "/":
                    sum = Converter(split[0]) / Converter(split[1]);
                    break;
                default:
                    Console.WriteLine("nothing");
                    break;
            }
            return $"Sum: {Math.Round(sum)}";
        }

        static string GetNumbersFromString(string calcI)
        {
            return string.Join("", calcI.ToCharArray().Where(x => Char.IsDigit(x) || x == '*' || x == '-' || x == '+' || x == '/' || x == '.'));
        }

        static double Converter(string convertToDouble)
        {
            return double.Parse(convertToDouble, CultureInfo.InvariantCulture);
        }
    }
}
