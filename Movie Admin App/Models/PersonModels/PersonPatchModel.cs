using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Admin_App.Models.PersonModels
{
    public class PersonPatchModel
    {
        [StringLength(30)]
        public string? FirstName { get; set; }


        [StringLength(30)]
        public string? LastName { get; set; }


        [Column(Order = 3)]
        public DateTime? Birthday { get; set; }


        [Column(Order = 4)]
        [Range(1.2, 2.1)]
        public double? Height { get; set; }


        [Column("Biography", Order = 5)]
        [StringLength(1000)]
        public string? Bio { get; set; }


        [Column(Order = 6)]
        public int? CountryId { get; set; }
    }
}
