using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingLINQApplication
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Department_ID { get; set; }
        public override string ToString()
        {
            return "ID " + Id + " Name " + Name + " Department " + Department_ID;
        }
    }
    class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        List<Department> departments = new List<Department>()
            {
                new Department{ Id = 1, Name = "Admin" },
                new Department{ Id = 2, Name = "Development" },
                new Department{ Id = 3, Name = "Testing" }
            };
        List<Employee> employees = new List<Employee>()
            {
                new Employee{ Id = 100, Name = "Tim", Department_ID = 1 },
                new Employee{ Id = 101, Name = "Jim", Department_ID = 2 },
                new Employee{ Id = 102, Name = "Kim", Department_ID = 3 },
                new Employee{ Id = 103, Name = "Lim", Department_ID = 1 },
                new Employee{ Id = 104, Name = "Pim", Department_ID = 2 },
                new Employee{ Id = 105, Name = "Rim", Department_ID = 3 },
            };
        void SimpleWhere()
        {
            int[] scores = { 90, 67, 89, 100, 45, 69, 50, 88 };
            foreach (var item in scores.Where(x => x > 70))
            {
                Console.WriteLine(item);
            }
        }
        void LINQWithCollection()
        {
            //foreach (var item in employees.Where(e => e.Department_ID == 1))
            //{
            //    Console.WriteLine(item);
            //}
            //var emp = employees.SingleOrDefault(e => e.Id == 109);
            //if (emp != null)
            //{
            //    Console.WriteLine(emp);
            //}
            //else
            //{
            //    Console.WriteLine("No such employee");
            //}
            var empWithDeptName = employees
                //.Where(e => e.Department_ID == 2)
                .OrderBy(e => e.Name)
                .Select
                (
                e => new
                {
                    EmployeeName = e.Name,
                    EmployeeId = e.Id,
                    DepartmentName = departments.SingleOrDefault(d => d.Id == e.Department_ID).Name
                }
                );

            var data = from e in employees
                       join d in departments
                       on e.Department_ID equals d.Id
                       select
                       new
                       {
                           EmployeeName = e.Name,
                           EmployeeId = e.Id,
                           DepartmentName = d.Name
                       };
            var data1 =
                employees
                .Join(
                departments,
                e => e.Department_ID,
                d => d.Id,
                (e, d) => new
                {
                    EmployeeName = e.Name,
                    EmployeeId = e.Id,
                    DepartmentName = d.Name,
                    DepartmentId = d.Id
                })
                .Where(dt => dt.DepartmentName.Contains("i"))
                .Select(dt => new { Name = dt.EmployeeName, From = dt.DepartmentName });
            //var data3 =
            //    employees
            //    .Join(
            //        departments,
            //        (e, d) => new
            //        {
            //            EmployeeName = e.Name,
            //            EmployeeId = e.Id,
            //            DepartmentName = d.Name
            //        });
            foreach (var item in data1)
            {
                Console.WriteLine(item.Name + " from " + item.From);
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.SimpleWhere();
            program.LINQWithCollection();
            Console.ReadLine();
        }
    }
}
