using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SubProject.Models;

namespace SubProject.DataServices
{
    public class TitleBasicsDS : ITitleBasicsDS
    {

        public IList<TitleBasics> GetTitleBasics()
        {
            using var ctx = new MoviesContext("host=localhost;db=rawlocal;uid=postgres;pwd=Pass2020");
            return ctx.titleBasics.ToList();
        }
    }
}
//"host=rawdata.ruc.dk;db=raw10;uid=raw10;pwd=Y)oCi6U("
//"host=localhost;db=rawlocal;uid=postgres;pwd=Pass2020"