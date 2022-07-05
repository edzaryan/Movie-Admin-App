using Movie_Admin_App.Controllers;
using System.ComponentModel.DataAnnotations;

namespace Movie_Admin_App.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter genre name")]
        [StringLength(40)]
        public string? Name { get; set; }

        public List<GenreMovie>? GenreMovies { get; set; } = new();
    }
}
