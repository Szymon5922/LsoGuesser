namespace LsoAPI.Models
{
    public class AnswerDto
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public AnswerDto(string text, bool isCorrect) 
        {
            Text = text;
            IsCorrect = isCorrect;
        }
        
    }
}
