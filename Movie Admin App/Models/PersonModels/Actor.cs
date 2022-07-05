using Movie_Admin_App.Models.MovieModels;
using Movie_Admin_App.Models.PersonModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Admin_App.Models
{
    public class Actor : Person
    {
        [NotMapped]
        public List<Movie>? Movies { get; set; } = new();
    }
}
