using SuperHeroes_Project.Data;

namespace SuperHeroes_Project.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        // Side note: You'll notice that we're not "using" SuperHero model in this file up top. 
        // If you look into the program.cs file, you'll see it's being used globally
        private readonly DataContext _context;
        public SuperHeroService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            await _context.SuperHeroes.AddAsync(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllHeroes()
        {
            var superheroes = await _context.SuperHeroes.ToListAsync();
            return superheroes;
        }

        public async Task<SuperHero?> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FirstOrDefaultAsync(item => item.Id == id);

            if (hero == null)
                return null;
            return hero;
        }

        public async Task<List<SuperHero>?> RemoveHero(int id)
        {
            var hero = await _context.SuperHeroes.FirstOrDefaultAsync(item => item.Id == id);

            if (hero == null)
                return null;

            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync(); ;
        }

        public async Task<List<SuperHero>?> UpdateHero(int id, SuperHero updatedHero)
        {
            var hero = await _context.SuperHeroes.FirstOrDefaultAsync(item => item.Id == id);

            if (hero == null)
                return null;

            hero.FirstName = String.IsNullOrEmpty(updatedHero.FirstName) || updatedHero.FirstName == "string" ? hero.FirstName : updatedHero.FirstName;
            hero.LastName = String.IsNullOrEmpty(updatedHero.LastName) || updatedHero.LastName == "string" ? hero.LastName : updatedHero.LastName; ;
            hero.Place = String.IsNullOrEmpty(updatedHero.Place) || updatedHero.Place == "string" ? hero.Place : updatedHero.Place; ;
            hero.Name = String.IsNullOrEmpty(updatedHero.Name) || updatedHero.Name == "string" ? hero.Name : updatedHero.Name; ;
            await _context.SaveChangesAsync();

            //_context.Update(hero);
            //await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }
    }
}
