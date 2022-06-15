using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Admin_App.Models
{
    public class Actor
    {
        public int Id { get; set; }


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
        [Column("Biography")]
        [StringLength(1000)]
        public string? Bio { get; set; }


        [Required(ErrorMessage = "Please enter the image file name")]
        [Column("ImageFileName")]
        [StringLength(15)]
        public string? Image { get; set; }


        public int? CountryId { get; set; }
        public Country? Country { get; set; }


        public List<Movie>? Movies { get; set; }
        public List<ActorMovie>? ActorMovies { get; set; }
    }
}
 