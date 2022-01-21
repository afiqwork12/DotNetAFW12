using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingOOPSApplication
{
    class Customer
    {
        int num1;
        string phone;
        string Name { get; set; }
        public int Num1
        {
            get { return num1; }
            set { num1 = value * 2; }
        }
        public string Phone
        {
            get { return "XXXXXX" + phone.Substring(1, 4); }
            set { phone = value; }
        }
        //public int Id { get; set; }
        //public string Name { get; set; }
        //string phone;

        //public string Phone
        //{
        //    get
        //    {
        //        string masked = "XXXXXX" + phone.Substring(6, 4);
        //        return masked;
        //    }
        //    set
        //    {
        //        phone = value;
        //    }
        //}
    }
}
