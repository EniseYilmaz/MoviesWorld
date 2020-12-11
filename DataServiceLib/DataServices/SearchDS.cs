using DataServiceLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataServiceLib.DataServices
{
    public class SearchDS : ISearchDS
    {
        private readonly MoviesContext ctx = new MoviesContext();
        public IList<StringSearch> Search(string keyword, string userName)
        {
            return ctx.Search(keyword, userName);
        }
        public IList<SearchHistory>  SearchHistory(string userName)
        {
            return ctx.searchHistories.Where(s => s.UserName == userName).ToList();
        }
    }
}
