using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplicationPrac20012022
{
    class Program
    {
        //Method Header
        void PrintName()
        {
            //Method Body
            Console.WriteLine("Hello Afiq");
        }
        void PrintAnyName(string name)
        {
            //Method Body
            Console.WriteLine("Hello " + name);
        }
        void Greet(string greet)
        {
            //Method Body
            Console.WriteLine("Please enter your name");
            string name = Console.ReadLine();
            Console.WriteLine(greet + " " + name);
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Dope");
            //Program program = new Program();
            //program.PrintName();//Method Call
            //program.PrintAnyName("Guy Fawkes");//Method Call
            //program.Greet("Hi");

            //Calculator calc = new Calculator();
            //calc.Add();
            //calc.Product();

            Statements stats = new Statements();
            //stats.UnderstandingSelectionWithIf();
            //stats.IterationWithFor();
            //stats.IterationWithWhile();
            //stats.IterationWithDoWhile();
            //stats.UnderstandingSelectionWithSwitchCase();

            Pizza pizza = new Pizza();
            

            Console.ReadLine();
        }
    }
}
