using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return "ID: " + ID + "\nName: " + Name + "\nAge: " + Age;
        }

        public void TakeDetails()
        {
            Console.WriteLine("Enter Employee Name:");
            do
            {
                Name = Console.ReadLine();
                if (Name == "")
                {
                    Console.WriteLine("Name cannot be blank");
                }
                else
                {
                    break;
                }
            } while (true);
            Console.WriteLine("Enter Age:");
            int age;
            while (!int.TryParse(Console.ReadLine(), out age))
            {
                Console.WriteLine("Please enter a valid input. Try again.");
            }
            Age = age;
        }
    }
}
