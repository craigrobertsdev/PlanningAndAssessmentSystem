namespace PlanningAndAssessmentLib.Data.Curriculum;
using System.Net.Http.Headers;

public class CurriculumService
{
    private readonly HttpClient _client;

    public CurriculumService(HttpClient httpClient)
    {
        _client = httpClient;
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")
        );
    }

    // Read values from local spreadsheet and add approrpriate information to the database if not already populated.
    public async Task GetCurriculumData(string path) { }
}
