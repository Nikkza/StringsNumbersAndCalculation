using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<string> results;
            double numberOne = 0;
            double numberTwo = 0;
            var array = calcI.ToArray();
            double sum = 0;
            var op = array.Where(x => x == '*' || x == '-' || x == '+' || x == '/').FirstOrDefault();
            results = ListAsChar(calcI, op);
            numberOne = Converter(results[0]);
            numberTwo = Converter(results[1]);
         
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

        static List<string> ListAsChar(string splitToArray, char op)
        {
            var list = new List<string>();
            var split = splitToArray.Split(op);
            var charOne = split[0].ToCharArray();
            var charTwo = split[1].ToCharArray();
            var numberOne = charOne.Where(x => Char.IsDigit(x) || x == '.');
            var numberTwo = charTwo.Where(x => Char.IsDigit(x) || x == '.');
            list.Add(string.Join("", numberOne));
            list.Add(string.Join("", numberTwo));

            return list;
        }

        static double Converter(string convertToDouble)
        {
            return double.Parse(convertToDouble, CultureInfo.InvariantCulture);
        }
    }
}
