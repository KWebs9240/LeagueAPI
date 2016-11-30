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

            if(!File.Exists(APIKeyFile))
            {
                Console.WriteLine("Please enter in your API Key");
                LeagueAPIStaticFunctions.APIKey = Console.ReadLine();
                File.WriteAllText(APIKeyFile, LeagueAPIStaticFunctions.APIKey);
            }
            else
            {
                LeagueAPIStaticFunctions.APIKey = File.ReadAllText(APIKeyFile);
            }

            DynamicChampionDtoList testingOut = LeagueAPIStaticFunctions.GetCurrentFreeToPlayList();

            Console.ReadLine();
        }
    }
}
