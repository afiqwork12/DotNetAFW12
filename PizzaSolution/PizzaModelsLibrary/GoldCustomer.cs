using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaModelsLibrary
{
    public class GoldCustomer : Customer
    {

        public GoldCustomer()
        {
            Type = "Gold";
            MinimumAmount = 0;
        }

        public override string ToString()
        {
            return base.ToString() + "\nMinimum amount for delivery is " + MinimumAmount;
        }
        public override void TakeCustomerDetailsFromUser()
        {
            base.TakeCustomerDetailsFromUser();
            Console.WriteLine("Please enter your preferred minimum amount");
            int amount = 0;
            bool result = false;// Int32.TryParse(Console.ReadLine(), out amount);
            while (result == false)
            {
                result = Int32.TryParse(Console.ReadLine(), out amount);
                if (result == false)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }
            if (result)
            {
                MinimumAmount = amount;
            }
            //MinimumAmount = Convert.ToInt32(Console.ReadLine());
        }
    }
}
