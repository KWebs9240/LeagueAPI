using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIIntroductionLibrary.LeagueObjects
{
    public class ChampionMetaDtoList
    {
        [JsonProperty("champions")]
        public List<ChampionMetaDto> Champions { get; set; }
    }
}
