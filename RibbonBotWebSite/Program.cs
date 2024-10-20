using MudBlazor.Services;
using RibbonBotDAL.Data;
using RibbonBotDAL.DbAccess;

var builder = WebApplication.CreateBuilder(args);

#if !DEBUG 
builder.Configuration.AddJsonFile("appSettings.json");
#endif

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddSingleton<IMovieData, MovieData>();
builder.Services.AddSingleton<IRibbonData, RibbonData>();
builder.Services.AddSingleton<IUserRibbonData, UserRibbonData>();
builder.Services.AddSingleton<IPetsData, PetsData>();
builder.Services.AddSingleton<IUserData, UserData>();
builder.Services.AddSingleton<IUserLinkData, UserLinkData>();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
