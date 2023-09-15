using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public interface IPetsData
    {
        Task<IEnumerable<Pets>> GetAllPets();

        Task<Pets> GetPet(long id);
        Task<IEnumerable<DisplayPet>> GetUsersPets(string user);
        Task<IEnumerable<DisplayPet>> GetUsersPetsById(long petId);
    }
}
