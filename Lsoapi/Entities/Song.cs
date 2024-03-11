using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace LsoAPI.Entities
{
    public class Song
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string Title { get; set; }
        public int LinesNumber { get; set; }
        public virtual List<Line> Lines { get; set; }
    }
}
