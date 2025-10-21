using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class CreateCinemaDto
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(80, ErrorMessage = "Name must be less than 80 characters")]
    public string Name { get; set; }
    public int AddressId { get; set; }
}
