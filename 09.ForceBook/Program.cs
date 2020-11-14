using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> forceDataBase = new Dictionary<string, List<string>>();
            string command = Console.ReadLine();
            while (command != "Lumpawaroo")
            {
                string[] forceuser = command.Split(" | ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string[] userforce = command.Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (forceuser.Length > 1)
                {
                    if (forceDataBase.ContainsKey(forceuser[0]))
                    {
                        if (!forceDataBase[forceuser[0]].Contains(forceuser[1]))
                        {
                            forceDataBase[forceuser[0]].Add(forceuser[1]);
                        }
                    }
                    else
                    {
                        forceDataBase.Add(forceuser[0], new List<string>());
                        forceDataBase[forceuser[0]].Add(forceuser[1]);
                    }
                }
                else if (userforce.Length > 1)
                {
                    string containedIn = String.Empty;
                    bool isContained = false;
                    foreach (var item in forceDataBase)
                    {
                        if (item.Value.Contains(userforce[0]))
                        {
                            isContained = true;
                            containedIn = item.Key;
                        }
                    }
                    if (isContained)
                    {
                        forceDataBase[containedIn].Remove(userforce[0]);
                    }
                    forceDataBase[userforce[1]].Add(userforce[0]);
                    Console.WriteLine($"{userforce[0]} joins the {userforce[1]} side!");
                }
                command = Console.ReadLine();
            }
            foreach (var item in forceDataBase.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {item.Key}, Members: {item.Value.Count}");
                    foreach (var user in item.Value.OrderBy(x => x))
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
