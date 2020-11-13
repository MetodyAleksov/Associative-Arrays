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
            Dictionary<string, string> contests = new Dictionary<string, string>();
            string[] command = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while(command[0] != "end of contests")
            {
                string contest = command[0];
                string password = command[1];

                contests.Add(contest, password);
     
                command = Console.ReadLine()
                .Split(":", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            List<Contestant> players = new List<Contestant>();
            string[] cmd = Console.ReadLine()
                .Split("=>")
                .ToArray();
            while (cmd[0] != "end of submissions")
            {
                string contest = cmd[0];
                string password = cmd[1];
                string name = cmd[2];
                int points = int.Parse(cmd[3]);

                if (contests.ContainsKey(contest))
                {
                    if (contests[contest] == password)
                    {
                        Contestant curr = new Contestant(name, new Dictionary<string, int>());
                        curr.Contest.Add(contest, points);
                        foreach (Contestant item in players)
                        {
                            if (item.Name == curr.Name && item.Contest.Keys == curr.Contest.Keys && item.Contest.Values < curr.Contest.Values)
                        }
                    }
                }

                cmd = Console.ReadLine()
                .Split("=>")
                .ToArray();
            }
        }
    }
    class Contestant
    {
        public Contestant(string name, Dictionary<string, int> contest)
        {
            Name = name;
            Contest = contest;
        }

        public string Name { get; set; }
        public Dictionary<string, int> Contest { get; set; }
    }
}
