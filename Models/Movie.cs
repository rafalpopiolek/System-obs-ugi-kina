using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tytuł filmu")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Opis filmu")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Czas trwania")]
        public int Duration { get; set; }
    }
}
