using System.ComponentModel.DataAnnotations;

namespace Movie_Admin_App.CustomModels
{
    public class UpdateActorModel
    {
        [StringLength(30)]
        public string? FirstName { get; set; }


        [StringLength(30)]
        public string? LastName { get; set; }


        public double? Height { get; set; }


        public DateTime? Birthday { get; set; }


        [StringLength(1000)]
        public string? Bio { get; set; }


        public IFormFile? UploadedImage { get; set; }


        public int? CountryId { get; set; }
    }
}
