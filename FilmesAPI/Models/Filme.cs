using CodeCine.Models;
using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage ="O título é obrigatório.")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O genêro é obrigatório.")]
    [MaxLength(100, ErrorMessage ="O título deve ter no maximo 100 caracteres.")]
    public string Genero { get; set; }
    [Required(ErrorMessage ="A duração é obrigatória.")]
    [Range(0,180, ErrorMessage ="A duração deve ser entre 0 e 180 minutos.")]
    public int Duracao { get; set; }
    public virtual ICollection<Sessao> Sessoes { get; set; }
}
