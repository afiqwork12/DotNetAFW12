using ClassLibrary1;
using QnsForDay11DALLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QnsForDay11Application
{
    public class ManageEmployee
    {
        EmployeeDAL employeeDAL;
        public ManageEmployee()
        {
            employeeDAL = new EmployeeDAL();
        }
        public void PrintAllEmployees()
        {
            try
            {
                Console.WriteLine("Printing all employees");
                Console.WriteLine("{0,-2} | {1,-10} | {2,-3}",  "ID", "Name", "Age");
                foreach (var item in employeeDAL.GetAllEmployees())
                {
                    Console.WriteLine("{0,-2} | {1,-10} | {2,-3}", item.ID, item.Name, item.Age);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void AddEmployee()
        {
            try
            {
                Employee employee = new Employee();
                employee.TakeDetails();
                if (employeeDAL.InsertNewEmployee(employee))
                {
                    Console.WriteLine("Successfully added employee");
                }
                else
                {
                    Console.WriteLine("Unable to add employee. Try again.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void UpdateEmployeeAge()
        {
            PrintAllEmployees();
            Console.WriteLine("Enter Employee ID:");
            int id;
            do
            {
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Please enter a valid input");
                }
                var employee = employeeDAL.GetEmployeeByID(id);
                if (employee != null)
                {
                    int age;
                    Console.WriteLine("Please enter employee age:");
                    while (!int.TryParse(Console.ReadLine(), out age))
                    {
                        Console.WriteLine("Please enter a valid input");
                    }
                    employee.Age = age;
                    if (employeeDAL.UpdateEmployeeAgeByID(employee))
                    {
                        Console.WriteLine("Update Successful");
                    }
                    else
                    {
                        Console.WriteLine("Update Failed");
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid id from the list");
                }
            } while (true);
        }
        public void DeleteEmployee()
        {
            PrintAllEmployees();
            Console.WriteLine("Enter Employee ID:");
            int id;
            do
            {
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Please enter a valid input");
                }
                var employee = employeeDAL.GetEmployeeByID(id);
                if (employee != null)
                {
                    Console.WriteLine("Are you sure? (Yes/No)");
                    do
                    {
                        if (Console.ReadLine().ToLower() == "yes")
                        {
                            if (employeeDAL.DeleteEmployeeByID(employee))
                            {
                                Console.WriteLine("Deletion Successful");
                            }
                            else
                            {
                                Console.WriteLine("Deletion Failed");
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Deletion canceled");
                            break;
                        }
                    } while (true);
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid id from the list");
                }
            } while (true);
        }
    }
}
