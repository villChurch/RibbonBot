using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public interface IMovieData
    {
        Task<IEnumerable<Movies>> GetMovies();
        Task<Movies> GetMovie(string movie);
        Task<Movies> GetMovie(long id);

        Task AddMovie(string movie);
    }
}
