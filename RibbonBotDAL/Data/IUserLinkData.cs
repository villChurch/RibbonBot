using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data;

public interface IUserLinkData
{
    Task<UserLink?> GetUserLinkByCode(string code);

    Task DeleteUserLink(UserLink userLink);
    
}