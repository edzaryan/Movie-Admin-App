using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Admin_App.Models.PersonModels
{
    public class PersonCreateModel : PersonPatchModel
    {
        [Column(Order = 1)]
        [StringLength(30)]
        [Required(ErrorMessage = "Please enter actor's Firstname")]
        public new string? FirstName { get; set; }


        [Column(Order = 2)]
        [StringLength(30)]
        [Required(ErrorMessage = "Please enter actor's Lastname")]
        public new string? LastName { get; set; }
    }
}
