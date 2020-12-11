using DataServiceLib.Models;
using System.Collections.Generic;

namespace DataServiceLib.DataServices
{
    public interface ISearchDS
    {
        IList<StringSearch> Search(string keyword, string userName);

        IList<SearchHistory> SearchHistory(string userName);
    }
}