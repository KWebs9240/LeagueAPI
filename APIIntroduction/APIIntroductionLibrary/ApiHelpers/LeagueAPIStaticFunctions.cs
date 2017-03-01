using APIIntroductionLibrary.LeagueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIIntroductionLibrary.ApiHelpers
{
    public static class LeagueAPIStaticFunctions
    {
        public static string APIKey;
        private static HttpClient _ApiClient = new HttpClient();

        #region Using Http Client

        public static ChampionMetaDtoList GetCurrentFreeToPlayListHttpClient()
        {
            string sURL = String.Format(LeagueURLConstants.APIPaths.ChampMetaPath, APIKey);

            ChampionMetaDtoList freeToPlayChamps = null;

            using (StreamReader response = new StreamReader(_ApiClient.GetStreamAsync(sURL).Result))
            using (JsonReader jsonResponse = new JsonTextReader(response))
            {
                JsonSerializer serializer = new JsonSerializer();
                freeToPlayChamps = serializer.Deserialize<ChampionMetaDtoList>(jsonResponse);
            }

            if (freeToPlayChamps == null)
            {
                Console.WriteLine("Something went wrong while retreiving free to play champs");
            }
            return freeToPlayChamps;
        }

        public static ChampionDto GetChampionFromIDHttpClient(int id)
        {
            string sURL = String.Format(LeagueURLConstants.APIPaths.ChampPath, id.ToString(), APIKey);

            ChampionDto leagueChampion = null;

            using (StreamReader response = new StreamReader(_ApiClient.GetStreamAsync(sURL).Result))
            using (JsonReader jsonResponse = new JsonTextReader(response))
            {
                JsonSerializer serializer = new JsonSerializer();
                leagueChampion = serializer.Deserialize<ChampionDto>(jsonResponse);
            }

            if (leagueChampion == null)
            {
                Console.WriteLine("Error occured while trying to retreive information for {0}", id.ToString());
            }

            return leagueChampion;
        }

        public static SummonerMetaDto GetSummonerMetaByName(string name)
        {
            string sURL = String.Format(LeagueURLConstants.APIPaths.SummonerMetaPath, name, APIKey);

            Dictionary<string, SummonerMetaDto> summonerDict = null;

            using (StreamReader response = new StreamReader(_ApiClient.GetStreamAsync(sURL).Result))
            using (JsonReader jsonResponse = new JsonTextReader(response))
            {
                JsonSerializer serializer = new JsonSerializer();
                summonerDict = serializer.Deserialize<Dictionary<string, SummonerMetaDto>>(jsonResponse);
            }

            if (summonerDict == null)
            {
                Console.WriteLine("Error occured while trying to retreive summoner information for {0}", name);
            }

            return summonerDict.FirstOrDefault().Value;
        }
        #endregion
    }
}
