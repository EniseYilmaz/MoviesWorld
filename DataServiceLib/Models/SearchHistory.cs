using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Keywords { get; set; }
        public int SearchNumber { get; set; }
    }
}
