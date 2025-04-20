namespace PokemonDex.Models.ViewModels
{
    public class PokemonSearchViewModel
    {
        public string? SearchTerm { get; set; }
        public string? SearchType { get; set; } // "id", "name", "type"
        public List<Pokemon>? pokemons { get; set; }
    }
} 