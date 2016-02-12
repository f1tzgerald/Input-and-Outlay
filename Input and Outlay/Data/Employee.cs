using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace BelarusianDoor.Data
{
    /// <summary>
    /// Клас співробітника
    /// </summary>
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public bool Status { get; set; }
    }
}
