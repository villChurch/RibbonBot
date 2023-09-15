namespace RibbonBotMinimalAPI.API
{
    public static class UserRibbonApi
    {
        public static void ConfigureUserRibbonApi(this WebApplication app)
        {

        }

        private static async Task<IResult> GetUserRibbons(IUserRibbonData data)
        {
            try
            {
                return Results.Ok(await data.GetAllUserRibbons());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetUserRibbon(long id, IUserRibbonData data)
        {
            try
            {
                var result = await data.GetUserRibbon(id);
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
