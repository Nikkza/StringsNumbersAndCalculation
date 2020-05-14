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
            List<double> results;
            double numberOne = 0;
            double numberTwo = 0;
            var array = calcI.ToArray();
            double sum = 0;
            var op = array.Where(x => x == '*' || x == '-' || x == '+' || x == '/').FirstOrDefault();
            results = ListAsChar(calcI, op);
            numberOne = results[0];
            numberTwo = results[1];
         
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

        static List<double> ListAsChar(string splitToArray, char op)
        {
            var list = new List<double>();
            var getNumbers = string.Join("", splitToArray.ToCharArray().Where( x => Char.IsDigit(x) || x == '*' || x == '-' || x == '+' || x == '/' || x == '.'));
            var spliNumbers = getNumbers.Split(op);
            list.Add(Converter(spliNumbers[0]));
            list.Add(Converter(spliNumbers[1]));

            return list;
        }

        static double Converter(string convertToDouble)
        {
            return double.Parse(convertToDouble, CultureInfo.InvariantCulture);
        }
    }
}
