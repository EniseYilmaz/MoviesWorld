using Microsoft.AspNetCore.Mvc;
using SubProject.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/favorite")]
    public class FavoriteController : ControllerBase
    {
        IFavoriteDS ds;

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
    }
}
