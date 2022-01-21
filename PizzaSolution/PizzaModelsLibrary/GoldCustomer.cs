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
            return base.ToString() + "\nMinimum amount for delivery is 0";
        }
    }
}
