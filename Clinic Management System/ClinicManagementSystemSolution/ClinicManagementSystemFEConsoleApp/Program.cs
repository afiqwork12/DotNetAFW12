using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystemFEConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageUsers manageUsers = new ManageUsers();
            manageUsers.RegisterUsers();
            manageUsers.DisplayUsers();
            Console.ReadLine();
        }
    }
}
