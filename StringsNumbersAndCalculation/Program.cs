using System;
using System.Collections.Generic;
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
                var sun = CalculateString(calcString);
                Console.WriteLine(sun);
            }
        }

        static string CalculateString(string calcI)
        {
            List<string> results;
            int numberOne = 0;
            int numberTwo = 0;
            var s = calcI.ToArray();
            double sum = 0;
            var op = s.Where(x => x == '*' || x == '-' || x == '+' || x == '/').FirstOrDefault();
            results = ListAsChar(calcI, op);
            numberOne = Convert.ToInt32(results[0].ToString());
            numberTwo = Convert.ToInt32(results[1].ToString());
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

            return $"Sum: {sum.ToString()}";
        }

        static List<string> ListAsChar(string splitToArray, char op)
        {
            var list = new List<string>();
            var split = splitToArray.Split(op);
            var charOne = split[0].ToCharArray();
            var charTwo = split[1].ToCharArray();
            var numberOne = charOne.Where(x => Char.IsDigit(x));
            var numberTwo = charTwo.Where(x => Char.IsDigit(x));
            list.Add(string.Join("", numberOne));
            list.Add(string.Join("", numberTwo));

            return list;
        }

        static int Converter(string convertToInt) => Convert.ToInt32(convertToInt);
    }
}
