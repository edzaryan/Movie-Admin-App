using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Admin_App.CustomModels
{
    public class CreateActorModel
    {
        [Required(ErrorMessage = "Please enter first name")]
        [StringLength(30)]
        public string? FirstName { get; set; }


        [Required(ErrorMessage = "Please enter last name")]
        [StringLength(30)]
        public string? LastName { get; set; }


        [Required(ErrorMessage = "Please enter height")]
        public double? Height { get; set; }


        [Required(ErrorMessage = "Please enter birthday")]
        public DateTime? Birthday { get; set; }


        [Required(ErrorMessage = "Please enter the biography")]
        [StringLength(1000)]
        public string? Bio { get; set; }


        [Required(ErrorMessage = "Please enter the image file name")]
        //[StringLength(15)]
        public IFormFile? UploadedImage { get; set; }

        
        [Required(ErrorMessage = "Please enter the actor country")]
        public int? CountryId { get; set; }
    }
}
