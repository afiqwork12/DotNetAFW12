using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplicationPrac20012022
{
    class Statements
    {
        public void UnderstandingSelectionWithIf()
        {
            Console.WriteLine("Please enter the first number");
            int number1 = Convert.ToInt32(Console.ReadLine());
            if (number1 == 0)
            {
                Console.WriteLine("It is Zero");
            }
            else if (number1 > 100)
            {
                Console.WriteLine("It is more than 100");
            }
            else
            {
                Console.WriteLine("It is something");
            }
        }
        public void UnderstandingSelectionWithSwitchCase()
        {
            Console.WriteLine("Please enter the first number");
            int number1 = Convert.ToInt32(Console.ReadLine());
            switch (number1)
            {
                case 0:
                    Console.WriteLine("It is Zero");
                    break;
                case 1:
                    Console.WriteLine("It is One");
                    break;
                case 2:
                    Console.WriteLine("It is Two");
                    break;
                default:
                    break;
            }
        }
        public void IterationWithFor()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }
        }
        public void IterationWithWhile()
        {
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine(i);
                i++;
            }
        }
        public void IterationWithDoWhile()
        {
            int i = 10;
            do
            {
                Console.WriteLine(i);
                i++;
            } while (i < 1);
        }
    }
}
