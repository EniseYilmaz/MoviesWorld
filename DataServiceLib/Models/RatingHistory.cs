using System;
using System.Collections.Generic;
using System.Text;

namespace DataServiceLib.Models
{
    public class RatingHistories
    {
            public string UserName { get; set; }
            public string MovieId { get; set; }
            public int? Rating { get; set; }
    }
}
