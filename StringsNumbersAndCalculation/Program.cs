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
            double numberOne = 0;
            double numberTwo = 0;
            double sum = 0;
            var results = GetNumbersFromString(calcI);
            var op = results.Where(x => x == '*' || x == '-' || x == '+' || x == '/').FirstOrDefault();
            var split = results.Split(op);
            numberOne = Converter(split[0]);
            numberTwo = Converter(split[1]);

            switch (op.ToString())
            {
                case "*":
                    sum = numberOne * numberTwo;
                    break;
                case "-":
                    sum = numberOne - numberTwo;
                    break;
                case "+":
                    sum = numberOne + numberTwo;
                    break;
                case "/":
                    sum = numberOne / numberTwo;
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
