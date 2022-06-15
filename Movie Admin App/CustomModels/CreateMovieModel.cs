using System.ComponentModel.DataAnnotations;

namespace MovieWebAppAdmin.ViewModels
{
    public class CreateMovieModel
    {
        [Required(ErrorMessage = "Please enter title")]
        [StringLength(100)]
        public string? Title { get; set; }


        [Required(ErrorMessage = "Please enter release year")]
        public int Year { get; set; }


        [Required(ErrorMessage = "Please enter description")]
        [StringLength(1000)]
        public string? Description { get; set; }


        //[Required(ErrorMessage = "Please enter genres")]
        //public int[] Genres { get; set; }


        //[Required(ErrorMessage = "Please enter countires")]
        //public int[] Countries { get; set; }


        //[Required(ErrorMessage = "Please enter actors")]
        //public int[] Actors { get; set; }


        //[Required(ErrorMessage = "Please enter director")]
        //public int Director { get; set; }


        [Required(ErrorMessage = "Please choose movie image")]
        public IFormFile? UploadedImage { get; set; }


        [Required(ErrorMessage = "Please choose movie video file")]
        public IFormFile? UploadedVideo { get; set; }
    }
}
