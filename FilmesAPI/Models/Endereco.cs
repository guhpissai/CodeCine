using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Endereco
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "O logradouro é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O logradouro deve ter no máximo {1} caracteres.")]
    public string Logradouro { get; set; } = string.Empty;

    [Required(ErrorMessage = "O número é obrigatório.")]
    public int Numero { get; set; }

    public virtual Cinema? Cinema { get; set; }
}
