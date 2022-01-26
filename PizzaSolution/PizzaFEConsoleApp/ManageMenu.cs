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
        List<Pizza> pizzas = new List<Pizza>();
        public Pizza this[int index]
        {
            get { return pizzas[index]; }
            set { pizzas[index] = value; }
        }
        public ManageMenu()
        {

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
                pizza.Id = 
                    pizzas.Count < 0 ? 1 : pizzas.Max(p => p.Id) + 1;
                Console.WriteLine("Please enter details for pizza number " + (i + 1));
                pizza.GetPizzaDetails();
                pizzas.Add(pizza);
            }
            PrintPizzas();
        }

        public void PrintPizzas()
        {
            pizzas.Sort();
            foreach (var pizza in pizzas)
            {
                PrintPizza(pizza);
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
            for (int i = 0; i < pizzas.Count; i++)
            {
                if (pizzas[i].Id == pizza.Id)
                {
                    pizzas[i].Price = pizza.Price;
                    break;
                }
            }
            Console.WriteLine("New Pizza Details");
            Console.WriteLine(pizza);
        }
        public void RemovePizza()
        {
            Pizza pizza = GetPizzaById(GetIdFromUser());
            if (pizza != null)
            {
                Console.WriteLine("Do you want to delete the following Pizza?");
                PrintPizza(pizza);
                string check = Console.ReadLine();
                if (check == "Yes")
                {
                    for (int i = 0; i < pizzas.Count; i++)
                    {
                        if (pizza.Id == pizzas[i].Id)
                        {
                            pizzas.Remove(pizzas[i]);
                            break;
                        }
                    }
                    Console.WriteLine("New Pizza List");
                    PrintPizzas();
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
