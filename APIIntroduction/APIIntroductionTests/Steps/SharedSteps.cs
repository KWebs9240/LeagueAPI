using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace APIIntroductionTests.Steps
{
    [Binding]
    public sealed class SharedSteps
    {
        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef

        [Given(@"I've set my APIKey")]
        public void GivenIVeSetMyAPIKey()
        {
            string APIKeyFile = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "APIKey.txt");

            if (!File.Exists(APIKeyFile))
            {
                throw new Exception("The API Key has not been set yet. Please use the console app to save it off first.");
            }
            else
            {
                ScenarioContext.Current.Add("API_KEY", File.ReadAllText(APIKeyFile));
            }
        }

    }
}
