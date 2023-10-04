using Microsoft.AspNetCore.Components.Authorization;
using RibbonBotDAL.Model;
using System.Security.Claims;

namespace RibbonBotWebSite.Data
{
    public class RibbonBotAuthenticationStateProvider : AuthenticationStateProvider, IDisposable
    {

        private readonly UserService _userService;
        public User? CurrentUser { get; private set; } = new();
        public RibbonBotAuthenticationStateProvider(UserService userService)
        {
            _userService = userService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var principal = new ClaimsPrincipal();
            var user = await _userService.FetchUserFromBrowserAysnc();
            if (user is not null)
            {
                var userInDatabase = _userService.LookupUserInDatabase(user.username, user.password);
                if (userInDatabase is not null)
                {
                    principal = userInDatabase.ToClaimsPrincipal();
                    CurrentUser = userInDatabase;
                }
            }
            return new(principal);
        }

        public async Task LoginAsync(string username, string password)
        {
            var principal = new ClaimsPrincipal();
            var user = _userService.LookupUserInDatabase(username, password);

            if(user is not null)
            {
                await _userService.PersistUserToBrowserAsync(user);
                principal = user.ToClaimsPrincipal();
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        }

        public async Task LogoutAsync() 
        {
            await _userService.ClearBrwoserUserDataAsync();
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }

        private async void OnAuthenticationStateChangedAsync(Task<AuthenticationState> task)
        {
            var authState = await task;
            var user = authState.User;
            if (user.Identity is not null && user.Identity.IsAuthenticated)
            {
                CurrentUser = User.FromClaimsPrincipal(user);
            }
            else
            {
                CurrentUser = null;
            }
           // NotifyAuthenticationStateChanged(Task.FromResult(authState));
        }

        public void Dispose() => AuthenticationStateChanged -= OnAuthenticationStateChangedAsync;

    }
}
