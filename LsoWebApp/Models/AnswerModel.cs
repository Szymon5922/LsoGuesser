using System.Text.Json.Serialization;

namespace LsoWebApp.Models
{
    public class AnswerModel
    {
        [JsonPropertyName("text")]
        public string Text { get; set; }
        [JsonPropertyName("isCorrect")]
        public bool IsCorrect { get; set; }
    }
}
