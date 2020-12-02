using Microsoft.AspNetCore.Mvc;
using DataServiceLib.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SubProject.Attributes;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/bookmarks")]
    [Authorization]
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

        [HttpGet("titles/{userName}")]
        public IActionResult ShowUsersBookmarksTitles(string userName, int page = 0, int pagesize = 10)
        {
            var data = ds.GetUsersBookmarksTitles(userName, page, pagesize);
            return Ok(data);
        }
        [HttpGet("actors/{userName}")]
        public IActionResult ShowUsersBookmarksActors(string userName, int page = 0, int pagesize = 10)
        {
            var data = ds.GetUsersBookmarksActors(userName, page, pagesize);
            return Ok(data);
        }

    }
}
