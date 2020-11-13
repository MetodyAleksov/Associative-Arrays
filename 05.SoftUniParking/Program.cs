using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> registry = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine()
                    .Split()
                    .ToArray();
                if (command[0] == "register")
                {
                    if (registry.ContainsKey(command[1]))
                    {
                        if (registry[command[1]] == command[2])
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {command[2]}");
                        }
                    }
                    else
                    {
                        registry.Add(command[1], command[2]);
                        Console.WriteLine($"{command[1]} registered {registry[command[1]]} successfully");
                    }
                }
                else if (command[0] == "unregister")
                {
                    if (registry.ContainsKey(command[1]))
                    {
                        registry.Remove(command[1]);
                        Console.WriteLine($"{command[1]} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {command[1]} not found");
                    }
                }
            }
            foreach (var item in registry)
            {
                Console.WriteLine($"{item.Key} => {item.Value}");
            }
        }
    }
}
