using RibbonBotDAL.DbAccess;
using RibbonBotDAL.Model;

namespace RibbonBotDAL.Data
{
    public class MovieData : IMovieData
    {

        private readonly ISqlDataAccess _db;

        public MovieData(ISqlDataAccess db)
        {
            _db = db;
        }

        public async Task<Movies> GetMovie(string movie)
        {
            var result = await _db.LoadData<Movies, dynamic>("select * from eponaRibbon.moives where movie = @movie", new { movie });
            return result.FirstOrDefault();
        }

        public async Task<Movies> GetMovie(long id)
        {
            var result = await _db.LoadData<Movies, dynamic>("select * from eponaRibbon.movies where id = @id", new { id });
            return result.FirstOrDefault();
        }

        public Task<IEnumerable<Movies>> GetMovies() => _db.LoadData<Movies, dynamic>("select * from eponaRibbon.movies", new { });

        public Task AddMovie(string movie) => _db.SaveData("insert into eponaRibbon.movies (movie) values (@movie)", new { movie });
        public async Task AddMovie(string movie, bool afterDark)
        {
            if (afterDark)
            {
                const string genre = "After Dark";
                await _db.SaveData("insert into eponaRibbon.movies (movie, genre) values (@movie, @genre)", new { movie, genre });
            }
            else
            {
                await AddMovie(movie);
            }
        }

        public async Task<bool> UpdateMovie(Movies movie)
        {
            try
            {
                await _db.SaveData("update eponaRibbon.movies set movie = @movie, watched = @watched, genre = @genre where id = @id",
                    new { movie.movie, movie.watched, movie.genre, movie.id });
                return true;
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
