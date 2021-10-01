using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PulpoChecker.DTO
{
    public class PulpoData
    {
        [JsonPropertyName("groups")]
        public IEnumerable<PulpoGroup> Groups { get; set; }
    }
}