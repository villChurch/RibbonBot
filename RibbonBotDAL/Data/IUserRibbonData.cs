
using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public interface IUserRibbonData
    {
        Task<IEnumerable<UserRibbon>> GetAllUserRibbons();
        Task<UserRibbon> GetUserRibbon(long id);
    }
}
