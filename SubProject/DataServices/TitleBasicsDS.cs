using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SubProject.Models;

namespace SubProject.DataServices
{
    public class TitleBasicsDS : ITitleBasicsDS
    {

        public IList<TitleBasics> GetTitleBasics(int page = 1, int pagesize = 10)
        {
            using var ctx = new MoviesContext("host=rawdata.ruc.dk;db=raw10;uid=raw10;pwd=Y)oCi6U(");
            Console.WriteLine(ctx);
            return ctx.titleBasics.Skip(page*pagesize).Take(pagesize).ToList();
        }
    }
}
//"host=rawdata.ruc.dk;db=raw10;uid=raw10;pwd=Y)oCi6U("
//"host=localhost;db=rawlocal;uid=postgres;pwd=Pass2020"