using Movie_Admin_App.Models.MovieModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Admin_App.Models.PersonModels
{
    public class Person : PersonCreateModel
    {
        [Column(Order = 0)]
        public int Id { get; set; }


        public Country? Country { get; set; }


        [Column(Order = 7)]
        [StringLength(15)]
        public new string? Image { get; set; }


        public List<ActorMovie>? ActorMovies { get; set; } = new();


        public List<Movie>? Movies { get; set; } = new();
    }
}
