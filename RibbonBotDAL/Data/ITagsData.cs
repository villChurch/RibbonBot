using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public interface ITagsData
    {
        Task<IEnumerable<Tags>> GetAllTags();
        Task<IEnumerable<Tags>> GetGuildTags(string guild);
        Task<IEnumerable<Tags>> GetTagsByUserId(string userId);
        Task<Tags> GetTagByName(string tagName);
    }
}
