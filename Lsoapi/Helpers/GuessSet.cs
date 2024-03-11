using LsoAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LsoAPI.Helpers
{
    public class GuessSet
    {
        private static readonly Random Rand = new Random();
        private readonly LsoDbContext _dbContext;
        private readonly List<int> _avalibleSongsIds;
        private int _answer;
        private List<int> _falseSet;
        private Song _correctSong;
        public int Answer { get=>_answer; }
        public List<int> FalseSet { get=>_falseSet; }
        public Song CorrectSong { get=>_correctSong; }
        public int GetRand(int to) => Rand.Next(1,to);
        
        public GuessSet(int count, LsoDbContext dbContext)
        {
            _dbContext = dbContext;            
            _avalibleSongsIds = _dbContext.Songs.Select(p=>p.Id).ToList();

            HashSet<int> randSet = new();
            
            while (randSet.Count < count)
                randSet.Add(_avalibleSongsIds[GetRand(_avalibleSongsIds.Count)]);
            

            _answer = randSet.Last();

            randSet.Remove(_answer);
            _falseSet = randSet.ToList();

            _correctSong = _dbContext.Songs.Include(x=>x.Lines).First(p => p.Id == _answer);
        }
        public string GetRandLine(Song song)
        {
            int chuj = GetRand(song.LinesNumber);
            return song.Lines.First(p => p.Verse == chuj).Content;
        }
        public string GetRandLine(int id)
        {
            int linesCount = _dbContext.Songs.First(p => p.Id == id).LinesNumber;
            return _dbContext.Lines.First(p=>p.SongId==id&&p.Verse==GetRand(linesCount)).Content;
        }
    }
}
