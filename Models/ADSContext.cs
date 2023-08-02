using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Login_Page.Models
{
    public class ADSContext : DbContext
    {
        public virtual DbSet<Employee> Employees { get; set; }
    }
}