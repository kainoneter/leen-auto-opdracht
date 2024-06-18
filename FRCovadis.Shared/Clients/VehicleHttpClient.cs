namespace GraafschapCollege.Shared.Clients;

using FRCovadis.Responses;
using FRCovadis.Shared;
using FRCovadis.Shared.Options;
using Microsoft.Extensions.Options;

using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

public class VehicleHttpClient
{
    private readonly HttpClient client;

    public VehicleHttpClient(IHttpClientFactory httpClientFactory, IOptions<ApiOptions> options)
    {
        client = httpClientFactory.CreateClient(nameof(VehicleHttpClient));
        client.BaseAddress = new Uri($"{options.Value.BaseUrl}/vehicles");
    }

    public async Task<IEnumerable<AutoResponse>> GetVehiclesAsync()
    {
        var response = await client.GetAsync(string.Empty);

        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        var content = await response.Content.ReadAsStringAsync();
        var vehicles = JsonSerializer.Deserialize<IEnumerable<AutoResponse>>(content, JsonOptions.SerializerOptions);

        if (vehicles is null)
        {
            return [];
        }

        return vehicles;
    }
}
