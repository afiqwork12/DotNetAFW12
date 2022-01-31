using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary1;

namespace QnsForDay11DALLibrary
{
    public class EmployeeDAL
    {
        SqlConnection conn;
        public EmployeeDAL()
        {
            conn = MyConnection.GetConnection();
        }
        /// <summary>
        /// Gets all the records from the table in the Employee Database
        /// </summary>
        /// <returns>
        /// ICollection&lt;Employee&lt;
        /// </returns>
        public ICollection<Employee> GetAllEmployees()
        {
            List<Employee> employees = new List<Employee>();
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter("proc_GetAllEmployee", conn);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.Fill(ds);
            if (ds.Tables[0].Rows.Count != 0)
            {
                Employee employee;
                foreach (DataRow item in ds.Tables[0].Rows)
                {
                    employee = new Employee();
                    employee.ID = Convert.ToInt32(item[0]);
                    employee.Name = item[1].ToString();
                    employee.Age = Convert.ToInt32(item[2]);
                    employees.Add(employee);
                }
                return employees;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Inserts employee into database
        /// </summary>
        /// <returns>
        /// bool
        /// </returns>
        public bool InsertNewEmployee(Employee employee)
        {
            SqlCommand cmd = new SqlCommand("proc_InsertEmploye", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ename", employee.Name);
            cmd.Parameters.AddWithValue("@eage", employee.Age);
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Updates employee age by id
        /// </summary>
        /// <returns>
        /// bool
        /// </returns>
        public bool UpdateEmployeeAgeByID(Employee employee)
        {
            SqlCommand cmd = new SqlCommand("proc_UpdateEmployeeAgeByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", employee.ID);
            cmd.Parameters.AddWithValue("@eage", employee.Age);
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            return false;
        }
        /// <summary>
        /// Deletes employee by id
        /// </summary>
        /// <returns>
        /// bool
        /// </returns>
        public bool DeleteEmployeeByID(Employee employee)
        {
            SqlCommand cmd = new SqlCommand("proc_DeleteEmployeeByID", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", employee.ID);
            conn.Open();
            if (cmd.ExecuteNonQuery() > 0)
            {
                conn.Close();
                return true;
            }
            return false;
        }
        public Employee GetEmployeeByID(int id)
        {
            var employee = GetAllEmployees().SingleOrDefault(x => x.ID == id);
            if (employee != null)
            {
                return employee;
            }
            return null;
        }
    }
}
