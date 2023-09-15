namespace RibbonBotMinimalAPI.API
{
    public static class MovieApi
    {
        public static void ConfigureMovieApi(this WebApplication app)
        {
            app.MapGet("/Movies", GetMovies);
            app.MapGet("/Movies/{id}", GetMovie);
        }

        private static async Task<IResult> GetMovies(IMovieData data)
        {
            try
            {
                return Results.Ok(await data.GetMovies());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetMovie(long id, IMovieData data)
        {
            try
            {
                var result = await data.GetMovie(id);
                if (result is null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
