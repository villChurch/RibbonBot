using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public interface IPetsData
    {
        Task<IEnumerable<Pets>> GetAllPets();

        Task<Pets> GetPet(long id);
        Task<IEnumerable<DisplayPet>> GetUsersPets(string user);
        Task<DisplayPet> GetUsersPetsById(long petId);

        Task<long> InsertPet(Pets pet);

        Task<bool> UpdatePet(Pets pet);
    }
}
