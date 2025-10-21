using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos
{
    public class ReadEnderecoDto
    {
        public string AddressLine1 { get; set; }
        public int Number { get; set; }
    }
}
