using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _01.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            //Passwords for courses
            Dictionary<string, string> contestPasswords = new Dictionary<string, string>();
            //Storing the contests contestatants participate in
            Dictionary<string, Dictionary<string, int>> contestsDataBase = new Dictionary<string, Dictionary<string, int>>();

            string[] input = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            //Declaring the passwords
            while(input[0] != "end of contests")
            {
                contestPasswords.Add(input[0], input[1]);
                input = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            input = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            //Entering the contestants and their results
            while (input[0] != "end of submissions")
            {
                string contest = input[0];
                string password = input[1];
                string name = input[2];
                int points = int.Parse(input[3]);

                if(contestPasswords.ContainsKey(contest))
                {
                    if (contestPasswords[contest] == password)
                    {
                        if (contestsDataBase.ContainsKey(name))
                        {
                            if (contestsDataBase[name].ContainsKey(contest))
                            {
                                if (contestsDataBase[name][contest] < points)
                                {
                                    contestsDataBase[name][contest] = points;
                                }
                            }
                            else
                            {
                                contestsDataBase[name].Add(contest, points);
                            }
                        }
                        else
                        {
                            contestsDataBase.Add(name, new Dictionary<string, int>());
                            contestsDataBase[name].Add(contest, points);
                        }
                    }
                }
                input = Console.ReadLine()
                .Split("=>", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            int bestScore = int.MinValue;
            string bestContestant = String.Empty;
            foreach (var item in contestsDataBase)
            {
                if (item.Value.Values.Sum() > bestScore)
                {
                    bestScore = item.Value.Values.Sum();
                    bestContestant = item.Key;
                }
            }
            Console.WriteLine($"Best candidate is {bestContestant} with total {bestScore} points.");
            Console.WriteLine($"Ranking: ");
            foreach (var item in contestsDataBase.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key}");
                foreach (var contest in item.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
