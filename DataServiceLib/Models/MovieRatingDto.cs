﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServiceLib.Models
{
    public class MovieRatingDto
    {
        public string UserName { get; set; }
        public string MovieId { get; set; }
        public int Rating { get; set; }
    }
}
