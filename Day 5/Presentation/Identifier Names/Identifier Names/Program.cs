using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identifier_Names
{
    //An identifier is the name you assign to a type (class, interface, struct, delegate, or enum), member, variable, or namespace
    // Interface - > IThenFirstLetterCapital -> Nouns
    interface IEmployee 
    {
        void PrintEmployeeDetails();
    }
    // Class Name -> CapitalFirstLetter -> Nouns
    class Employee : IEmployee 
    {
        // Private Variable Name -> nonCapitalFirstLetter -> Nouns
        private int employeeID;
        // Public Variable Name -> CapitalFirstLetter -> Nouns
        public string Name;
        public Employee(int employeeID, string name)
        {
            this.employeeID = employeeID;
            Name = name;
        }
        // Method Name -> CapitalFirstLetter -> Verbs e.g. Print,Check
        public void PrintEmployeeDetails()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine(" Employee ID: " + employeeID);
            Console.WriteLine("        Name: " + Name);
            Console.WriteLine("--------------------------");
        }
    }
    class Program
    {
        //Readonly Variable -> _nonCapitalFirstLetter -> Nouns
        static readonly string _readOnlyVariable = "This is a readonly variable";
        //Constant Variable -> ALLCAPITALLETTERS -> Nouns
        const double PI = 3.14159;
        static void Main(string[] args)
        {
            IEmployee employee = new Employee(1, "John");
            employee.PrintEmployeeDetails();
            Console.WriteLine(_readOnlyVariable);
            Console.WriteLine("The value of PI is " + PI);
            Console.ReadLine();
        }
    }
}
