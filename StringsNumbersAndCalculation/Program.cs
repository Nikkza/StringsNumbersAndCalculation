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
           
            double numberOne = 0;
            double numberTwo = 0;
            var array = calcI.ToArray();
            double sum = 0;
            var op = array.Where(x => x == '*' || x == '-' || x == '+' || x == '/').FirstOrDefault();
            var results = ListAsString(calcI, op);
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

        static string[] ListAsString(string splitToArray, char op)
        {            
            return string.Join("", splitToArray.ToCharArray().Where( x => Char.IsDigit(x) || x == '*' || x == '-' || x == '+' || x == '/' || x == '.')).Split(op);      
        }

        static double Converter(string convertToDouble)
        {
            return double.Parse(convertToDouble, CultureInfo.InvariantCulture);
        }
    }
}
