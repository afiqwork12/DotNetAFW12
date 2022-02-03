using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionForDay12Application
{
    class Program
    {
        static void ManageMenu()
        {
            try
            {
                Console.WriteLine("Welcome to menu management");
                int choice = 0;
                ManageMenu menu = new ManageMenu();
                do
                {
                    Console.WriteLine("1: Add Department");
                    Console.WriteLine("2: Edit Department Name");
                    Console.WriteLine("3: Print Departments");
                    Console.WriteLine("4: Add Employee");
                    Console.WriteLine("5: Edit Employee Age");
                    Console.WriteLine("6: Edit Employee Department");
                    Console.WriteLine("7: Print Employees");
                    Console.WriteLine("0: Exit");
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Please enter a number");
                    }
                    switch (choice)
                    {
                        case 1:
                            menu.AddDepartment();
                            break;
                        case 2:
                            menu.EditDepartmentName();
                            break;
                        case 3:
                            menu.PrintAllDepartments();
                            break;
                        case 4:
                            menu.AddEmployee();
                            break;
                        case 5:
                            menu.EditEmployeeAge();
                            break;
                        case 6:
                            menu.EditEmployeeDepartment();
                            break;
                        case 7:
                            menu.PrintAllEmployees();
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
        static void Main(string[] args)
        {
            ManageMenu();
            Console.ReadLine();
        }
    }
}
