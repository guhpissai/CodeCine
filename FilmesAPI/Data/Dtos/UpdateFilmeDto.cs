using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class UpdateFilmeDto
{
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Gender is required")]
    [StringLength(100, ErrorMessage = "The gender must be more than 100 characters")]
    public string Gender { get; set; }
    [Required(ErrorMessage = "The Duration is required")]
    [Range(0, 120, ErrorMessage = "Duration must be between 0 and 120")]
    public int Duration { get; set; }
}
