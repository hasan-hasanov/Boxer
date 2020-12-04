using System.Text.Json.Serialization;

namespace Boxer.Models
{
    public class Configuration
    {
        [JsonPropertyName("args")]
        public string[] Args { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
