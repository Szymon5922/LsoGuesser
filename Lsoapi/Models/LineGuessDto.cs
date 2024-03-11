namespace LsoAPI.Models
{
    public class LineGuessDto
    {
        public string RightLine { get; set; }
        public List<string> FalseLines { get; set; }
        public string Song { get; set; }
    }
}
