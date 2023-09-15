namespace RibbonBotMinimalAPI.API
{
    public static class QodApi
    {
        public static void ConfigureQodApi(this WebApplication app)
        {
            app.MapGet("/qod", GetAllQuestions);
            app.MapGet("/qod/posted", GetAllPostedQuestions);
            app.MapGet("/qod/not-posted", GetAllNonPostedQuestions);
        }

        private static async Task<IResult> GetAllQuestions(IQodData data)
        {
            try
            {
                return Results.Ok(await data.GetAllQuestions());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetAllPostedQuestions(IQodData data)
        {
            try
            {
                return Results.Ok(await data.GetAllPostedQuestions());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetAllNonPostedQuestions(IQodData data)
        {
            try
            {
                return Results.Ok(await data.GetAllNotPostedQuestions());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
