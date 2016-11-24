using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIIntroduction.ApiHelpers
{
    class LeagueURLBuilder
    {
        public string BaseURL { get; set; }
        public string APIPath { get; set; }
        public Dictionary<string, string> Parameters { get; set; }

        public string GetFullURL()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(BaseURL);
            sb.Append(APIPath);
            if(Parameters.Any())
            {
                sb.Append("?");
            }
            bool bFirst = true;
            foreach(string key in Parameters.Keys)
            {
                if(!bFirst)
                {
                    sb.Append("&");
                }
                sb.Append(key);
                sb.Append("=");
                sb.Append(Parameters[key]);

                bFirst = false;
            }

            return sb.ToString();
        }
    }
}
