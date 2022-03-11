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
        private GestionQREntities db = new GestionQREntities();

        public ActionResult BuzonPrincipal()
        {
            return View();
        }

        // GET: Clientes/Create
        public ActionResult CreateCliente()
        {
            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCliente([Bind(Include = "Id,Nombres_Cliente,Apellidos_Cliente,Teléfono,Direccion,Provincia,Sector,Email,Estado")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Estado = new SelectList(db.Estado, "Id", "Descripcion", clientes.Estado);
            return View(clientes);
        }

        public ActionResult Usuarios()
        {
            //write logic here  
            return View();
        }

        public ActionResult Administrador()
        {
            //write logic here  
            return View();
        }

        /*
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
        */
    }
}
