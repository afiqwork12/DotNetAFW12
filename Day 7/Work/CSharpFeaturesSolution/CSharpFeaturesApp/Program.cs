using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFeaturesApp
{
    class Program
    {
        void UnderstandingCheckedBlock()
        {
            int num = int.MaxValue;
            Console.WriteLine(num);
            //num++;
            //Console.WriteLine(num);
            checked
            {
                num++;
                Console.WriteLine(num);
            }
        }
        void NullablePrimitiveTypes()
        {
            int? num1 = 100;
            num1 = null;
            int num2 = num1 ?? 10;
            Console.WriteLine("num1 " + num1);
            Console.WriteLine("num2 " + num2);
        }
        bool MethodWithOut(int value1, out int value2)
        {
            value2 = value1 * 50;
            return true;
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            //p.UnderstandingCheckedBlock();
            //p.NullablePrimitiveTypes();
            int v1 = 10, v2;
            p.MethodWithOut(v1,out v2);
            Console.WriteLine("v2 " + v2);
            Console.ReadLine();
        }
    }
}
