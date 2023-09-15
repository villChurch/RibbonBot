namespace RibbonBotMinimalAPI.API
{
    public static class TagsApi
    {
        public static void ConfigureTagsApi(this WebApplication app)
        {
            app.MapGet("/tags", GetAllTags);
            app.MapGet("/tags/guild/{guildId}", GetTagsByGuildId);
            app.MapGet("/tags/user/{userId}", GetTagsByUserId);
            app.MapGet("/tags/tag/{name}", GetTagByName);
        }

        private static async Task<IResult> GetAllTags(ITagsData data)
        {
            try
            {
                return Results.Ok(await data.GetAllTags());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetTagsByGuildId(string guild, ITagsData data)
        {
            try
            {
                var results = await data.GetGuildTags(guild);
                if (results is null || results.Count() == 0) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetTagsByUserId(string user, ITagsData data)
        {
            try
            {
                var results = await data.GetTagsByUserId(user);
                if (results is null || results.Count() == 0) return Results.NotFound();
                return Results.Ok(results);
            }
            catch
            (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetTagByName(string tag, ITagsData data)
        {
            try
            {
                var result = await data.GetTagByName(tag);
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
