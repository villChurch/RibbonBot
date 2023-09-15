namespace RibbonBotMinimalAPI.API
{
    public static class RibbonApi
    {
        public static void ConfigureRibbonApi(this WebApplication app)
        {
            app.MapGet("/Ribbons", GetRibbons);
            app.MapGet("/Ribbons/id/{id}", GetRibbonById);
            app.MapGet("/Ribbons/name/{name}", GetRibbonByName);
        }

        private static async Task<IResult> GetRibbons(IRibbonData data)
        {
            try
            {
                return Results.Ok(await data.GetAllRibbons());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetRibbonById(long id, IRibbonData data)
        {
            try
            {
                var result = await data.GetRibbon(id);
                if (result is null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetRibbonByName(string name, IRibbonData data)
        {
            try
            {
                var result = await data.GetRibbon(name);
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
