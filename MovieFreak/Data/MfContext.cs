using Microsoft.EntityFrameworkCore;
using MovieFreak.Models;

namespace MovieFreak.Data
{
    public class MfContext : DbContext
    {
        public MfContext(DbContextOptions<MfContext> options) : base(options)
        {
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<FilmTaal> FilmTalen { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Personage> Personages { get; set; }
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Taal> Talen { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
        }
    }
}