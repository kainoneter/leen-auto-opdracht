using FRCovadis.Requests;
using FRCovadis.Responses;
using Microsoft.AspNetCore.Components;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FrontendCovadis.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> LogIn(LoginRequest loginRequest)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync("https://localhost:7165/api/auth", loginRequest);

                if (response.IsSuccessStatusCode)
                {
                    AuthResponse authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();
                    return authResponse.Token;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during login: " + ex.Message);
                return null;
            }
        }
    }
}