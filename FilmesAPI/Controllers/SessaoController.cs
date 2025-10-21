using AutoMapper;
using CodeCine.Data.Dtos;
using CodeCine.Models;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeCine.Controllers;

[ApiController]
[Route("[controller]")]
public class SessaoController : ControllerBase
{
    private readonly CodeCineContext _context;
    private readonly IMapper _mapper;

    public SessaoController(CodeCineContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ReadSessaoDto> GetSessaos([FromQuery] int skip, [FromQuery] int take = 20)
        => _mapper.Map<List<ReadSessaoDto>>(_context.Sessoes.Skip(skip).Take(take).ToList());

    [HttpGet("{id}")]
    public ReadSessaoDto GetSessaoById(int id)
        => _mapper.Map<ReadSessaoDto>(_context.Sessoes.FirstOrDefault(c => c.Id == id));

    [HttpPost]
    public IActionResult AddSessao(CreateSessaoDto sessaoDto)
    {
        Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
        _context.Add(sessao);

        _context.SaveChanges();
        return CreatedAtAction(nameof(GetSessaoById), new { id = sessao.Id }, sessao);
    }

    //[HttpPut("{id}")]
    //public IActionResult UpdateSessao(int id, UpdateSessaoDto sessaoDto)
    //{
    //    var sessao = _context.Sessoes.FirstOrDefault(s => s.Id == id);

    //    if (sessao is null) NotFound();

    //    _mapper.Map(sessaoDto, sessao);
    //    _context.SaveChanges();
    //    return NoContent();
    //}
}
