using FrontendCovadis.Components;
using FRCovadis.Shared.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ReservationHttpClient>();
builder.Services.AddHttpClient(nameof(ReservationHttpClient));
builder.Services.AddScoped < VehicleHttpClient>();
builder.Services.AddHttpClient(nameof(VehicleHttpClient));
builder.Services.AddScoped < UserHttpClient>();
builder.Services.AddHttpClient(nameof(UserHttpClient));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
