using System;
using System.Collections.Generic;
using System.Text;

namespace _02.AMinorTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            string command = Console.ReadLine();
            while (command != "stop")
            {
                int amount = int.Parse(Console.ReadLine());
                if (resources.ContainsKey(command))
                {
                    resources[command] += amount;
                }
                else
                {
                    resources.Add(command, amount);
                }
                command = Console.ReadLine();
            }
            StringBuilder sb = new StringBuilder();

            foreach (var item in resources)
            {
                sb.AppendLine($"{item.Key} -> {item.Value}");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
