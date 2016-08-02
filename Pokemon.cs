using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokemonScanner
{
    public class Pokemon
    {
        [JsonProperty(PropertyName = "pokemon_id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "pokemon_name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "expires")]
        public long Expires { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }
    }

    public class PokemonCollection
    {
        [JsonProperty(PropertyName = "pokemons")]
        public Pokemon[] Pokemons { get; set; }
    }
}
