using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingCollectionsApplication
{
    class Program
    {
        void UnderstandingList()
        {
            //int[] numArr = new int[10];
            //numArr[10] = 100;
            //System.IndexOutOfRangeException: 'Index was outside the bounds of the array.'
            //ArrayList arrList = new ArrayList();
            ////ArrayList is legacy collection
            ////not type safe
            //arrList.Add(100);
            //arrList.Add(100);
            //arrList.Add(100);
            //arrList.Add(100);
            //arrList.Add(100);
            //arrList.Add(100);
            //arrList.Add(100);
            //arrList.Add(100);
            //arrList.Add(100);
            //arrList.Add(100);
            //arrList.Add("test");
            //int sum = 0;
            //foreach (var item in arrList)
            //{
            //    Console.WriteLine(item);
            //    sum += Convert.ToInt32(item);
            //}
            List<int> numList = new List<int>();
            //List is more type safe
            numList.Add(100);
            numList.Add(100);
            numList.Add(100);
            numList.Add(100);
            numList.Add(100);
            numList.Add(100);
            numList.Add(100);
            numList.Add(100);
            //numList.Add("test");
            Console.WriteLine("Item in 3rd positon {0}", numList[2]);
        }
        void UnderstandingStack()
        {
            Stack<string> names = new Stack<string>();
            names.Push("Tim");
            names.Push("Jim");
            names.Push("Kim");
            names.Push("Lim");
            foreach (var item in names)
                Console.WriteLine(item);
            Console.WriteLine(names.Count);
            //Console.WriteLine(names.Pop());
            Console.WriteLine(names.Peek());
            Console.WriteLine(names.Count);
        }
        void UnderstandingQueue()
        {
            Queue<string> names = new Queue<string>();
            names.Enqueue("Tim");
            names.Enqueue("Jim");
            names.Enqueue("Kim");
            names.Enqueue("Lim");
            foreach (var item in names)
                Console.WriteLine(item);
            Console.WriteLine(names.Count);
            Console.WriteLine(names.Dequeue());
            //Console.WriteLine(names.Peek());
            Console.WriteLine(names.Count);
        }
        void UnderstandingDictionary()
        {
            Dictionary<int, string> users = new Dictionary<int, string>();
            users.Add(101, "Tim");
            users.Add(102, "Lim");
            users.Add(103, "Kim");
            users.Add(104, null);
            foreach (var item in users.Keys)
                Console.WriteLine(item + " " + users[item]);
            if (users.ContainsKey(104))
                Console.WriteLine("Key 104 already present");
            Console.WriteLine(users.ContainsValue("Jim"));
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.UnderstandingList();
            //program.UnderstandingStack();
            //program.UnderstandingQueue();
            program.UnderstandingDictionary();
            Console.ReadLine();
        }
    }
}
