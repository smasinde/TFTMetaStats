using System.Text.Json.Serialization;

namespace TFTMeta.Models
{
    public class MatchDto
    {
        [JsonPropertyName("metadata")]
        public MetadataDto Metadata { get; set; }

        [JsonPropertyName("info")]
        public InfoDto Info { get; set; }
    }

    public class MetadataDto
    {

        [JsonPropertyName("data_version")]
        public string DataVersion { get; set; }

        [JsonPropertyName("match_id")]
        public string MatchId { get; set; }

        [JsonPropertyName("participants")]
        public string[] Participants { get; set; }
    }

    public class InfoDto
    {

        [JsonPropertyName("game_datatime")]
        public ulong GameDatetime { get; set; }

        [JsonPropertyName("game_length")]
        public float GameLength { get; set; }

        [JsonPropertyName("game_variation")]
        public string GameVariation { get; set; }

        [JsonPropertyName("game_version")]
        public string GameVersion { get; set; }
        [JsonPropertyName("participants")]
        public ParticipantDto[] Participants { get; set; }

        [JsonPropertyName("queue_id")]
        public int QueueId { get; set; }
        [JsonPropertyName("tft_set_number")]
        public int TftSetNumber { get; set; }
    }

    public class ParticipantDto
    {

        [JsonPropertyName("companion")]
        public CompanionDto Companion { get; set; }

        [JsonPropertyName("gold_left")]
        public int GoldLeft { get; set; }

        [JsonPropertyName("last_round")]
        public int LastRound { get; set; }

        [JsonPropertyName("level")]
        public int Level { get; set; }
        [JsonPropertyName("placement")]
        public int Placement { get; set; }

        [JsonPropertyName("players_eliminated")]
        public int PlayersEliminated { get; set; }
        [JsonPropertyName("puuid")]
        public string Puuid { get; set; }
        [JsonPropertyName("time_eliminated")]
        public float TimeELiminated { get; set; }
        [JsonPropertyName("total_damage_to_players")]
        public int TotalDamageToPlayers { get; set; }
        [JsonPropertyName("traits")]
        public TraitDto[] Traits { get; set; }
        [JsonPropertyName("units")]
        public UnitDto[] Units { get; set; }
    }
    public class CompanionDto
    {
        [JsonPropertyName("content_ID")]
        public string ContentId { get; set; }
        [JsonPropertyName("skin_ID")]
        public int SkinId { get; set; }
        [JsonPropertyName("species")]
        public string Species { get; set; }
    }
    public class TraitDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("num_units")]
        public int NumUnits { get; set; }
        [JsonPropertyName("style")]
        public int Style { get; set; }
        [JsonPropertyName("tier_current")]
        public int TierCurrent { get; set; }
        [JsonPropertyName("tier_total")]
        public int TierTotal { get; set; }
    }

    public class UnitDto
    {
        [JsonPropertyName("items")]
        public int[] Items { get; set; }
        [JsonPropertyName("character_id")]
        public string CharacterId { get; set; }
        [JsonPropertyName("chosen")]
        public string Chosen { get; set; }
        [JsonPropertyName("name")]
        public string name { get; set; }
        [JsonPropertyName("rarity")]
        public int rarity { get; set; }

        [JsonPropertyName("tier")]
        public int Tier { get; set; }
    }
}