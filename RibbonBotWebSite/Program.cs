using MudBlazor.Services;
using RibbonBotWebSite.Data;
using RibbonBotDAL.Data;
using RibbonBotDAL.DbAccess;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IMovieData, MovieData>();
builder.Services.AddSingleton<IRibbonData, RibbonData>();
builder.Services.AddSingleton<IUserRibbonData, UserRibbonData>();
builder.Services.AddSingleton<IPetsData, PetsData>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<RibbonBotAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(
    sp => sp.GetRequiredService<RibbonBotAuthenticationStateProvider>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
