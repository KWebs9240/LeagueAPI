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
            public const string ChampMetaPath = "https://na1.api.riotgames.com/lol/platform/v3/champions?freeToPlay=true";
            public const string ChampPath = "https://na1.api.riotgames.com/lol/static-data/v3/champions/{0}";
            public const string SummonerMetaPath = "https://na1.api.riotgames.com/lol/summoner/v3/summoners/by-name/{0}";
            public const string MatchListPath = "https://na1.api.riotgames.com/lol/match/v3/matchlists/by-account/{0}/recent";
            public const string MatchPath = "https://na1.api.riotgames.com/lol/match/v3/matches/{0}";
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

        public static class HeaderConstants
        {
            public const string APIKeyHeader = "X-Riot-Token";
        }
    }
}
