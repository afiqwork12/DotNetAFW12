using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment20012022
{
    class Program
    {
        static void Main(string[] args)
        {
            //PrintZeroToGivenNumber();
            //CheckIfGivenNumIsOddOrEven();
            //FindGreatestOfTwoNums();
            //FindGreatestOfThreeNums();
            //PrintAllNumbersBetweenTwoNumbers();
            //CheckIfNumberIsPrime();
            //FindPrimeBetweenTwoNumbers();
            //FindSumOfGivenNumsDivisibleBySeven();
            //SumOfDigits();
            //CheckIfNumIsPalindrome();
            Console.WriteLine(IsHappy(19));
            Console.WriteLine(IsHappy(2));
            Console.ReadLine();
        }
        private static int GetNumberFromUser()
        {
            Console.Write("Please enter a number:");
            int num = Convert.ToInt32(Console.ReadLine());
            return num;
        }
        static void PrintZeroToGivenNumber()
        {
            int num = GetNumberFromUser();
            for (int i = 0; i <= num; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void CheckIfGivenNumIsOddOrEven()
        {
            int num = GetNumberFromUser();
            if (num % 2 == 0)
            {
                Console.WriteLine("It is a even number");
            }
            else
            {
                Console.WriteLine("It is a odd number");
            }
        }
        static void FindGreatestOfTwoNums()
        {
            Console.WriteLine("Please enter 2 numbers");
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            if (num1 > num2)
            {
                Console.WriteLine("The greatest of the 2 numbers is the first number");
            }
            else
            {
                Console.WriteLine("The greatest of the 2 numbers is the second number");
            }
        }
        static void FindGreatestOfThreeNums()
        {
            Console.WriteLine("Please enter 3 numbers");
            int greatest = 0;
            int[] array = 
            {
                Convert.ToInt32(Console.ReadLine()),
                Convert.ToInt32(Console.ReadLine()),
                Convert.ToInt32(Console.ReadLine())
            };
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > greatest)
                {
                    greatest = array[i];
                }
            }
            Console.WriteLine("Number " + greatest + " is the greatest number");
        }
        static void PrintAllNumbersBetweenTwoNumbers()
        {
            Console.Write("Please enter a minimum number:");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter a maximum number:");
            int max = Convert.ToInt32(Console.ReadLine());
            for (int i = min + 1; i < max; i++)
            {
                Console.WriteLine(i);
            }
        }
        static void CheckIfNumberIsPrime()
        {
            Console.Write("Please enter a number:");
            int num = Convert.ToInt32(Console.ReadLine());
            var check = true;
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    check = false;
                    break;
                }
            }
            if (check)
            {
                Console.WriteLine("It is a prime number");
            }
            else
            {
                Console.WriteLine("It is not a prime number");
            }
        }
        static void FindPrimeBetweenTwoNumbers()
        {
            Console.Write("Please enter a minimum number:");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter a maximum number:");
            int max = Convert.ToInt32(Console.ReadLine());
            for (int i = min + 1; i < max; i++)
            {
                var check = true;
                for (int j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    Console.WriteLine(i + " is a prime number");
                }
                else
                {
                    Console.WriteLine(i + " is not a prime number");
                }
            }
        }
        static void FindSumOfGivenNumsDivisibleBySeven()
        {
            Console.WriteLine("Please enter numbers and enter a negative number to stop");
            var list = new List<int>();
            int input = 1;
            while (input > 0)
            {
                input = Convert.ToInt32(Console.ReadLine());
                list.Add(input);
            }
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 7 == 0)
                {
                    sum += list[i];
                }
            }
            Console.WriteLine("The sum of given numbers divisible by 7 is "  + sum);
        }
        static void SumOfDigits()
        {
            Console.Write("Please enter a four digit number:");
            string num = Console.ReadLine();
            int sum = 0;
            for (int i = 0; i < num.Length; i++)
            {
                sum += Convert.ToInt32(num[i].ToString());
            }
            Console.WriteLine("The sum is " + sum);
        }
        static void CheckIfNumIsPalindrome()
        {
            Console.Write("Please enter a four digit number:");
            string num = Console.ReadLine();
            string rev = "";
            for (int i = num.Length - 1; i >= 0; i--)
            {
                rev += num[i].ToString();
            }
            //if (Convert.ToInt32(num) == Convert.ToInt32(rev))
            if (num.Equals(rev))
            {
                Console.WriteLine("Palindrome");
            }
            else
            {
                Console.WriteLine("Not a Palindrome");
            }
        }
        static bool IsHappy(int n)
        {
            string input = n.ToString();
            var check = false;
            var listOfInputs = new List<string>();
            Console.WriteLine(input);
            while (check == false)
            {
                int sum = 0;
                for (int i = 0; i < input.Length; i++)
                {
                    sum += Convert.ToInt32(Math.Pow(Convert.ToDouble(input[i].ToString()), 2.0));
                }
                input = sum.ToString();
                Console.WriteLine(input);
                if (sum == 1)
                {
                    check = true;
                    break;
                }
                if (listOfInputs.Count < 0)
                {
                    listOfInputs.Add(input);
                }
                else
                {
                    if (listOfInputs.Contains(input))
                    {
                        break;
                    }
                    else
                    {
                        listOfInputs.Add(input);
                    }
                }
            }
            return check;
        }
    }
}
