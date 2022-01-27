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
        public List<User> users;
        public User currentUser;
        public ManageUsers()
        {
        }
        public ManageUsers(User user, List<User> users)
        {
            currentUser = user;
            this.users = users;
        }
        public User LoginUser()
        {
            do
            {
                string username = "";
                Console.WriteLine("Please enter your username");
                do
                {
                    username = Console.ReadLine();
                    if (username == "")
                    {
                        Console.WriteLine("Username cannot be blank");
                    }                    
                } while (username == "");
                string password = "";
                Console.WriteLine("Please enter your password");
                do
                {
                    password = Console.ReadLine();
                    if (password == "")
                    {
                        Console.WriteLine("Password cannot be blank");
                    }
                } while (password == "");
                currentUser = users.SingleOrDefault(u => username == u.Name + u.Id && u.Password == password);
                if (currentUser == null)
                {
                    Console.WriteLine("Please enter the correct username and password");
                }
            } while (currentUser == null);
            Console.Clear();
            if (currentUser.Type == "Patient")
            {
                Console.WriteLine("Welcome, " + currentUser.Name);

            }
            else
            {
                Console.WriteLine("Welcome, Dr." + currentUser.Name);

            }
            return currentUser;
        }

        public void RegisterUsers()
        {
            Console.WriteLine("Number of Users to be created:");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input. Try again.");
            }
            Console.WriteLine("Registering " + number + " users");
            for (int i = 0; i < number; i++)
            {
                Console.WriteLine("Please enter user type: (Patient / Doctor}");
                User user;
                var type = Console.ReadLine().ToLower();
                switch (type)
                {
                    case "patient":
                        user = new Patient();
                        break;
                    case "doctor":
                        user = new Doctor();
                        break;
                    default:
                        user = new Patient();
                        Console.WriteLine("Invalid entry. Treating as user type patient");
                        break;
                }
                user.TakeDetails();
                users.Add(user);
            }
        }
        public void DisplayUsers()
        {
            Console.WriteLine("Displaying User Records");
            Console.WriteLine("--------------------------------");
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine(users[i]);
                Console.WriteLine("--------------------------------");
            }
        }
    }
}
