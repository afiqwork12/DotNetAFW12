using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionForDay12Application
{
    public class DataAccessLibrary
    {
        readonly DatabaseContext _databaseContext;
        public DataAccessLibrary()
        {
            _databaseContext = new DatabaseContext();
        }
        public bool InsertDepartment(Department department)
        {
            _databaseContext.Departments.Add(department);
            return SaveChanges();
        }
        public bool EditDepartmentName(int id, string name)
        {
            Department department = _databaseContext.Departments.SingleOrDefault(d => d.Id == id);
            if (department == null)
            {
                return false;
            }
            else
            {
                department.Name = name;
                return SaveChanges();
            }
        }
        public List<Department> GetAllDepartments()
        {
            return _databaseContext.Departments.ToList();
        }
        public bool InsertEmployee(Employee employee)
        {
            _databaseContext.Employees.Add(employee);
            return SaveChanges();
        }
        private bool SaveChanges()
        {
            if (_databaseContext.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }
        public bool EditEmployeeAge(int id, int age)
        {
            Employee employee = _databaseContext.Employees.SingleOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return false;
            }
            else
            {
                employee.Age = age;
                return SaveChanges();
            }
        }
        public bool EditEmployeeDepartment(int id, int deptId)
        {
            Employee employee = _databaseContext.Employees.SingleOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return false;
            }
            else
            {
                employee.Department_Id = deptId;
                return SaveChanges();
            }
        }
        public List<Employee> GetAllEmployees()
        {
            return _databaseContext.Employees.ToList();
        }
    }
}
