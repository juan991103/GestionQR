using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SistemaRH.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Admin()
        {
            //write logic here  
            return View();
        }

        public ActionResult Users()
        {
            //write logic here  
            return View();
        }
    }
}
