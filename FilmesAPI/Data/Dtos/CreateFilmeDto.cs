using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class CreateFilmeDto
{
    [Required(ErrorMessage = "O título é obrigatório.")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O genêro é obrigatório.")]
    [MaxLength(100, ErrorMessage = "O título deve ter no maximo 100 caracteres.")]
    public string Genero { get; set; }
    [Required(ErrorMessage = "A duração é obrigatória.")]
    [Range(0, 180, ErrorMessage = "A duração deve ser entre 0 e 180 minutos.")]
    public int Duracao { get; set; }
}
