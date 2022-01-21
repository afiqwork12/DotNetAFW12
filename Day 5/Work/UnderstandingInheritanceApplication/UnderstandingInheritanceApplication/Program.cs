using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingInheritanceApplication
{
    class Program
    {
        void UsePhone(Phone phone)
        {
            //MobilePhone phone = new MobilePhone();
            //It has to behave like a phone is phone object is passed
            //It has to behave like a MobilePhone if mobilephone object is passed
            phone.MakeCall();
            phone.ReceiveCall();
            ((MobilePhone)phone).Carry();
        }
        static void Main(string[] args)
        {
            Phone phone = new MobilePhone();
            Program program = new Program();
            program.UsePhone(phone);

            Console.ReadLine();
        }
    }
}
