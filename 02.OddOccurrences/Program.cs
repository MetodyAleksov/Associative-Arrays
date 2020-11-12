using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace _02.OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine()
                .Split()
                .ToArray();
            Dictionary<string, int> words = new Dictionary<string, int>();
            foreach (var item in arr)
            {
                if (words.ContainsKey(item.ToLower()))
                {
                    words[item.ToLower()]++;
                }
                else
                {
                    words.Add(item.ToLower(), 1);
                }
            }
            foreach (var item in words)
            {
                if (item.Value % 2 != 0)
                {
                    Console.Write($"{item.Key} ");
                }
            }
        }
    }
}
