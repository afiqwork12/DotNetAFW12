using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingInheritanceApplication
{
    public class Phone
    {
        public string PhoneNumber { get; set; }
        public Phone()
        {
            PhoneNumber = "96552365";
            Console.WriteLine("Hey its a phone");
        }
        public virtual void MakeCall()
        {
            Console.WriteLine("We can make calls from " + PhoneNumber);
            Console.WriteLine("Dial Number. Wait for call to connect");
        }
        public void ReceiveCall()
        {
            Console.WriteLine("Tring........Tring");
            Console.WriteLine("We can receive calls");
        }
    }
}
