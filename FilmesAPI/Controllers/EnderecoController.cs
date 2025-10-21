using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private readonly CodeCineContext _context;
    private readonly IMapper _mapper;

    public EnderecoController(CodeCineContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> GetEnderecos([FromQuery] int skip, [FromQuery] int take = 20)
        => _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.Skip(skip).Take(take).ToList());

    [HttpGet("{id}")]
    public ReadEnderecoDto GetEnderecoById(int id)
        => _mapper.Map<ReadEnderecoDto>(_context.Enderecos.FirstOrDefault(c => c.Id == id));

    [HttpPost]
    public IActionResult AddEndereco(CreateEnderecoDto EnderecoDto)
    {
        Endereco address = _mapper.Map<Endereco>(EnderecoDto);
        _context.Add(address);

        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEnderecoById), new { id = address.Id }, address);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEndereco(int id, UpdateEnderecoDto EnderecoDto)
    {
        var Endereco = _context.Enderecos.FirstOrDefault(c => c.Id == id);

        if (Endereco is null) NotFound();

        _mapper.Map(EnderecoDto, Endereco);
        _context.SaveChanges();
        return NoContent();
    }
}
