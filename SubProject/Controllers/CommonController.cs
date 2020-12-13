using DataServiceLib.DataServices;
using DataServiceLib.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/common")]
    public class CommonController : ControllerBase
    {
        IRatingDS rDs;
        IBookMarkDS bDs;
        IFavoriteDS fDs;

        public CommonController(IRatingDS ratingDS, IBookMarkDS bookmarkDS, IFavoriteDS favoriteDS)
        {
            rDs = ratingDS;
            bDs = bookmarkDS;
            fDs = favoriteDS;
        }

        [HttpGet("activities/{userName}/{movieId}")]
        public IActionResult GetRatingByUser(string userName, string movieId)
        {
            var rating = rDs.getRatingByUser(userName, movieId);
            var bookmark = bDs.isBookmarked(userName, movieId);
            var favorite = fDs.isFav(userName, movieId);

            bool isBookmark = bookmark != null ? true : false;
            bool isFav = favorite != null ? true : false;

            var activities = new ActivitiesDto();

            activities.Rating = rating?.Rating;
            activities.isBookmarked = isBookmark;
            activities.isFav = isFav;

            return Ok(activities);
        }
    }
}
