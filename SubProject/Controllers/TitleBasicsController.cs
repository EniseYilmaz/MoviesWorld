using Microsoft.AspNetCore.Mvc;
using SubProject.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/namebasics")]
    public class TitleBasicsController : ControllerBase
    {
        ITitleBasicsDS ds;

        public TitleBasicsController(ITitleBasicsDS dataservice)
        {
            ds = dataservice;
        }

        [HttpGet]
        public IActionResult GetTitleBasics()
        {
            var titlebasics = ds.GetTitleBasics();

            return Ok(titlebasics);
        }
    }
}
