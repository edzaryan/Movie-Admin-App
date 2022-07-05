using Movie_Admin_App.Models.MovieModels;

namespace Movie_Admin_App.Models
{
    public class CountryMovie
    {
        public int CountryId { get; set; }
        public Country? Country { get; set; }

        public int MovieId { get; set; }
        public Movie? Movie { get; set; }
    }
}
