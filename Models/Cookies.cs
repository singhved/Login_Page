using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Login_Page.Models;
using Newtonsoft.Json;

namespace Login_Page.Models
{
    public class Cookies
    {
        public static void SaveUserCookies(int id)
        {
            ADSContext db = new ADSContext();
            var users = db.Employees.Where(b => b.id == id).FirstOrDefault();
            HttpContext.Current.Response.Cookies["UserDetails"].Value = JsonConvert.SerializeObject(users);
        }
        public static void Logout()
        {
            HttpContext.Current.Response.Cookies["UserDetails"].Expires = DateTime.Now.Date.AddDays(-1);
        }

        public static Employee GetUserDetails
        {
            get
            {
                Employee employee;
                try
                {
                    var data = HttpContext.Current.Request.Cookies["UserDetails"].Value;
                    if (data != null)
                    {
                        employee = JsonConvert.DeserializeObject<Employee>(data);
                        return employee;
                    }
                }
                catch (Exception) { }
                employee = new Employee();
                return employee;
            }
        }
    }
}