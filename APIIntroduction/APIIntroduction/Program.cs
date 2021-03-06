﻿using APIIntroductionLibrary.ApiHelpers;
using APIIntroductionLibrary.LeagueObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            string APIKeyFile = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "APIKey.txt");

            if(!File.Exists(APIKeyFile))
            {
                Console.WriteLine("Please enter in your API Key");
                string apiKey = Console.ReadLine();
                LeagueAPIStaticFunctions.ApiClient.DefaultRequestHeaders.Add(LeagueURLConstants.HeaderConstants.APIKeyHeader, apiKey);
                File.WriteAllText(APIKeyFile, apiKey);
            }
            else
            {
                LeagueAPIStaticFunctions.ApiClient.DefaultRequestHeaders.Add(LeagueURLConstants.HeaderConstants.APIKeyHeader, File.ReadAllText(APIKeyFile));
            }

            ChampionMetaDtoList freeToPlayMetaList = LeagueAPIStaticFunctions.GetCurrentFreeToPlayListHttpClient();

            List<ChampionDto> freeToPlayList = new List<ChampionDto>();

            foreach(ChampionMetaDto champMeta in freeToPlayMetaList.Champions)
            {
                freeToPlayList.Add(LeagueAPIStaticFunctions.GetChampionFromIDHttpClient(Convert.ToInt32(champMeta.Id)));
            }

            foreach(ChampionDto champ in freeToPlayList)
            {
                Console.WriteLine(string.Format("{0:000}: {1}", champ.Id, champ.Name));
            }

            Console.WriteLine("Please enter the name of a summoner to get information for");
            string summonerName = Console.ReadLine();

            //This name should really be checked before doing this
            //Riot would probably yell at me.
            SummonerDto summoner = LeagueAPIStaticFunctions.GetSummonerMetaByName(summonerName);

            Console.WriteLine(string.Format("The ID for Summoner with name {0} is {1}", summonerName, summoner.Id));

            ChampionDto MostRecentChamp = LeagueAPIStaticFunctions.GetMostRecentlyPlayedChamp(summonerName);

            Console.WriteLine(string.Format("The most recent champt that {0} played is {1}", summonerName, MostRecentChamp.Name));

            Console.ReadLine();
        }
    }
}
