using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.DataServices
{
    public class TitleBasicsDS : ITitleBasicsDS
    {

        public IList<TitleBasics> GetTitleBasics()
        {
            using var ctx = new MoviesContext("host=rawdata.ruc.dk;db=raw10;uid=raw10;pwd=Y)oCi6U(");
            return ctx.titleBasics.ToList();
        }
    }
}
