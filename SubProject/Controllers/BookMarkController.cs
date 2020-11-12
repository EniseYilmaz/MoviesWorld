using Microsoft.AspNetCore.Mvc;
using SubProject.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/bookmark")]
    public class BookMarkController : ControllerBase
    {
        IBookMarkDS ds;

        public BookMarkController(IBookMarkDS dataservice)
        {
            ds = dataservice;
        }

        [HttpGet("movie/add/{userName}/{movieId}")]
        public IActionResult AddMovieBookMark(string userName, string movieId)
        {
            var data = ds.AddMovieBookMark(userName, movieId);
            return Ok(data);
        }

        [HttpGet("movie/remove/{userName}/{movieId}")]
        public IActionResult RemoveMovieBookMark(string userName, string movieId)
        {
            var data = ds.RemoveMovieBookMark(userName, movieId);
            return Ok(data);
        }

        [HttpGet("person/add/{userName}/{personId}")]
        public IActionResult AddNameBookMark(string userName, string personId)
        {
            var data = ds.AddNameBookMark(userName, personId);
            return Ok(data);
        }

        [HttpGet("person/remove/{userName}/{personId}")]
        public IActionResult RemoveNameBookMark(string userName, string personId)
        {
            var data = ds.RemoveNameBookMark(userName, personId);
            return Ok(data);
        }
    }
}
