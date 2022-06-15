using Microsoft.EntityFrameworkCore;
using Movie_Admin_App.Models;

namespace Movie_Admin_App.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<ActorMovie> ActorMovies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryMovie> CountryMovies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreMovie> GenreMovies { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MovieAdminApp;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Movie>()
                .HasMany(c => c.Actors)
                .WithMany(s => s.Movies)
                .UsingEntity<ActorMovie>(
                    j => j
                        .HasOne(pt => pt.Actor)
                        .WithMany(t => t.ActorMovies)
                        .HasForeignKey(pt => pt.ActorId),
                    j => j
                        .HasOne(pt => pt.Movie)
                        .WithMany(p => p.ActorMovies)
                        .HasForeignKey(pt => pt.MovieId),
                    j =>
                    {
                        j.HasKey(t => new { t.MovieId, t.ActorId });
                        j.ToTable("ActorMovie");
                    });


            modelBuilder
                .Entity<Movie>()
                .HasMany(c => c.Countries)
                .WithMany(s => s.Movies)
                .UsingEntity<CountryMovie>(
                    j => j
                        .HasOne(pt => pt.Country)
                        .WithMany(t => t.CountryMovies)
                        .HasForeignKey(pt => pt.MovieId),
                    j => j
                        .HasOne(pt => pt.Movie)
                        .WithMany(p => p.CountryMovies)
                        .HasForeignKey(pt => pt.MovieId),
                    j =>
                    {
                        j.HasKey(t => new { t.MovieId, t.CountryId });
                        j.ToTable("CountryMovie");
                    });


            modelBuilder
                .Entity<Movie>()
                .HasMany(c => c.Genres)
                .WithMany(s => s.Movies)
                .UsingEntity<GenreMovie>(
                    j => j
                        .HasOne(pt => pt.Genre)
                        .WithMany(t => t.GenreMovies)
                        .HasForeignKey(pt => pt.MovieId),
                    j => j 
                        .HasOne(pt => pt.Movie)
                        .WithMany(p => p.GenreMovies)
                        .HasForeignKey(pt => pt.MovieId),
                    j =>
                    {
                        j.HasKey(t => new { t.MovieId, t.GenreId });
                        j.ToTable("GenreMovie");
                    });
        }
    }
}
