using RibbonBotDAL.DbAccess;
using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public class PetsData : IPetsData
    {
        private readonly ISqlDataAccess _db;

        public PetsData(ISqlDataAccess db) 
        {
            _db = db; 
        }

        public Task<IEnumerable<Pets>> GetAllPets() => _db.LoadData<Pets, dynamic>("select * from eponaRibbon.pets", new { });

        public async Task<Pets> GetPet(long id)
        {
            var results = await _db.LoadData<Pets, dynamic>("select * from eponaRibbon.pets where id = ?i", new { i = id});
            
            return results.FirstOrDefault() ?? new Pets();
        }

        public Task<IEnumerable<DisplayPet>> GetUsersPets(string user) => _db.LoadData<DisplayPet, dynamic>("select up.id, up.name, CASE " +
            "when up.adult = true THEN pets.adultlink " +
            "else pets.childlink end path from eponaRibbon.userpets up " +
            "join eponaRibbon.pets pets on pets.id = up.petid where up.owner = @owner", new { owner = user });

        public Task<IEnumerable<DisplayPet>> GetUsersPetsById(long petId) => _db.LoadData<DisplayPet, dynamic>("select up.id, up.name, CASE " +
            "when up.adult = true THEN pets.adultlink " +
            "else pets.childlink end path from eponaRibbon.userpets up " +
            "join eponaRibbon.pets pets on pets.id = up.petid where up.id = @id", new { id = petId });
    }
}
