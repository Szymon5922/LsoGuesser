using System.Text.Json.Serialization;

namespace LsoWebApp.Models
{
    public class GuessSetModel
    {
        [JsonPropertyName("question")]
        public string Question { get; set; }
        [JsonPropertyName("answers")]
        public List<AnswerModel> Answers { get; set; }
        [JsonPropertyName("videoUrl")]
        public string? ViedoUrl { get; set; }

    }
}
