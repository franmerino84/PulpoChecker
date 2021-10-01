using System.Globalization;
using System.Text.Json.Serialization;

namespace PulpoChecker.DTO
{
    public class PulpoPlatform
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("vertical")]
        public string Vertical { get; set; }

        [JsonPropertyName("slot_price_original")]
        public string SlotPriceOriginal { get; set; }

        [JsonPropertyName("slot_price_original_float")]
        public float SlotPriceOriginalFloat { get { return float.Parse(SlotPriceOriginal, CultureInfo.InvariantCulture); } }

        [JsonPropertyName("info_color")]
        public string InfoColor { get; set; }

        [JsonPropertyName("info_logo_colored")]
        public string InfoLogoColored { get; set; }

        [JsonPropertyName("info_logo_transparent")]
        public string InfoLogoTransparent { get; set; }

        [JsonPropertyName("stats_active_group_members")]
        public int StatsActiveGroupMembers { get; set; }
    }
}