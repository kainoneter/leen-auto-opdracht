using FRCovadis.Responses;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class AutoService
{
    private readonly HttpClient _httpClient;

    public AutoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<AutoResponse>> GetAutos(string token)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var autos = await _httpClient.GetFromJsonAsync<List<AutoResponse>>("https://localhost:7165/api/Auto/autos");

        return autos;
    }
}