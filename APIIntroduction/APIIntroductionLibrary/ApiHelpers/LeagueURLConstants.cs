using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIIntroduction.ApiHelpers
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
        }
    }
}
