namespace ZumPokeApi.Models
{
    public class PokemonFightStats(int id, string name, string type, int wins, int losses, int ties)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Type { get; set; } = type;
        public int Wins { get; set; } = wins;
        public int Losses { get; set; } = losses;
        public int Ties { get; set; } = ties;
    }
}
