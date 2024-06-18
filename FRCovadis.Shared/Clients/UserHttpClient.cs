namespace FRCovadis.Shared.Clients;

using FRCovadis.Responses;
using FRCovadis.Shared;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;

public class UserHttpClient
{
    private readonly HttpClient client;

    public UserHttpClient(IHttpClientFactory httpClientFactory)
    {
        client = httpClientFactory.CreateClient(nameof(UserHttpClient));
        client.BaseAddress = new Uri($"https://localhost:7165/api/User");
    }

    public async Task<UserResponse?> GetUserAsync(int id)
    {
        var response = await client.GetAsync(id.ToString());

        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var content = await response.Content.ReadAsStringAsync();
        var user = JsonSerializer.Deserialize<UserResponse>(content, JsonOptions.SerializerOptions);

        return user;
    }

    public async Task<IEnumerable<UserResponse>> GetUsersAsync()
    {
        var response = await client.GetAsync(string.Empty);

        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        var content = await response.Content.ReadAsStringAsync();
        var users = JsonSerializer.Deserialize<IEnumerable<UserResponse>>(content, JsonOptions.SerializerOptions);

        if (users is null)
        {
            return [];
        }

        return users;
    }
}
