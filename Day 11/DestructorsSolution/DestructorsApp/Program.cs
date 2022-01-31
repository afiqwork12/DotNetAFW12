using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestructorsApp
{
    //destructors are also known as finalizers
    //Finalizers cannot be defined in structs. They are only used with classes.
    //A class can only have one finalizer.
    //Finalizers cannot be inherited or overloaded.
    //Finalizers cannot be called. They are invoked automatically.
    //A finalizer does not take modifiers or have parameters.
    public class MyClass
    {
        public int ID { get; set; }
        public MyClass(int id)
        {
            ID = id;
            Console.WriteLine("An instance of MyClass with an ID of " + ID + " has been made");
        }
        //
        ~MyClass()
        {
            Console.WriteLine("An instance of MyClass with an ID of " + ID + " has been destroyed");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CreateClasses();
            Console.Write("Press enter to collect garbage");
            Console.ReadLine();
            GC.Collect();
            Console.ReadLine();
        }

        private static void CreateClasses()
        {
            MyClass instance1 = new MyClass(1);
            MyClass instance2 = new MyClass(2);
        }
    }
}
