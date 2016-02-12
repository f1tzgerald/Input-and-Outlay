using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BelarusianDoor.Data
{
    public class Balance
    {
        [Key]
        public DateTime WorkingDate { get; set; }
        public int SummaAtTheMorning { get; set; }
        public int SummaAtTheEvening { get; set; }
    }
}
