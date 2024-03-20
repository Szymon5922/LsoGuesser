using LsoAPI.Entities;

namespace LsoAPI.GuessSets
{
    public class GuessSongData : GuessSet
    {
        public GuessSongData(int songsCountExpected, LsoDbContext dbContext) : base(songsCountExpected, dbContext)
        {}
        protected override string SetQuestion() => GetRandLine(_correctSong);
        protected override string SetAnswer() => _correctSong.Title;
        protected override List<string> SetFalseSet() => _dbContext.Songs
                                                            .Where(p => _falseSongsIds.Contains(p.Id))
                                                            .Select(s => s.Title).ToList();        
    }
}
