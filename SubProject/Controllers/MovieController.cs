using Microsoft.AspNetCore.Mvc;
using DataServiceLib.DataServices;
using AutoMapper;
using SubProject.Dto;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMoviesDS ds;

        public MovieController(IMoviesDS dataservice, IMapper mapper)
        {
            ds = dataservice;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(string id)
        {
            var data = ds.GetMovie(id);

            if(data == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<MovieDto>(data);
            return Ok(dto);
        }

        [HttpGet("similar/{movieTitle}")]
        public IActionResult SimilarMovies(string movieTitle)
        {
            var data = ds.SimilarMovies(movieTitle);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult GetMovies(int page = 0, int pagesize = 10)
        {
            var titlebasics = ds.GetMovies(page, pagesize);
            var dto = _mapper.Map<MovieDto>(titlebasics);

            return Ok(dto.ToJson());
        }
    }
}
