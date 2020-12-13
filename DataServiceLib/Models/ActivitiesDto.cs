using System;
using System.Collections.Generic;
using System.Text;

namespace DataServiceLib.Models
{
    public class ActivitiesDto
    {
        public int? Rating { get; set; }
        public bool isBookmarked { get; set; }
        public bool isFav { get; set; }
    }
}
