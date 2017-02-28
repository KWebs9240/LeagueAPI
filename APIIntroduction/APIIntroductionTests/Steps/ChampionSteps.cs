using APIIntroduction.ApiHelpers;
using APIIntroduction.LeagueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace APIIntroductionTests.Steps
{
    [Binding]
    public sealed class ChampionSteps
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

    }
}
