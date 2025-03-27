using System.Text.Json;
using PokemonDex.Models;

namespace PokemonDex.Data
{
    public class PokemonJsonData
    {
        public required string id { get; set; }
        public required string name { get; set; }
        public required string[] type { get; set; }
        public required string description { get; set; }
    }

    public static class PokemonSeedData
    {
        public static List<Pokemon> GetPokemonData()
        {
            string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "data.json");
            string jsonContent = File.ReadAllText(jsonPath);
            
            var jsonData = JsonSerializer.Deserialize<List<PokemonJsonData>>(jsonContent)
                ?? throw new InvalidOperationException("Failed to deserialize Pokemon data");

            var pokemonList = new List<Pokemon>();
            int id = 1;
            var processedIds = new HashSet<string>();

            foreach (var item in jsonData)
            {
                if (!processedIds.Contains(item.id))
                {
                    pokemonList.Add(new Pokemon
                    {
                        Id = id++,
                        IndexId = item.id,
                        Name = item.name,
                        Type = string.Join(", ", item.type),
                        Description = item.description
                    });
                    processedIds.Add(item.id);
                }
            }

            return pokemonList;
        }
    }
} 