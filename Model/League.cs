using System.Text.Json.Serialization;

namespace TFTMeta.Models
{
    public class League
    {
        [JsonPropertyName("leagueId")]
        public string LeagueId { get; set; }

        [JsonPropertyName("entries")]
        public LeagueItemDTO[] entries { get; set; }

        [JsonPropertyName("tier")]
        public string tier { get; set; }

        [JsonPropertyName("name")]
        public string name { get; set; }

        [JsonPropertyName("queue")]
        public string queue { get; set; }

    }

    public class LeagueItemDTO
    {
        [JsonPropertyName("freshBlood")]
        public bool FreshBlood { get; set; }
        [JsonPropertyName("wins")]
        public ushort Wins { get; set; }
        [JsonPropertyName("summonerName")]
        public string SummonerName { get; set; }
        [JsonPropertyName("miniSeries")]
        public MiniSeriesDTO MiniSeries { get; set; }
        [JsonPropertyName("inactive")]
        public bool Inactive { get; set; }
        [JsonPropertyName("veteran")]
        public bool Veteran { get; set; }
        [JsonPropertyName("hotStreak")]
        public bool HotStreak { get; set; }
        [JsonPropertyName("rank")]
        public string Rank { get; set; }
        [JsonPropertyName("leaguePoints")]
        public int LeaguePoints { get; set; }
        [JsonPropertyName("losses")]
        public int Losses { get; set; }
        [JsonPropertyName("summonerId")]
        public string SummonerId { get; set; }
    }

    public class MiniSeriesDTO
    {
        [JsonPropertyName("losses")]
        public int Losses { get; set; }
        [JsonPropertyName("progress")]
        public string Progress { get; set; }
        [JsonPropertyName("target")]
        public int Target { get; set; }
        [JsonPropertyName("wins")]
        public int Wins { get; set; }
    }
}