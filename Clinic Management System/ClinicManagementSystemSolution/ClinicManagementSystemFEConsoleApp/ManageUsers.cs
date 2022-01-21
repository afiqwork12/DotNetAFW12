using ClinicManagementSystemModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystemFEConsoleApp
{
    public class ManageUsers
    {
        User[] users = new User[2];
        public void RegisterUsers()
        {
            Console.WriteLine("Registering " + users.Length + " users");
            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine("Please enter user type: (Patient / Doctor}");
                var type = Console.ReadLine().ToLower();
                switch (type)
                {
                    case "patient":
                        users[i] = new Patient();
                        break;
                    case "doctor":
                        users[i] = new Doctor();
                        break;
                    default:
                        users[i] = new Patient();
                        Console.WriteLine("Invalid entry. Treating as user type patient");
                        break;
                }
                users[i].TakeDetails();
            }
        }
        public void DisplayUsers()
        {
            Console.WriteLine("Displaying User Records");
            Console.WriteLine("--------------------------------");
            for (int i = 0; i < users.Length; i++)
            {
                Console.WriteLine(users[i]);
                Console.WriteLine("--------------------------------");
            }
        }
    }
}
