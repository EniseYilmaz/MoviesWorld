using Microsoft.AspNetCore.Mvc;
using SubProject.Attributes;
using DataServiceLib.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.DataServices
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

        
        [HttpGet("{keyword}/{userName}")]
        public IActionResult SimpleSearch(string keyword, string userName, int page = 0, int pagesize = 10)
        {
            var data = ds.Search(keyword, userName, page, pagesize);
            return Ok(data.ToJson());
        }

        [HttpGet("history/{userName}")]
        public IActionResult SearchHistory(string userName)
            {
                var data = ds.SearchHistory(userName);
                return Ok(data.ToJson());
            }
    }
}
