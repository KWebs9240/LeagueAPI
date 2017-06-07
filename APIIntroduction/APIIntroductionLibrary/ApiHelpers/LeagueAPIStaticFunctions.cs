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
        public static HttpClient ApiClient = new HttpClient();

        #region Using Http Client

        public static ChampionMetaDtoList GetCurrentFreeToPlayListHttpClient()
        {
            string sURL = String.Format(LeagueURLConstants.APIPaths.ChampMetaPath);

            ChampionMetaDtoList freeToPlayChamps = null;

            using (StreamReader response = new StreamReader(ApiClient.GetStreamAsync(sURL).Result))
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
            string sURL = String.Format(LeagueURLConstants.APIPaths.ChampPath, id.ToString());

            ChampionDto leagueChampion = null;

            using (StreamReader response = new StreamReader(ApiClient.GetStreamAsync(sURL).Result))
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

        public static SummonerDto GetSummonerMetaByName(string name)
        {
            string sURL = String.Format(LeagueURLConstants.APIPaths.SummonerMetaPath, name);

            SummonerDto summoner = null;

            using (StreamReader response = new StreamReader(ApiClient.GetStreamAsync(sURL).Result))
            using (JsonReader jsonResponse = new JsonTextReader(response))
            {
                JsonSerializer serializer = new JsonSerializer();
                summoner = serializer.Deserialize<SummonerDto>(jsonResponse);
            }

            if (summoner == null)
            {
                Console.WriteLine("Error occured while trying to retreive summoner information for {0}", name);
            }

            return summoner;
        }

        public static MatchListDto GetRecentMatchesBySummonerId (long summonerId)
        {
            MatchListDto listOfMatches;

            string sURL = String.Format(LeagueURLConstants.APIPaths.MatchListPath, summonerId);

            using (StreamReader response = new StreamReader(ApiClient.GetStreamAsync(sURL).Result))
            using (JsonReader jsonResponse = new JsonTextReader(response))
            {
                JsonSerializer serializer = new JsonSerializer();
                listOfMatches = serializer.Deserialize<MatchListDto>(jsonResponse);
            }

            return listOfMatches;
        }

        public static MatchDto GetMatchByMatchId (long matchId)
        {
            MatchDto match;

            string sURL = String.Format(LeagueURLConstants.APIPaths.MatchPath, matchId);

            using (StreamReader response = new StreamReader(ApiClient.GetStreamAsync(sURL).Result))
            using (JsonReader jsonResponse = new JsonTextReader(response))
            {
                JsonSerializer serializer = new JsonSerializer();
                match = serializer.Deserialize<MatchDto>(jsonResponse);
            }

            return match;
        }

        public static ChampionDto GetMostRecentlyPlayedChamp (string summonerName)
        {
            SummonerDto needTheId = GetSummonerMetaByName(summonerName);

            MatchReferenceDto mostRecentMatch = GetRecentMatchesBySummonerId(needTheId.Id).Matches.OrderByDescending(x => x.TimeStamp).First();

            int mostRecentChampId = Convert.ToInt32(mostRecentMatch.Champion);

            return GetChampionFromIDHttpClient(mostRecentChampId);
        }

        public static MatchDto GetMostRecentMatch (string summonerName)
        {
            SummonerDto needTheId = GetSummonerMetaByName(summonerName);

            MatchReferenceDto mostRecentMatch = GetRecentMatchesBySummonerId(needTheId.AccountId).Matches.OrderByDescending(x => x.TimeStamp).First();

            return GetMatchByMatchId(mostRecentMatch.GameId);
        }
        #endregion
    }
}
