using SubProject.Models;
using System.Collections.Generic;

namespace SubProject.DataServices
{
    public interface ISearchDS
    {
        IList<StringSearch> Search(string keyword);
    }
}