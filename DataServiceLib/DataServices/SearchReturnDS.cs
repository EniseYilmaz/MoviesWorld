using DataServiceLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataServiceLib.DataServices
{
    public class SearchReturn
    {
        public int ResultSize { get; set; }
        public List<StringSearch> SearchResultsList { get; set; }
    }
}
