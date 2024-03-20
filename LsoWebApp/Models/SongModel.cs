using System.Text.Json.Serialization;

namespace LsoWebApp.Models
{
    public class SongModel
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("lines")]
        public List<string> Lines { get; set; }
    }
}
