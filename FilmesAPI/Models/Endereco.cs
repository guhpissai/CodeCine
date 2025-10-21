using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models
{
    public class Endereco
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [MaxLength(100, ErrorMessage = "Address must be less than 100 characters")]
        public string AddressLine1 { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public int Number { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}
