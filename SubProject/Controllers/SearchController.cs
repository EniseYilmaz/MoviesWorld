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

            [HttpGet("{keyword}")]
            public IActionResult SimpleSearch(string keyword)
            {
                var data = ds.Search(keyword);
                return Ok(data);
            }

            [HttpGet("{firstKeyword}/{secondKeyword}")]
            public IActionResult ExactSearch(string firstKeyword, string secondKeyword)
            {
                var data = ds.ExactSearch(firstKeyword, secondKeyword);
                return Ok(data);
            }

            [HttpGet("{firstKeyword}/{secondKeyword}/{thirdKeyword}")]
            public IActionResult BestSearch(string firstKeyword, string secondKeyword, string thirdKeyword)
            {
                var data = ds.BestSearch(firstKeyword, secondKeyword, thirdKeyword);
                return Ok(data);
            }
    }
}
