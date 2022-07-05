using Movie_Admin_App.Controllers;
using Movie_Admin_App.Models.PersonModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Admin_App.Models.MovieModels
{
    public class Movie : MovieCreateModel
    {
        [Column(Order = 5)]
        public int? Duration { get; set; }


        [Column(Order = 6)]
        public int Views { get; set; } = 1;


        [Column(Order = 7)]
        public int Voters { get; set; } = 1;


        [Column(Order = 8)]
        public int Stars { get; set; } = 1;


        [Column(Order = 9)]
        [StringLength(15)]
        public new string? Image { get; set; }


        [StringLength(15)]
        [Column("VideoFileName", Order = 10)]
        public new string? Video { get; set; }


        public Director? Director { get; set; }


        public List<ActorMovie>? ActorMovies { get; set; } = new();

        public List<CountryMovie>? CountryMovies { get; set; } = new();

        public List<GenreMovie>? GenreMovies { get; set; } = new();
    }
}
