using System.Text.Json.Serialization;

namespace PulpoChecker.DTO
{
    public class PulpoResponseContent
    {
        [JsonPropertyName("data")]
        public PulpoData Data { get; set; }
    }
}
