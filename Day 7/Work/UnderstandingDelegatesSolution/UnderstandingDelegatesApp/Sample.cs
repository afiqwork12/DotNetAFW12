using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingDelegatesApp
{
    class Sample
    {
        //Action (for methods with/without para but no return) 
        //Func (for methods with/without para with one return type)
        //Predicate (for methods with one para and a boolean return)
        //public delegate void SampleDelegate<T>(T var1, T var2);
        //public SampleDelegate<int> MyDel;
        //public SampleDelegate<string> MyStringDel;
        public Action<int, int> MyDel;
        public Action<string, string> MyStringDel;
        public Sample()
        {
            //MyDel = new SampleDelegate(Add);
            MyDel = delegate (int num1, int num2)
            {
                int sum = num1 + num2;
                Console.WriteLine("The sum is " + sum);
            };
            //MyDel += Product;
            //MyDel += delegate (int num1, int num2)
            //{
            //    int product = num1 * num2;
            //    Console.WriteLine("The product is " + product);
            //};
            MyDel += (n1,n2) => Console.WriteLine("The product is " + (n1 *  n2));
            MyStringDel = Concat;
        }
        void Concat(string str1, string str2)
        {
            string concat = str1 + str2;
            Console.WriteLine("The concat is " + concat);
        }
        void Add(int num1, int num2)
        {
            int sum = num1 + num2;
            Console.WriteLine("The sum is " + sum);
        }
        void Product(int num1, int num2)
        {
            int sum = num1 * num2;
            Console.WriteLine("The sum is " + sum);
        }
    }
}
