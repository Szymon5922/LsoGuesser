using LsoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LsoAPI.GuessSets
{
    public abstract class GuessSet
    {
        private static readonly Random _random = new Random();
        private readonly List<int> _avalibleSongsIds;
        protected readonly LsoDbContext _dbContext;
        protected Song _correctSong;
        protected string _correct;
        protected List<int> _falseSongsIds;
        protected List<string> _falseSet;
        protected string _question;
        public string Question => _question;
        public string Correct => _correct;
        public List<string> FalseSet => _falseSet;
        public int GetRand(int to) => _random.Next(1,to);
        
        public GuessSet(int songsCountExpected, LsoDbContext dbContext)
        {
            _dbContext = dbContext;            
            _avalibleSongsIds = _dbContext.Songs.Select(p=>p.Id).ToList();

            HashSet<int> randSet = new();
            
            while (randSet.Count < songsCountExpected)
                randSet.Add(_avalibleSongsIds[GetRand(_avalibleSongsIds.Count)]);

            int correctSongId = randSet.Last();
            _correctSong = _dbContext.Songs
                .Include(p => p.Lines)
                .First(s => s.Id == correctSongId);
            randSet.Remove(correctSongId);

            _falseSongsIds = randSet.ToList();

            _question = SetQuestion();
            _correct = SetAnswer();
            _falseSet = SetFalseSet();
        }

        protected abstract string SetQuestion();
        protected abstract string SetAnswer();
        protected abstract List<string> SetFalseSet();
        public string GetRandLine(Song song)
        {
            int randLineNo = GetRand(song.LinesNumber);
            return song.Lines.First(p => p.Verse == randLineNo).Content;
        }
        public string GetRandLine(int id)
        {
            int linesCount = _dbContext.Songs.First(p => p.Id == id).LinesNumber;
            return _dbContext.Lines.First(p=>p.SongId==id&&p.Verse==GetRand(linesCount)).Content;
        }
    }
}
