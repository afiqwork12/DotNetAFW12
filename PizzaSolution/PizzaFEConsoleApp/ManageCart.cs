using PizzaDALEFLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFEConsoleApp
{
    class ManageCart
    {
        CartDAL cartDAL;
        public ManageCart()
        {
            cartDAL = new CartDAL();
        }
        public void PrintCart()
        {
            Console.WriteLine("Enter customer number");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input try again");
            }
            cartDAL.GetCart(id);
        }
    }
}
