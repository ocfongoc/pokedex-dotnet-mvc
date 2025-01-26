namespace PokemonDex.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public required string IndexId { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public string? Description { get; set; }
    }
}
