using APIIntroduction.LeagueObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APIIntroduction.ApiHelpers
{
    public static class LeagueAPIStaticFunctions
    {
        public static string APIKey;
        private static HttpClient _ApiClient = new HttpClient();

        #region Using Web Request

        public static ChampionMetaDtoList GetCurrentFreeToPlayList()
        {
            string sURL = String.Format("https://na.api.pvp.net/api/lol/na/v1.2/champion?freeToPlay=TRUE&api_key={0}", APIKey);

            WebRequest wrGETURL = WebRequest.Create(sURL);

            ChampionMetaDtoList freeToPlayChamps = null;

            using (StreamReader response = new StreamReader(wrGETURL.GetResponse().GetResponseStream()))
            using (JsonReader jsonResponse = new JsonTextReader(response))
            {
                JsonSerializer serializer = new JsonSerializer();
                freeToPlayChamps = (ChampionMetaDtoList)serializer.Deserialize<ChampionMetaDtoList>(jsonResponse);
            }

            if(freeToPlayChamps == null)
            {
                Console.WriteLine("Something went wrong while retreiving free to play champs");
            }
            return freeToPlayChamps;
        }

        public static ChampionDto GetChampionFromID(int id)
        {
            string sURL = String.Format("https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion/{0}?api_key={1}", id.ToString(), APIKey);

            WebRequest wrGETURL = WebRequest.Create(sURL);

            ChampionDto leagueChampion = null;

            using (StreamReader response = new StreamReader(wrGETURL.GetResponse().GetResponseStream()))
            using (JsonReader jsonResponse = new JsonTextReader(response))
            {
                JsonSerializer serializer = new JsonSerializer();
                leagueChampion = serializer.Deserialize<ChampionDto>(jsonResponse);
            }

            if(leagueChampion == null)
            {
                Console.WriteLine("Error occured while trying to retreive information for {0}", id.ToString());
            }

            return leagueChampion;
        }

        #endregion

        #region Using Http Client

        public static ChampionMetaDtoList GetCurrentFreeToPlayListHttpClient()
        {
            string sURL = String.Format("https://na.api.pvp.net/api/lol/na/v1.2/champion?freeToPlay=TRUE&api_key={0}", APIKey);

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
            string sURL = String.Format("https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion/{0}?api_key={1}", id.ToString(), APIKey);

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

        #endregion
    }
}
