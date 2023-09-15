using RibbonBotDAL.DbAccess;
using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public class UserPetData : IUserPetData
    {
        private readonly ISqlDataAccess _db;
        public UserPetData(ISqlDataAccess db)
        { 
            _db = db; 
        }

        public Task<IEnumerable<UserPet>> GetAllUserPets() => _db.LoadData<UserPet, dynamic>("select * from eponaRibbon.userpets", new { });

        public async Task<UserPet> GetUserPet(long id)
        {
            var results = await _db.LoadData<UserPet, dynamic>("select * from eponaRibbon.userpets where id = @id", new { id });
            return results.FirstOrDefault();
        }
    }
}
