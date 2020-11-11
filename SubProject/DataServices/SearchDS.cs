using Microsoft.EntityFrameworkCore;
using SubProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public IList<StringSearch> ExactSearch(string firstKeyword, String secondKeyword)
        {
            using var ctx = new MoviesContext("host=localhost;db=rawlocal;uid=postgres;pwd=Pass2020");
            return ctx.ExactSearch(firstKeyword, secondKeyword);
        }

        public IList<BestSearch> BestSearch(string firstKeyword, String secondKeyword, string thirdKeyword)
        {
            using var ctx = new MoviesContext("host=localhost;db=rawlocal;uid=postgres;pwd=Pass2020");
            return ctx.BestSearch(firstKeyword, secondKeyword, thirdKeyword);
        }
        public IList<SearchHistory>  SearchHistory(string userName)
        {
            using var ctx = new MoviesContext("host=localhost;db=rawlocal;uid=postgres;pwd=Pass2020");
            return ctx.searchHistories.Where(s => s.UserName == userName).ToList();
        }
    }
}
