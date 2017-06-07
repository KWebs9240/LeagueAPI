using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIIntroductionLibrary.LeagueObjects
{
    public class MatchDto
    {
        [JsonProperty("seasonId")]
        public int SeasonId { get; set; }

        [JsonProperty("queueId")]
        public int QueueId { get; set; }

        [JsonProperty("gameId")]
        public long GameId { get; set; }

        [JsonProperty("participantIdentities")]
        public List<ParticipantIdentityDto> ParticipantIdentities { get; set; }

        [JsonProperty("gameVersion")]
        public string GameVersion { get; set; }

        [JsonProperty("platformId")]
        public string PlatformId { get; set; }

        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("mapId")]
        public int MapId { get; set; }

        [JsonProperty("gameType")]
        public string GameType { get; set; }

        //Super lazy takes over
        //[JsonProperty("teams")]
        //public List<TeamStatsDto> Teams { get; set; }

        [JsonProperty("participants")]
        public List<ParticipantDto> Participants { get; set; }

        [JsonProperty("gameDuration")]
        public long GameDuration { get; set; }

        [JsonProperty("gameCreation")]
        public long GameCreation { get; set; }

    }
}
