using LsoAPI.Models;

namespace LsoAPI.Services
{
    public interface ILsoService
    {
        IEnumerable<SongDto> GetAll();
        SongDto GetRandom();
        SongDto GetById(int id);
        SongGuessDto GetRandomSongGuessData(int songsToTake);
        LineGuessDto GetRandomLineGuessData(int songsToTake);
        int Create(CreateSongDto song);
        void Update(int id, CreateSongDto song);
        bool Delete(int id);
    }
}
