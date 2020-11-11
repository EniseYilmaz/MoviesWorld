using System.Collections.Generic;
using SubProject.Models;

namespace SubProject.DataServices
{
    public interface ITitleBasicsDS
    {
        IList<TitleBasics> GetTitleBasics (int page, int pagesize);
    }
}