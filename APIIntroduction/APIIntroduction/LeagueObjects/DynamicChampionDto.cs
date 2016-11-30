using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIIntroduction.LeagueObjects
{
    public class DynamicChampionDto
    {
        [JsonProperty("active")]
        bool Active { get; set; }

        [JsonProperty("botEnabled")]
        bool BotEnabled { get; set; }

        [JsonProperty("botMmEnabled")]
        bool BotMmEnabled { get; set; }

        [JsonProperty("freeToPlay")]
        bool FreeToPlay { get; set; }

        [JsonProperty("id")]
        long Id { get; set; }

        [JsonProperty("rankedPlayEnabled")]
        bool RankedPlayEnabled { get; set; }
    }
}
