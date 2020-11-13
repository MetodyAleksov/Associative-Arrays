using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.Chars
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split().ToArray();
            List<char> list = new List<char>();
            foreach (string item in arr)
            {
                char[] word = item.ToCharArray();
                foreach (char letter in word)
                {
                    list.Add(letter);
                }
            }
            Dictionary<char, int> final = new Dictionary<char, int>();
            foreach (char item in list)
            {
                if (final.ContainsKey(item))
                {
                    final[item]++;
                }
                else
                {
                    final.Add(item, 1);
                }
            }
            StringBuilder sb = new StringBuilder();
            foreach (var item in final)
            {
                sb.AppendLine($"{item.Key} -> {item.Value}");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
