using LsoAPI.Entities;

namespace LsoAPI.GuessSets
{
    public class GuessSongData : GuessSet
    {
        public GuessSongData(int songsCountExpected, LsoDbContext dbContext) : base(songsCountExpected, dbContext)
        { 
        }

        protected override void SetQuestion()
        {
            _question = GetRandLine(_correctSong);
        }
        protected override void SetAnswer()
        {
            _correct = _correctSong.Title;
        }
        protected override void SetFalseSet()
        {
            _falseSet = _dbContext.Songs.Where(p => _falseSongsIds.Contains(p.Id)).Select(s => s.Title).ToList();
        }
    }
}
