using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly CodeCineContext _context;
        private readonly IMapper _mapper;

        public CinemaController(CodeCineContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ReadCinemaDto> GetCinemas([FromQuery] int skip, [FromQuery] int take = 20)
            => _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.Skip(skip).Take(take).ToList());

        [HttpGet("{id}")]
        public ReadCinemaDto GetCinemaById(int id)
            => _mapper.Map<ReadCinemaDto>(_context.Cinemas.FirstOrDefault(c => c.Id == id));

        [HttpPost]
        public IActionResult AddCinema(CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
            _context.Add(cinema);

            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCinemaById), new { id = cinema.Id }, cinema);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCinema(int id, UpdateCinemaDto cinemaDto)
        {
            var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);

            if (cinema is null) NotFound();

            _mapper.Map(cinemaDto, cinema);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
