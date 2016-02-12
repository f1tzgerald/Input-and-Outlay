using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BelarusianDoor.Data
{
    /// <summary>
    /// Клас надходження грошей від клієнта
    /// </summary>
    public class IncomeMoney
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime DateTimeIn { get; set; }
        public string CustomersName { get; set; }
        public double Summa { get; set; }
        public byte EmployeeId { get; set; }
    }
}
