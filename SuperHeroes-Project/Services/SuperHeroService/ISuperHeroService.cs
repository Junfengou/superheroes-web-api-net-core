namespace SuperHeroes_Project.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        // Remember to register this file in the Program.cs file
        // builder.Services.AddScoped<ISuperHeroService, SuperHeroService>();
        Task<List<SuperHero>> GetAllHeroes();
        Task<SuperHero?> GetHero(int id);
        Task<List<SuperHero>> AddHero(SuperHero hero);
        Task<List<SuperHero>?> UpdateHero(int id, SuperHero updatedHero);
        Task<List<SuperHero>?> RemoveHero(int id);

    }
}
