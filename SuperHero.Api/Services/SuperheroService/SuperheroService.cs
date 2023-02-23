using Microsoft.EntityFrameworkCore;
using SuperHero.Api.Data;
using System.Collections;

namespace SuperHero.Api.Services.SuperheroService
{
    public class SuperheroService : ISuperheroService
    {
        //private static List<Superhero> superHeroes = new List<Superhero>
        //    {
        //        new Superhero{ Id = 1, Name = "Spider Man", FirstName = "Peter", LastName = "Parker", Place = "New York City" },
        //        new Superhero{ Id = 2, Name = "Iron Man", FirstName = "Tony", LastName = "Stark", Place = "Malibu" },
        //    };
        private readonly DataContext context;

        public SuperheroService(DataContext context)
        {
            this.context = context;
        }

        public async Task<Superhero> AddHeroAsync(Superhero entity)
        {
            await context.Superheroes.AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async void DeleteHeroAsync(Superhero entity)
        {
            context.Superheroes.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<Superhero>> GetAllHerosAsync()
        {
            return await context.Superheroes.ToListAsync();
        }

        public async Task<Superhero?> GetHeroByIdAsync(int id)
        {
            return await context.Superheroes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Superhero>?> UpdateHeroAsync(int id, Superhero entity)
        {
            var result = await GetHeroByIdAsync(id);
            if (result == null) return null;

            result.Name = entity.Name;
            result.FirstName = entity.FirstName;
            result.LastName = entity.LastName;
            result.Place = entity.Place;

            await context.SaveChangesAsync();

            return await GetAllHerosAsync();
        }
    }
}
