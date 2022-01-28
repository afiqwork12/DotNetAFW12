using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkTestApp.Modals;

namespace EntityFrameworkTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NorthwindEntities())
            {
                foreach (var item in db.Ten_Most_Expensive_Products().ToList())
                {
                    Console.WriteLine(item.TenMostExpensiveProducts + ":\t\t" + item.UnitPrice);
                }
            }
            Console.ReadLine();
        }
    }
}
