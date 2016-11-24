using APIIntroduction.ApiHelpers;
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
            string APIKeyFile = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "APIKey.txt");

            string APIKey = null;

            if(!File.Exists(APIKeyFile))
            {
                Console.WriteLine("Please enter in your API Key");
                APIKey = Console.ReadLine();
                File.WriteAllText(APIKeyFile, APIKey);
            }
            else
            {
                APIKey = File.ReadAllText(APIKeyFile);
            }

            string sURL = String.Format("https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion/143?api_key={0}", APIKey);

            //Playing with a URL builder
            LeagueURLBuilder TestBuilder = new LeagueURLBuilder();
            TestBuilder.BaseURL = "https://global.api.pvp.net/";
            TestBuilder.APIPath = "api/lol/static-data/na/v1.2/champion/143";
            TestBuilder.Parameters = new Dictionary<string, string>() { { "api_key", APIKey } };
            string otherURL = TestBuilder.GetFullURL();

            WebRequest wrGETURL = WebRequest.Create(sURL);

            Stream objStream;
            objStream = wrGETURL.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);
            using (StreamReader response = new StreamReader(wrGETURL.GetResponse().GetResponseStream()))
            {
                JsonSerializer serializer = new JsonSerializer();
                MinStaticChampionDto leagueChampion = (MinStaticChampionDto)serializer.Deserialize(response, typeof(MinStaticChampionDto));
            }

            Console.ReadLine();
        }
    }
}
