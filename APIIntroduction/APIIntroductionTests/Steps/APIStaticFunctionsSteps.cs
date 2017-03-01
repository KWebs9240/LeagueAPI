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
            LeagueAPIStaticFunctions.APIKey = ScenarioContext.Current["API_KEY"].ToString();

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
            LeagueAPIStaticFunctions.APIKey = ScenarioContext.Current["API_KEY"].ToString();

            ScenarioContext.Current.Add("SUMMONER_DTO", LeagueAPIStaticFunctions.GetSummonerMetaByName(summonerName));
        }

        [Then(@"I've gotten information for summoner Id (.*)")]
        public void ThenIVeGottenInformationForSummonerId(int id)
        {
            SummonerMetaDto summoner = ScenarioContext.Current["SUMMONER_DTO"] as SummonerMetaDto;

            Assert.IsTrue(summoner.Id.Equals(id));
        }

    }
}
