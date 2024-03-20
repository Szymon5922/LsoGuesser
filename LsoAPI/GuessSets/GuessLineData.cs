using LsoAPI.Entities;

namespace LsoAPI.GuessSets
{
    public class GuessLineData : GuessSet
    {
        public GuessLineData(int songsCountExpected, LsoDbContext dbContext) : base(songsCountExpected, dbContext)
        {}
        protected override string SetQuestion() => _correctSong.Title;        
        protected override string SetAnswer() => GetRandLine(_correctSong);        
        protected override List<string> SetFalseSet()
        {
            List<string> verses = new();
            foreach(int id in _falseSongsIds) 
            {
                verses.Add(GetRandLine(id));
            }
            return verses;
        }
    }
}
