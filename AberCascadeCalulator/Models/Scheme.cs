using System;
using System.Collections.Generic;

namespace AberCascadeCalulator.Models
{
    public class Scheme
    {
        public string SchemeId { get; set; }
        public string Title { get; set; }
        public string Award { get; set; }
        public string Department { get; set; }
        public string UndergraduateOrPostgraduate { get; set; }
        public string SchemeType { get; set; }
        public long? Year { get; set; }
        public long? Duration { get; set; }
        public string Url { get; set; }
    }
}
