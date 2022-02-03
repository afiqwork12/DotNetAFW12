using PizzaDALEFLibrary;
using PizzaModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFEConsoleApp
{
    public class ManageMenu
    {
        List<Pizza> pizzas;
        PizzaDAL PizzaDAL;
        public Pizza this[int index]
        {
            get { return pizzas[index]; }
            set { pizzas[index] = value; }
        }
        public ManageMenu()
        {
            PizzaDAL = new PizzaDAL();
        }
        public void AddPizzas()
        {
            Console.WriteLine("Number of Pizzas to be created:");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input. Try again.");
            }
            for (int i = 0; i < number; i++)
            {
                Pizza pizza = new Pizza();
                //pizza.Id =
                //    pizzas.Count < 0 ? 1 : pizzas.Max(p => p.Id) + 1;
                Console.WriteLine("Please enter details for pizza number " + (i + 1));
                pizza.GetPizzaDetails();
                try
                {
                    PizzaDAL.InsertNewPizza(pizza);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not add pizza");
                    throw;
                }
            }
            PrintPizzas();
            
        }

        void GetAllPizza()
        {
            try
            {
                pizzas = PizzaDAL.GetAllPizza().ToList();
            }
            catch (NoPizzaException npe)
            {
                Console.WriteLine(npe.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong");
                Console.WriteLine(e.Message);
            }
        }

        public void PrintPizzas()
        {
            GetAllPizza();
            if (pizzas != null || pizzas.Count > 0)
            {
                pizzas.Sort();
                foreach (var pizza in pizzas)
                {
                    PrintPizza(pizza);
                }
            }
            else
            {
                Console.WriteLine("No pizzas available. Try again later.");
            }
        }

        public void PrintPizza(Pizza pizza)
        {
            Console.WriteLine("************************");
            Console.WriteLine(pizza);
            Console.WriteLine("************************");
        }
        public void PrintPizzaById()
        {
            Pizza pizza = GetPizzaById(GetIdFromUser());
            if (pizza != null)
            {
                Console.WriteLine(pizza);
            }
            else
            {
                Console.WriteLine("No such pizza");
            }
        }

        public Pizza GetPizzaById(int id)
        {
            //Pizza pizza = new Pizza();
            //for (int i = 0; i < pizzas.Count; i++)
            //{
            //    if (pizzas[i].Id == id)
            //    {
            //        pizza = pizzas[i];
            //        break;
            //    }
            //}
            //Predicate<Pizza> findPizza = p => p.Id == id;
            Pizza pizza = pizzas.SingleOrDefault(p => p.Id == id);
            //Pizza pizza = pizzas.Find(findPizza);
            return pizza;
        }
        public void EditPizzaPrice()
        {
            Pizza pizza = GetPizzaById(GetIdFromUser());
            Console.WriteLine("Please enter new pizza price:");
            double price;
            while (!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            pizza.Price = price;
            if (PizzaDAL.UpdatePizzaPrice(pizza.Id, pizza.Price))
            {
                Console.WriteLine("New Pizza Details");
                Console.WriteLine(pizza);
            }
            else
            {
                Console.WriteLine("Unable to update pizza price");
            }
        }
        public void RemovePizza()
        {
            Pizza pizza = GetPizzaById(GetIdFromUser());
            if (pizza != null)
            {
                Console.WriteLine("Do you want to delete the following Pizza? Yes / No");
                PrintPizza(pizza);
                string check = Console.ReadLine();
                if (check == "Yes")
                {
                    if (PizzaDAL.RemovePizza(pizza.Id))
                    {
                        Console.WriteLine("New Pizza List");
                        PrintPizzas();
                    }
                    else
                    {
                        Console.WriteLine("Deletion Failed");
                    }
                }
            }
        }

        private int GetIdFromUser()
        {
            Console.WriteLine("Please enter the pizza ID:");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            return id;
        }
    }
}
