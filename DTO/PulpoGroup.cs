using System.Globalization;
using System.Text.Json.Serialization;

namespace PulpoChecker.DTO
{
    public class PulpoGroup
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("owner_id")]
        public int OwnerId { get; set; }

        [JsonPropertyName("mask")]
        public string Mask { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("public")]
        public bool Public { get; set; }

        [JsonPropertyName("slot_num_total")]
        public int SlotNumTotal { get; set; }

        [JsonPropertyName("slot_num_available")]
        public int SlotNumAvailable { get; set; }

        [JsonPropertyName("slot_price")]
        public string SlotPrice { get; set; }

        [JsonPropertyName("slot_price_float")]
        public float SlotPriceFloat { get { return float.Parse(SlotPrice, CultureInfo.InvariantCulture); } }

        [JsonPropertyName("slot_fee")]
        public string SlotFee { get; set; }

        [JsonPropertyName("slot_fee_float")]
        public float SlotFeeFloat { get { return float.Parse(SlotFee, CultureInfo.InvariantCulture); } }

        [JsonPropertyName("allow_enrollments")]
        public bool AllowEnrollments { get; set; }

        [JsonPropertyName("slot_to_pay")]
        public string SlotToPay { get; set; }

        [JsonPropertyName("slot_to_pay_float")]
        public float SlotToPayFloat { get { return float.Parse(SlotToPay, CultureInfo.InvariantCulture); } }

        [JsonPropertyName("platform")]
        public PulpoPlatform Platform { get; set; }

        [JsonPropertyName("owner")]
        public PulpoOwner Owner { get; set; }
    }
}