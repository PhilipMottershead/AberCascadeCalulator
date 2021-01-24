using System;
using System.Collections.Generic;

namespace AberCascadeCalulator.Models
{
    public class Module
    {
        public string ModuleId { get; set; }
        public string Title { get; set; }
        public string Coordinator { get; set; }
        public string Semester { get; set; }
        public string Year { get; set; }
        public string Department { get; set; }
        public long? Credits { get; set; }
        public bool Welsh { get; set; }
        public string Url { get; set; }
    }
}
