using Microsoft.AspNetCore.Mvc;
using SubProject.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/favorites")]
    public class FavoriteController : ControllerBase
    {
        IFavoriteDS ds;
        public FavoriteController(IFavoriteDS dataservice)
        {
            ds = dataservice;
        }

        [HttpGet]
        public IActionResult BookmarkPage()
        {

            // can be used with cookies to enter the bookmarks for the logged in user. LATER... The add bookmark, maybe
            var temp = new
            {
                Addmovietofavorites = "http://localhost:5000/api/favorites/movie/add/{userName}/{movieId}",
                RemoveMoviefromfavorites = "http://localhost:5000/api/favorites/movie/remove/{userName}/{movieId}",
                Getusersfavorites = "http://localhost:5000/api/favorites/{userName}"
            };


            return Ok(temp.ToJson());
        }


        [HttpGet("movie/add/{userName}/{movieId}")]
        public IActionResult AddMovieFavorite(string userName, string movieId)
        {
            var data = ds.AddMovieFavorite(userName, movieId);
            return Ok(data);
        }

        [HttpGet("movie/remove/{userName}/{movieId}")]
        public IActionResult RemoveMovieFavorite(string userName, string movieId)
        {
            var data = ds.RemoveMovieFavorite(userName, movieId);
            return Ok(data);
        }

        [HttpGet("{userName}")]
        public IActionResult ShowUserFavorites(string userName, int page = 0, int pagesize = 10)
        {
            var data = ds.GetUsersFavorites(userName, page, pagesize);
           // Console.WriteLine(data[0].Id);
            return Ok(data.ToJson());

        }
    }
}
