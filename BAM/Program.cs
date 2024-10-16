﻿class Solution
{
    public static async Task Main(string[] args)
    {
        var hackerrankService = new HackerrankService();
        var leagues = await hackerrankService.GetLeaguessAsync();
        for(int i = 0; i< leagues.Length; i++)
        {
            Console.WriteLine($"{i} {leagues[i]}");
        }

        while (true)
        {
            Console.WriteLine("______________");
            Console.WriteLine("Select league by its number...");

            var leaguePosition = Console.ReadLine();
            if (!int.TryParse(leaguePosition, out var index))
            {
                Console.WriteLine("Wrong selection");
                continue;
            }

            var league = leagues[index];

            var teams = await hackerrankService.GetTeamsAsync(league);
            var revenue = await RevenueCalculator.LeagueEarnings(teams);
            Console.WriteLine($"{league}: TotalEarnings = {revenue.TotalEarningsRounded}, AverageRevenuePerMatch={revenue.AverageRevenuePerMatch}");
        }
    }
}
