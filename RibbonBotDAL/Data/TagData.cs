using RibbonBotDAL.DbAccess;
using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public class TagData : ITagsData
    {
        private ISqlDataAccess _db;

        public TagData(ISqlDataAccess db)
        {
           _db = db;
        }
        public Task<IEnumerable<Tags>> GetAllTags() => _db.LoadData<Tags, dynamic>("select * from eponaRibbon.tags", new { });

        public Task<IEnumerable<Tags>> GetGuildTags(string guild) => _db.LoadData<Tags, dynamic>("select * from eponaRibbon.tags where guildId = @guildId", new { guildId = guild });

        public async Task<Tags> GetTagByName(string tagName)
        {
            var result = await _db.LoadData<Tags, dynamic>("select * from eponaRibbon.tags where tag = @tag", new { tag = tagName });
            return result.FirstOrDefault();
        }

        public Task<IEnumerable<Tags>> GetTagsByUserId(string userId) => _db.LoadData<Tags, dynamic>("select * from eponaRibbon.tags where userid = @userId", new { userId });
    }
}
