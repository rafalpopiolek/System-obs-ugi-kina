using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Show
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Film")]
        public int MovieId { get; set; }
        [Required]
        [Display(Name = "Czas rozpoczęcia")]
        public DateTime MovieStart { get; set; }
        [Display(Name = "Film")]
        public Movie? Movie { get; set; }
    }
}
