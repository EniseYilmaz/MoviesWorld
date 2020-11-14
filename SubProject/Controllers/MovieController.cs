using Microsoft.AspNetCore.Mvc;
using DataServiceLib.DataServices;
using AutoMapper;
using SubProject.Dto;
using DataServiceLib.Models;
using System.Collections.Generic;
using SubProject.Attributes;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/movies")]
    [Authorization]
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
            var data = (TitleBasics)ds.GetMovie(id);

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
            var titlebasics = (IList <TitleBasics>)ds.GetMovies(page, pagesize);
            var dto = _mapper.Map<IList<MovieDto>>(titlebasics);

            return Ok(dto.ToJson());
        }
    }
}
