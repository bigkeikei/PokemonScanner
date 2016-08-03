using System;
using Newtonsoft.Json;

namespace PokemonScanner
{
    public class WildPokemon
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

        public long SecondsRemains
        {
            get
            {
                DateTime time = new DateTime(Expires * 10000000).AddYears(1969).AddDays(-1);
                return (long)time.Subtract(DateTime.Now.ToUniversalTime()).TotalSeconds;
            }
        }
    }

    public class WildPokemonCollection
    {
        [JsonProperty(PropertyName = "pokemons")]
        public WildPokemon[] Pokemons { get; set; }
    }
}
