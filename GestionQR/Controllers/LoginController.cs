using GestionQR.Models;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Usuarios_quejas quejas, Usuarios_reclamaciones reclamacion)
        {
            if (ModelState.IsValid)
            {
                using (GestionQREntities db = new GestionQREntities())
                {
                    var obj = db.Usuarios_quejas.Where(a => a.Usuario_quejas.Equals(quejas.Usuario_quejas) && a.Clave.Equals(quejas.Clave)).FirstOrDefault();
                    var obj2 = db.Usuarios_reclamaciones.Where(a => a.Usuario_reclamo.Equals(reclamacion.Usuario_reclamo) && a.Clave.Equals(reclamacion.Clave)).FirstOrDefault();
                    
                    if (obj != null)
                    {
                        Session["Id"] = obj.Id.ToString();
                        Session["Usuario_quejas"] = obj.Usuario_quejas.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                    else if (obj2 != null)
                    {
                        Session["Id"] = obj2.Id.ToString();
                        Session["Usuario_reclamo"] = obj2.Usuario_reclamo.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View();
        }

        public ActionResult UserDashBoard()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Home");
            }
        }

        public ActionResult Administrador()
        {
            //write logic here  
            return View();
        }
    }
}
