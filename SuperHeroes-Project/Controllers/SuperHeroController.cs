using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroes_Project.Services.SuperHeroService;

namespace SuperHeroes_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly ISuperHeroService _superHeroService;
        public SuperHeroController(ISuperHeroService superHeroService)
        {
            _superHeroService = superHeroService;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            return await _superHeroService.GetAllHeroes();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var result = await _superHeroService.GetHero(id);
            if (result == null)
                return NotFound("Hero not found");
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            return await _superHeroService.AddHero(hero);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int id, SuperHero updatedHero)
        {
            var result = await _superHeroService.UpdateHero(id, updatedHero);
            if (result == null)
                return NotFound("Hero not found");
            return result;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<SuperHero>>> RemoveHero(int id)
        {
            var result = await _superHeroService.RemoveHero(id);
            if (result == null)
                return NotFound("Hero not found");
            return result;
        }
    }
}
