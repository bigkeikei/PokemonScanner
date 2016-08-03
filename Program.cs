using System;
using System.Linq;
using System.Threading;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace PokemonScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://skiplagged.com/api/pokemon.php?bounds=";
            Pokedex pokedex = new Pokedex();
            ZoneCollection scan = new ZoneCollection();

            while (true)
            {
                for(int i = 0; i < scan.Zones.Count(); i++)
                {
                    string res = HttpGet(url + scan.Zones[i]);
                    var result = JsonConvert.DeserializeObject<WildPokemonCollection>(res);
                    if (result.Pokemons != null)
                    {
                        Console.WriteLine(result.Pokemons.Count() + " pokemon(s) scanned in zone[" + i + "]");
                        foreach (WildPokemon pokemon in result.Pokemons)
                        {
                            if (pokedex.IsWanted(pokemon.Id))
                            {
                                Console.WriteLine(JsonConvert.SerializeObject(pokemon));
                            }
                        }
                    }
                    Thread.Sleep(5000);
                }
            }
        }

        static string HttpGet(string url)
        {
            string response = "{}";
            try { 
                WebRequest req = WebRequest.Create(url);
                ((HttpWebRequest)req).UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.103 Safari/537.36";
                WebResponse res = req.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                response = reader.ReadToEnd();
                reader.Close();
                res.Close();
            }
            catch(Exception) {};

            return response;
        }

    }
}
