using RibbonBotDAL.DbAccess;
using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public class UserRibbonData : IUserRibbonData
    {
        private readonly ISqlDataAccess _db;

        public UserRibbonData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<IEnumerable<UserRibbon>> GetAllUserRibbons() => _db.LoadData<UserRibbon, dynamic>("select * from eponaRibbon.userribbon", new { });

        public async Task<UserRibbon> GetUserRibbon(long id)
        {
            var results = await _db.LoadData<UserRibbon, dynamic>("select * from eponaRibbon.userribbon where id = ?i", new { i = id });
            return results.FirstOrDefault() ?? new UserRibbon();
        }
    }
}
