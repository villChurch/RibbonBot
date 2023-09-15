using RibbonBotDAL.DbAccess;
using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public class QodData : IQodData
    {
        private readonly ISqlDataAccess _db;

        public QodData(ISqlDataAccess db)
        {
            _db = db;
        }
        public Task<IEnumerable<Qod>> GetAllNotPostedQuestions() => _db.LoadData<Qod, dynamic>("select * from eponaRibbon.qod where posted = ?posted", new { posted = false });

        public Task<IEnumerable<Qod>> GetAllPostedQuestions() => _db.LoadData<Qod, dynamic>("select * from eponaRibbon.qod where posted = ?posted", new { posted = true });

        public Task<IEnumerable<Qod>> GetAllQuestions() => _db.LoadData<Qod, dynamic>("select * from eponaRibbon.qod", new { });
    }
}
