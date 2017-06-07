using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIIntroductionLibrary.LeagueObjects
{
    public class ParticipantIdentityDto
    {
        [JsonProperty("player")]
        public PlayerDto Player { get; set; }

        [JsonProperty("participantId")]
        public int ParticipantId { get; set; }

    }
}
