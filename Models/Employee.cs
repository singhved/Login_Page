using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Login_Page.Models
{
    [Table("Employee")]
    public class Employee
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Userid { get; set; }
        public string Password { get; set; }
    }
}