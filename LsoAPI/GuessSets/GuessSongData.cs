using LsoAPI.Entities;
using LsoAPI.Models;

namespace LsoAPI.GuessSets
{
    public class GuessSongData : GuessSet
    {
        public GuessSongData(int songsCountExpected, LsoDbContext dbContext) : base(songsCountExpected, dbContext)
        {}
        protected override string SetQuestion() => GetRandLine(_correctSong);
        protected override List<AnswerDto> SetAnswers()
        {
            List<string> falseTitles = _dbContext.Songs
                .Where(p => _falseSongsIds.Contains(p.Id))
                .Select(s => s.Title)
                .ToList();

            List<AnswerDto> answers = new();

            foreach(string title in falseTitles)
                answers.Add(new AnswerDto(title,false));

            answers.Add(new AnswerDto(_correctSong.Title,true));

            return answers;
        }
    }
}
