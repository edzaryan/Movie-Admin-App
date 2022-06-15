using System.ComponentModel.DataAnnotations;

namespace Movie_Admin_App.ViewModels
{
    public class UpdateMovieViewModel
    {
        [StringLength(100)]
        public string? Title { get; set; }


        public int? Year { get; set; }


        [StringLength(1000)]
        public string? Description { get; set; }


        public IFormFile? UploadedImage { get; set; }


        public IFormFile? UploadedVideo { get; set; }
    }
}
