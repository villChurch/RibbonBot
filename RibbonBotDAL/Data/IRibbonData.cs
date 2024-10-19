using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public interface IRibbonData
    {
        Task<IEnumerable<Ribbon>> GetAllRibbons();

        Task<Ribbon> GetRibbon(long id);

        Task<Ribbon> GetRibbon(string name);

        Task<IEnumerable<Ribbon>> GetUsersRibbons(string user);

        Task<long> InsertRibbon(Ribbon ribbon);

        Task<bool> UpdateRibbon(Ribbon ribbon);
    }
}
