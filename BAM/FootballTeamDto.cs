using Newtonsoft.Json;

public class FootballTeamDto
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("league")]
    public string League { get; set; }

    [JsonProperty("stadium_capacity")]
    public int StadiumCapacity { get; set; }

    [JsonProperty("number_of_champions_league_won")]
    public int NumberOfChampionsLeagueWon { get; set; }

    [JsonProperty("total_silverware_count")]
    public int TotalSilverwareCount { get; set; }
}
