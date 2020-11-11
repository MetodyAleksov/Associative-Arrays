using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace Associative_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, List<string>> dictionary = new SortedDictionary<string, List<string>>();
            for (int i = 0; i < n; i++)
            {
                string word = Console.ReadLine();
                string synonym = Console.ReadLine();
                if (dictionary.ContainsKey(word))
                {
                    dictionary[word].Add(synonym);
                }
                else
                {
                    dictionary.Add(word, new List<string>());
                    dictionary[word].Add(synonym);
                }
            }
            foreach (var item in dictionary)
            {
                Console.WriteLine($"{item.Key} - {string.Join(", ", item.Value)}");
            }
        } 
    }
}
