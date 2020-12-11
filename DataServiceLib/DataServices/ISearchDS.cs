using DataServiceLib.Models;
using System.Collections.Generic;

namespace DataServiceLib.DataServices
{
    public interface ISearchDS
    {
        SearchReturn Search(string keyword, string userName, int page = 0, int pagesize = 10);

        IList<SearchHistory> SearchHistory(string userName);
    }
}