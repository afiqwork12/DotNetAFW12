using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOOPSApplication
{
    class Program
    {
        int iInstanceNum1 = 0;
        static int iStaticNum = 0;
        void Increament()
        {
            iInstanceNum1++;
            iStaticNum++;
        }
        void PrintValues()
        {
            Console.WriteLine("The value of iInstanceNum1 is {0}", iInstanceNum1);
            Console.WriteLine("The value of iStaticNum is {0}", iStaticNum);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            Customer customer = new Customer();
            customer.Num1 = 1;
            Console.WriteLine(customer.Num1);
            customer.Phone = "98565865";
            Console.WriteLine(customer.Phone);
            //Program p1 = new Program();
            //Program p2 = new Program();
            //Console.WriteLine("Values before increament");
            //Console.WriteLine("P1");
            //p1.PrintValues();
            //Console.WriteLine("P2");
            //p2.PrintValues();
            //p1.Increament();
            //p2.Increament();
            //Console.WriteLine("Values after increament");
            //Console.WriteLine("P1");
            //p1.PrintValues();
            //Console.WriteLine("P2");
            //p2.PrintValues();
            //p1.Increament();
            //Console.WriteLine("Values after increament only P1");
            //Console.WriteLine("P1");
            //p1.PrintValues();
            //Console.WriteLine("P2");
            //p2.PrintValues();
            Console.ReadLine();
        }
    }
}
