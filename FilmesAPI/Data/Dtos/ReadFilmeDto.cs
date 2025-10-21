using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dtos;

public class ReadFilmeDto
{
    public string Title { get; set; }
    public string Gender { get; set; }
    public int Duration { get; set; }
    public DateTime SearchTime { get; set; } = DateTime.Now;
}
