using PizzaDALEFLibrary;
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
        static void ManageMenu()
        {
            try
            {
                Console.WriteLine("Welcome to menu management");
                int choice = 0;
                ManageMenu menu = new ManageMenu();
                do
                {
                    Console.WriteLine("1: Add pizzas");
                    Console.WriteLine("2: Edit Pizza Price");
                    Console.WriteLine("3: Remove Pizza");
                    Console.WriteLine("4: Print Pizza Details");
                    Console.WriteLine("5: Print All Pizza Details");
                    Console.WriteLine("0: Exit");
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Please enter a number");
                    }
                    switch (choice)
                    {
                        case 1:
                            menu.AddPizzas();
                            break;
                        case 2:
                            menu.EditPizzaPrice();
                            break;
                        case 3:
                            menu.RemovePizza();
                            break;
                        case 4:
                            menu.PrintPizzaById();
                            break;
                        case 5:
                            menu.PrintPizzas();
                            break;
                        case 0:
                            Console.WriteLine("Bye Bye");
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                } while (choice != 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                switch (ex.GetType().Name)
                {
                    case "NullReferenceException":
                        break;
                    case "ArgumentOutOfRangeException":
                        break;
                    default:
                        break;
                }
            }
        }
        static void ManageCart()
        {
            ManageCart cart = new ManageCart();
            cart.PrintCart();
        }
        static void Main(string[] args)
        {
            //ManageCustomer manage = new ManageCustomer();
            //manage.RegisterCustomer();
            //manage.DisplayCustomers();
            //ManageMenu();
            //using (var db = new dbPizzaStoreEntities())
            //{
            //    foreach (var item in db.proc_GetAllPizzas())
            //    {
            //        Console.WriteLine(item.id + " " + item.name);
            //    }
            //}
            ManageCart();
            Console.ReadLine();
        }
    }
}
