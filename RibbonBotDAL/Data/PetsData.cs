using RibbonBotDAL.DbAccess;
using RibbonBotDAL.Model;
using Dapper.Contrib.Extensions;

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
            var results = await _db.LoadData<Pets, dynamic>("select * from eponaRibbon.pets where id = @id", new { id });
            
            return results.FirstOrDefault();
        }

        public Task<IEnumerable<DisplayPet>> GetUsersPets(string user) => _db.LoadData<DisplayPet, dynamic>("select up.id, up.name, CASE " +
            "when up.adult = true THEN pets.adultlink " +
            "else pets.childlink end path from eponaRibbon.userpets up " +
            "join eponaRibbon.pets pets on pets.id = up.petid where up.owner = @owner", new { owner = user });

        public async Task<DisplayPet> GetUsersPetsById(long petId)
        {
            var results = await _db.LoadData<DisplayPet, dynamic>("select up.id, up.name, CASE " +
            "when up.adult = true THEN pets.adultlink " +
            "else pets.childlink end path from eponaRibbon.userpets up " +
            "join eponaRibbon.pets pets on pets.id = up.petid where up.id = @id", new { id = petId });

            return results.First() ?? new DisplayPet();
        }

        public async Task<long> InsertPet(Pets pet)
        {
            using var connection = _db.GetConnection();
            return await connection.InsertAsync<Pets>(pet);
        }

        public async Task<bool> UpdatePet(Pets pet)
        {
            using var connection = _db.GetConnection();
            return await connection.UpdateAsync<Pets>(pet);
            //return await connection.UpdateAsync(new Pets() { adultlink = pet.adultlink, childlink = pet.childlink, id = pet.id });
        }
    }
}
