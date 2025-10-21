using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateEnderecoDto
    {
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address must be less than 100 characters")]
        public string AddressLine1 { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public int Number { get; set; }
    }
}
