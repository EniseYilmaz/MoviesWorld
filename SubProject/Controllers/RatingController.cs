using System;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using SubProject.Models;

namespace SubProject.DataServices
{
    [ApiController]
    [Route("api/rating")]
    public class RatingController : ControllerBase
    {
        IRatingDS ds;
        IMapper _mapper;

        public RatingController(IRatingDS dataservice, IMapper mapper)
        {
            ds = dataservice;
            _mapper = mapper;
        }


        //Create movie rating
        [HttpPost]
        public IActionResult CreateRating(TitleRating RatingCreation)
        {

            ds.AddMovieRating(RatingCreation);

            return Created("", RatingCreation);

        }

        //Update movie rating
        [HttpPut("rating/movie/update/{Username}/{movieId}/{MovieRating}")]
        public IActionResult UpdateRating(string Username, string movieId, int MovieRating, TitleRating RatingCreation)
        {

            if (!ds.UpdateMovieRating(Username, movieId, MovieRating))
            {
                return NotFound("Couldn't find");
            }

            return Ok("Succesfully removed");

        }


        //Delete movie rating
        [HttpDelete("rating/movie/remove/{Username}/{movieId}/{MovieRating}")]
        public IActionResult DeleteRating(string Username, string movieId, int MovieRating)
        {
            if (!ds.RemoveMovieRating(Username, movieId, MovieRating))
            {
                return NotFound("Couldn't find");
            }

            return Ok("Succesfully removed");
        }



        //Create actor rating
        [HttpPost]
        public IActionResult CreateActorRating(NameRating ActorRatingCreation)
        {

            ds.AddActorRating(ActorRatingCreation);

            return Created("", ActorRatingCreation);

        }


        //Update actor rating
        [HttpPut("rating/actor/update/{Username}/{personId}/{ActorRating}")]
        public IActionResult UpdateActorRating(string Username, string personId, int ActorRating, NameRating ActorRatingCreation)
        {

            if (!ds.UpdateActorRating(Username, personId, ActorRating))
            {
                return NotFound();
            }

            return NoContent();

        }


        //Delete actor rating
        [HttpDelete("rating/actor/remove/{Username}/{personId}/{ActorRating}")]
        public IActionResult RemoveActorRating(string Username, string movieId, int MovieRating)
        {
            if (!ds.RemoveMovieRating(Username, movieId, MovieRating))
            {
                return NotFound("Couldn't find");
            }

            return Ok("Succecfully removed");
        }


    }
}

