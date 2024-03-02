using RibbonBotDAL.DbAccess;
using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data;

public class UserLinkData : IUserLinkData
{
    private readonly ISqlDataAccess _db;

    public UserLinkData(ISqlDataAccess db)
    {
        _db = db;
    }
    
    public async Task<UserLink?> GetUserLinkByCode(string code)
    {
        var result =
            await _db.LoadData<UserLink, dynamic>("select * from eponaRibbon.userLink where code = @code",
                new { code });
        return result.FirstOrDefault();
    }

    public Task DeleteUserLink(UserLink userLink) => _db.DeleteData("delete from eponaRibbon.userlink where id = @id", new { userLink.id });
}