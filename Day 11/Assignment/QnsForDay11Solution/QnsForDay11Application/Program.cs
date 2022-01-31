using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnsForDay11Application
{
    class Program
    {
        static void ManageEmployees()
        {
            ManageEmployee me = new ManageEmployee();
            Console.WriteLine("Welcome to employee management");
            int choice = 0;
            do
            {
                Console.WriteLine("1: Print all Employees");
                Console.WriteLine("2: Add an Employee");
                Console.WriteLine("3: Update Employee Age");
                Console.WriteLine("4: Delete an Employee");
                Console.WriteLine("Select an option");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Please enter a number");
                }
                switch (choice)
                {
                    case 1:
                        me.PrintAllEmployees();
                        break;
                    case 2:
                        me.AddEmployee();
                        break;
                    case 3:
                        me.UpdateEmployeeAge();
                        break;
                    case 4:
                        me.DeleteEmployee();
                        break;
                    case 0:
                        Console.WriteLine("Bye Bye");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice != 0);
            
        }
        static void Main(string[] args)
        {
            ManageEmployees();
            Console.ReadLine();
        }
    }
}
