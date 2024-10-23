using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZumPokeApi.Models;
using ZumPokeApi.Services;

namespace ZumPokeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController(ILogger<PokemonController> logger, PokemonFightService fightService) : ControllerBase
    {
        [HttpGet]
        [Route("/pokemon/tournament/statistics")]
        public async Task<IActionResult> GetAsync([FromQuery] PokeFilter filter)
        {
            if (!ModelState.IsValid) return BadRequest();
            HttpClient client = new();
            Random rand = new();

            var idList = new List<int>();
            for (int i = 0; i < 8; i++)
            {
                int pokeId;
                do
                {
                    pokeId = rand.Next(1, 151);
                }
                while (idList.Contains(pokeId));
                idList.Add(pokeId);
            }

            List<Pokemon> fighters = [];
            List<PokemonFightStats> pokemonFightStats = [];
            foreach (var id in idList)
            {
                string url = $"https://pokeapi.co/api/v2/pokemon/{id}";
                var resultbody = await client.GetStringAsync(url);
                var deserializedPokemon = JsonConvert.DeserializeObject<Pokemon>(resultbody);
                fighters.Add(deserializedPokemon);
            }
            for (int i = 0; i < fighters.Count; i++)
            {
                var currentFighter = fighters[i];
                var fightStats = fightService.GetFightStats(currentFighter, fighters.Where((value, y) => y != i).ToList());

                pokemonFightStats.Add(new PokemonFightStats(currentFighter.id, currentFighter.name, currentFighter.type, fightStats[1], fightStats[0], fightStats[-1]));
            }

            var sorted = pokemonFightStats.AsQueryable().OrderBy($"{filter.SortBy} {filter.SortDirection}");
            return Ok(sorted);
        }
    }
}
