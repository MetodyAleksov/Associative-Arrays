using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MOBAChallenger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> playerRoster = new Dictionary<string, Dictionary<string, int>>();

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            while (input[0] != "Season" && input[1] != "end")
            {
                if (input.Contains("->"))
                {
                    string name = input[0];
                    string position = input[2];
                    int skill = int.Parse(input[4]);
                    if (playerRoster.ContainsKey(name))
                    {
                        if (playerRoster[name].ContainsKey(position))
                        {
                            if (playerRoster[name][position] < skill)
                            {
                                playerRoster[name][position] = skill;
                            }
                        }
                        else
                        {
                            playerRoster[name].Add(position, skill);
                        }
                    }
                    else
                    {
                        playerRoster.Add(name, new Dictionary<string, int>());
                        playerRoster[name].Add(position, skill);
                    }
                }
                else if (input.Contains("vs"))
                {
                    string player1 = input[0];
                    string player2 = input[2];
                    string commonPosition = "none";
                    if (playerRoster.ContainsKey(player1) && playerRoster.ContainsKey(player2))
                    {

                        foreach (var item in playerRoster[player1])
                        {
                            if (playerRoster[player2].ContainsKey(item.Key))
                            {
                                commonPosition = item.Key;
                                break;
                            }
                        }
                        if (commonPosition != "none")
                        {
                            int player1Skill = playerRoster[player1].Sum(x => x.Value);
                            int player2Skill = playerRoster[player2].Sum(x => x.Value);
                            if (player1Skill > player2Skill)
                            {
                                playerRoster.Remove(player2);
                            }
                            else if (player2Skill > player1Skill)
                            {
                                playerRoster.Remove(player1);
                            }
                        }
                    }
                }
                input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            }

            foreach (var player in playerRoster.OrderByDescending(x => x.Value.Sum(x => x.Value)).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Sum(x => x.Value)} skill");
                foreach (var position in player.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"- {position.Key} <::> {position.Value}");
                }
            }

        }
    }
}
