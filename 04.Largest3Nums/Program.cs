using System;
using System.Linq;

namespace _04.Largest3Nums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .OrderByDescending(x => x)
                .ToArray();
            if (arr.Length > 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{arr[i]} ");
                }
            }
            else
            {
                Console.WriteLine(string.Join(" ", arr));
            }
        }
    }
}
