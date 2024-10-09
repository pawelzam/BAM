using Newtonsoft.Json;

public class HackerrankService
{
    HttpClient _httpClient;

    public HackerrankService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<FootballTeamDto[]> GetTeamsAsync(string league)
    {
        var teams = new List<FootballTeamDto>();
        int currentPage = 1;
        int totalPages = 1;

        while (currentPage <= totalPages)
        {
            var url = $"https://jsonmock.hackerrank.com/api/football_teams?league={league}&page={currentPage}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponseDto>(jsonResponse);

                totalPages = apiResponse!.TotalPages;
                teams.AddRange(apiResponse.Data);
            }
            else
            {
                throw new Exception("Error fetching data from the API");
            }

            currentPage++;
        }

        return [.. teams];
    }

    public async Task<string[]> GetLeaguessAsync()
    {
        var leagues = new List<string>();
        int currentPage = 1;
        int totalPages = 1;

        while (currentPage <= totalPages)
        {
            var url = $"https://jsonmock.hackerrank.com/api/football_teams?page={currentPage}";
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponseDto>(jsonResponse);

                totalPages = apiResponse!.TotalPages;
                leagues.AddRange(apiResponse.Data.Select(p=>p.League));
            }
            else
            {
                throw new Exception("Error fetching data from the API");
            }

            currentPage++;
        }

        return [.. leagues.Distinct()];
    }
}
