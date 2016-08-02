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
            string[] urls = {
                "http://skiplagged.com/api/pokemon.php?bounds=22.371945,113.950123,22.423506,113.998324",
                "http://skiplagged.com/api/pokemon.php?bounds=22.423156,113.990416,22.474617,114.062785",
                "http://skiplagged.com/api/pokemon.php?bounds=22.367684,114.161805,22.430902,114.244480",
                "http://skiplagged.com/api/pokemon.php?bounds=22.327029,114.076295,22.378765,114.148641",
                "http://skiplagged.com/api/pokemon.php?bounds=22.295827,114.146012,22.327883,114.198095",
                "http://skiplagged.com/api/pokemon.php?bounds=22.328938,114.144102,22.343714,114.216538",
                "http://skiplagged.com/api/pokemon.php?bounds=22.261931,114.215444,22.328741,114.268432",
                "http://skiplagged.com/api/pokemon.php?bounds=22.232476,114.123339,22.294026,114.212946"
            };
            string[] wanted = { "Chansey", "Snorlax", "Lapras" };
            //test
            while (true)
            {
                for(int i = 0; i < urls.Count(); i++)
                {
                    string res = HttpGet(urls[i]);
                    var result = JsonConvert.DeserializeObject<PokemonCollection>(res);
                    if (result.Pokemons != null)
                    {
                        Console.WriteLine(result.Pokemons.Count() + " pokemon(s) scanned in zone[" + i + "]");
                        foreach (Pokemon pokemon in result.Pokemons)
                        {
                            if (wanted.Contains(pokemon.Name))
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
            catch(Exception ex) {};

            return response;
        }

    }
}
