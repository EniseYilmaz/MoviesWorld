﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataServiceLib.Models
{
    public class ActorRatingDto
    {
        public string UserName { get; set; }
        public string PersonId { get; set; }
        public int Rating { get; set; }
    }
}
