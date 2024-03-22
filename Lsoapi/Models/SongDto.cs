namespace LsoAPI.Models
{
    public class SongDto
    {
        public string Title { get; set; }
        public List<string> Lines { get; set; }
        public string? VideoUrl { get; set; }
    }
}
