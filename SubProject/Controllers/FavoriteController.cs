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
    [Route("api/favorites")]
    public class FavoriteController : ControllerBase
    {
        IFavoriteDS ds;

        //public _loggedUser = Request.HttpContext.Items["User"] as User;

        public FavoriteController(IFavoriteDS dataservice)
        {
            ds = dataservice;
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
            return Ok(data);

        }
    }
}
