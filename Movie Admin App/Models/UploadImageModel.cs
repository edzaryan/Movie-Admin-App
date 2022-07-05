using System.ComponentModel.DataAnnotations;

namespace Movie_Admin_App.Models
{
    public class UploadImageModel
    {
        [Required(ErrorMessage = "Please enter the image file")]
        public IFormFile? Image { get; set; }
    }
}
