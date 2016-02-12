using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BelarusianDoor.Data
{
    public class Visitor
    {
        [Key]
        public DateTime DateTime { get; set; }
        public ushort VisitorsCount { get; set; }
    }
}
