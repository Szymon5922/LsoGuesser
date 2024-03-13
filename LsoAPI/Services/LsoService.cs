using AutoMapper;
using LsoAPI.Entities;
using LsoAPI.Models;
using LsoAPI.Helpers;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace LsoAPI.Services
{
    public class LsoService : ILsoService
    {
        private readonly LsoDbContext _dbContext;
        private readonly IMapper _mapper;
        public LsoService(LsoDbContext dbContext, IMapper mapper) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Create(CreateSongDto dto)
        {
            var song = _mapper.Map<Song>(dto);                                                
            _dbContext.Add(song);
            _dbContext.SaveChanges();

            return song.Id;
        }

        public bool Delete(int id)
        {
            Song? song = _dbContext.Songs.FirstOrDefault(p => p.Id == id);
            if (song is null)
                return false;
            
            _dbContext.Songs.Remove(song);
            _dbContext.SaveChanges();
            return true;
        }

        public IEnumerable<SongDto> GetAll()
        {
            List<Song> songs = _dbContext.Songs
                .Include(t => t.Lines)
                .ToList();
            var songsDto = _mapper.Map<List<SongDto>>(songs);

            return songsDto;
        }
        public SongDto GetRandom()
        {
            Song song = _dbContext.Songs
                .OrderBy(r => Guid.NewGuid())
                .Include(t => t.Lines)
                .First();

            var songDto = _mapper.Map<SongDto>(song);

            return songDto;
        }

        public SongDto GetById(int id)
        {
            Song? song = _dbContext.Songs
                .Include(p => p.Lines)
                .FirstOrDefault(p => p.Id == id);
            //return _mapper.Map<SongDto>(song) ?? throw new Exception("Not found");
            return _mapper.Map<SongDto>(song);
        }


        public LineGuessDto GetRandomLineGuessData(int songsToTake)
        {
            GuessSet guessSet = new GuessSet(songsToTake, _dbContext);
            List<string> falseLines = new();
            foreach(int songId in guessSet.FalseSet)
            {
                falseLines.Add(guessSet.GetRandLine(songId));
            }
            LineGuessDto lineGuessDto = new LineGuessDto()
            {
                Song = guessSet.CorrectSong.Title,
                FalseLines = falseLines,
                RightLine = guessSet.GetRandLine(guessSet.CorrectSong)
            };

            return lineGuessDto;

        }

        public SongGuessDto GetRandomSongGuessData(int songsToTake)
        {
            GuessSet guessSet = new GuessSet(songsToTake,_dbContext);
            
            List<string> falseSongsTitles = _dbContext.Songs
                .Where(p => guessSet.FalseSet.Contains(p.Id))
                .Select(x =>x.Title)
                .ToList();

            SongGuessDto songGuessData = new SongGuessDto(guessSet.CorrectSong.Title
                ,falseSongsTitles
                ,guessSet.GetRandLine(guessSet.CorrectSong));

            return songGuessData;
        }

        public void Update(int id, CreateSongDto song)
        {
            throw new NotImplementedException();
        }
    }
}
