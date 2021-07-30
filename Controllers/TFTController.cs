using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TFTMeta.Models;
using System.Linq;

namespace TFTMeta.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TFTController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        static Dictionary<string, string> PLATFORM_ROUTES = new Dictionary<string, string>
        {
            {"BR1", "br1.api.riotgames.com"},
            {"EUN1", "eun1.api.riotgames.com"},
            {"EUW1", "euw1.api.riotgames.com"},
            {"JP1", "jp1.api.riotgames.com"},
            {"KR", "kr.api.riotgames.com"},
            {"LA1", "la1.api.riotgames.com"},
            {"LA2", "la2.api.riotgames.com"},
            {"NA1", "na1.api.riotgames.com"},
            {"OC1", "oc1.api.riotgames.com"},
            {"TR1", "tr1.api.riotgames.com"},
            {"RU", "ru.api.riotgames.com"}
        };
        static Dictionary<string, string> REGIONAL_ROUTES = new Dictionary<string, string>
        {
            {"AMERICAS", "americas.api.riotgames.com"},
            {"ASIA", "asia.api.riotgames.com"},
            {"EUROPE", "europe.api.riotgames.com"}
        };
        enum TIERS { challenger, master, grandmaster };
        private static async Task<League> RetrieveLeagueInfo()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            client.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-c83319fe-4f2d-4992-8b10-e9d1b37feaa3");

            var stringTask = client.GetStringAsync($"https://{PLATFORM_ROUTES["EUW1"]}/tft/league/v1/{TIERS.grandmaster}");
            var getString = await stringTask;

            League leagueRepo = JsonSerializer.Deserialize<League>(getString);
            return leagueRepo;
        }

        [HttpGet]
        public async Task<ActionResult<League>> Get()
        {
            return await RetrieveLeagueInfo();
        }

        private static async Task<Summoner> RetrieveSummoner(string sumid)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            client.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-c83319fe-4f2d-4992-8b10-e9d1b37feaa3");

            var stringTask = client.GetStringAsync($"https://{PLATFORM_ROUTES["EUW1"]}/tft/summoner/v1/summoners/{sumid}");
            var getString = await stringTask;

            Summoner summoner = JsonSerializer.Deserialize<Summoner>(getString);

            return summoner;
        }

        // [HttpGet("{summonerId}")]
        // public async Task<ActionResult<Summoner>> Get(string summonerId)
        // {
        //     return await RetrieveSummoner(summonerId);
        // }

        private static async Task<string[]> RetrieveSummonerMatches(string puuid)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            client.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-c83319fe-4f2d-4992-8b10-e9d1b37feaa3");

            var stringTask = client.GetStringAsync($"https://{REGIONAL_ROUTES["EUROPE"]}/tft/match/v1/matches/by-puuid/{puuid}/ids?count=3");
            var getString = await stringTask;

            string[] summonerMatches = JsonSerializer.Deserialize<string[]>(getString);

            var sm = summonerMatches.Select((x) => x);
            foreach (var m in sm)
            {
                Console.WriteLine(m);
            }
            return summonerMatches;
        }
        // [HttpGet("{puuid}")]
        // public async Task<ActionResult<string[]>> Get(string puuid)
        // {
        //     return await RetrieveSummonerMatches(puuid);
        // }

        private static async Task<MatchDto> RetrieveMatchData(string matchuuid)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            client.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-c83319fe-4f2d-4992-8b10-e9d1b37feaa3");

            var stringTask = client.GetStringAsync($"https://{REGIONAL_ROUTES["EUROPE"]}/tft/match/v1/matches/{matchuuid}");
            var getString = await stringTask;

            MatchDto match = JsonSerializer.Deserialize<MatchDto>(getString);

            return match;
        }
        [HttpGet("{matchuuid}")]
        public async Task<ActionResult<MatchDto>> Get(string matchuuid)
        {
            return await RetrieveMatchData(matchuuid);
        }
    }
}