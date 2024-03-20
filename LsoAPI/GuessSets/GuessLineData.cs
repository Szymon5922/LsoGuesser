using LsoAPI.Entities;
using LsoAPI.Models;

namespace LsoAPI.GuessSets
{
    public class GuessLineData : GuessSet
    {
        public GuessLineData(int songsCountExpected, LsoDbContext dbContext) : base(songsCountExpected, dbContext)
        {}
        protected override string SetQuestion() => _correctSong.Title;        
        protected override List<AnswerDto> SetAnswers()
        {
            List<string> randLines = new();
            
            foreach(int id in _falseSongsIds) 
                randLines.Add(GetRandLine(id));

            List<AnswerDto> answers = new();

            foreach(string line in randLines)
            {
                answers.Add(new AnswerDto(line,false));
            }

            answers.Add(new AnswerDto(GetRandLine(_correctSong), true));

            return answers;
        }
    }
}
