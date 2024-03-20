using System.Text.Json.Serialization;

namespace LsoWebApp.Models
{
    public class GuessSetModel
    {
        [JsonPropertyName("question")]
        public string Question { get; set; }
        [JsonPropertyName("correct")]
        public string Correct { get; set; }
        [JsonPropertyName("falseSet")]
        public List<string> False { get; set; }
    }
}
