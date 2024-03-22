using LsoAPI.Entities;
namespace LsoAPI.Models
{
    public class CreateSongDto
    {
        public string Title { get; set; }
        public List<string> Lyrics { get; set; }
        public string VideoUrl { get; set; }
    }
}
