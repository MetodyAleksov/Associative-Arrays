using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> gradebook = new Dictionary<string, List<double>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (gradebook.ContainsKey(name))
                {
                    gradebook[name].Add(grade);
                }
                else
                {
                    gradebook.Add(name, new List<double>() { grade });
                }
            }

            Dictionary<string, double> averageGrade = new Dictionary<string, double>();

            foreach (var item in gradebook)
            {
                double avrgGrade = item.Value.Sum() / item.Value.Count;
                averageGrade.Add(item.Key, avrgGrade);
            }
            foreach (var item in averageGrade.Where(x => x.Value >= 4.50).OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    }
}
