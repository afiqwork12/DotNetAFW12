using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingExceptionsApplication
{
    class Program
    {
        int num1, num2;
        void TakeTwoNumbersFromUser()
        {
            Console.WriteLine("Please enter the first number");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the second number");
            num2 = Convert.ToInt32(Console.ReadLine());
            //try
            //{
            //    Console.WriteLine("Please enter the first number");
            //    num1 = Convert.ToInt32(Console.ReadLine());
            //    Console.WriteLine("Please enter the second number");
            //    num2 = Convert.ToInt32(Console.ReadLine());
            //}
            //catch (FormatException fa)
            //{
            //    Console.WriteLine(fa.Message);
            //    Console.WriteLine("We were expecting a whole number");
            //}
        }
        void Calculate()
        {
            float result = 0;
            result = num1 / num2;
            Console.WriteLine("The result is " + result);
            Console.WriteLine("Done and dusted");
        }
        static void Main(string[] args)
        {
            try
            {
                Program p = new Program();
                p.TakeTwoNumbersFromUser();
                p.Calculate();
            }
            //catch (FormatException fe)
            //{
            //    Console.WriteLine(fe.Message);
            //    Console.WriteLine("We were expecting a whole number");
            //}
            //catch (OverflowException oe)
            //{
            //    Console.WriteLine(oe.Message);
            //    Console.WriteLine("The numebr is tooooooo big");
            //}
            //catch (DivideByZeroException dbze)
            //{
            //    Console.WriteLine(dbze.Message);
            //    Console.WriteLine("The denominator cannot be zero.");
            //}
            catch (Exception fa)
            {
                Console.WriteLine(fa.Message);
                Console.WriteLine(fa.GetType().ToString());
                Console.WriteLine(fa.GetType().Name);
                Console.WriteLine(fa.GetType().FullName);
                Console.WriteLine(fa.GetType().AssemblyQualifiedName);
            }
            finally
            {
                Console.WriteLine("Bye...........");
            }
            Console.ReadLine();
        }
    }
}
