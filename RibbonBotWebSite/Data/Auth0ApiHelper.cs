using Auth0.ManagementApi;
using Auth0.ManagementApi.Models;

namespace RibbonBotWebSite.Data;

public class Auth0ApiHelper
{
    public async Task GetUsers()
    {
            var _client = new 
        ManagementApiClient("",
            new Uri("https://dev-uiptoc23azm55tqd.us.auth0.com/api/v2/"));
            var usr = await _client.Users.GetAllAsync(new GetUsersRequest());
    }
}
