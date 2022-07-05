using Microsoft.EntityFrameworkCore;
using Movie_Admin_App.Models;
using Movie_Admin_App.Models.MovieModels;
using Movie_Admin_App.Models.PersonModels;

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
            modelBuilder.Entity<ActorMovie>()
                .HasKey(bc => new { bc.ActorId, bc.MovieId });
            modelBuilder.Entity<ActorMovie>()
                .HasOne(bc => bc.Actor)
                .WithMany(b => b.ActorMovies)
                .HasForeignKey(bc => bc.ActorId);
            modelBuilder.Entity<ActorMovie>()
                .HasOne(bc => bc.Movie)
                .WithMany(b => b.ActorMovies)
                .HasForeignKey(bc => bc.MovieId);

            modelBuilder.Entity<GenreMovie>()
                .HasKey(bc => new { bc.GenreId, bc.MovieId });
            modelBuilder.Entity<GenreMovie>()
                .HasOne(bc => bc.Genre)
                .WithMany(b => b.GenreMovies)
                .HasForeignKey(bc => bc.GenreId);
            modelBuilder.Entity<GenreMovie>()
                .HasOne(bc => bc.Movie)
                .WithMany(b => b.GenreMovies)
                .HasForeignKey(bc => bc.MovieId);

            modelBuilder.Entity<CountryMovie>()
                .HasKey(bc => new { bc.CountryId, bc.MovieId });
            modelBuilder.Entity<CountryMovie>()
                .HasOne(bc => bc.Country)
                .WithMany(b => b.CountryMovies)
                .HasForeignKey(bc => bc.CountryId);
            modelBuilder.Entity<CountryMovie>()
                .HasOne(bc => bc.Movie)
                .WithMany(b => b.CountryMovies)
                .HasForeignKey(bc => bc.MovieId);
        }
    }
}
