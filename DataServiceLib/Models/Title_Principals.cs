using System;
using System.Collections.Generic;
using System.Text;

namespace DataServiceLib.Models
{
    public class Title_Principals
    {
        public string MovieId { get; set; }
        public int Ordering { get; set; }
        public string PersonId { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }
        public List<String> Characters { get; set; }
    }
}
