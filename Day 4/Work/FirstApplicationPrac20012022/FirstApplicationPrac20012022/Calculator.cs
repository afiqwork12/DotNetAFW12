using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplicationPrac20012022
{
    class Calculator
    {
        int number1, number2;
        void TakeNumbers()
        {
            Console.WriteLine("Please enter the first number");
            number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the second number");
            number2 = Convert.ToInt32(Console.ReadLine());

        }
        public void Add()
        {
            TakeNumbers();
            int sum = number1 + number2;
            Console.WriteLine("The sum of " + number1 + " and " + number2 + " is " + sum);
        }
        public void Product()
        {
            TakeNumbers();
            int product = number1 * number2;
            Console.WriteLine("The product of " + number1 + " and " + number2 + " is " + product);
        }
    }
}
