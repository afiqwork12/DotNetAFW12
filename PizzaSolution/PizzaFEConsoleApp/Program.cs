using PizzaModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFEConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageCustomer manage = new ManageCustomer();
            manage.RegisterCustomer();
            manage.DisplayCustomers();
            Console.ReadLine();
        }
    }
}
