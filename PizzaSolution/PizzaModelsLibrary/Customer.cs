using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaModelsLibrary
{
    public class Customer : IComparable
    {
        //private int checkIfPrivate;
        //protected int checkIfProtected;
        //internal int checkIfInternal;
        //protected internal int checkIfProtectedInternal;
        public int MinimumAmount { get; set; }
        [Key]
        public int CustomerNumber { get; set; }
        public string Name { get; set; }
        string phone;

        public string Type { get; set; }

        public Customer()
        {
            MinimumAmount = 100;
            Type = "Standard";
        }

        public string Phone
        {
            get
            {
                string masked = "XXXXXX" + phone.Substring(phone.Length - 4);
                return masked;
            }
            set
            {
                phone = value;
            }
        }
        public virtual void TakeCustomerDetailsFromUser()
        {
            Console.WriteLine("Please enter the customer ID");
            CustomerNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the customer Name");
            Name = Console.ReadLine();
            Console.WriteLine("Please enter the customer Phone");
            Phone = Console.ReadLine();
            //Console.WriteLine("Please enter the customer ID");
            //Id = 111;
            //Console.WriteLine("Please enter the customer Name");
            //Name = "asasasas";
            //Console.WriteLine("Please enter the customer Phone");
            //Phone = "228636523645";
        }
        public void PrintCustomerDetails()
        {
            Console.WriteLine("Customer ID: {0} Name: {1} Phone: {2}", CustomerNumber, Name, Phone);
        }
        public override string ToString()
        {
            return "Customer ID: " + CustomerNumber + "\nName: " + Name + "\nPhone: " + Phone + "\nType: " + Type;
        }

        public int CompareTo(object obj)
        {
            return Name.CompareTo(((Customer)obj).Name);
        }

        //public int CompareTo(object obj)
        //{
        //    return Id.CompareTo(((Customer)obj).Id);
        //}
        //public int CartNumber { get; set; }
        //[ForeignKey("CartNumber")]
    }
}
