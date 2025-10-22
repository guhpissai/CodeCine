using FilmesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CodeCine.Models;

public class Sessao
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int FilmeId { get; set; }
    public virtual Filme Filme { get; set; }
}
