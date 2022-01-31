using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaModelsLibrary
{
    public class NoPizzaException : Exception
    {
        string message;
        public NoPizzaException()
        {
            message = "No pizzas available. Try again later.";
        }
        public override string Message => message;
    }
}
