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

        
        [HttpGet("{keyword}")]
        public IActionResult SimpleSearch(string keyword)
        {
            var data = ds.Search(keyword);
            return Ok(data.ToJson());
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
