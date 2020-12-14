using DataServiceLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataServiceLib.DataServices
{
    public class SearchDS : ISearchDS
    {
        public SearchReturn Search(string keyword, string userName, int page,  int pagesize)
        {
            using (var ctx = new MoviesContext())
            {
                var temp = ctx.Search(keyword, userName);
                var searchResults = new SearchReturn()
                {
                    ResultSize = temp.Count(),
                    SearchResultsList = temp.Skip(page * pagesize).Take(pagesize).ToList()

                };

                return searchResults;
            }
        }
        public IList<SearchHistory>  SearchHistory(string userName)
        {
            using (var ctx = new MoviesContext())
            {
                return ctx.searchHistories.Where(s => s.UserName == userName).ToList();
            }
        }
    }
}
