using System.ComponentModel.DataAnnotations;

namespace Movie_Admin_App.Models
{
    public class UploadVideoModel
    {
        [Required(ErrorMessage = "Please enter the video file")]
        public IFormFile? VideoFile { get; set; }
    }
}
