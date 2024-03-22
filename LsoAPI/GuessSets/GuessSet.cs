using LsoAPI.Entities;
using LsoAPI.Extensions;
using LsoAPI.Models;
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
        protected List<AnswerDto> _answers;
        protected string _question;
        public string Question => _question;
        public List<AnswerDto> Answers => _answers;
        public string? VideoUrl => _correctSong.VideoUrl;
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
            _answers = SetAnswers();

            _answers.Shuffle();
        }

        protected abstract string SetQuestion();
        protected abstract List<AnswerDto> SetAnswers();
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
