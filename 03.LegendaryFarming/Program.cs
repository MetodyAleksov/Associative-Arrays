
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();
            resources.Add("shards", 0);
            resources.Add("fragments", 0);
            resources.Add("motes", 0);
            Dictionary<string, int> junk = new Dictionary<string, int>();
            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (resources["shards"] < 250 || resources["fragments"] < 250 || resources["motes"] < 250)
            {
                for (int i = 1; i < command.Length; i += 2)
                {
                    if (resources.ContainsKey(command[i].ToLower()))
                    {
                        resources[command[i].ToLower()] += int.Parse(command[i - 1]);
                    }
                    else
                    {
                        if (command[i].ToLower() != "fragments" && command[i].ToLower() != "shards" && command[i].ToLower() != "motes")
                        {
                            if (junk.ContainsKey(command[i]))
                            {
                                junk[command[i]] += int.Parse(command[i - 1]);
                            }
                            else
                            {
                                junk.Add(command[i], int.Parse(command[i - 1]));
                            }
                        }
                    }
                }
                if (resources["shards"] >= 250)
                {
                    Console.WriteLine("Shadowmourne obtained!");
                    resources["shards"] -= 250;
                    break;
                }
                else if (resources["fragments"] >= 250)
                {
                    Console.WriteLine("Valanyr obtained!");
                    resources["fragments"] -= 250;
                    break;
                }
                else  if (resources["motes"] >= 250)
                {
                    Console.WriteLine("Dragonwrath obtained!");
                    resources["motes"] -= 250;
                    break;
                }
                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            foreach (var item in resources.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
            foreach (var item in junk.OrderBy(x => x.Key).ThenByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
