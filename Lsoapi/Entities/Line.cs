using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace LsoAPI.Entities
{
    public class Line
    {
        public int Verse { get; set; }
        public int SongId { get; set; }
        [MaxLength(300)]
        public string Content { get; set; }
        public virtual Song Song { get; set; }
    }
}
