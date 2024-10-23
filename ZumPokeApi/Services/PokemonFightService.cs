using ZumPokeApi.Models;

namespace ZumPokeApi.Services
{
    public class PokemonFightService
    {
        public Dictionary<int,int> GetFightStats(Pokemon pokemon1, List<Pokemon> opponents)
        {
            var Outcomes = new Dictionary<int, int>()
            {
                {1, 0},
                {0, 0},
                {-1, 0},
            };
            foreach (var pokemon2 in opponents)
            {
                int fightOutcome = pokemon1.type switch
                {
                    "water" => pokemon2.type == "fire" || pokemon1.base_experience > pokemon2.base_experience ? 1 : pokemon1.base_experience == pokemon2.base_experience ? -1 : 0,
                    "fire" => pokemon2.type == "grass" || pokemon1.base_experience > pokemon2.base_experience ? 1 : pokemon1.base_experience == pokemon2.base_experience ? -1 : 0,
                    "grass" => pokemon2.type == "electric" || pokemon1.base_experience > pokemon2.base_experience ? 1 : pokemon1.base_experience == pokemon2.base_experience ? -1 : 0,
                    "electric" => pokemon2.type == "water" || pokemon1.base_experience > pokemon2.base_experience ? 1 : pokemon1.base_experience == pokemon2.base_experience ? -1 : 0,
                    "ghost" => pokemon2.type == "psychic" || pokemon1.base_experience > pokemon2.base_experience ? 1 : pokemon1.base_experience == pokemon2.base_experience ? -1 : 0,
                    "psychic" => pokemon2.type == "fighting" || pokemon1.base_experience > pokemon2.base_experience ? 1 : pokemon1.base_experience == pokemon2.base_experience ? -1 : 0,
                    "fighting" => pokemon2.type == "dark" || pokemon1.base_experience > pokemon2.base_experience ? 1 : pokemon1.base_experience == pokemon2.base_experience ? -1 : 0,
                    "dark" => pokemon2.type == "ghost" || pokemon1.base_experience > pokemon2.base_experience ? 1 : pokemon1.base_experience == pokemon2.base_experience ? -1 : 0,
                    _ => pokemon1.base_experience > pokemon2.base_experience ? 1 : pokemon1.base_experience == pokemon2.base_experience ? -1 : 0,
                };
                Outcomes[fightOutcome]++;
            }
            return Outcomes;
        }
    }
}
