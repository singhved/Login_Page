using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_Page.Models;

namespace Login_Page.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public string Auth(string Uid, string Pass)
        {
            string res = AllProcs.CheckUser(Uid, Pass);
            if (Convert.ToInt32(res) > 0)
                Cookies.SaveUserCookies(Convert.ToInt32(res));
            return res;
        }

        public void Logout()
        {
            Cookies.Logout();
        }
    }
}