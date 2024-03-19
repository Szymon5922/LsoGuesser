using LsoAPI.Entities;

namespace LsoAPI.GuessSets
{
    public class GuessLineData : GuessSet
    {
        public GuessLineData(int songsCountExpected, LsoDbContext dbContext) : base(songsCountExpected, dbContext)
        {
        }

        protected override void SetQuestion()
        {
            _question = _correctSong.Title;
        }
        protected override void SetAnswer()
        {
            _correct = GetRandLine(_correctSong);
        }
        protected override void SetFalseSet()
        {
            List<string> verses = new();
            foreach(int id in _falseSongsIds) 
            {
                verses.Add(GetRandLine(id));
            }
            _falseSet = verses;
        }
    }
}
