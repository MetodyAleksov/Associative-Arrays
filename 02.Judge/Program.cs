using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Judge
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> dataBase = new Dictionary<string, Dictionary<string, int>>();

            string[] input = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "no more time")
            {
                string contest = input[1];
                string participant = input[0];
                int points = int.Parse(input[2]);
                if (dataBase.ContainsKey(contest))
                {
                    if (dataBase[contest].ContainsKey(participant))
                    {
                        if (dataBase[contest][participant] < points)
                        {
                            dataBase[contest][participant] = points;
                        }
                    }
                    else
                    {
                        dataBase[contest].Add(participant, points);
                    }
                }
                else
                {
                    dataBase.Add(contest, new Dictionary<string, int>());
                    dataBase[contest].Add(participant, points);
                }

                input = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var item in dataBase)
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count} participants");
                int n = 1;
                foreach (var participant in item.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{n}. {participant.Key} <::> {participant.Value}");
                    n++;
                }
            }
            Console.WriteLine("Individual standings:");
            Dictionary<string, int> individual = new Dictionary<string, int>();
            foreach (var item in dataBase)
            {
                foreach (var person in item.Value)
                {
                    if (individual.ContainsKey(person.Key))
                    {
                        individual[person.Key] += person.Value;
                    }
                    else
                    {
                        individual.Add(person.Key, person.Value);
                    }
                }
            }
            int k = 1;
            foreach (var item in individual.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{k}. {item.Key} -> {item.Value}");
                k++;
            }
        }
    }
}
