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
        Pizza[] pizzas = new Pizza[3];
        public Pizza this[int index]
        {
            get { return pizzas[index]; }
            set { pizzas[index] = value; }
        }
        public ManageMenu()
        {

        }
        public ManageMenu(int size)
        {
            pizzas = new Pizza[size];
        }
        public void AddPizzas()
        {
            for (int i = 0; i < pizzas.Length; i++)
            {
                pizzas[i] = new Pizza();
                pizzas[i].Id = 100 + i;
                Console.WriteLine("Please enter details for pizza number " + (i + 1));
                pizzas[i].GetPizzaDetails();
            }
            PrintPizzas();
        }

        public void PrintPizzas()
        {
            Array.Sort(pizzas);
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
            Pizza pizza = new Pizza();
            for (int i = 0; i < pizzas.Length; i++)
            {
                if (pizzas[i].Id == id)
                {
                    pizza = pizzas[i];
                }
            }
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
            for (int i = 0; i < pizzas.Length; i++)
            {
                if (pizzas[i].Id == pizza.Id)
                {
                    pizzas[i].Price = pizza.Price;
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
                    Pizza[] newPizzas = new Pizza[pizzas.Length - 1];
                    int count = 0;
                    foreach (var item in pizzas)
                    {
                        if (item.Id != pizza.Id)
                        {
                            newPizzas[count] = item;
                            count++;
                        }
                    }
                    pizzas = newPizzas;
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
