namespace RibbonBotMinimalAPI.API
{
    public static class PetsApi
    {
        public static void ConfigurePetsApi(this WebApplication app)
        {
            app.MapGet("/Pets", GetPets);
            app.MapGet("/Pets/{id}", GetPet);
            app.MapGet("/Pets/user/{id}", GetUserPets);
        }

        private static async Task<IResult> GetPets(IPetsData data)
        {
            try
            {
                return Results.Ok(await data.GetAllPets());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetPet(long id, IPetsData data)
        {
            try
            {
                var result = await data.GetPet(id);
                if (result is null) return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetUserPets(string userId, IPetsData data)
        {
            try
            {
                var result = await data.GetUsersPets(userId);
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
