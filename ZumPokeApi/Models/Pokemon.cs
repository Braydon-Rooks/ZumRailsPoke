using Newtonsoft.Json;

namespace ZumPokeApi.Models
{
    public class Pokemon(int base_experience, int id, string name, List<Pokemon.Type> types, int weight)
    {
        public int base_experience { get; set; } = base_experience;
        public int id { get; set; } = id;
        public string name { get; set; } = name;
        public string type { get; set; } = types[0].Value.Name;
        public int weight { get; set; } = weight;

        public class Type
        {
            public int Slot { get; set; }
            [JsonProperty("Type")]
            public Type2 Value { get; set; }
        }
        public class Type2
        {
            public string Name { get; set; }
            public string Url { get; set; }
        }
    }

    

}
