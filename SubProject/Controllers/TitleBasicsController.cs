using Microsoft.AspNetCore.Mvc;
using SubProject.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/title_basics")]
    public class TitleBasicsController : ControllerBase
    {
        ITitleBasicsDS ds;

        public TitleBasicsController(ITitleBasicsDS dataservice)
        {
            ds = dataservice;
        }

        [HttpGet]
        public IActionResult GetTitleBasics(int page = 0, int pagesize = 10)
        {
            var titlebasics = ds.GetTitleBasics(page, pagesize);

            return Ok(titlebasics.ToJson());
        }
        [HttpGet("{id}")]
        public IActionResult GetSingleTitleBasics(string id)
        {
            var titlebasics = ds.GetSingleTitleBasics(id);

            return Ok(titlebasics.ToJson());
        }

    }
}
