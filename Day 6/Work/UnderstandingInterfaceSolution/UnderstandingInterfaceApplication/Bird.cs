using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingInterfaceApplication
{
    public class Bird : IFlying, ILiving
    {
        public Bird()
        {
            Console.WriteLine("You have created a bird");
        }
        public void Breath()
        {
            Console.WriteLine("Breath in.......Breath out");
        }

        public void Eat()
        {
            Console.WriteLine("Munch munch");

        }

        public void Fly()
        {
            Console.WriteLine("Fly Fly");
        }

        public void Land()
        {
            Console.WriteLine("Stop flapping wings");
        }

        public void Sleep()
        {
            Console.WriteLine("ZZzzzzzz");

        }

        public void TakeOff()
        {
            Console.WriteLine("Flaps wings harder");
        }
    }
}
