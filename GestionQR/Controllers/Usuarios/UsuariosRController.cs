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
    public class UsuariosRController : Controller
    {
        private GestionQREntities db = new GestionQREntities();

        // GET: UsuariosR
        public ActionResult Index()
        {
            return View(db.Usuarios_reclamaciones.ToList());
        }

        // GET: UsuariosR/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuarios_reclamaciones usuarios_reclamaciones = db.Usuarios_reclamaciones.Find(id);
            if (usuarios_reclamaciones == null)
            {
                return HttpNotFound();
            }
            return View(usuarios_reclamaciones);
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
