
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> material = new Dictionary<string, int>();
            material.Add("shards", 0);
            material.Add("fragments", 0);
            material.Add("motes", 0);
            Dictionary<string, int> junk = new Dictionary<string, int>();
            bool cycleisbroken = false;
            string[] command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (material.Any(x => x.Value < 250))
            {
                for (int i = 1; i < command.Length; i += 2)
                {
                    if (material.ContainsKey(command[i].ToLower()))
                    {
                        material[command[i].ToLower()] += int.Parse(command[i - 1]);
                        if (material[command[i].ToLower()] >= 250)
                        {
                            cycleisbroken = true;
                            break;
                        }
                    }
                    else
                    {
                        if (junk.ContainsKey(command[i].ToLower()))
                        {
                            junk[command[i].ToLower()] += int.Parse(command[i - 1]);
                        }
                        else
                        {
                            junk.Add(command[i].ToLower(), int.Parse(command[i - 1]));
                        }
                    }
                }
                if (cycleisbroken)
                {
                    break;
                }
                command = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            if (material["shards"] >= 250)
            {
                Console.WriteLine("Shadowmourne obtained!");
                material["shards"] -= 250;
            }
            else if (material["fragments"] >= 250)
            {
                Console.WriteLine("Valanyr obtained!");
                material["fragments"] -= 250;
            }
            else if (material["motes"] >= 250)
            {
                Console.WriteLine("Dragonwrath obtained!");
                material["motes"] -= 250;
            }
            foreach (var item in material.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
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
