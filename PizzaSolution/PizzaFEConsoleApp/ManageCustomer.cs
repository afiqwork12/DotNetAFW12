using PizzaModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFEConsoleApp
{
    class ManageCustomer
    {
        Customer[] customers = new Customer[3];
        public void RegisterCustomer()
        {
            for (int i = 0; i < customers.Length; i++)
            {
                Console.WriteLine("Please enter the customer type (Standard / Gold)");
                string type = ""; //Console.ReadLine();
                if (i % 2 == 0)
                {
                    type = "Standard";
                }
                else
                {
                    type = "Gold";
                }
                switch (type)
                {
                    case "Standard":
                        customers[i] = new Customer();
                        break;
                    case "Gold":
                        customers[i] = new GoldCustomer();
                        break;
                    default:
                        customers[i] = new Customer();
                        Console.WriteLine("Invalid entry. Treating as standard");
                        break;
                }
                customers[i].TakeCustomerDetailsFromUser();
            }
            //customer.TakeCustomerDetailsFromUser();
        }
        //public void DisplayCustomer()
        //{
        //    //customer.PrintCustomerDetails();
        //    Console.WriteLine(customer);
        //}
        public void DisplayCustomers()
        {
            for (int i = 0; i < customers.Length; i++)
            {
                Console.WriteLine(customers[i]);
            }
        }
    }
}
