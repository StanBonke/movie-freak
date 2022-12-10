using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieFreak.Models;
using System;

namespace MovieFreak.Data
{
    public class MfContext : IdentityDbContext<IdentityUser>
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
            base.OnModelCreating(mb);

            mb.HasDefaultSchema("MovieFreakDb");
            mb.Entity<Film>().ToTable("Film");
            mb.Entity<FilmTaal>().ToTable("Filmtaal");
            mb.Entity<Genre>().ToTable("Genre");
            mb.Entity<Personage>().ToTable("Personage");
            mb.Entity<Persoon>().ToTable("Persoon");
            mb.Entity<Taal>().ToTable("Taal");

            mb.Entity<Film>()
                .HasOne(g => g.Genre)
                .WithMany(x => x.Films)
                .HasForeignKey(g => g.GenreId)
                .IsRequired();

            mb.Entity<Personage>()
                .HasOne(p => p.Persoon)
                .WithMany(x => x.Personages)
                .HasForeignKey(p => p.PersoonId)
                .IsRequired();

            mb.Entity<Personage>()
                .HasOne(f => f.Film)
                .WithMany(x => x.Personages)
                .HasForeignKey(f => f.FilmId)
                .IsRequired();

            mb.Entity<FilmTaal>()
                .HasOne(t => t.Taal)
                .WithMany(x => x.FilmTalen)
                .HasForeignKey(t => t.TaalId)
                .IsRequired();

            mb.Entity<FilmTaal>()
                .HasOne(f => f.Film)
                .WithMany(x => x.FilmTalen)
                .HasForeignKey(f => f.FilmId)
                .IsRequired();
        }
    }
}