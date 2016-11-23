using APIIntroduction.LeagueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string APIKeyFile = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().CodeBase, "APIKey.txt");

            if(!File.Exists(APIKeyFile))
            {
                Console.WriteLine("Please enter in your API Key");
                Console.ReadLine();
            }

            string sURL = @"https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion/143?api_key=<API-KEY>"; //Replace API-KEY with the actual API key

            WebRequest wrGETURL = WebRequest.Create(sURL);

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);
            using (StreamReader response = new StreamReader(wrGETURL.GetResponse().GetResponseStream()))
            {
                JsonSerializer serializer = new JsonSerializer();
                MinimalChampionDto leagueChampion = (MinimalChampionDto)serializer.Deserialize(response, typeof(MinimalChampionDto));
            }

            Console.ReadLine();
        }
    }
}
