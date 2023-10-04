using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using RibbonBotDAL.Model;

namespace RibbonBotWebSite.Data
{
    //TODO: Move to RibbonBotDAL and implement interface
    public class UserService
    {
        private readonly ProtectedLocalStorage _localStorage;
        private readonly string _userKey = "user";
        public UserService(ProtectedLocalStorage localStorage)
        {
              _localStorage = localStorage;
        }

        public User? LookupUserInDatabase(string username, string password)
        {
            //TODO: Implement database lookup
            var usersFromDatabase = new List<User>
            {
                new User()
                {
                    username = "test",
                    password = "test"
                }
            };

            return usersFromDatabase.FirstOrDefault(u => u.username == username && u.password == password);
        }

        public async Task PersistUserToBrowserAsync(User user)
        {
            string userJson = JsonConvert.SerializeObject(user);
            await _localStorage.SetAsync(_userKey, userJson);
        }

        public async Task<User?> FetchUserFromBrowserAysnc()
        {
            try
            {
                var storedUserResult = await _localStorage.GetAsync<string>(_userKey);
                if (storedUserResult.Success && !string.IsNullOrEmpty(storedUserResult.Value))
                {
                    return JsonConvert.DeserializeObject<User>(storedUserResult.Value);
                }
            } catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public async Task ClearBrwoserUserDataAsync() => await _localStorage.DeleteAsync(_userKey);
    }
}
