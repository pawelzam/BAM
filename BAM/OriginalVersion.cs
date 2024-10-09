//using Newtonsoft.Json;

//namespace BAM;
//internal class OriginalVersion
//{
//    public class Result
//    {
//        public static async Task<(int, int)> leagueEarnings(string league)
//        {
//            var teams = new List<FootballTeamDto>();
//            var client = new HttpClient();
//            int currentPage = 1;
//            int totalPages = 1;
//            decimal totalEarnings = 0;

//            while (currentPage <= totalPages)
//            {
//                var url = $"https://jsonmock.hackerrank.com/api/football_teams?league={league}&page={currentPage}";
//                var response = await client.GetAsync(url);
//                if (response.IsSuccessStatusCode)
//                {
//                    var jsonResponse = await response.Content.ReadAsStringAsync();
//                    var apiResponse = JsonConvert.DeserializeObject<ApiResponseDto>(jsonResponse);

//                    totalPages = apiResponse!.TotalPages;
//                    teams.AddRange(apiResponse.Data);
//                }
//                else
//                {
//                    throw new Exception("Error fetching data from the API");
//                }

//                currentPage++;
//            }

//            var numberOfTeams = teams.Count;
//            for (var i = 0; i < numberOfTeams; i++)
//            {
//                var team = teams[i];
//                for (var j = 0; j < numberOfTeams; j++)
//                {
//                    if (i != j)
//                    {
//                        var ticketPriceHome = GetTicketPrice(teams[i].TotalSilverwareCount);
//                        var homeRevenue = Math.Floor(ticketPriceHome * teams[i].StadiumCapacity); // Here I made a mistake Math.Floor should not be here
//                        totalEarnings += homeRevenue;

//                        Console.WriteLine($"{team.Name} {team.TotalSilverwareCount} {ticketPriceHome}");
//                    }
//                }
//            }

//            var totalNumberOfMatches = numberOfTeams * (numberOfTeams - 1);
//            //var numberMatchesPerTeamInOwnStadium = totalNumberOfMatches / numberOfTeams;

//            //foreach (var team in teams)
//            //{
//            //    var ticketPrice = GetTicketPrice(team.TotalSilverwareCount);
//            //    var teamEarnings = ticketPrice * team.StadiumCapacity * numberMatchesPerTeamInOwnStadium;
//            //    totalEarnings += teamEarnings;

//            //    Console.WriteLine($"{team.Name} {teamEarnings}");
//            //}

//            var averageRevenuePerMatch = (int)Math.Floor(totalEarnings / totalNumberOfMatches);
//            var totalEarningsRounded = (int)Math.Floor(totalEarnings);

//            return (totalEarningsRounded, averageRevenuePerMatch);
//        }

//        public static decimal GetTicketPrice(int totalSilverwareCount)
//        {
//            if (totalSilverwareCount > 40)
//                return 1.5m;
//            else if (totalSilverwareCount > 25)
//                return 1.25m;
//            else if (totalSilverwareCount > 10)
//                return 1m;
//            else
//                return 0.5m;
//        }
//    }
//}
