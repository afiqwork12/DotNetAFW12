using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionForDay12Application
{
    public class ManageMenu
    {
        DataAccessLibrary DataAccessLibrary;
        public ManageMenu()
        {
            DataAccessLibrary = new DataAccessLibrary();
        }
        public void AddDepartment()
        {
            Console.WriteLine("Enter Name of Department:");
            
            do
            {
                string name = Console.ReadLine();
                if (name.Trim() == "")
                {
                    Console.WriteLine("Name cannot be blank");
                }
                else
                {
                    Department department = new Department() { Name = name };
                    if (DataAccessLibrary.InsertDepartment(department))
                    {
                        Console.WriteLine("Department Addition Success");
                    }
                    else
                    {
                        Console.WriteLine("Department Addition Failure");
                    }
                    break;
                }
            } while (true);
        }
        public void EditDepartmentName()
        {
            var departments = DataAccessLibrary.GetAllDepartments();
            if (departments.Count > 0)
            {
                PrintDepartmentsFromList(departments);
                Console.WriteLine("Select from the above departments");
                int id;
                do
                {
                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("Please enter a number");
                    }
                    if (departments.Select(d => d.Id).Contains(id))
                    {
                        Console.WriteLine("Please enter a new name");
                        do
                        {
                            string name = Console.ReadLine();
                            if (name.Trim() != "")
                            {
                                if (DataAccessLibrary.EditDepartmentName(id, name))
                                {
                                    Console.WriteLine("Edit Success");
                                }
                                else
                                {
                                    Console.WriteLine("Edit Failed");
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Name cannot be blank. Try again.");
                            }
                        } while (true);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No such department exists. Try again.");
                    }
                } while (true);
            }
            else
            {
                Console.WriteLine("No departments created yet");
            }
        }
        public void AddEmployee()
        {
            Console.WriteLine("Enter Employee Name");
            
            do
            {
                string name = Console.ReadLine();
                if (name.Trim() != "")
                {
                    Console.WriteLine("Enter Age");
                    int age;
                    while (!int.TryParse(Console.ReadLine(), out age))
                    {
                        Console.WriteLine("Invalid input. Try again.");
                    }
                    var departments = DataAccessLibrary.GetAllDepartments();
                    PrintDepartmentsFromList(departments);
                    Console.WriteLine("Please select which department the employee should be under");
                    do
                    {
                        int id;
                        while (!int.TryParse(Console.ReadLine(), out id))
                        {
                            Console.WriteLine("Invalid input. Try again.");
                        }
                        if (departments.Select(d => d.Id).Contains(id))
                        {
                            Employee employee = new Employee() { Name = name, Age = age, Department_Id = id };
                            if (DataAccessLibrary.InsertEmployee(employee))
                            {
                                Console.WriteLine("Employee added successfully");
                            }
                            else
                            {
                                Console.WriteLine("Failed to add employee");
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("No such department exists. Select again");
                        }
                    } while (true);
                    break;
                }
                else
                {
                    Console.WriteLine("Name cannot be blank. Try again.");
                }
            } while (true);
        }
        public void PrintAllEmployees()
        {
            var employees = DataAccessLibrary.GetAllEmployees();
            if (employees.Count > 0)
            {
                PrintEmployeesFromList(employees);
            }
            else
            {
                Console.WriteLine("No employees added yet");
            }
        }
        public void PrintAllDepartments()
        {
            var departments = DataAccessLibrary.GetAllDepartments();
            if (departments.Count > 0)
            {
                PrintDepartmentsFromList(departments);
            }
            else
            {
                Console.WriteLine("No departments created yet");
            }
        }
        private void PrintDepartmentsFromList(List<Department> departments)
        {
            Console.WriteLine("Printing all departments");
            //var employees = DataAccessLibrary.GetAllEmployees();
            Console.WriteLine("------------------------");
            foreach (var item in departments)
            {
                Console.WriteLine("ID: " + item.Id);
                Console.WriteLine("Name: " + item.Name);
                //var deptEmpl = employees.Where(e => e.Department_Id == item.Id).ToList();
                //if (deptEmpl != null)
                //{
                //    Console.WriteLine("Employees");
                //    foreach (var empl in deptEmpl)
                //    {
                //        Console.WriteLine("\tID: " + empl.Id);
                //        Console.WriteLine("\tName: " + empl.Name);
                //        Console.WriteLine("\tAge: " + empl.Age);
                //    }
                //}
                Console.WriteLine("------------------------");
            }
        }
        private void PrintEmployeesFromList(List<Employee> employees)
        {
            Console.WriteLine("Printing all Employees");
            var departments = DataAccessLibrary.GetAllDepartments();
            Console.WriteLine("------------------------");
            foreach (var item in employees)
            {
                Console.WriteLine("ID: " + item.Id);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Age: " + item.Age);
                Console.WriteLine("From: " + departments.SingleOrDefault(d => d.Id == item.Department_Id).Name);
                Console.WriteLine("------------------------");
            }
        }
        public void EditEmployeeAge()
        {
            var employees = DataAccessLibrary.GetAllEmployees();
            if (employees.Count > 0)
            {
                PrintEmployeesFromList(employees);
                Console.WriteLine("Please select from the above employees");
                do
                {
                    int id;
                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("Invalid Input. Try again.");
                    }
                    if (employees.Select(e => e.Id).Contains(id))
                    {
                        Console.WriteLine("Enter Age");
                        int age;
                        while (!int.TryParse(Console.ReadLine(), out age))
                        {
                            Console.WriteLine("Invalid Input. Try again.");
                        }
                        if (DataAccessLibrary.EditEmployeeAge(id, age))
                        {
                            Console.WriteLine("Edit success");
                        }
                        else
                        {
                            Console.WriteLine("Edit failed");
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No such employee exists. Try again.");
                    }
                } while (true);
            }
            else
            {
                Console.WriteLine("No employees added yet");
            }
        }
        public void EditEmployeeDepartment()
        {
            var employees = DataAccessLibrary.GetAllEmployees();
            if (employees.Count > 0)
            {
                PrintEmployeesFromList(employees);
                Console.WriteLine("Please select from the above employees");
                do
                {
                    int id;
                    while (!int.TryParse(Console.ReadLine(), out id))
                    {
                        Console.WriteLine("Invalid Input");
                    }
                    if (employees.Select(e => e.Id).Contains(id))
                    {
                        int prevDeptID = employees.Where(e => e.Id == id).SingleOrDefault().Department_Id;
                        var departments = DataAccessLibrary.GetAllDepartments().Where(d => d.Id != prevDeptID).ToList();
                        PrintDepartmentsFromList(departments);
                        Console.WriteLine("Please select from the above department");
                        int deptID;
                        do
                        {
                            while (!int.TryParse(Console.ReadLine(), out deptID))
                            {
                                Console.WriteLine("Invalid Input. Try again.");
                            }
                            if (departments.Select(d => d.Id).Contains(deptID))
                            {
                                if (DataAccessLibrary.EditEmployeeDepartment(id, deptID))
                                {
                                    Console.WriteLine("Edit success");
                                }
                                else
                                {
                                    Console.WriteLine("Edit failed");
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("No such department exists. Try again.");
                            }
                        } while (true);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No such employee exists. Try again.");
                    }
                } while (true);
            }
            else
            {
                Console.WriteLine("No employees added yet");
            }
        }
    }
}
