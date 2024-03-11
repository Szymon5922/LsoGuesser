using Microsoft.EntityFrameworkCore;

namespace LsoAPI.Entities
{
    public class LsoDbContext :DbContext
    {
        private string _connectionString = "Data Source=DESKTOP-BL6EN7A\\SQLEXPRESS;Initial Catalog=LsoDb;Integrated Security=True;Trust Server Certificate=True";
        public DbSet<Song> Songs { get; set; }
        public DbSet<Line> Lines { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Line>()
                .HasKey(new []{ "SongId", "Verse"});
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
