using Microsoft.EntityFrameworkCore;
using PokemonDex.Models;

namespace PokemonDex.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed Pokemon data
            var pokemonData = PokemonSeedData.GetPokemonData();
            modelBuilder.Entity<Pokemon>().HasData(pokemonData);
        }
    }
}
