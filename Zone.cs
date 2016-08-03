using System.IO;
using System;
using Newtonsoft.Json;

namespace PokemonScanner
{
    public class ZoneCollection
    {
        public string[] Zones { get; set; }

        public ZoneCollection()
        {
            FileStream fs = new FileStream(".\\zone.js", FileMode.Open);
            StreamReader r = new StreamReader(fs);
            string js = r.ReadToEnd();
            r.Close();

            Zones = JsonConvert.DeserializeObject<string[]>(js);
        }
    }
}
