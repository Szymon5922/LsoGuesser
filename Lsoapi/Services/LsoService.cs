using AutoMapper;
using LsoAPI.Entities;
using LsoAPI.Models;
using LsoAPI.GuessSets;
using LsoAPI.Exceptions;
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

        public void Delete(int id)
        {
            Song? song = _dbContext.Songs.FirstOrDefault(p => p.Id == id);
            
            if (song is null)
                throw new SongNotFoundException();
            
            _dbContext.Songs.Remove(song);
            _dbContext.SaveChanges();
        }
        public SongDto GetRandom()
        {
            Song song = _dbContext.Songs
                .Include(t => t.Lines)
                .OrderBy(r => Guid.NewGuid())
                .First();

            var songDto = _mapper.Map<SongDto>(song);

            return songDto;
        }

        public IEnumerable<SongDto> GetAll()
        {
            List<Song> songs = _dbContext.Songs
                .Include(t => t.Lines)
                .ToList();
            var songsDto = _mapper.Map<List<SongDto>>(songs);

            return songsDto;
        }
        public SongDto GetById(int id)
        {
            Song? song = _dbContext.Songs
                .Include(p => p.Lines)
                .FirstOrDefault(p => p.Id == id);

            if (song is null)
                throw new SongNotFoundException();

            return _mapper.Map<SongDto>(song);
        }

        public GuessSet GetRandomLineGuessData(int songsToTake)
        {
            GuessSet guessSet = new GuessLineData(songsToTake, _dbContext);            
            return guessSet;
        }

        public GuessSet GetRandomSongGuessData(int songsToTake)
        {
            GuessSet guessSet = new GuessSongData(songsToTake,_dbContext);
            return guessSet;
        }

        public void Update(int id, CreateSongDto song)
        {
            throw new NotImplementedException();
        }
    }
}
