using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BelarusianDoor.Data
{
    public class OutlayMoney
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateTimeOut { get; set; }
        public string WhereSpend { get; set; }
        public double Summa { get; set; }
        public string WhoReceiveMoney { get; set; }
    }
}
