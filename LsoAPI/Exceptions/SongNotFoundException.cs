namespace LsoAPI.Exceptions
{
    public class SongNotFoundException:Exception
    {
        public SongNotFoundException():base("Song not found")
        {
        }
    }
}
