using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace BelarusianDoor.Data
{
    class MainContext : DbContext
    {
        public MainContext() : base("Connection") { }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<IncomeMoney> Income { get; set; }
        public DbSet<OutlayMoney> Outlay { get; set; }
        public DbSet<Balance> Balances { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
