using System.Text.Json.Serialization;

namespace UtilitiesDB
{
    public class Config
    {
        [JsonPropertyName("Database")]
        public string Database { get; set; }

        [JsonPropertyName("User")]
        public string User { get; set; }

        [JsonPropertyName("Password")]
        public string Password { get; set; }

        [JsonPropertyName("Timeout")]
        public int Timeout { get; set; }

        [JsonPropertyName("Servers")]
        public string[] Servers { get; set; }
    }
}
