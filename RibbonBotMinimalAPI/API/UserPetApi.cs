namespace RibbonBotMinimalAPI.API
{
    public static class UserPetApi
    {
        public static void ConfigureUserPetApi(this WebApplication app)
        {
            app.MapGet("/UserPets", GetUserPets);
            app.MapGet("/UserPets/{id}", GetUserPet);
        }

        private static async Task<IResult> GetUserPets(IUserPetData data)
        {
            try
            {
                return Results.Ok(await data.GetAllUserPets());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        private static async Task<IResult> GetUserPet(long id, IUserPetData data)
        {
            try
            {
                var result = await data.GetUserPet(id);
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
