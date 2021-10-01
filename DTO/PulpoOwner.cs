using System.Text.Json.Serialization;

namespace PulpoChecker.DTO
{
    public class PulpoOwner
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("image_avatar")]
        public string ImageAvatar { get; set; }

        [JsonPropertyName("is_phone_verified")]
        public bool IsPhoneVerified { get; set; }
    }
}