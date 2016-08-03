using Newtonsoft.Json;
using System.IO;

namespace PokemonScanner
{
    public class Pokedex
    {
        public Pokemon[] Pokemons { get; set; }
        public Pokedex()
        {
            FileStream fs = new FileStream(".\\pokedex.js", FileMode.Open);
            StreamReader r = new StreamReader(fs);
            string js = r.ReadToEnd();
            r.Close();

            Pokemons = JsonConvert.DeserializeObject<Pokemon[]>(js);
        }

        public bool IsWanted(int Id)
        {
            foreach(Pokemon p in Pokemons)
            {
                if (p.Id == Id && !p.Gotcha)
                {
                    return true;
                }
            }
            return false;
        }
    }

    public class Pokemon
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "gotcha")]
        public bool Gotcha { get; set; }
    }
}
