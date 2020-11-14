using DataServiceLib.Models;
using System.Collections.Generic;

namespace DataServiceLib.DataServices
{
    public interface ISearchDS
    {
        IList<StringSearch> Search(string keyword);

        IList<StringSearch> ExactSearch(string firstKeyword, string secondKeyword);

        IList<BestSearch> BestSearch(string firstKeyword, string secondKeyword, string thirdKeyword);

        IList<SearchHistory> SearchHistory(string userName);
    }
}