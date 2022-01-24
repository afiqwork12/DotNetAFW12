using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodilityApplication
{
    class Program
    {
        static int Solution(int n)
        {
            string binary = Convert.ToString(n, 2);

            int curLength = 0;
            int maxLength = 0;


            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '0')
                {
                    curLength++;
                }
                if (binary[i] == '1')
                {
                    if (curLength > maxLength)
                    {
                        maxLength = curLength;
                    }
                    curLength = 0;
                }
            }

            return maxLength;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Number 9 has the binary gap of " + Solution(9));
            Console.WriteLine("Number 529 has the binary gap of " + Solution(529));
            Console.WriteLine("Number 20 has the binary gap of " + Solution(20));
            Console.WriteLine("Number 15 has the binary gap of " + Solution(15));
            Console.WriteLine("Number 32 has the binary gap of " + Solution(32));
            Console.ReadLine();
        }
    }
}
