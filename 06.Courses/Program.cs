using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string[] input = Console.ReadLine()
                .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            while(input[0] != "end")
            {
                string course = input[0];
                string student = input[1];
                if (courses.ContainsKey(course))
                {
                    courses[course].Add(student);
                }
                else
                {
                    courses.Add(course, new List<string>());
                    courses[course].Add(student);
                }

                input = Console.ReadLine()
                .Split(" : ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }
            foreach (var item in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"{item.Key}: {item.Value.Count}");
                foreach (var student in item.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}
