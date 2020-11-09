using System.Collections.Generic;

namespace SubProject.DataServices
{
    public interface ITitleBasicsDS
    {
        IList<TitleBasics> GetTitleBasics();
    }
}