using Microsoft.AspNetCore.Mvc;
using SubProject.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/bookmarks")]
    public class BookMarkController : ControllerBase
    {
        IBookMarkDS ds;

        public BookMarkController(IBookMarkDS dataservice)
        {
            ds = dataservice;
        }

        [HttpGet]
        public IActionResult BookmarkPage()
        {

            // can be used with cookies to enter the bookmarks for the logged in user. LATER... The add bookmark, maybe
            var temp = new
            {
                Addmovietobookmarks = "http://localhost:5000/api/bookmarks/movie/add/{userName}/{movieId}",
                RemoveMoviefromBookmarks = "http://localhost:5000/api/bookmarks/movie/remove/{userName}/{movieId}",
                AddActortoBookmark = "http://localhost:5000/api/bookmarks/person/add/{userName}/{personId}",
                RemoveActorfromBookmark = "http://localhost:5000/api/bookmarks/person/remove/{userName}/{personId}",
                GetusersbookmarksTitles = "http://localhost:5000/api/bookmarks/titles/{userName}",
                GetusersbookmarksActors = "http://localhost:5000/api/bookmarks/actors/{userName}"
            };

        
            return Ok(temp.ToJson());
        }

        [HttpGet("title/add/{userName}/{movieId}")]
        public IActionResult AddMovieBookMark(string userName, string movieId)
        {
            var data = ds.AddMovieBookMark(userName, movieId);
            return Ok(data);
        }

        [HttpGet("title/remove/{userName}/{movieId}")]
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
            return Ok(data.ToJson());
        }
        [HttpGet("actors/{userName}")]
        public IActionResult ShowUsersBookmarksActors(string userName, int page = 0, int pagesize = 10)
        {
            var data = ds.GetUsersBookmarksActors(userName, page, pagesize);
            return Ok(data.ToJson());
        }

    }
}
