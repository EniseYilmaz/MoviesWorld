using Microsoft.EntityFrameworkCore;
using SubProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.DataServices
{
    public class SearchDS : ISearchDS
    {
        public IList<StringSearch> Search(string keyword)
        {
            using var ctx = new MoviesContext("host=localhost;db=rawlocal;uid=postgres;pwd=Pass2020");
            return ctx.Search(keyword);
        }
    }
}
