using AutoMapper;
using Azure;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private CodeCineContext _context;
    private IMapper _mapper;

    public FilmeController(CodeCineContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> GetMovies(
        [FromQuery] int skip = 0, 
        [FromQuery] int take = 20)
        => _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));

    [HttpGet("{id}")]
    public IActionResult? GetMovieById(int id)
    {
        var movie = _context.Filmes.FirstOrDefault(m => m.Id == id);
        if(movie is null) return NotFound();
        var movieDto = _mapper.Map<ReadFilmeDto>(movie);
        return Ok(movie);
    }

    [HttpPost]
    public IActionResult AddMovie([FromBody] CreateFilmeDto movieDto)
    {
        Filme movie = _mapper.Map<Filme>(movieDto);
        _context.Filmes.Add(movie);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetMovieById), new { id = movie.Id }, movie);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateMovie(int id, UpdateFilmeDto updateMovieDto)
    {
        var movie = _context.Filmes.FirstOrDefault(m => m.Id == id);
        if(movie is null) return NotFound();
        _mapper.Map(updateMovieDto, movie);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateMovieParcial(int id, 
        JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var movie = _context.Filmes.FirstOrDefault(m => m.Id == id);
        if (movie is null) return NotFound();

        var movieToPatch = _mapper.Map<UpdateFilmeDto>(movie);

        patch.ApplyTo(movieToPatch, ModelState);
        if(!TryValidateModel(movie))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(movieToPatch, movie);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteMovie(int id) 
    {
        var movie = _context.Filmes.FirstOrDefault(m => m.Id == id);
        if(movie is null) return NotFound();

        _context.Remove(movie);
        _context.SaveChanges();

        return NoContent();
    }
}
