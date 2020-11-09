using System;
using System.Collections.Generic;
using System.Text;

namespace DataServiceLib
{
    class TitleBasics
    {
        public int Id { get; set; }
        public string TitleType { get; set; }
        public string PrimaryTitle { get; set; }
        public string OriginalTitle { get; set; }
        public bool IsAdult { get; set; }
        public double StartYear { get; set; }
        public double EndYear { get; set; }
        public int RunTimeMinutes { get; set; }
        public string Genres { get; set; }
    }
}
