namespace Movie_Admin_App.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Actor>? Actors { get; set; }
        public List<Director>? Directors { get; set; }

        public List<Movie>? Movies { get; set; }
        public List<CountryMovie>? CountryMovies { get; set; }

    }
}
