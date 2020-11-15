using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> languages = new Dictionary<string, List<string>>();
            Dictionary<string, int> participants = new Dictionary<string, int>();
            string[] input = Console.ReadLine()
                .Split("-", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while (input[0] != "exam finished")
            {
                string user = input[0];
                if (input[1] == "banned")
                {
                    if (participants.ContainsKey(user))
                    {
                        participants.Remove(user);
                    }
                }
                else
                {
                    string language = input[1];
                    int points = int.Parse(input[2]);
                    if (participants.ContainsKey(user))
                    {
                        if (participants[user] < points)
                        {
                            participants[user] = points;
                        }
                    }
                    else
                    {
                        participants.Add(user, points);
                    }
                    if (!languages.ContainsKey(language))
                    {
                        languages.Add(language, new List<string>());
                    }
                    languages[language].Add(user);
                }

                input = Console.ReadLine()
                                .Split("-", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray();
            }
            Console.WriteLine("Results:");
            foreach (var item in participants.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var item in languages.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value.Count}");
            }
            
        }
    }

}
