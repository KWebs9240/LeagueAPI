using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIIntroductionLibrary.LeagueObjects
{
    public class MatchReferenceDto
    {
        [JsonProperty("lane")]
        public string Lane { get; set; }

        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("champion")]
        public long Champion { get; set; }

        [JsonProperty("platformId")]
        public string LeaguePlatformId { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("queue")]
        public string Queue { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("timestamp")]
        public long TimeStamp { get; set; }
    }
}
