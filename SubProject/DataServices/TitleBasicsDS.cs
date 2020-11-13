using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SubProject.Models;

namespace SubProject.DataServices
{
    public class TitleBasicsDS : ITitleBasicsDS
    {

        public IList<TitleBasics> GetTitleBasics(int page, int pagesize)
        {
            using var ctx = new MoviesContext();
            return ctx.titleBasics.Skip(page*pagesize).Take(pagesize).ToList();
        }
        public TitleBasics GetSingleTitleBasics(string id)
        {
            using var ctx = new MoviesContext();
            return ctx.titleBasics.Where(t => t.Id == id).FirstOrDefault();
        }

    }
}
//"host=rawdata.ruc.dk;db=raw10;uid=raw10;pwd=Y)oCi6U("
//"host=localhost;db=rawlocal;uid=postgres;pwd=Pass2020"