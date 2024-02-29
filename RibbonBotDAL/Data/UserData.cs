using RibbonBotDAL.DbAccess;
using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data;

public class UserData : IUserData
{

    private readonly ISqlDataAccess _db;
    
    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }
    
    public async Task<User?> GetUserById(long id)
    {
        var result = await _db.LoadData<User, dynamic>("select * from eponaRibbon.users where id = @id", new { id });
        return result.FirstOrDefault();
    }

    public async Task<User?> GetUserByName(string name)
    {
        var result = await _db.LoadData<User, dynamic>("select * from eponaRibbon.users where name = @name", new { name });
        return result.FirstOrDefault();
    }

    public Task<IEnumerable<User>> GetAllUsers() => _db.LoadData<User, dynamic>("select * from eponaRibbon.users", new { });
    
    public Task SaveUser(User user) => _db.SaveData("insert into eponaRibbon.users (name, role, discordid) values (@name, @role, @discordId)", 
        new { user.name, user.role, discordId = user.discordid ?? ""});
    
    public async Task<User> CheckForUser(IUserData UserData, string userName)
    {
        User saveuser;
        saveuser = await UserData.GetUserByName(userName) ?? null;
        if (saveuser is null)
        {
            saveuser = new User();
            saveuser.name = userName;
            await UserData.SaveUser(saveuser);
        }

        return saveuser;
    }
}