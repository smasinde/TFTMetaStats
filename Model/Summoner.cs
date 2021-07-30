using System.Text.Json.Serialization;

namespace TFTMeta.Models
{
    public class Summoner
    {
        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }
        [JsonPropertyName("profileIconId")]
        public int ProfileIconId { get; set; }
        [JsonPropertyName("revisionDate")]
        public ulong RevisionDate { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("puuid")]
        public string Puuid { get; set; }
        [JsonPropertyName("summonerLevel")]
        public ulong SummonerLevel { get; set; }

    }
}