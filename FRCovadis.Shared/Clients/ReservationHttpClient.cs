﻿namespace FRCovadis.Shared.Clients;

using FRCovadis.Requests;
using FRCovadis.Responses;
using FRCovadis.Shared;
using FRCovadis.Shared.Options;


using Microsoft.Extensions.Options;

using System.Collections.Generic;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class ReservationHttpClient 
{
    private readonly HttpClient client;

    public ReservationHttpClient(IHttpClientFactory httpClientFactory, IOptions<ApiOptions> options)
    {
        client = httpClientFactory.CreateClient(nameof(ReservationHttpClient));
        client.BaseAddress = new Uri($"{options.Value.BaseUrl}/reservations");
    }

    public async Task<ReservationResponse> CreateReservationAsync(CreateReservationRequest request)
    {
        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, MediaTypeNames.Application.Json);
        var response = await client.PostAsync(string.Empty, content);
        
        var responseContent = await response.Content.ReadAsStringAsync();
        var reservation = JsonSerializer.Deserialize<ReservationResponse>(responseContent, JsonOptions.SerializerOptions);

        return reservation!;
    }

    public async Task<IEnumerable<ReservationResponse>> GetReservationsAsync()
    {
        var response = await client.GetAsync(string.Empty);

        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        var content = await response.Content.ReadAsStringAsync();
        var reservations = JsonSerializer.Deserialize<IEnumerable<ReservationResponse>>(content, JsonOptions.SerializerOptions);

        if (reservations is null)
        {
            return [];
        }

        return reservations;
    }
}
