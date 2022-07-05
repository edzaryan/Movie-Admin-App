using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Admin_App.Models.MovieModels
{
    public class MoviePatchModel
    {
        [StringLength(100)]
        public string? Title { get; set; }

        [Column(Order = 2)]
        public int? Year { get; set; }


        [Column("Description", Order = 3)]
        [StringLength(1000)]
        public string? Desc { get; set; }


        [Column(Order = 4)]
        public int? DirectorId { get; set; }


        [NotMapped]
        public string? ActorIds { get; set; }
    }
}
