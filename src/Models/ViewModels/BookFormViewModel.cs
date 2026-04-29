using System.ComponentModel.DataAnnotations;

namespace Visual.Models.ViewModels
{
    public class BookFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(150, ErrorMessage = "Title cannot exceed 150 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is required")]
        [MaxLength(100, ErrorMessage = "Author cannot exceed 100 characters")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "Genre is required")]
        [MaxLength(80, ErrorMessage = "Genre cannot exceed 80 characters")]
        public string Genre { get; set; } = string.Empty;

        [Display(Name = "Published Year")]
        [Range(1450, 2100, ErrorMessage = "Published year must be between 1450 and 2100")]
        public int PublishedYear { get; set; }

        [Display(Name = "Copies Available")]
        [Range(0, 1000, ErrorMessage = "Copies available must be between 0 and 1000")]
        public int CopiesAvailable { get; set; }
    }
}
