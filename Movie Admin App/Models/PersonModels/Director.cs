using Movie_Admin_App.Models.MovieModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Admin_App.Models.PersonModels
{
    public class Director : Person
    {
        [NotMapped]
        public List<ActorMovie>? ActorMovies { get; set; } = new();
    }
}
