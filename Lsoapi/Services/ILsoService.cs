using LsoAPI.GuessSets;
using LsoAPI.Models;

namespace LsoAPI.Services
{
    public interface ILsoService
    {
        IEnumerable<SongDto> GetAll();
        SongDto GetRandom();
        SongDto GetById(int id);
        GuessSet GetRandomSongGuessData(int songsToTake);
        GuessSet GetRandomLineGuessData(int songsToTake);
        int Create(CreateSongDto song);
        void Update(int id, CreateSongDto song);
        void Delete(int id);
    }
}
