using ZumPokeApi.Models;

namespace ZumPokeApi.Services
{
    public class PokemonFightService
    {
        public Dictionary<string,int> GetFightStats(Pokemon pokemon1, List<Pokemon> opponents)
        {
            var Outcomes = new Dictionary<string, int>()
            {
                {"win", 0},
                {"loss", 0},
                {"draw", 0},
            };
            foreach (var pokemon2 in opponents)
            {
                string fightOutcome = pokemon1.type switch
                {
                    "water" => pokemon2.type == "fire" || pokemon1.base_experience > pokemon2.base_experience ? "win" : pokemon1.base_experience == pokemon2.base_experience ? "draw" : "loss",
                    "fire" => pokemon2.type == "grass" || pokemon1.base_experience > pokemon2.base_experience ? "win" : pokemon1.base_experience == pokemon2.base_experience ? "draw" : "loss",
                    "grass" => pokemon2.type == "electric" || pokemon1.base_experience > pokemon2.base_experience ? "win" : pokemon1.base_experience == pokemon2.base_experience ? "draw" : "loss",
                    "electric" => pokemon2.type == "water" || pokemon1.base_experience > pokemon2.base_experience ? "win" : pokemon1.base_experience == pokemon2.base_experience ? "draw" : "loss",
                    "ghost" => pokemon2.type == "psychic" || pokemon1.base_experience > pokemon2.base_experience ? "win" : pokemon1.base_experience == pokemon2.base_experience ? "draw" : "loss",
                    "psychic" => pokemon2.type == "fighting" || pokemon1.base_experience > pokemon2.base_experience ? "win" : pokemon1.base_experience == pokemon2.base_experience ? "draw" : "loss",
                    "fighting" => pokemon2.type == "dark" || pokemon1.base_experience > pokemon2.base_experience ? "win" : pokemon1.base_experience == pokemon2.base_experience ? "draw" : "loss",
                    "dark" => pokemon2.type == "ghost" || pokemon1.base_experience > pokemon2.base_experience ? "win" : pokemon1.base_experience == pokemon2.base_experience ? "draw" : "loss",
                    _ => pokemon1.base_experience > pokemon2.base_experience ? "win" : pokemon1.base_experience == pokemon2.base_experience ? "draw" : "loss",
                };
                Outcomes[fightOutcome]++;
            }
            return Outcomes;
        }
    }
}
