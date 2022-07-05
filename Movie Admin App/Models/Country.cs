using System.ComponentModel.DataAnnotations;

namespace Movie_Admin_App.Models
{
    public class Country
    {
        public int Id { get; set; }


        [StringLength(50)]
        [Required(ErrorMessage = "Please enter country name")]
        public string? Name { get; set; }

        public List<Actor>? Actors { get; set; }

        public List<CountryMovie>? CountryMovies { get; set; } = new();
    }
}
