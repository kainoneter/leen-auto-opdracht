using FRCovadis.Responses;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using FRCovadis.Requests;
using FrontendCovadis.Services;

namespace FrontendCovadis.Components.Pages
{
    public partial class Home
    {
        [Inject]
        AuthService AuthService { get; set; }

        /*   [Inject]
           public HttpClient HttpClient { get; set; }


           public List<AutoResponse> Autos { get; set; }




           public async Task<AutoResponse> GetAutos(string token)
           {
               // Set the authorization header with the bearer token
               HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

               // Make the request and deserialize the JSON response
               Autos = await HttpClient.GetFromJsonAsync<List<AutoResponse>>("https://localhost:7165/api/Auto/autos");

               return Autos
           }*/

        private async Task Login()
        {
            LoginRequest loginRequest = new LoginRequest { /* Populate login request if needed */ };

            string token = await AuthService.LogIn(loginRequest);

            if (!string.IsNullOrEmpty(token))
            {
                // Token obtained successfully, proceed with your application logic
                Console.WriteLine("Token obtained: " + token);
            }
            else
            {
                // Handle failed login scenario (e.g., show error message)
                Console.WriteLine("Login failed");
            }
        }

        protected override async Task OnInitializedAsync()
        {
            string token = AuthService.LogIn(new LoginRequest { })



        }
    }
}