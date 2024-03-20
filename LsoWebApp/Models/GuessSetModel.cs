using System.Text.Json.Serialization;
using LsoWebApp.Extensions;

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
        public List<(string, bool)> Answers => GetAnswers();
        private List<(string,bool)> GetAnswers()
        {
            List<(string,bool)> answers = new List<(string, bool)>();
            foreach (string s in False)
            {
                answers.Add((s, false));
            }

            answers.Add((Correct, true));

            MyExtensions.Shuffle<(string, bool)>(answers);

            return answers;
        }

    }
}
