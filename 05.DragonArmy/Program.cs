using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, Dragon>> dragonDB = new Dictionary<string, Dictionary<string, Dragon>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                string type = input[0];
                string name = input[1];
                double DMG = 45;
                if (input[2] != "null")
                {
                    DMG = double.Parse(input[2]);
                }
                double health = 250;
                if (input[3] != "null")
                {
                    health = double.Parse(input[3]);
                }
                double armor = 10;
                if (input[4] != "null")
                {
                    armor = double.Parse(input[4]);
                }

                if (dragonDB.ContainsKey(type))
                {
                    if (dragonDB[type].ContainsKey(name))
                    {
                        dragonDB[type][name] = new Dragon(DMG, health, armor);
                    }
                    else
                    {
                        dragonDB[type].Add(name, new Dragon(DMG, health, armor));
                    }
                }
                else
                {
                    dragonDB.Add(type, new Dictionary<string, Dragon>());
                    dragonDB[type].Add(name, new Dragon(DMG, health, armor));
                }
            }

            foreach (var item in dragonDB)
            {
                double dmgAverage = item.Value.Sum(x => x.Value.Damage) / item.Value.Count;
                double healthAverage = item.Value.Sum(x => x.Value.Health) / item.Value.Count;
                double armorAverage = item.Value.Sum(x => x.Value.Armor) / item.Value.Count;
                Console.WriteLine($"{item.Key}::({dmgAverage:f2}/{healthAverage:f2}/{armorAverage:f2})");
                foreach (var dragon in item.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-{dragon.Key} -> damage: {dragon.Value.Damage}, health: {dragon.Value.Health}, armor: {dragon.Value.Armor}");
                }
            }
        }
    }
    class Dragon
    {
        public Dragon(double damage, double health, double armor)
        {
            Damage = damage;
            Health = health;
            Armor = armor;
        }

        public double Damage { get; set; }
        public double Health { get; set; }
        public double Armor { get; set; }
    }
}
