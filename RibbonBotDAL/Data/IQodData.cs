using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public interface IQodData
    {
        Task<IEnumerable<Qod>> GetAllQuestions();
        Task<IEnumerable<Qod>> GetAllPostedQuestions();
        Task<IEnumerable<Qod>> GetAllNotPostedQuestions();
    }
}
