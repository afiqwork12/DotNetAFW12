using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingInheritanceApplication
{
    public class MobilePhone : Phone
    {
        public MobilePhone()
        {
            Console.WriteLine("and a mobile phone");
            PhoneNumber = "13232561354";
        }
        public void Carry()
        {
            Console.WriteLine("Take where you go....");
        }
        public override void MakeCall()
        {
            Console.WriteLine("We can make wireless calls from " + PhoneNumber);
            Console.WriteLine("Go wireless");
        }
    }
}
