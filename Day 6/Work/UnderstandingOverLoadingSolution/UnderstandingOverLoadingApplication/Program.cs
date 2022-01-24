using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOverLoadingApplication
{
    class Program
    {
        Program()
        {
            Console.WriteLine("Default Constructor");
        }
        Program(int i)
        {
            Console.WriteLine("Parameterised Constructor");
        }
        void Add(int num1)
        {
            int sum = num1++;
            Console.WriteLine("The increament value of {0} is {1}", sum, num1);
        }
        void Add(int num1, int num2)
        {
            int sum = num1 + num2;
            Console.WriteLine("The sum of {0} and {1} is {2}", num1, num2, sum);
        }
        void Add(string str1, string str2)
        {
            string concat = str1 + str2;
            Console.WriteLine("The concat of {0} and {1} is {2}", str1, str2, concat);
        }
        static void Main(string[] args)
        {
            //Program p = new Program();
            //Program p1 = new Program(1);
            //p.Add(10, 20);
            //p.Add(10);
            //p.Add("Hello","World");
            //Employee employee = new Employee();
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine(employee[i]);
            //}
            //Console.WriteLine("The index of skill MS SQL is " + employee["MS SQL"]);
            Employee e1, e2;
            e1 = new Employee();
            e2 = new Employee();
            e1[0] = "Java";
            Employee e3 = e1 + e2;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(e3[i]);
            }
            Console.ReadLine();
        }
    }
}
