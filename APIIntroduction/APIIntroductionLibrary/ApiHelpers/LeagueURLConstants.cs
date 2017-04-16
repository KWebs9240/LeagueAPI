using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIIntroductionLibrary.ApiHelpers
{
    public static class LeagueURLConstants
    {
        public static class BaseURLs
        {
            public const string Global = "https://global.api.pvp.net/";
            public const string NorthAmerica = "https://na.api.pvp.net/";
        }

        public static class APIPaths
        {
            //add /{id} to get the information for a speific champion
            public const string StaticChampInfo = "/api/lol/static-data/na/v1.2/champion"; //na is a region specific field
            public const string DynamicChampInfo = "/api/lol/na/v1.2/champion"; //na is a region specific field

            public const string ChampMetaPath = "https://na.api.pvp.net/api/lol/na/v1.2/champion?freeToPlay=TRUE&api_key={0}";
            public const string ChampPath = "https://global.api.pvp.net/api/lol/static-data/na/v1.2/champion/{0}?api_key={1}";
            public const string SummonerMetaPath = "https://na.api.pvp.net/api/lol/na/v1.4/summoner/by-name/{0}?api_key={1}";
            public const string MatchListPath = "https://na.api.riotgames.com/api/lol/NA/v2.2/matchlist/by-summoner/{0}?rankedQueues={1}&api_key={2}";
        }

        public static class RankedQueues
        {
            public const string RankedFlex = "RANKED_FLEX_SR";
            public const string RankedSoloFives = "RANKED_SOLO_5x5";
            public const string RankedSoloThrees = "RANKED_TEAM_3x3";
            public const string RankedTeamThrees = "RANKED_TEAM_3x3";
            public const string RankedTeamFives = "RANKED_TEAM_5x5";
            public const string TeamBuilderRankedFives = "TEAM_BUILDER_DRAFT_RANKED_5x5";
            public const string TeamBuilderRankedSolo = "TEAM_BUILDER_RANKED_SOLO";
        }
    }
}
