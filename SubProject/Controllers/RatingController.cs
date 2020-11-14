using Microsoft.AspNetCore.Mvc;
using DataServiceLib.DataServices;
using DataServiceLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/rating")]
    public class RatingController : ControllerBase
    {
        IRatingDS ds;

        //public _loggedUser = Request.HttpContext.Items["User"] as User;

        public RatingController(IRatingDS dataservice)
        {
            ds = dataservice;
        }

        [HttpPost("add/actor")]
        public IActionResult AddActorRating(ActorRatingDto actorRatingDto)
        {
            bool result = ds.AddActorRating(actorRatingDto);
            return Ok(result.ToJson());
        }

        [HttpPost("add/movie")]
        public IActionResult AddMovieRating(MovieRatingDto movieRatingDto)
        {
            bool result = ds.AddMovieRating(movieRatingDto);
            return Ok(result.ToJson());
        }

        [HttpPost("remove/actor")]
        public IActionResult RemoveActorRating(ActorRatingDto actorRatingDto)
        {
            bool result = ds.RemoveActorRating(actorRatingDto);
            return Ok(result.ToJson());
        }

        [HttpPost("remove/movie")]
        public IActionResult RemoveMovieRating(MovieRatingDto movieRatingDto)
        {
            bool result = ds.RemoveMovieRating(movieRatingDto);
            return Ok(result.ToJson());
        }
    }
}
