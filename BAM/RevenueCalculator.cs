public class RevenueCalculator
{
    public static async Task<Revenue> LeagueEarnings(FootballTeamDto[] teams)
    {
        var totalEarnings = 0m;
        var numberOfTeams = teams.Length;
        var totalNumberOfMatches = numberOfTeams * (numberOfTeams - 1);
        var numberMatchesPerTeamInOwnStadium = numberOfTeams - 1;

        foreach (var team in teams)
        {
            var ticketPrice = GetTicketPrice(team.TotalSilverwareCount);
            totalEarnings += ticketPrice * team.StadiumCapacity * numberMatchesPerTeamInOwnStadium;
        }

        var averageRevenuePerMatch = (int)Math.Floor(totalEarnings / totalNumberOfMatches);
        var totalEarningsRounded = (int)Math.Floor(totalEarnings);

        return new Revenue(totalEarningsRounded, averageRevenuePerMatch);
    }

    public static decimal GetTicketPrice(int totalSilverwareCount) => totalSilverwareCount switch
    {
        > 40 => 1.5m,
        > 25 => 1.25m,
        > 10 => 1m,
        _ => 0.5m
    };
}
