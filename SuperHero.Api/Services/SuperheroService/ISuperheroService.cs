namespace SuperHero.Api.Services.SuperheroService
{
    public interface ISuperheroService
    {     
        Task<List<Superhero>> GetAllHerosAsync();
        Task<Superhero?> GetHeroByIdAsync(int id);
        //Task<IEnumerable<Superhero>> GetHeroByIdAsync(int id);
        Task<Superhero> AddHeroAsync(Superhero entity);
        //Task<IEnumerable<Superhero>> AddHeroAsync(Superhero entity);
        Task<List<Superhero>?> UpdateHeroAsync(int id, Superhero entity);
        //Task<IEnumerable<Superhero>> UpdateHeroAsync(Superhero entity);
        void DeleteHeroAsync(Superhero entity);
    }
}
