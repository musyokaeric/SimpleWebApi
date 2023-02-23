using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHero.Api.Models;
using SuperHero.Api.Services.SuperheroService;

namespace SuperHero.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        //private static List<Superhero> superHeroes = new List<Superhero>
        //    {
        //        new Superhero{ Id = 1, Name = "Spider Man", FirstName = "Peter", LastName = "Parker", Place = "New York City" },
        //        new Superhero{ Id = 2, Name = "Iron Man", FirstName = "Tony", LastName = "Stark", Place = "Malibu" },
        //    };

        private readonly ISuperheroService superheroService;

        public SuperHeroController(ISuperheroService superheroService)
        {
            this.superheroService = superheroService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Superhero>>> GetAllHeroes() => await superheroService.GetAllHerosAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Superhero>> GetHero(int id)
        {
            var result = await superheroService.GetHeroByIdAsync(id);
            if (result == null)
                return NotFound("Sorry, but this hero does not exist.");
            
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Superhero>>> AddHero(Superhero superhero) => Ok(await superheroService.AddHeroAsync(superhero));

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Superhero>>> UpdateHero(int id, Superhero request)
        {
            var result = await superheroService.GetHeroByIdAsync(id);
            if (result == null)
                return NotFound("Sorry, but this hero does not exist.");

            return await superheroService.UpdateHeroAsync(id, request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Superhero>>> DeleteHero(int id)
        {
            var result = await superheroService.GetHeroByIdAsync(id);
            if (result == null)
                return NotFound("Sorry, but this hero does not exist.");

            superheroService.DeleteHeroAsync(result);
            return Ok(result);
        }
    }
}
