using Dapper.Contrib.Extensions;
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

        public Task<IEnumerable<Ribbon>> GetUsersRibbons(string user) => _db.LoadData<Ribbon, dynamic>("select ribbon.id, ribbon.name, ribbon.description, ribbon.path from eponaribbon.ribbon " +
            "join eponaribbon.userribbon on eponaribbon.ribbon.id = eponaribbon.userribbon.ribbonid " +
            "where userribbon.userid = @userId", new { userId = user });

        public async Task<long> InsertRibbon(Ribbon ribbon)
        {
            using var connection = _db.GetConnection();
            return await connection.InsertAsync<Ribbon>(ribbon);
        }

        public async Task<bool> UpdateRibbon(Ribbon ribbon)
        {
            using var connection = _db.GetConnection();
            return await connection.UpdateAsync<Ribbon>(ribbon);
        }
    }
}
