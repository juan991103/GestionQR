using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionQR.Models;

namespace GestionQR.Controllers.Usuarios
{
    public class UsuariosQController : Controller
    {
        private GestionQREntities db = new GestionQREntities();

        // GET: UsuariosQ
        public ActionResult Index()
        {
            if (Session["Id"] != null)
            {
                return View(db.Usuarios_quejas.ToList());
            }
            else
            {
                return RedirectToAction("Usuarios", "Login");
            }
        }

        // GET: UsuariosQ/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_quejas usuarios_quejas = db.Usuarios_quejas.Find(id);
            if (usuarios_quejas == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_quejas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
