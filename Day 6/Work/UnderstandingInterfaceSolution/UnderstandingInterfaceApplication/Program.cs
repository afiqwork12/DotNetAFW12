using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingInterfaceApplication
{
    class Program
    {
        void ExploreForest(ILiving living)
        {
            living.Breath();
            living.Eat();
            living.Sleep();
        }
        void CheckSky(IFlying flying)
        {
            flying.TakeOff();
            flying.Fly();
            flying.Land();
        }
        void SortAndPrintNames()
        {
            string[] names = { "Tim", "Jim", "Lim" };
            Array.Sort(names);
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
        static void Main(string[] args)
        {
            Bird bird = new Bird();
            Program program = new Program();
            program.ExploreForest(bird);
            program.CheckSky(bird);
            program.SortAndPrintNames();
            Console.ReadLine();
        }
    }
}
