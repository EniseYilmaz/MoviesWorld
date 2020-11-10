using Microsoft.AspNetCore.Mvc;
using SubProject.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/search")]
    public class SearchController : ControllerBase
    {
        
            ISearchDS ds;

            public SearchController(ISearchDS dataservice)
            {
                ds = dataservice;
            }

            [HttpGet]
            public IActionResult SimpleSearch()
            {
                var titlebasics = ds.Search("Red Dead");

                return Ok(titlebasics);
            }
    }
}
