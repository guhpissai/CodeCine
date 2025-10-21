using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Cinema
{
    [Required]
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    [MaxLength(80, ErrorMessage = "Name must be less than 100 characters")]
    public string Name { get; set; }
    public int AddressId { get; set; }
    public virtual Endereco Address { get; set; }
}
