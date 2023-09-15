using RibbonBotDAL.DbAccess;
using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public class RibbonData : IRibbonData
    {
        private readonly ISqlDataAccess _db;

        public RibbonData(ISqlDataAccess db) 
        {
            _db = db; 
        }
        public Task<IEnumerable<Ribbon>> GetAllRibbons() => _db.LoadData<Ribbon, dynamic>("select * from eponaRibbon.ribbon", new { });

        public async Task<Ribbon> GetRibbon(long id)
        {
            var results = await _db.LoadData<Ribbon, dynamic>("select * from eponaRibbon.ribbon where id = @id", new { id });
            return results.FirstOrDefault();
        }

        public async Task<Ribbon> GetRibbon(string name)
        {
            var results  = await _db.LoadData<Ribbon, dynamic>("select * from eponaRibbon.ribbon where name = @rName", new { rName = name });
            return results.FirstOrDefault();
        }
    }
}
