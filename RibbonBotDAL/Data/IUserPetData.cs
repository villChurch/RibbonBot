
using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public interface IUserPetData
    {
        Task<IEnumerable<UserPet>> GetAllUserPets();
        Task<UserPet> GetUserPet(long id);
    }
}
