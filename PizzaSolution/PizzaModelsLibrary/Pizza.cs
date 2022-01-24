using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaModelsLibrary
{
    public class Pizza : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsVeg { get; set; }
        public double Price { get; set; }
        public Pizza()
        {

        }
        public int CompareTo(object obj)
        {
            return Price.CompareTo(((Pizza)obj).Price);
        }
        public void GetPizzaDetails()
        {
            //Console.WriteLine("Please enter pizza ID");
            //int id;
            //while (!int.TryParse(Console.ReadLine(), out id))
            //{
            //    Console.WriteLine("Invalid entry. Please try again.");
            //}
            //Id = id;
            Console.WriteLine("Please enter pizza name");
            Name = Console.ReadLine();
            Console.WriteLine("Is the pizza vegetarian?");
            bool isVeg;
            while (!bool.TryParse(Console.ReadLine(),out isVeg))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            IsVeg = isVeg;
            Console.WriteLine("Please enter pizza price");
            double price;
            while(!double.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("Invalid entry. Please try again.");
            }
            Price = price;
        }
        public override string ToString()
        {
            return "Pizza ID: " + Id +
            "\nName: " + Name +
            "\nIsVeg: " + IsVeg +
            "\nPrice: $" + Price;
        }
    }
}
