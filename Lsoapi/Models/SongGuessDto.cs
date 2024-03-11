using Microsoft.IdentityModel.Tokens;

namespace LsoAPI.Models
{
    public class SongGuessDto
    {
        private string _correctSong;
        private List<string> _falseSongs;
        private string _line;
        public string CorrectSong { get => _correctSong; 
            private set 
            { 
                if(!value.IsNullOrEmpty())
                    _correctSong = value;
                else
                    throw new ArgumentNullException(nameof(value));
            } }
        public List<string> FalseSongs { get => _falseSongs; 
            private set
            {
                if(value is not null && value.Count>0 && !value.IsNullOrEmpty())
                    _falseSongs = value;
                else
                    throw new ArgumentException(nameof(value));
            } }
        public string Line { get => _line; 
            private set 
            { 
                if(!value.IsNullOrEmpty())
                    _line = value;
                else
                    throw new ArgumentException(nameof(value));
            } }
        public SongGuessDto(string correctSong, List<string> falseSongs, string line)
        {
            CorrectSong = correctSong;
            FalseSongs = falseSongs;
            Line = line;
        }
    }
}
