using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, double> prices = new Dictionary<string, double>();
            Dictionary<string, int> numOfOrders = new Dictionary<string, int>();
            string[] arr = Console.ReadLine()
                .Split()
                .ToArray();
            while (arr[0] != "buy")
            {
                string name = arr[0];
                double pricePerOne = double.Parse(arr[1]);
                int quantity = int.Parse(arr[2]);

                if (prices.ContainsKey(name))
                {
                    if (prices[name] != pricePerOne)
                    {
                        prices[name] = pricePerOne;
                    }
                    numOfOrders[name] += quantity;
                }
                else
                {
                    prices.Add(name, pricePerOne);
                    numOfOrders.Add(name, quantity);
                }

                arr = Console.ReadLine()
                .Split()
                .ToArray();
            }

            foreach (var item in numOfOrders)
            {
                prices[item.Key] = prices[item.Key] * item.Value;
            }
            foreach (var item in prices)
            {
                Console.WriteLine($"{item.Key} -> {item.Value:f2}");
            }
        }
    } 
}
