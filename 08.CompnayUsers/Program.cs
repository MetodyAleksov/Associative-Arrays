using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.CompnayUsers
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> companyRoster = new Dictionary<string, List<string>>();
            string[] input = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "End")
            {
                string company = input[0];
                string employee = input[1];
                if (companyRoster.ContainsKey(company))
                {
                    if (!companyRoster[company].Contains(employee))
                    {
                        companyRoster[company].Add(employee);
                    }
                }
                else
                {
                    companyRoster.Add(company, new List<string>() { employee });
                }
                input = Console.ReadLine()
                .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var item in companyRoster.OrderBy(x => x.Key))
            {
                Console.WriteLine(item.Key);
                foreach (string employee in item.Value)
                {
                    Console.WriteLine($"-- {employee}");
                }
            }
        }
    }
}
