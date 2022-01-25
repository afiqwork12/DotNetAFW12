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
        List<User> users = new List<User>();
        User CurrentUser;
        public ManageUsers()
        {
            GenerateUsers();
        }
        public User LoginUser()
        {
            do
            {
                Console.WriteLine("Please enter your username");
                string username = Console.ReadLine();
                Console.WriteLine("Please enter your password");
                string password = Console.ReadLine();
                CurrentUser = users.Find(u => username == u.Name + u.Id && u.Password == password);
                if (CurrentUser == null)
                {
                    Console.WriteLine("Please enter the correct username and password");
                }
            } while (CurrentUser == null);
            if (CurrentUser.Type == "Patient")
            {
                Console.WriteLine("Welcome, " + CurrentUser.Name);

            }
            else
            {
                Console.WriteLine("Welcome, Dr." + CurrentUser.Name);

            }
            return CurrentUser;
        }
        void GenerateUsers()
        {
            users.Add(new Patient() { Id = 101, Name = "John", Password = "123456", Age = 25, Remarks = "Lower Back Pain", Status = "Pain Manageable" });
            users.Add(new Patient() { Id = 102, Name = "Mary", Password = "123456", Age = 36, Remarks = "Swollen Appendix", Status = "In alot of pain" });
            users.Add(new Doctor() { Id = 201, Name = "James", Password = "123456", Age = 33, Speciality = "Orthopedics", Experience = 4 });
            users.Add(new Doctor() { Id = 202, Name = "Sally", Password = "123456", Age = 38, Speciality = "Surgery", Experience = 10 });
            users.Add(new Doctor() { Id = 203, Name = "Mark", Password = "123456", Age = 28, Speciality = "Dermatology", Experience = 5 });
            users.Add(new Doctor() { Id = 204, Name = "Jane", Password = "123456", Age = 29, Speciality = "Family Medicine", Experience = 6 });
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
