using System.ComponentModel.DataAnnotations;

namespace Visual.Models.ViewModels
{
    public class CourseFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Course title is required")]
        [MaxLength(200)]
        [Display(Name = "Course Title")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required")]
        [MinLength(10, ErrorMessage = "Description should be at least 10 characters")]
        public string Description { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Hours must be between 1 and 100")]
        public int Hours { get; set; }

        [Required(ErrorMessage = "Instructor name is required")]
        [Display(Name = "Instructor Name")]
        public string Instructor { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        [Range(0, 5000)]
        public decimal Price { get; set; }
    }
}
