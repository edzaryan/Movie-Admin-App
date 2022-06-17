using System.ComponentModel.DataAnnotations;

namespace Movie_Admin_App.Models
{
    public class Movie
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please enter movie title")]
        [StringLength(100)]
        public string? Title { get; set; }


        [Required(ErrorMessage = "Please enter release year")]
        public int? Year { get; set; }


        [Required(ErrorMessage = "Please enter description")]
        [StringLength(1000)]
        public string? Description { get; set; }


        [Required(ErrorMessage = "Please enter the duration")]
        public int Duration { get; set; }


        public int Views { get; set; } = 0;


        public int Voters { get; set; } = 0;


        public int Stars { get; set; } = 0;


        [Required(ErrorMessage = "Please enter image file name")]
        [Display(Name = "ImageFileName")]
        [StringLength(15)]
        public string? Image { get; set; }


        [Required(ErrorMessage = "Please enter video file name")]
        [StringLength(15)]
        public string? VideoFileName { get; set; }


        public int? DirectorId { get; set; }
        public Director? Director { get; set; }

        public List<ActorMovie>? ActorMovies { get; set; }

        public List<CountryMovie>? CountryMovies { get; set; }

        public List<GenreMovie>? GenreMovies { get; set; }
    }
}
