namespace GraafschapCollege.BlazorApp.Pages.Reservation;

using GraafschapCollege.Shared.Clients;
using FRCovadis.Shared;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using FRCovadis.Requests;
using FRCovadis.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

[Authorize]
[Microsoft.AspNetCore.Components.Route("/reservation/create")]
public partial class CreateReservation
{
    private bool isLoading = true;
    private readonly CreateReservationRequest Request = new();

    private IEnumerable<AutoResponse> Vehicles { get; set; }
    private IEnumerable<string> Errors { get; set; } = [];

    [Inject]
    private ReservationHttpClient ReservationHttpClient { get; set; }

    [Inject]
    private VehicleHttpClient VehicleHttpClient { get; set; }

    [Inject]
    private NavigationManager NavigationManager { get; set; }

    protected async Task OnInitializedAsync()
    {
        Vehicles = await VehicleHttpClient.GetVehiclesAsync();

        Request.VehicleId = 0;
        Request.From = DateTime.Now;
        Request.Until = Request.From.AddDays(1);

        isLoading = false;
    }

    private async Task CreateReservationAsync()
    {
        var response = await ReservationHttpClient.CreateReservationAsync(Request);

        if(response == null)
        {
            new BadRequestObjectResult("no response");
        }
        else
        {       
            NavigationManager.NavigateTo("/");
        }
        
        
    }
}