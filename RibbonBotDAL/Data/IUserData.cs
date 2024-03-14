using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data;

public interface IUserData
{
    Task<User?> GetUserById(long id);   
    Task<User?> GetUserByName(string name);
    Task<IEnumerable<User>> GetAllUsers();
    
    Task SaveUser(User user);
    
    Task<User> CheckForUser(IUserData UserData, string userName);

    Task<bool> UpdateUser(User user);
}