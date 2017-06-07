using APIIntroductionLibrary.ApiHelpers;
using APIIntroductionLibrary.LeagueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace APIIntroductionTests.Steps
{
    [Binding]
    public sealed class APIStaticFunctionsSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [When(@"I get champion information for ChampID (.*)")]
        public void WhenIGetChampionInformationForChampID(int id)
        {
            LeagueAPIStaticFunctions.ApiClient.DefaultRequestHeaders.Add(LeagueURLConstants.HeaderConstants.APIKeyHeader, ScenarioContext.Current["API_KEY"].ToString());

            ScenarioContext.Current.Add("CHAMP_DTO", LeagueAPIStaticFunctions.GetChampionFromIDHttpClient(id));
        }

        [Then(@"I've gotten information for ""(.*)""")]
        public void ThenIVeGottenInformationFor(string name)
        {
            ChampionDto champ = ScenarioContext.Current["CHAMP_DTO"] as ChampionDto;

            Assert.IsTrue(champ.Name.Equals(name));
        }

        [When(@"I get summoner information for ""(.*)""")]
        public void WhenIGetSummonerInformationFor(string summonerName)
        {
            LeagueAPIStaticFunctions.ApiClient.DefaultRequestHeaders.Add(LeagueURLConstants.HeaderConstants.APIKeyHeader, ScenarioContext.Current["API_KEY"].ToString());

            ScenarioContext.Current.Add("SUMMONER_DTO", LeagueAPIStaticFunctions.GetSummonerMetaByName(summonerName));
        }

        [Then(@"I've gotten information for summoner Id (.*)")]
        public void ThenIVeGottenInformationForSummonerId(int id)
        {
            SummonerDto summoner = ScenarioContext.Current["SUMMONER_DTO"] as SummonerDto;

            Assert.IsTrue(summoner.Id.Equals(id));
        }

        [When(@"I get the most recent game for ""(.*)""")]
        public void WhenIGetTheMostRecentGameFor(string summonerName)
        {
            LeagueAPIStaticFunctions.ApiClient.DefaultRequestHeaders.Add(LeagueURLConstants.HeaderConstants.APIKeyHeader, ScenarioContext.Current["API_KEY"].ToString());

            ScenarioContext.Current.Add("MATCH_DTO", LeagueAPIStaticFunctions.GetMostRecentMatch(summonerName));
        }

        [Then(@"I have a match with a non-zero game id")]
        public void ThenIHaveAMatchWithANon_ZeroGameId()
        {
            MatchDto currentMatch = ScenarioContext.Current.Get<MatchDto>("MATCH_DTO");

            Assert.IsTrue(!currentMatch.GameId.Equals(0));
        }

        [Then(@"The match has participant identities")]
        public void ThenTheMatchHasParticipantIdentities()
        {
            MatchDto currentMatch = ScenarioContext.Current.Get<MatchDto>("MATCH_DTO");

            Assert.IsTrue(currentMatch.ParticipantIdentities.Any());
        }

        [Then(@"The match has participants")]
        public void ThenTheMatchHasParticipants()
        {
            MatchDto currentMatch = ScenarioContext.Current.Get<MatchDto>("MATCH_DTO");

            Assert.IsTrue(currentMatch.Participants.Any());
        }

        [Then(@"The first participant has stats")]
        public void ThenTheFirstParticipantHasStats()
        {
            MatchDto currentMatch = ScenarioContext.Current.Get<MatchDto>("MATCH_DTO");

            Assert.IsTrue(!currentMatch.Participants.First().Stats.TotalDamageDealtToChampions.Equals(0));
        }
    }
}
