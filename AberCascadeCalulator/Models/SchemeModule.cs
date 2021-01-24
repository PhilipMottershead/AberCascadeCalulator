using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AberCascadeCalulator.Models
{
    public class SchemeModule
    {
        public int SchemeModuleId { get; set; }
        public string SchemeId { get; set; }
        public string ModuleId { get; set; }
        public string ModuleType { get; set; }
        public virtual Module Module { get; set; }
        public virtual Scheme Scheme { get; set; }
    }
}
