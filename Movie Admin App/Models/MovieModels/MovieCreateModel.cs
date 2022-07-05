using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Admin_App.Models.MovieModels
{
    public class MovieCreateModel : MoviePatchModel
    {
        [Column(Order = 0)]
        public int Id { get; set; }


        [Column(Order = 1)]
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter the movie title")]
        public new string? Title { get; set; }


        public IFormFile? Image { get; set; }


        public IFormFile? Video { get; set; }
    }
}
