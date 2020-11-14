using Microsoft.AspNetCore.Mvc;
using SubProject.DataServices;
using System;
using System.Collections.Generic;
namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/movies")]
    public class MovieController : ControllerBase
    {
        IMoviesDS ds;

        public MovieController(IMoviesDS dataservice)
        {
            ds = dataservice;
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(string id)
        {
            var data = ds.GetMovie(id);
            return Ok(data);
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

            return Ok(titlebasics.ToJson());
        }
    }
}
