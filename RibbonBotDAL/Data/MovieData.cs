using RibbonBotDAL.DbAccess;
using RibbonBotDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var result = await _db.LoadData<Movies, dynamic>("select * from eponaRibbon.moives where movie = ?m", new { m = movie });
            return result.FirstOrDefault() ?? new Movies();
        }

        public async Task<Movies> GetMovie(long id)
        {
            var result = await _db.LoadData<Movies, dynamic>("select * from eponaRibbon.movies where id = ?i", new { i = id});
            return result.FirstOrDefault() ?? new Movies();
        }

        public Task<IEnumerable<Movies>> GetMovies() => _db.LoadData<Movies, dynamic>("select * from eponaRibbon.movies", new { });
    }
}
