using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagementSystemModelsLibrary
{
    public class User
    {
        private int id;
        private string name;
        private string password;
        private int age;
        public string Type;
        public User()
        {
            Type = "User";
        }
        public override string ToString()
        {
            var output = "";
            output += "Type: " + Type + "\n";
            output += "ID: " + id + "\n";
            output += "Name: " + name + "\n";
            output += "Password: ******************\n";
            output += "Age: " + age + "\n";
            return output;
        }
        public virtual void TakeDetails()
        {
            Console.WriteLine("Please Enter Your ID:");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter Your Name:");
            name = Console.ReadLine();
            Console.WriteLine("Please Enter Your Password:");
            password = Console.ReadLine();
            Console.WriteLine("Please Enter Your Age:");
            age = Convert.ToInt32(Console.ReadLine());
        }
    }
}
